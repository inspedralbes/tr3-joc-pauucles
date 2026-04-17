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
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
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
        Debug.Log("He xocat contra: " + collision.gameObject.name + " amb Tag: " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Player"))
        {
            Player opponent = collision.gameObject.GetComponent<Player>();
            if (opponent != null && MinijocUIManager.Instance != null && !MinijocUIManager.Instance.minijocActiu && potMoure && opponent.potMoure && potCombatre && opponent.potCombatre)
            {
                MinijocUIManager.Instance.ShowUI(this, opponent);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bandera") && banderaAgafada == null)
        {
            Bandera scriptB = collision.GetComponentInParent<Bandera>();
            if (scriptB != null)
            {
                banderaAgafada = scriptB.transform;
                Collider2D meuCol = GetComponent<Collider2D>();
                Collider2D[] dinoCols = scriptB.GetComponentsInChildren<Collider2D>();
                foreach (Collider2D c in dinoCols)
                {
                    if (c != null && meuCol != null)
                    {
                        Physics2D.IgnoreCollision(meuCol, c, true);
                    }
                }
                scriptB.ComençarASeguir(this.transform);
            }
        }

        if (collision.CompareTag("BaseRoja") && banderaAgafada != null)
        {
            Debug.Log("¡EL EQUIPO ROJO HA CAPTURADO LA BANDERA Y GANA LA PARTIDA!");

            Destroy(banderaAgafada.gameObject);
            banderaAgafada = null; 
        }

        if (collision.CompareTag("ZonaEscalera"))
        {
            isNearLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ZonaEscalera"))
        {
            isNearLadder = false;
            isClimbing = false;
            rb.gravityScale = defaultGravity;
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
        StartCoroutine(HandleWinCoroutine(5));
    }

    public void LoseCombat()
    {
        if (isInvulnerable) return;

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
