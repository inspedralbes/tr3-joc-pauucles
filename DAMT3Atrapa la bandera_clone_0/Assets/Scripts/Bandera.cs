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

        // Sincronització de xarxa per a la bandera (NPC)
        NetworkSync ns = GetComponent<NetworkSync>();
        if (ns == null) ns = gameObject.AddComponent<NetworkSync>();
        ns.idNPC = "BANDERA_" + equipPropietari;
        ns.sendRate = 0.1f;
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
                string elMeuUser = WebSocketClient.Username;
                if (string.IsNullOrEmpty(elMeuUser) && MenuManager.Instance != null) elMeuUser = MenuManager.Instance.userId;

                // Task 7.1: Comparació sense majúscules per evitar errors de "pau21" vs "Pau21"
                if (string.IsNullOrEmpty(player.username) || string.IsNullOrEmpty(elMeuUser) || 
                    !player.username.Equals(elMeuUser, System.StringComparison.OrdinalIgnoreCase)) 
                {
                    return;
                }

                string elMeuEquip = player.equip;
                if (string.IsNullOrEmpty(elMeuEquip) && MenuManager.Instance != null) elMeuEquip = MenuManager.Instance.meuEquip;

                // Task 7.11: Seguretat - Si no sabem l'equip, BLOQUEM (evita errors inicials)
                if (string.IsNullOrEmpty(elMeuEquip)) return;

                // Debug log per saber qui som al tocar la bandera
                Debug.Log($"<color=cyan>[DEBUG-BANDERA]</color> Col·lisió detectada!");
                Debug.Log($" - Jugador: {player.username}");
                Debug.Log($" - Equip Jugador (local): {player.equip}");
                Debug.Log($" - Equip Jugador (MenuManager): {MenuManager.Instance.meuEquip}");
                Debug.Log($" - Propietari Bandera: {this.equipPropietari}");

                // REGLA DE ORO: Mateix equip = BLOQUEIG FISIC
                bool esLaMeva = false;
                if (!string.IsNullOrEmpty(elMeuEquip) && elMeuEquip.Equals(this.equipPropietari, System.StringComparison.OrdinalIgnoreCase)) esLaMeva = true;
                
                if (esLaMeva)
                {
                    Debug.Log($"<color=red>[BANDERA]</color> REBUTJAT: {player.username} ({elMeuEquip}) ha intentat agafar la SEVA bandera ({this.equipPropietari}).");
                    
                    // Empenyem el jugador una mica enrera perquè no es quedi a sobre
                    Vector2 dirRebutj = (player.transform.position - transform.position).normalized;
                    Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
                    if (playerRB != null) 
                    {
                        playerRB.linearVelocity = Vector2.zero;
                        playerRB.AddForce(dirRebutj * 15f, ForceMode2D.Impulse);
                    }
                    
                    return;
                }

                // Task 7.14: Capturar la bandera si tot està OK
                if (player.banderaAgafada == null && player.potCombatre)
                {
                    Debug.Log($"<color=green>[BANDERA]</color> EXIT: {player.username} ha capturat la bandera ENEMIGA ({this.equipPropietari}).");
                    Capturar(player);
                }
                else
                {
                    string rao = (player.banderaAgafada != null) ? "Ja portes una bandera" : "No pots combatre ara mateix";
                    Debug.Log($"<color=yellow>[BANDERA]</color> No es pot capturar: {rao}");
                }
            }
        }
    }

    private void Capturar(Player player)
    {
        // Task 7.8: Seguretat extrema - No es pot capturar la pròpia bandera mai
        string elMeuEquip = player.equip;
        if (string.IsNullOrEmpty(elMeuEquip) && MenuManager.Instance != null) elMeuEquip = MenuManager.Instance.meuEquip;

        if (!string.IsNullOrEmpty(elMeuEquip) && elMeuEquip.Equals(this.equipPropietari, System.StringComparison.OrdinalIgnoreCase))
        {
            Debug.LogError($"[BANDERA] BLOQUEIG CRÍTIC: {player.username} ha intentat capturar la seva pròpia bandera ({this.equipPropietari})!");
            return;
        }

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
            if (holder != null && holder.isFrozen)
            {
                DeixarDeSeguir();
                holder.banderaAgafada = null;
                return;
            }
            
            // Sincronitzar flipX
            SpriteRenderer pSprite = transform.parent.GetComponentInChildren<SpriteRenderer>();
            if (pSprite != null && mySprite != null) mySprite.flipX = pSprite.flipX;

            // Task 4.2: Si portem la bandera, desactivem el seu NetworkSync propi per evitar conflictes
            NetworkSync ns = GetComponent<NetworkSync>();
            if (ns != null && ns.enabled) ns.enabled = false;
        }
        else
        {
            // Task 4.2: Si la bandera està lliure, el NetworkSync ha d'estar actiu per sincronitzar terra/fugida
            NetworkSync ns = GetComponent<NetworkSync>();
            if (ns != null && !ns.enabled) ns.enabled = true;
        }

        if (transform.parent == null && fugint)
        {
            // Només el Host mou la bandera cap a la base, els altres sincronitzen posició
            if (MenuManager.Instance != null && MenuManager.Instance.IsHost())
            {
                transform.position = Vector3.MoveTowards(transform.position, posicioInicial, 5f * Time.deltaTime);
                if (Vector3.Distance(transform.position, posicioInicial) < 0.1f) fugint = false;
            }
        }
    }

    public void ResetABase()
    {
        transform.SetParent(null);
        transform.position = posicioInicial;
        fugint = false;
        if (rb != null) 
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
        Debug.Log($"[BANDERA] {equipPropietari} ha tornat a la seva base.");
    }
}
