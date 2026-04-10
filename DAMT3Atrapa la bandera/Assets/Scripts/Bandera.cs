using UnityEngine;

public class Bandera : MonoBehaviour
{
    private Vector3 posicioInicial;
    public bool fugint = false;
    private Collider2D col;

    void Start()
    {
        posicioInicial = transform.position;
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (fugint)
        {
            // Moviment cap a la posició inicial
            transform.position = Vector3.MoveTowards(transform.position, posicioInicial, 4f * Time.deltaTime);

            // Comprovació d'arribada
            if (Vector3.Distance(transform.position, posicioInicial) < 0.1f)
            {
                fugint = false;
                if (col != null) col.enabled = true;
                Debug.Log("La bandera ha tornat a la base.");
            }
        }
    }
}
