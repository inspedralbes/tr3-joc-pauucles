using UnityEngine;

public class Bandera : MonoBehaviour
{
    private Vector3 posicioInicial;
    public bool fugint = false;
    public string equipPropietari; // "A" o "B"

    private Rigidbody2D rb;
    private SpriteRenderer mySprite;

    void Start()
    {
        posicioInicial = transform.position;
        rb = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. Si ja la porta algú, ignorem
        if (transform.parent != null) return;

        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponentInParent<Player>();
            if (player == null) player = collision.GetComponent<Player>();
            
            if (player != null)
            {
                // NOMÉS el jugador local decideix si agafa la bandera
                if (player.username != WebSocketClient.Username) return;

                // REGLA DE ORO: Mateix equip = BLOQUEIG FISIC
                if (player.equip == equipPropietari)
                {
                    Debug.Log($"[BANDERA] REBUTJAT: Ets de l'equip {player.equip}. No pots tocar aquesta bandera.");
                    
                    // Empenyem el jugador una mica enrera perquè no es quedi a sobre
                    Vector2 dirRebutj = (player.transform.position - transform.position).normalized;
                    Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
                    if (playerRB != null) playerRB.AddForce(dirRebutj * 10f, ForceMode2D.Impulse);
                    
                    return;
                }

                // Si és de l'enemic i no en portem cap, la capturem
                if (player.banderaAgafada == null && player.potCombatre)
                {
                    Capturar(player);
                }
            }
        }
    }

    private void Capturar(Player player)
    {
        transform.SetParent(player.transform);
        player.banderaAgafada = this.transform;
        if (rb != null) rb.bodyType = RigidbodyType2D.Kinematic;
        transform.localPosition = new Vector3(0f, 0.5f, 0f);
        Debug.Log($"[BANDERA] {equipPropietari} CAPTURADA per {player.username}");
    }

    public void DeixarDeSeguir()
    {
        transform.SetParent(null);
        if (rb != null) rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void Update()
    {
        if (transform.parent != null)
        {
            Player holder = transform.parent.GetComponent<Player>();
            if (holder != null && !holder.potCombatre)
            {
                DeixarDeSeguir();
                holder.banderaAgafada = null;
            }
            
            // Sincronitzar flipX
            SpriteRenderer pSprite = transform.parent.GetComponentInChildren<SpriteRenderer>();
            if (pSprite != null && mySprite != null) mySprite.flipX = pSprite.flipX;
        }

        if (transform.parent == null && fugint)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicioInicial, 5f * Time.deltaTime);
            if (Vector3.Distance(transform.position, posicioInicial) < 0.1f) fugint = false;
        }
    }
}
