using UnityEngine;
using System;

public class DroneNetworkSync : MonoBehaviour
{
    [System.Serializable]
    public class DroneMoveMessage
    {
        public string type = "DRONE_MOVE";
        public string teamId;
        public float x;
        public float y;
        public bool flipX;
        public string state;
        public bool portantDino;
    }

    private DroneAI droneAI;
    private SpriteRenderer sr;
    private Transform dinosaurioTransform;
    private bool isHost = false; 
    private float sendInterval = 0.05f; 
    private float lastSendTime = 0f;

    // Para clientes remotos (Interpolación)
    private Vector3 targetPosition;
    private bool isRemote = true; 
    public float interpolationSpeed = 40f; 

    void Start()
    {
        droneAI = GetComponent<DroneAI>();
        sr = GetComponentInChildren<SpriteRenderer>();
        targetPosition = transform.position;

        BuscarDinosaurio();

        // Registro redundante por si DroneAI.Initialize falló o fue antes del Singleton
        if (GameManager.Instance != null && droneAI != null && !GameManager.Instance.dronsEscena.Contains(droneAI))
        {
            GameManager.Instance.dronsEscena.Add(droneAI);
            Debug.Log($"[DRONE-SYNC-START] Dron {droneAI.teamId} registrado (redundante).");
        }

        CheckHostStatus();
    }

    void BuscarDinosaurio()
    {
        if (dinosaurioTransform != null) return;
        if (droneAI == null) return;

        Bandera[] banderas = FindObjectsByType<Bandera>(FindObjectsSortMode.None);
        foreach (var b in banderas)
        {
            if (b.equipPropietari == droneAI.teamId)
            {
                dinosaurioTransform = b.transform;
                break;
            }
        }
    }

    void CheckHostStatus()
    {
        if (MenuManager.Instance != null && MenuManager.Instance.currentRoomData != null)
        {
            string myId = MenuManager.Instance.userId?.ToLower() ?? "";
            string hostId = MenuManager.Instance.currentRoomData.host?.ToLower() ?? "";
            
            isHost = (myId == hostId) && !string.IsNullOrEmpty(hostId);
            isRemote = !isHost;
            
            Debug.Log($"[DRON-NET] Dron {droneAI.teamId} | Yo: {myId} | Host: {hostId} | Soc Host: {isHost}");
        }
        else
        {
            // Fallback para pruebas locales
            isHost = true;
            isRemote = false;
            Debug.Log($"[DRON-NET] Dron {droneAI.teamId} en mode LOCAL/PROVES (Host per defecte).");
        }

        string tid = (droneAI != null) ? droneAI.teamId : "Desconocido";

        if (isRemote)
        {
            // Task 1.2, 1.3: Neutralización de IA en Clientes
            // Destruimos componentes que solicitan decisiones para asegurar espejo exacto sin interferencias
            var dr = GetComponent<Unity.MLAgents.DecisionRequester>();
            if (dr != null) Destroy(dr);

            var bp = GetComponent<Unity.MLAgents.Policies.BehaviorParameters>();
            if (bp != null) Destroy(bp);

            // NO DESTRUIMOS droneAI porque lo necesitamos para guardar estado (portantDino, teamId)
            if (droneAI != null) 
            {
                droneAI.enabled = false;
                // Destroy(droneAI); // ¡ERROR! Si lo destruyes, el código de abajo (ReceiveUpdate, Update) que lee de droneAI fallará y el dino no se moverá.
            }
            
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Kinematic; // Task 1.4: Kinematic en clientes
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
            
            Debug.Log($"[DRON-NET] Dron {tid} configurat com a ESPEJO (IA apagada, Físiques OFF).");
        }
        else
        {
            // Modo Cerebro (Host)
            if (droneAI != null) droneAI.enabled = true;
            var dr = GetComponent<Unity.MLAgents.DecisionRequester>();
            if (dr != null) dr.enabled = true;
            
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null) rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void Update()
    {
        // Re-verificar host periódicamente por si el cambio de sala es lento
        if (Time.frameCount % 120 == 0 && MenuManager.Instance != null && MenuManager.Instance.currentRoomData != null)
        {
            string myId = MenuManager.Instance.userId?.ToLower() ?? "";
            string hostId = MenuManager.Instance.currentRoomData.host?.ToLower() ?? "";
            bool actuallyHost = (myId == hostId) && !string.IsNullOrEmpty(hostId);
            if (actuallyHost != isHost) CheckHostStatus();
        }

        if (isHost)
        {
            if (Time.time - lastSendTime >= sendInterval)
            {
                lastSendTime = Time.time;
                SendPosition();
            }
        }
        else
        {
            // Task 2.2: Snap de seguretat si la distància és massa gran
            float dist = Vector3.Distance(transform.position, targetPosition);
            if (dist > 0.5f)
            {
                transform.position = targetPosition;
            }
            else
            {
                // Task 2.1: Interpolació suau però molt ràpida (40f) cap a la posició rebuda
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * interpolationSpeed);
            }
            
            // Sincronización visual del dinosaurio capturado en clientes
            if (droneAI != null && dinosaurioTransform != null)
            {
                if (droneAI.portantDino && dinosaurioTransform.parent != transform)
                {
                    dinosaurioTransform.SetParent(transform);
                    dinosaurioTransform.localPosition = Vector3.zero;
                    
                    Rigidbody2D rbDino = dinosaurioTransform.GetComponent<Rigidbody2D>();
                    if (rbDino != null) rbDino.bodyType = RigidbodyType2D.Kinematic;
                }
                else if (!droneAI.portantDino && dinosaurioTransform.parent == transform)
                {
                    dinosaurioTransform.SetParent(null);
                    Rigidbody2D rbDino = dinosaurioTransform.GetComponent<Rigidbody2D>();
                    if (rbDino != null) rbDino.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }
    }

    void SendPosition()
    {
        if (MenuManager.Instance == null || droneAI == null) return;

        DroneMoveMessage msg = new DroneMoveMessage
        {
            teamId = droneAI.teamId,
            x = transform.position.x,
            y = transform.position.y,
            flipX = (sr != null) ? sr.flipX : false,
            state = droneAI.currentState.ToString(),
            portantDino = droneAI.portantDino
        };

        string json = JsonUtility.ToJson(msg);
        MenuManager.Instance.EnviarMovimientoDron(json);

        // Log ocasional para no saturar
        if (Time.frameCount % 600 == 0) Debug.Log($"[DRONE_SEND] Dron {msg.teamId} a ({msg.x:F1}, {msg.y:F1}) | Portant: {msg.portantDino}");
    }

    public void ReceiveUpdate(DroneMoveMessage msg)
    {
        if (!isRemote) return;

        // Mantenim la Z original del dron per evitar que desaparegui darrere del fons (Z=0)
        targetPosition = new Vector3(msg.x, msg.y, transform.position.z);
        if (sr != null) sr.flipX = msg.flipX;

        if (droneAI != null)
        {
            droneAI.portantDino = msg.portantDino;
            if (Enum.TryParse(msg.state, out DroneAI.DroneState remoteState))
            {
                droneAI.currentState = remoteState;
            }
        }

        if (Time.frameCount % 600 == 0) Debug.Log($"[DRONE_RECV] Dron {msg.teamId} rebut a ({msg.x:F1}, {msg.y:F1}) | Portant: {msg.portantDino}");
    }

    public bool SocHost()
    {
        return !isRemote;
    }
}
