using UnityEngine;
using TMPro;

public class Nametag : MonoBehaviour
{
    public TextMeshProUGUI textNom;

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
