using UnityEngine;
using System.Collections;
using NativeWebSocket;

public class NetworkSync : MonoBehaviour
{
    public float sendRate = 0.1f; // 10Hz
    public float moveThreshold = 0.05f; // Llindar mínim de moviment
    public float interpolationSpeed = 15f; // Velocitat de suavitzat per a remots
    
    private float lastSendTime;
    private Vector3 lastPosition;
    private Vector3 posicioObjectiu;
    private bool isRemote = false;
    public string idNPC = ""; // Si no es buit, som un NPC (Dron, etc)
    
    private Player localPlayer;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    [System.Serializable]
    public class PlayerMoveMessage
    {
        public string type = "PLAYER_MOVE";
        public string roomId;
        public string username;
        public string skin;
        public float x;
        public float y;
        public float z;
        public bool flipX;
        public bool isRunning;
        public bool isGrounded;
        public bool isClimbing;
        public float yVelocity;
        public string banderaEquip; // "A", "B" o ""
    }

    void Start()
    {
        localPlayer = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
        lastPosition = transform.position;
        posicioObjectiu = transform.position;

        // Detecció de rol
        if (!string.IsNullOrEmpty(idNPC))
        {
            // Som un NPC. El Host és qui el mou, els altres són remots.
            if (MenuManager.Instance != null)
            {
                isRemote = !MenuManager.Instance.IsHost();
            }
        }
        else if (GameManager.Instance != null && GameManager.Instance.localPlayer != null)
        {
            isRemote = (GameManager.Instance.localPlayer.gameObject != this.gameObject);
        }
        else
        {
            // Fallback si el GameManager encara no està llest o som el primer en despertar
            // Podem comprovar si tenim el script Player actiu
            Player p = GetComponent<Player>();
            isRemote = (p != null && !p.enabled); 
        }

        if (isRemote)
        {
            // Per als remots, forcem Rigidbody cinemàtic per evitar que la gravetat local interfereixi
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.simulated = true;
            }
            Debug.Log($"[NetworkSync] Configurat com a REMOT per a {gameObject.name}. Rigidbody ara és Cinemàtic.");
        }

        if (!isRemote && (MenuManager.Instance == null || MenuManager.Instance.websocket == null))
        {
            Debug.LogWarning("NetworkSync: MenuManager o websocket no disponibles. El moviment NO es sincronitzarà fins que estiguin llestos.");
        }
    }

    void Update()
    {
        if (isRemote)
        {
            // Task 5.2: Si tenim pare, no interpolar (Unity ja ens mou amb el pare)
            if (transform.parent != null) return;

            // Lògica de suavitzat per a jugadors remots
            transform.position = Vector3.Lerp(transform.position, posicioObjectiu, Time.deltaTime * interpolationSpeed);
        }
        else
        {
            // Task 5.2: Si som el Host/Local però tenim pare, no enviem posició pròpia
            // (el que ens porta ja enviarà que ens porta)
            if (transform.parent != null) return;

            // Lògica de transmissió per al jugador local
            float distanceMoved = Vector3.Distance(transform.position, lastPosition);
            bool timeElapsed = Time.time - lastSendTime > sendRate;

            if (timeElapsed && (distanceMoved > moveThreshold))
            {
                SendPosition();
                lastSendTime = Time.time;
                lastPosition = transform.position;
            }
        }
    }

    public void RebrePosicio(float x, float y, float z = 0f)
    {
        // Task 5.2: Si tenim un pare (algú ens porta), ignorem la posició de xarxa 
        // per deixar que el sistema de parenting d'Unity faci la seva feina sense salts.
        if (transform.parent != null) return;

        posicioObjectiu = new Vector3(x, y, z);
        
        // Si la distància és massa gran (teletransport), fem snap directe
        if (Vector3.Distance(transform.position, posicioObjectiu) > 5f)
        {
            transform.position = posicioObjectiu;
        }
    }

    void SendPosition()
    {
        if (MenuManager.Instance != null && MenuManager.Instance.websocket != null && MenuManager.Instance.websocket.State == WebSocketState.Open)
        {
            PlayerMoveMessage msg = new PlayerMoveMessage
            {
                roomId = MenuManager.Instance.currentRoomId,
                username = !string.IsNullOrEmpty(idNPC) ? idNPC : WebSocketClient.Username,
                skin = !string.IsNullOrEmpty(idNPC) ? "NPC" : MenuManager.Instance.currentSkin,
                x = transform.position.x,
                y = transform.position.y,
                z = transform.position.z,
                flipX = sr.flipX,
                isRunning = GetBoolSafe("isRunning"),
                isGrounded = GetBoolSafe("isGrounded"),
                isClimbing = GetBoolSafe("isClimbing"),
                yVelocity = rb.linearVelocity.y,
                banderaEquip = (localPlayer != null && localPlayer.banderaAgafada != null) ? 
                               localPlayer.banderaAgafada.GetComponent<Bandera>().equipPropietari : ""
            };

            string json = JsonUtility.ToJson(msg);
            MenuManager.Instance.websocket.SendText(json);
        }
    }

    private bool GetBoolSafe(string name)
    {
        if (anim == null) return false;
        foreach (AnimatorControllerParameter param in anim.parameters)
        {
            if (param.name == name) return anim.GetBool(name);
        }
        return false;
    }
}
