using UnityEngine;

public class Bandera : MonoBehaviour
{
    public string equipPropietari; // "A" o "B"
    private Vector3 posicioInicial;
    private Rigidbody2D rb;

    void Start()
    {
        posicioInicial = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si ja té pare, no fem res
        if (transform.parent != null) return;

        if (collision.CompareTag("Player"))
        {
            Player p = collision.GetComponentInParent<Player>();
            if (p == null) p = collision.GetComponent<Player>();

            if (p != null)
            {
                // Només el jugador local decideix la seva captura
                if (p.username != WebSocketClient.Username) return;

                // REGLA: Si ets de l'altre equip, la agafes. Si ets del mateix, et fa rebotar.
                string elMeuEquip = GameManager.Instance.GetTeamFromRoomData(p.username);

                if (elMeuEquip != equipPropietari)
                {
                    if (p.banderaAgafada == null && p.potCombatre) Capturar(p);
                }
                else
                {
                    // Empenta si és la teva
                    p.AplicarEmpenta(transform.position);
                }
            }
        }
    }

    private void Capturar(Player p)
    {
        transform.SetParent(p.transform);
        p.banderaAgafada = this.transform;
        if (rb != null) rb.bodyType = RigidbodyType2D.Kinematic;
        transform.localPosition = new Vector3(0f, 0.5f, 0f);
        Debug.Log($"[BANDERA] Capturada per {p.username}");
    }

    public void DeixarDeSeguir()
    {
        transform.SetParent(null);
        if (rb != null) rb.bodyType = RigidbodyType2D.Dynamic;
    }

    // Tornar a la base si arriba a la base contraria (Victoria)
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Spawn"))
        {
            // Lògica de victoria ja gestionada per altres scripts o per distància
        }
    }
}
