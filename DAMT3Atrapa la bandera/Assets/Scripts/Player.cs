using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float climbSpeed = 4f;
    public float coyoteTime = 0.2f;
    public float jumpBufferTime = 0.2f;
    public Transform respawnPoint;
    public UIDocument uiDocument;
    public bool potMoure = true;
    public bool potCombatre = true;
    public int idJugador = 1; // 1 per a J1, 2 per a J2

    private int lives = 5;
    private bool isFrozen = false;
    private bool isInvulnerable = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Collider2D col; // Referència al collider
    private float originalGravity; // Emmagatzematge de la gravetat original
    private bool isGrounded = false;
    private bool tocantEscala = false;
    private bool escalant = false;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;
    public Transform banderaAgafada;
    private Transform banderaPortant; // Referència optimitzada per a la bandera
    private List<VisualElement> lifeIcons = new List<VisualElement>();
    private float tempsInactiu = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        
        rb.freezeRotation = true; 
        originalGravity = rb.gravityScale; // Guardem el valor inicial

        if (uiDocument != null)
        {
            VisualElement root = uiDocument.rootVisualElement;
            for (int i = 1; i <= 5; i++)
            {
                VisualElement icon = root.Q<VisualElement>("Vida" + i);
                if (icon != null) lifeIcons.Add(icon);
            }
        }

        UpdateLivesUI();
    }

    void Update()
    {
        if (isFrozen || !potMoure) 
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            
            // RESET AFK: Si no ens podem moure, no podem estar AFK
            if (tempsInactiu > 0)
            {
                tempsInactiu = 0f;
                Color c = sr.color;
                c.a = 1f;
                sr.color = c;
            }
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

        // GESTIÓ AFK (Parpelleig)
        if (moveInput == 0 && !escalant)
        {
            tempsInactiu += Time.deltaTime;
            if (tempsInactiu > 3f)
            {
                float alpha = Mathf.PingPong(Time.time * 4f, 1f);
                Color c = sr.color;
                c.a = alpha;
                sr.color = c;
            }
        }
        else
        {
            if (tempsInactiu > 0)
            {
                tempsInactiu = 0f;
                Color c = sr.color;
                c.a = 1f;
                sr.color = c;
            }
        }

        // Coyote Time Counter
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        // Jump Buffer Counter
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        // Lògica d'Escalada
        if (tocantEscala && (Input.GetAxisRaw("Vertical") > 0.1f || Input.GetButton("Jump")))
        {
            escalant = true;
        }

        // Jump Execution
        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f && !escalant)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            jumpBufferCounter = 0f;
            coyoteTimeCounter = 0f;
        }

        // Variable Jump Height
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }

        // Gestió dinàmica de la posició de la bandera
        ActualitzarPosicioBandera(moveInput);
    }

    void FixedUpdate()
    {
        if (escalant)
        {
            rb.gravityScale = 0;
            float vInput = Input.GetAxisRaw("Vertical");

            if (Input.GetButton("Jump"))
            {
                vInput = 1f;
            }

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, vInput * climbSpeed);
        }
        else if (!isFrozen) // Evitem sobreescriure gravityScale si estem en un estat especial (com el respawn)
        {
            rb.gravityScale = originalGravity;
        }
    }

    private void ActualitzarPosicioBandera(float moveInput)
    {
        // Busquem la bandera si no la tenim (optimitzat)
        if (banderaPortant == null)
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("Bandera"))
                {
                    banderaPortant = child;
                    break;
                }
            }
        }

        if (banderaPortant != null)
        {
            float targetX = banderaPortant.localPosition.x;

            if (moveInput > 0) targetX = -0.8f; // Moviment dreta -> bandera esquerra
            else if (moveInput < 0) targetX = 0.8f; // Moviment esquerra -> bandera dreta

            // Mantindrem l'Y a 0 per deixar espai al futur nametag a sobre del cap (Y=0.8 era l'anterior)
            Vector3 posicioDesitjada = new Vector3(targetX, 0, 0);
            banderaPortant.localPosition = Vector3.Lerp(banderaPortant.localPosition, posicioDesitjada, Time.deltaTime * 6f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("He xocat contra: " + collision.gameObject.name + " amb Tag: " + collision.gameObject.tag);
        isGrounded = true; 

        if (collision.gameObject.CompareTag("Player"))
        {
            Player opponent = collision.gameObject.GetComponent<Player>();
            if (opponent != null && MinijocUIManager.Instance != null && !MinijocUIManager.Instance.minijocActiu && potMoure && opponent.potMoure && potCombatre && opponent.potCombatre)
            {
                MinijocUIManager.Instance.ShowUI(this, opponent);
            }
        }
        else if (collision.gameObject.CompareTag("Bandera") && banderaAgafada == null)
        {
            AgafarBanderaAutomàticament(collision.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bandera") && banderaAgafada == null)
        {
            AgafarBanderaAutomàticament(other.gameObject);
        }

        if (other.CompareTag("BaseRoja") && banderaAgafada != null)
        {
            Debug.Log("¡EL EQUIPO ROJO HA CAPTURADO LA BANDERA Y GANA LA PARTIDA!");

            Destroy(banderaAgafada.gameObject);
            banderaAgafada = null; 
            banderaPortant = null;
        }

        if (other.CompareTag("ZonaEscalera"))
        {
            tocantEscala = true;
        }
    }

    private void AgafarBanderaAutomàticament(GameObject objBandera)
    {
        Debug.Log(this.name + " ha recollit la bandera automàticament!");

        Bandera scriptB = objBandera.GetComponent<Bandera>();
        if (scriptB != null) scriptB.fugint = false;

        Collider2D colB = objBandera.GetComponent<Collider2D>();
        if (colB != null) colB.enabled = false;

        AgafarBandera(objBandera.transform);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ZonaEscalera"))
        {
            tocantEscala = false;
            escalant = false;
            rb.gravityScale = originalGravity;
        }
    }

    public void WinCombat()
    {
        StartCoroutine(HandleWinCoroutine(5));
    }

    public void LoseCombat()
    {
        if (isInvulnerable) return;

        lives--;
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

    public void RobarBandera(Player perdedor)
    {
        // FIX: Cerca global de la bandera
        GameObject banderaObj = GameObject.FindGameObjectWithTag("Bandera");
        
        if (banderaObj != null)
        {
            if (perdedor != null) perdedor.DeixarBandera();
            this.AgafarBandera(banderaObj.transform);
            Debug.Log($"{this.name} ha robat la bandera!");
        }
    }

    public void AgafarBandera(Transform bandera)
    {
        banderaAgafada = bandera;
        banderaPortant = bandera;
        banderaAgafada.SetParent(this.transform);
        
        // Inicialització lateral (esquerra per defecte)
        banderaAgafada.localPosition = new Vector3(-0.8f, 0, 0);
        banderaAgafada.localScale = new Vector3(3f, 3f, 1f); // Forcem escala correcta
        
        Rigidbody2D rbBandera = banderaAgafada.GetComponent<Rigidbody2D>();
        if (rbBandera != null)
        {
            // FIX: Rigidbody2D.isKinematic is obsolete. Use bodyType = RigidbodyType2D.Kinematic.
            rbBandera.bodyType = RigidbodyType2D.Kinematic;
            rbBandera.linearVelocity = Vector2.zero;
        }
    }

    public void DeixarBandera()
    {
        if (banderaAgafada != null)
        {
            Rigidbody2D rbBandera = banderaAgafada.GetComponent<Rigidbody2D>();
            if (rbBandera != null)
            {
                // FIX: Rigidbody2D.isKinematic is obsolete. Use bodyType = RigidbodyType2D.Dynamic.
                rbBandera.bodyType = RigidbodyType2D.Dynamic;
            }
            
            banderaAgafada.SetParent(null);
            banderaAgafada = null;
            banderaPortant = null;
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
        rb.gravityScale = originalGravity; 
        potMoure = true; 
    }

    private System.Collections.IEnumerator HandleRespawnCoroutine(int duration)
    {
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
        rb.gravityScale = originalGravity;
        potMoure = true;
    }
}
