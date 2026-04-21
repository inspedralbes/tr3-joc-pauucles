using UnityEngine;

public class RemotePlayer : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator anim;
    private Nametag nametag;
    public string username;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        nametag = GetComponentInChildren<Nametag>();
        
        // Desactivem scripts de control local si n'hi ha
        Player localPlayerScript = GetComponent<Player>();
        if (localPlayerScript != null) localPlayerScript.enabled = false;
        
        // El NetworkSync ja s'encarrega d'auto-configurar-se com a remot i cinemàtic
    }

    public void Configurar(string username)
    {
        this.username = username;
        if (nametag != null)
        {
            nametag.Configurar(username, "white"); // Color per defecte per a remots
        }
    }

    public void UpdateStatus(NetworkSync.PlayerMoveMessage msg)
    {
        // Utilitzem el NetworkSync per gestionar la posició suavitzada
        NetworkSync ns = GetComponent<NetworkSync>();
        if (ns != null)
        {
            ns.RebrePosicio(msg.x, msg.y, msg.z);
        }
        else
        {
            // Fallback si no hi ha NetworkSync (teletransport directe)
            transform.position = new Vector3(msg.x, msg.y, msg.z);
        }

        if (sr != null) sr.flipX = msg.flipX;
        
        if (anim != null)
        {
            anim.SetFloat("yVelocity", msg.yVelocity);
            anim.SetBool("isRunning", msg.isRunning);
            anim.SetBool("isGrounded", msg.isGrounded);
            anim.SetBool("isClimbing", msg.isClimbing);
        }

        // --- SINCRONITZACIÓ DE BANDERA ---
        SincronitzarBanderaRemota(msg.banderaEquip);
    }

    private void SincronitzarBanderaRemota(string equipBandera)
    {
        // 1. Si no hauríem de portar res
        if (string.IsNullOrEmpty(equipBandera))
        {
            // Si tenim alguna cosa, la deixem anar
            Player p = GetComponent<Player>();
            if (p != null && p.banderaAgafada != null)
            {
                p.DeixarBandera();
            }
            return;
        }

        // 2. Si hauríem de portar una bandera
        Player localP = GetComponent<Player>();
        if (localP != null)
        {
            // Si ja portem la que toca, no fem res
            if (localP.banderaAgafada != null)
            {
                Bandera b = localP.banderaAgafada.GetComponent<Bandera>();
                if (b != null && b.equipPropietari == equipBandera) return;
            }

            // Si no la portem o es la equivocada, la busquem i la capturem
            GameObject[] banderes = GameObject.FindGameObjectsWithTag("Bandera");
            foreach (var bObj in banderes)
            {
                Bandera b = bObj.GetComponent<Bandera>();
                if (b != null && b.equipPropietari == equipBandera)
                {
                    // Forçar captura en aquest client pel personatge remot
                    b.transform.SetParent(this.transform);
                    localP.banderaAgafada = b.transform;
                    if (bObj.GetComponent<Rigidbody2D>() != null) 
                        bObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                    break;
                }
            }
        }
    }
}
