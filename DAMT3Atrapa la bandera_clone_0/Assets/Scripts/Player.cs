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
    public string username;

    // Variables per a la sincronització determinista (sense xarxa)
    private static float ultimXoc = 0f;
    private static int comptadorCombats = 0;

    private int lives = 3;
    private int maxLives = 3;
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
        if (string.IsNullOrEmpty(username)) username = WebSocketClient.LocalUsername;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>(); // Més robust per a prefabs complexes
        anim = GetComponentInChildren<Animator>();
        col = GetComponent<Collider2D>();
        
        rb.freezeRotation = true; 
        defaultGravity = rb.gravityScale; // Guardem el valor inicial

        if (uiDocument != null && GetComponent<RemotePlayer>() == null)
        {
            VisualElement root = uiDocument.rootVisualElement;
            for (int i = 1; i <= 5; i++)
            {
                // Búsqueda recursiva molt més potent
                VisualElement icon = root.Query<VisualElement>("Vida" + i).First();
                if (icon != null) {
                    lifeIcons.Add(icon);
                }
            }
            Debug.Log($"[HUD] Icones trobades: {lifeIcons.Count}");
        }
        else if (GetComponent<RemotePlayer>() != null)
        {
            Debug.Log($"[HUD] Jugador REMOT ({username}) detectat. Ignorant gestió de vides locals.");
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

        if (isFrozen || !potMoure || (rb != null && rb.bodyType == RigidbodyType2D.Static)) 
        {
            if (rb != null && rb.bodyType != RigidbodyType2D.Static)
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
        if (rb.bodyType == RigidbodyType2D.Static) return;

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
            // Bloquejar combat només si el propi jugador està en STUN
            // Ignorem el check del rival perquè la seva variable 'potCombatre' no se sincronitza per xarxa
            if (!potCombatre) {
                string nameForLog = string.IsNullOrEmpty(username) ? WebSocketClient.LocalUsername : username;
                Debug.Log($"[COMBAT] Skipped: {nameForLog} està en STUN/Cooldown.");
                return;
            }
            
            // 2.1 Tallafocs temporal per evitar doble dispar d'event (Physics Jitter)
            if (Time.time - ultimXoc < 3f) {
                Debug.Log($"[COMBAT] Skipped: Massa aviat des de l'últim xoc ({Time.time - ultimXoc:F1}s / 3.0s)");
                return;
            }

            RemotePlayer rp = collision.gameObject.GetComponent<RemotePlayer>();
            if (rp == null || string.IsNullOrEmpty(rp.username)) {
                // Si no hi ha RemotePlayer, pot ser un bot o un test local, però necessitem un nom pels minijocs
                return;
            }

            Player opponent = collision.gameObject.GetComponent<Player>();
            if (opponent != null && opponent.equip == this.equip) {
                Debug.Log($"[COMBAT] Skipped: {username} i {rp.username} són del mateix equip ({this.equip})");
                return;
            }

            if (opponent != null && opponent.equip != this.equip)
            {
                // 2.2 Sincronització de Col·lisió (Només un mana per evitar conflictes)
                ultimXoc = Time.time;
                comptadorCombats++;

                string localName = WebSocketClient.LocalUsername;
                string opponentName = rp != null ? rp.username : "Desconegut";

                // Lògica de Master: El que té el nom alfabèticament menor decideix el joc
                bool soyMaster = string.Compare(localName, opponentName) < 0;

                Debug.Log($"[COL·LISIÓ] Iniciant fase minijoc. Local={localName}, Rival={opponentName}, SocMaster={soyMaster}");

                if (soyMaster)
                {
                    // Generar un índex de joc aleatori entre els 5 jocs disponibles:
                    // 1: PPTLLS, 2: Parells/Senars, 3: Atura Barra, 5: Pols Força, 6: Acaparament
                    int[] jocsValids = { 1, 2, 3, 5, 6 };
                    int gameIndex = jocsValids[UnityEngine.Random.Range(0, jocsValids.Length)];

                    Debug.Log($"[MASTER] Col·lisió detectada. Escollit minijoc {gameIndex} de forma aleatòria.");

                    // 2.5 Enviar ordre d'inici per Xarxa
                    if (MenuManager.Instance != null)
                    {
                        MenuManager.Instance.EnviarMinijocStart(gameIndex, localName, opponentName);
                    }

                    // 2.6 Iniciar localment IMMEDIATAMENT (per al Master)
                    var managers = Resources.FindObjectsOfTypeAll<MinijocUIManager>();
                    if (managers.Length > 0)
                    {
                        var ui = managers[0];
                        ui.gameObject.SetActive(true);
                        ui.IniciarMinijoc(this.gameObject, collision.gameObject, gameIndex);
                    }
                }
                else
                {
                    Debug.Log($"[CLIENT] Col·lisió detectada. Esperant que el Master ({opponentName}) iniciï el joc...");
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
        this.username = username;
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
        // Reduir vida (Només una vegada) i iniciar procés de derrota
        ProcesarDerrota(8f);
    }

    public void GuanyarMinijoc()
    {
        Debug.Log("[Player] Victoria en minijoc. Restaurat moviment total.");
        potMoure = true;
        potCombatre = true;
        isFrozen = false; // Reset instantani del flag de congelat
        
        if (rb != null) {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = defaultGravity;
            rb.linearVelocity = Vector2.zero; // Limpiar inèrcies estranyes
        }
    }

    public void PerdreMinijoc()
    {
        ProcesarDerrota(8f);
    }

    public void ProcesarDerrota(float durada)
    {
        if (isInvulnerable) return;

        int videsAbans = lives;
        lives--;
        Debug.Log($"[DERROTA] {username} perd una vida. Abans: {videsAbans} -> Ara: {lives}");
        
        if (lives <= 0)
        {
            TornarABase();
            return;
        }

        UpdateLivesUI();

        if (anim != null) anim.SetTrigger("hurt");

        if (lives <= 0)
        {
            StartCoroutine(HandleRespawnCoroutine(45));
        }
        else
        {
            DeixarBandera(new Vector3(2f, 0f, 0f));
            AplicarEfecteVisualDerrota(durada);
        }
    }

    public void AplicarEfecteVisualDerrota(float durada)
    {
        StopAllCoroutines(); 
        StartCoroutine(RutinaDerrotaConsolidada(durada));
    }

    private System.Collections.IEnumerator RutinaDerrotaConsolidada(float temps)
    {
        isFrozen = true;
        potMoure = false;
        potCombatre = false;
        
        // ESPERAR UN MOMENT ABANS DE TORNAR-SE ESTÀTIC
        // Això permet que l'impulsió del knockback s'apliqui en mode Dynamic
        yield return new WaitForSeconds(0.3f);
        
        if (rb != null && isFrozen && rb.bodyType != RigidbodyType2D.Static) 
        {
            rb.linearVelocity = Vector2.zero; // FRENAR PRIMER
            rb.bodyType = RigidbodyType2D.Static; // CONGELAR DESPRÉS
        }

        if (col != null) col.isTrigger = true;

        float elapsed = 0f;
        bool visible = true;
        
        // Seguretat per al SpriteRenderer
        if (sr == null) sr = GetComponentInChildren<SpriteRenderer>();
        Color originalColor = (sr != null) ? sr.color : Color.white;

        while (elapsed < temps)
        {
            visible = !visible;
            if (sr != null) sr.color = visible ? Color.red : new Color(1, 0, 0, 0.2f);
            
            yield return new WaitForSeconds(0.1f);
            elapsed += 0.1f;
        }

        if (sr != null) sr.color = originalColor;
        isFrozen = false;
        if (col != null) col.isTrigger = false;
        
        if (rb != null) {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = defaultGravity;
        }

        potMoure = true;
        potCombatre = true;

        Debug.Log("[Player] Estat fantasma i bloqueig finalitzat.");
    }

    public void TornarABase()
    {
        Debug.Log($"[RESPAWN] {username} ha mort. Tornant a la base de l'equip {equip}.");
        
        // Reset de vides local
        lives = maxLives;
        UpdateLivesUI();

        // Trobar punt de spawn
        string spawnName = (equip == "A" || equip == "1") ? "PuntSpawn_Equip1" : "PuntSpawn_Equip2";
        GameObject spawnPoint = GameObject.Find(spawnName);
        
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.transform.position;
            // Si porta bandera, la deixa
            DeixarBandera();
        }
        else
        {
            Debug.LogWarning($"[RESPAWN] No s'ha trobat el punt de spawn: {spawnName}");
            // Fallback: usar el respawnPoint assignat si existeix
            if (respawnPoint != null) transform.position = respawnPoint.position;
        }

        // Recuperar moviment
        GuanyarMinijoc(); 
    }

    public void FinalitzarCombat()
    {
        // No restaurem potMoure aquí per no interrompre el STUN del perdedor
        StartCoroutine(CombatCooldownCoroutine(4f));
    }

    public void AplicarEmpenta(Vector2 rivalPos)
    {
        if (rb == null || rb.bodyType == RigidbodyType2D.Static) return;

        Vector2 dir = ((Vector2)transform.position - rivalPos).normalized;
        if (dir == Vector2.zero) dir = Random.insideUnitCircle.normalized;
        
        rb.AddForce(dir * 15f, ForceMode2D.Impulse);
        Debug.Log($"[Player] Aplicant empenta (knockback) en direcció {dir}");
    }

    public void DeixarBandera(Vector3? dropOffset = null)
    {
        if (banderaAgafada != null)
        {
            Bandera scriptB = banderaAgafada.GetComponent<Bandera>();
            if (scriptB != null)
            {
                scriptB.DeixarDeSeguir();
                if (dropOffset.HasValue)
                {
                    banderaAgafada.position += dropOffset.Value;
                }
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
        // Guard de seguretat: Només el jugador local pot tocar la UI global de vides
        if (GetComponent<RemotePlayer>() != null || uiDocument == null) return;

        VisualElement root = uiDocument.rootVisualElement;
        if (root == null) return;

        // 1. Cercar o crear el contenidor absolut HUD_Vides
        VisualElement hudVides = root.Q<VisualElement>("HUD_Vides");
        if (hudVides == null)
        {
            hudVides = new VisualElement();
            hudVides.name = "HUD_Vides";
            hudVides.style.position = Position.Absolute;
            hudVides.style.top = 20;
            hudVides.style.left = 20;
            hudVides.style.flexDirection = FlexDirection.Row;
            root.Add(hudVides);
            Debug.Log("[HUD] Creat nou contenidor 'HUD_Vides' al root.");
        }

        // 2. Netejar i redibuixar els cors segons la vida actual
        hudVides.Clear();
        
        // Intentar carregar l'sprite iconaVida des de Resources si no el tenim
        Sprite spriteVida = Resources.Load<Sprite>("Sprites/iconaVida");
        if (spriteVida == null)
        {
            // Fallback: buscar un sprite amb aquest nom a l'escena o actius carregats
            var sprites = Resources.FindObjectsOfTypeAll<Sprite>();
            foreach (var s in sprites) { if (s.name == "iconaVida") { spriteVida = s; break; } }
        }

        for (int i = 0; i < lives; i++)
        {
            VisualElement cor = new VisualElement();
            cor.style.width = 40;
            cor.style.height = 40;
            cor.style.marginLeft = 5;
            cor.style.marginRight = 5;
            
            if (spriteVida != null)
            {
                cor.style.backgroundImage = new StyleBackground(spriteVida);
            }
            else
            {
                cor.style.backgroundColor = Color.red; // Fallback visual
            }
            
            hudVides.Add(cor);
        }

        Debug.Log($"[HUD] Actualitzat HUD de vides: {lives} cors dibuixats.");
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

        lives = maxLives;
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
