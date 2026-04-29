using UnityEngine;
using System;

/// <summary>
/// MiniDinoNetworkSync: Gestiona la sincronització dels mini-dinosaures entre Host i Client.
/// Segueix la mateixa lògica que el dron: el Host calcula i el Client obeeix.
/// </summary>
public class MiniDinoNetworkSync : MonoBehaviour
{
    [System.Serializable]
    public class MiniDinoMoveMessage
    {
        public string type = "MINIDINO_MOVE";
        public string dinoId; // Identificador únic per si hi ha diversos mini-dinos
        public float x;
        public float y;
        public bool flipX;
    }

    private MiniDinoAgent agent;
    private SpriteRenderer sr;
    private bool isHost = false; 
    private float sendInterval = 0.05f; 
    private float lastSendTime = 0f;

    // Per a clients remots (Interpolació)
    private Vector3 targetPosition;
    private bool isRemote = true; 
    public float interpolationSpeed = 30f; 

    public string dinoId; // S'ha d'assignar a l'inspector o per codi

    void Start()
    {
        agent = GetComponent<MiniDinoAgent>();
        sr = GetComponentInChildren<SpriteRenderer>();
        targetPosition = transform.position;

        if (string.IsNullOrEmpty(dinoId)) dinoId = Guid.NewGuid().ToString().Substring(0, 8);

        CheckHostStatus();
    }

    void CheckHostStatus()
    {
        if (MenuManager.Instance != null && MenuManager.Instance.currentRoomData != null)
        {
            string myId = MenuManager.Instance.userId?.ToLower() ?? "";
            string hostId = MenuManager.Instance.currentRoomData.host?.ToLower() ?? "";
            
            isHost = (myId == hostId) && !string.IsNullOrEmpty(hostId);
            isRemote = !isHost;
        }
        else
        {
            isHost = true;
            isRemote = false;
        }

        if (isRemote)
        {
            // Desactivem la IA en els clients per evitar conflictes
            if (agent != null) agent.enabled = false;
            
            var dr = GetComponent<Unity.MLAgents.DecisionRequester>();
            if (dr != null) dr.enabled = false;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.linearVelocity = Vector2.zero;
            }
        }
        else
        {
            // El Host manté la IA activa
            if (agent != null) agent.enabled = true;
            
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null) rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void Update()
    {
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
            // Interpolació en el client
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * interpolationSpeed);
            
            // Flip visual basat en la velocitat o el missatge
            if (sr != null && Math.Abs(transform.position.x - targetPosition.x) > 0.01f)
            {
                // sr.flipX = (targetPosition.x < transform.position.x); // Opcional: calcular-ho aquí
            }
        }
    }

    void SendPosition()
    {
        if (MenuManager.Instance == null) return;

        MiniDinoMoveMessage msg = new MiniDinoMoveMessage
        {
            dinoId = this.dinoId,
            x = transform.position.x,
            y = transform.position.y,
            flipX = (sr != null) ? sr.flipX : false
        };

        string json = JsonUtility.ToJson(msg);
        // Podem reutilitzar el canal de missatges o crear-ne un de nou
        // De moment, l'enviem com a text genèric si no volem modificar el backend
        MenuManager.Instance.websocket.SendText(json);
    }

    public void ReceiveUpdate(MiniDinoMoveMessage msg)
    {
        if (!isRemote) return;
        targetPosition = new Vector3(msg.x, msg.y, transform.position.z);
        if (sr != null) sr.flipX = msg.flipX;
    }
}
