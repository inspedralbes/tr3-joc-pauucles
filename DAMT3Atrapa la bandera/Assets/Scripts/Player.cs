using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float climbSpeed = 4f;
    public Transform respawnPoint;
    public UIDocument uiDocument;
    public Nametag elMeuNametag;
    public bool potMoure = true;
    public bool potCombatre = true;
    public int idJugador = 1; // 1 per a J1, 2 per a J2
    public string equip; // "A" o "B"

    // Variables per a la sincronització determinista (sense xarxa)
    private static float ultimXoc = 0f;
    private static int comptadorCombats = 0;

    private int lives = 5;
    private bool isFrozen = false;
    private bool isInvulnerable = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private Collider2D col; // Referència al collider
    private float defaultGravity; // Emmagatzematge de la gravetat original
    private bool isGrounded = false;
    private bool isNearLadder = false;
    private bool isClimbing = false;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;
    public Transform banderaAgafada;
    private List<VisualElement> lifeIcons = new List<VisualElement>();
    private Vector3 posAbansDeGuanyar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        
        rb.freezeRotation = true; 
        defaultGravity = rb.gravityScale; // Guardem el valor inicial

        if (uiDocument != null)
        {
            VisualElement root = uiDocument.rootVisualElement;
            for (int i = 1; i <= 5; i++)
            {
                VisualElement icon = root.Q<VisualElement>("Vida" + i);
                if (icon != null) lifeIcons.Add(icon);
            }
        }

        // Configuració del Nametag si existeixen dades de sessió
        if (elMeuNametag != null && !string.IsNullOrEmpty(WebSocketClient.Username))
        {
            elMeuNametag.Configurar(WebSocketClient.Username, WebSocketClient.ColorName);
            
            // També aprofitem per configurar l'idJugador si és necessari
            if (WebSocketClient.Team.ToLower() == "rojo" || WebSocketClient.Team.ToLower() == "vermell") idJugador = 1;
            else if (WebSocketClient.Team.ToLower() == "azul" || WebSocketClient.Team.ToLower() == "blau") idJugador = 2;
        }
    }

    void Update()
    {
        isGrounded = CheckGrounded();

        if (isFrozen || !potMoure) 
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            return;
        }

        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Rotació visual del personatge (Flip)
        if (moveInput > 0)
        {
            sr.flipX = false;
        }
        else if (moveInput < 0)
        {
            sr.flipX = true;
        }

        // Lògica d'Escalada
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (isNearLadder && Mathf.Abs(verticalInput) > 0.1f)
        {
            isClimbing = true;
        }

        // Jump from Ladder
        if (isClimbing && Input.GetKeyDown(KeyCode.Space))
        {
            isClimbing = false;
            rb.gravityScale = defaultGravity;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Jump Execution
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isClimbing)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

        // Actualització de l'Animator
        if (anim != null)
        {
            anim.SetFloat("yVelocity", rb.linearVelocity.y);
            anim.SetBool("isRunning", Mathf.Abs(rb.linearVelocity.x) > 0.1f);
            anim.SetBool("isGrounded", isGrounded);
            anim.SetBool("isClimbing", isClimbing);
        }
    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            float vInput = Input.GetAxisRaw("Vertical");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, vInput * climbSpeed);
        }
        else if (!isFrozen) // Evitem sobreescriure gravityScale si estem en un estat especial (com el respawn)
        {
            rb.gravityScale = defaultGravity;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 2.1 Tallafocs temporal per evitar doble dispar d'event (Physics Jitter)
            if (Time.time - ultimXoc < 3f) return;

            RemotePlayer rp = collision.gameObject.GetComponent<RemotePlayer>();
            if (rp == null || string.IsNullOrEmpty(rp.username)) return;

            Player opponent = collision.gameObject.GetComponent<Player>();
            if (opponent != null && opponent.equip != this.equip)
            {
                // 2.2 Sincronització Determinista Pura
                ultimXoc = Time.time;
                comptadorCombats++;

                string localName = WebSocketClient.LocalUsername;
                string opponentName = rp.username;

                // 2.4 Clau idèntica per a tots dos participants
                string clau = string.Compare(localName, opponentName) < 0 ? localName + opponentName : opponentName + localName;
                
                // 2.5 Generar l'índex del joc (ex: % 5 si tenim 5 jocs)
                int gameIndex = Mathf.Abs((clau + comptadorCombats).GetHashCode()) % 5 + 1;

                Debug.Log($"[SISTEMA] Combat determinista #{comptadorCombats}. Clau: {clau}. Índex: {gameIndex}");

                // 3.1 Aturar moviment
                this.potMoure = false;
                opponent.potMoure = false;

                // 3.2 Obrir UI IMMEDIATAMENT (tots dos clients actuen com a Host local)
                var managers = Resources.FindObjectsOfTypeAll<MinijocUIManager>();
                if (managers.Length > 0)
                {
                    var ui = managers[0];
                    ui.gameObject.SetActive(true);
                    ui.IniciarMinijoc(this.gameObject, collision.gameObject, gameIndex);
                }
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1.2 i 1.3: Evitar que els clons (jugadors remots) disparin triggers locals (especialment la victòria)
        if (gameObject.name.Contains("(Clone)") || GetComponent<RemotePlayer>() != null)
        {
            return;
        }

        // Lògica de Bases (Punts de Spawn)
        if (collision.name.Contains("PuntSpawn_Equip"))
        {
            string equipoBase = collision.name.Contains("Equip1") ? "A" : "B";
            
            // 2.2 Ignorar si la base és de l'enemic
            if (equipoBase != this.equip) 
            {
                Debug.Log($"[Player] Passant per sobre de la base enemiga ({equipoBase}). Ignorant.");
                return;
            }

            // 2.3 Validar lliurament de bandera a la base pròpia
            if (banderaAgafada != null)
            {
                Debug.Log("[Player] Has entrat a la teva base amb la bandera! Finalitzant partida.");
                
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.FinalitzarPartida(true);
                }
            }
            else
            {
                Debug.Log("[Player] Estàs a la teva base, però no portes cap bandera.");
            }
            return;
        }

        // Altres triggers (escales, etc.)
        if (collision.CompareTag("ZonaEscalera"))
        {
            isNearLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other == null || other.gameObject == null) return;

        if (other.CompareTag("ZonaEscalera"))
        {
            isNearLadder = false;
            isClimbing = false;
            if (rb != null)
            {
                rb.gravityScale = defaultGravity;
            }
        }
    }

    public void InicialitzarJugador(string username, string team)
    {
        Debug.Log($"Inicialitzant jugador {username} a l'equip {team}");
        
        if (uiDocument != null)
        {
            VisualElement root = uiDocument.rootVisualElement;
            Label nameLabel = root.Q<Label>("NomUsuari"); // Busquem el label del nametag
            if (nameLabel != null)
            {
                nameLabel.text = username;
            }
        }

        // Configurem l'idJugador segons l'equip rebut
        if (team.ToLower() == "rojo") idJugador = 1;
        else if (team.ToLower() == "azul") idJugador = 2;
    }

    public void WinCombat()
    {
        GuanyarMinijoc();
        StartCoroutine(HandleWinCoroutine(5));
    }

    public void LoseCombat()
    {
        if (isInvulnerable) return;

        PerdreMinijoc();

        lives--;
        if (anim != null) anim.SetTrigger("hurt");
        UpdateLivesUI();

        if (lives <= 0)
        {
            StartCoroutine(HandleRespawnCoroutine(45));
        }
        else
        {
            AplicarCastigDerrota();
        }
    }

    public void GuanyarMinijoc()
    {
        Debug.Log("[Player] Victoria en minijoc. Enviant Senyal X (9999).");
        posAbansDeGuanyar = transform.position;
        transform.position = new Vector3(9999f, 9999f, 0);
        StartCoroutine(TornarPosicio());
        potMoure = true;
    }

    private System.Collections.IEnumerator TornarPosicio()
    {
        yield return new WaitForSeconds(0.2f);
        transform.position = posAbansDeGuanyar;
    }

    public void PerdreMinijoc()
    {
        Debug.Log("[Player] Derrota detectada. Iniciant STUN.");
        StartCoroutine(RutinaStun(3f));
    }

    private System.Collections.IEnumerator RutinaStun(float temps)
    {
        potMoure = false;
        yield return new WaitForSeconds(temps);
        potMoure = true;
        Debug.Log("[Player] STUN finalitzat.");
    }

    public void FinalitzarCombat()
    {
        potMoure = true;
        StartCoroutine(CombatCooldownCoroutine(4f));
    }

    public void AplicarCastigDerrota()
    {
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0; 

        StartCoroutine(HandleLossCoroutine(7));
        StartCoroutine(CombatCooldownCoroutine(4f));
    }

    public void DeixarBandera()
    {
        if (banderaAgafada != null)
        {
            Bandera scriptB = banderaAgafada.GetComponent<Bandera>();
            if (scriptB != null)
            {
                scriptB.DeixarDeSeguir();
            }
            banderaAgafada = null;
        }
    }

    private System.Collections.IEnumerator CombatCooldownCoroutine(float seconds)
    {
        potCombatre = false;
        yield return new WaitForSeconds(seconds);
        potCombatre = true;
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < lifeIcons.Count; i++)
        {
            if (i < lives)
            {
                lifeIcons[i].style.display = DisplayStyle.Flex;
            }
            else
            {
                lifeIcons[i].style.display = DisplayStyle.None;
            }
        }
    }

    private System.Collections.IEnumerator HandleWinCoroutine(int duration)
    {
        isInvulnerable = true;
        Color originalColor = sr.color;
        sr.color = Color.yellow;

        yield return new WaitForSeconds(duration);

        sr.color = originalColor;
        isInvulnerable = false;
    }

    private System.Collections.IEnumerator HandleLossCoroutine(int duration)
    {
        potMoure = false; 
        isFrozen = true;
        if (col != null) col.isTrigger = true;
        
        Color originalColor = sr.color;
        sr.color = Color.blue;

        yield return new WaitForSeconds(duration);

        sr.color = originalColor;
        isFrozen = false;
        if (col != null) col.isTrigger = false;
        rb.gravityScale = defaultGravity; 
        potMoure = true; 
    }

    private System.Collections.IEnumerator HandleRespawnCoroutine(int duration)
    {
        if (anim != null) anim.SetBool("isDead", true);
        potMoure = false;
        isFrozen = true;
        if (col != null) col.isTrigger = true; 
        rb.gravityScale = 0; 
        
        Color originalColor = sr.color;
        sr.color = Color.black;

        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
        }

        yield return new WaitForSeconds(duration);

        lives = 5;
        UpdateLivesUI();
        sr.color = originalColor;
        isFrozen = false;
        if (col != null) col.isTrigger = false;
        rb.gravityScale = defaultGravity;
        if (anim != null) anim.SetBool("isDead", false);
        potMoure = true;
    }

    private bool CheckGrounded()
    {
        Bounds bounds = col.bounds;
        Vector2 origin = new Vector2(bounds.center.x, bounds.min.y);
        Vector2 size = new Vector2(bounds.size.x * 0.8f, 0.1f);
        Collider2D[] hits = Physics2D.OverlapBoxAll(origin, size, 0f);
        foreach (Collider2D hit in hits)
        {
            if (hit != col && !hit.isTrigger) return true;
        }
        return false;
    }
}
