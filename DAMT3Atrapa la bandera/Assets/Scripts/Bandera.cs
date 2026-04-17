using UnityEngine;

public class Bandera : MonoBehaviour
{
    private Vector3 posicioInicial;
    public bool fugint = false;
    private Collider2D col;

    [Header("Mascota Settings")]
    public Transform targetSeguiment;
    public float velocitatSeguiment = 3f;
    public float distanciaMinima = 1.5f;
    public float forçaSaltDino = 5f;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        posicioInicial = transform.position;
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void ComençarASeguir(Transform target)
    {
        targetSeguiment = target;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.bodyType = RigidbodyType2D.Dynamic;
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = true;
    }

    public void DeixarDeSeguir()
    {
        targetSeguiment = null;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }

    void Update()
    {
        if (targetSeguiment != null)
        {
            float distanciaHoritzontal = targetSeguiment.position.x - transform.position.x;
            float direccioX = Mathf.Sign(distanciaHoritzontal);
            bool isGrounded = CheckGrounded();

            if (Mathf.Abs(distanciaHoritzontal) > distanciaMinima)
            {
                // Apliquem velocitat horitzontal
                rb.linearVelocity = new Vector2(direccioX * velocitatSeguiment, rb.linearVelocity.y);
                
                // Detecció d'obstacles (murs o escales) cap endavant
                RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(direccioX, 0), 1f);
                if (hit.collider != null && !hit.collider.isTrigger && isGrounded)
                {
                    // Saltem l'obstacle
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, forçaSaltDino);
                }
            }
            else
            {
                // Ens aturem horitzontalment si estem a prop
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            }

            // Lògica d'animació
            bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
            if (anim != null)
            {
                anim.SetBool("isRunning", isRunning);
                anim.SetBool("isSad", false);
            }

            // Flip visual segons la direcció del moviment
            if (rb.linearVelocity.x > 0.1f) transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            else if (rb.linearVelocity.x < -0.1f) transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (fugint)
        {
            // Moviment cap a la posició inicial
            transform.position = Vector3.MoveTowards(transform.position, posicioInicial, 4f * Time.deltaTime);

            if (anim != null)
            {
                anim.SetBool("isRunning", true);
                anim.SetBool("isSad", false);
            }

            // Flip cap a la base
            float diff = posicioInicial.x - transform.position.x;
            if (diff > 0.1f) transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            else if (diff < -0.1f) transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            // Comprovació d'arribada
            if (Vector3.Distance(transform.position, posicioInicial) < 0.1f)
            {
                fugint = false;
                if (col != null)
                {
                    col.isTrigger = false;
                    col.enabled = true;
                }
                if (anim != null) anim.SetBool("isRunning", false);
                Debug.Log("La bandera ha tornat a la base.");
            }
        }
    }

    private bool CheckGrounded()
    {
        if (col == null) return false;
        Bounds bounds = col.bounds;
        Vector2 origin = new Vector2(bounds.center.x, bounds.min.y);
        Vector2 size = new Vector2(bounds.size.x * 0.8f, 0.1f);
        Collider2D[] hits = Physics2D.OverlapBoxAll(origin, size, 0f);
        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject != gameObject && !hit.isTrigger) return true;
        }
        return false;
    }
}
