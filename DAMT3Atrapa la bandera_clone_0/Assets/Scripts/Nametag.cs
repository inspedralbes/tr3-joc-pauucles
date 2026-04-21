using UnityEngine;
using TMPro;

public class Nametag : MonoBehaviour
{
    public TextMeshProUGUI textNom;

    void Start()
    {
        // 1.2 Forçar que el Canvas del nametag estigui per sobre de tot
        Canvas c = GetComponent<Canvas>();
        if (c != null) c.sortingOrder = 10;

        // 1.3 Posicionar una mica per davant en l'eix Z per evitar parpelleig o quedar darrere
        transform.localPosition = new Vector3(0, 1.2f, -0.1f);
    }

    public void Configurar(string nom, string colorNom)
    {
        if (textNom != null)
        {
            textNom.text = nom;
            textNom.color = TraduirColor(colorNom);
        }
    }

    private Color TraduirColor(string colorNom)
    {
        if (string.IsNullOrEmpty(colorNom)) return Color.white;

        switch (colorNom.ToLower())
        {
            case "rojo":
            case "vermell":
                return Color.red;
            case "azul":
            case "blau":
                return Color.blue;
            case "verde":
            case "verd":
                return Color.green;
            case "amarillo":
            case "groc":
                return Color.yellow;
            default:
                Debug.LogWarning($"Color no reconegut: {colorNom}. Usant blanc.");
                return Color.white;
        }
    }

    void LateUpdate()
    {
        // Forçar que el nametag no roti amb el jugador (mantenir-se horitzontal)
        transform.rotation = Quaternion.identity;
    }
}
