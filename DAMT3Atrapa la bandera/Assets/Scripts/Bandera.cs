using UnityEngine;

public class Bandera : MonoBehaviour
{
    private Vector3 posicioInicial;
    public bool fugint = false;
    private Collider2D col;
    public string equipPropietari;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer mySprite;
    private Vector3 ultimaPosicio;

    void Start()
    {
        posicioInicial = transform.position;
        ultimaPosicio = transform.position;
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    public void DeixarDeSeguir()
    {
        transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.parent != null) return;

        Debug.Log($"[Bandera] Xoc detectat amb: {collision.gameObject.name}, Tag: {collision.tag}");

        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null && player.banderaAgafada == null)
            {
                // NO permetem recollir si el jugador està en STUN/FANTASMA (8s)
                if (!player.potCombatre)
                {
                    Debug.Log($"[Bandera] Ignorant recollida: {player.username} està en estat FANTASMA.");
                    return;
                }

                // Obtenim l'equip del jugador directament de la variable sincronitzada
                string equipJugador = player.equip;

                Debug.Log($"[Bandera] Equip Jugador: {equipJugador} vs Equip Bandera: {equipPropietari}");

                // Verificació d'equips: Si són diferents, es pot capturar
                if (!string.IsNullOrEmpty(equipJugador) && equipJugador != equipPropietari)
                {
                    // CAPTURA JERÀRQUICA: Ens fem fills del jugador
                    transform.SetParent(collision.transform);
                    
                    // Seguretat per al SpriteRenderer
                    if (mySprite == null) mySprite = GetComponentInChildren<SpriteRenderer>();
                    float offsetX = (mySprite != null && mySprite.flipX) ? 0.5f : -0.5f;
                    transform.localPosition = new Vector3(offsetX, 0f, 0f);
                    
                    // Registrem la bandera al jugador
                    player.banderaAgafada = this.transform;

                    // Desactivem física perquè es mogui només per la jerarquia
                    if (rb != null) rb.bodyType = RigidbodyType2D.Kinematic;
                    
                    // Ignorem col·lisions físiques entre el jugador i la bandera
                    Collider2D playerCol = player.GetComponent<Collider2D>();
                    if (col != null && playerCol != null)
                    {
                        Physics2D.IgnoreCollision(playerCol, col, true);
                    }

                    Debug.Log("[Bandera] CAPTURADA!");
                }
                else
                {
                    Debug.Log($"[Bandera] Ignorant col·lisió: El jugador pertany al mateix equip ({equipPropietari}) o equip no definit.");
                }
            }
        }
    }

    void Update()
    {
        // Lògica reactiva quan la bandera és portada per un jugador
        if (transform.parent != null)
        {
            Player holder = transform.parent.GetComponent<Player>();
            if (holder != null && (!holder.potCombatre || holder.idJugador == 0)) // idJugador 0 podria ser un error, però mirem potCombatre
            {
                // Si el que em porta no pot combatre (està en stun), me deixo anar
                DeixarDeSeguir();
                holder.banderaAgafada = null;
                return;
            }

            // 1) Detecció de moviment
            bool sestaMovent = Vector3.Distance(transform.position, ultimaPosicio) > 0.002f;
            if (anim != null && anim.runtimeAnimatorController != null) anim.SetBool("isWalking", sestaMovent);

            // 2) Sincronització de Flip i Posició com a mascota
            SpriteRenderer parentSprite = transform.parent.GetComponentInChildren<SpriteRenderer>();
            if (parentSprite != null && mySprite != null)
            {
                mySprite.flipX = parentSprite.flipX;
                
                // Ajustem la posició local a zero absolut per evitar desviaments en remots
                transform.localPosition = Vector3.zero;
                
                // Opciónal: Si vols un offset petit cap a un costat segons flip
                float offsetX = mySprite.flipX ? 0.3f : -0.3f;
                transform.localPosition = new Vector3(offsetX, 0.4f, 0f);
            }
        }

        // Si no som fills de ningú i estem fugint cap a la base
        if (transform.parent == null && fugint)
        {
            // Moviment cap a la posicio inicial
            transform.position = Vector3.MoveTowards(transform.position, posicioInicial, 4f * Time.deltaTime);

            if (anim != null && anim.runtimeAnimatorController != null)
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
                    col.isTrigger = true; // Assegurem que segueixi sent trigger
                    col.enabled = true;
                }
                if (anim != null && anim.runtimeAnimatorController != null) anim.SetBool("isRunning", false);
                Debug.Log("La bandera ha tornat a la base.");
            }
        }

        // Guardem la posició per al següent frame
        ultimaPosicio = transform.position;
    }
}
