using UnityEngine;
using TMPro;

public class Nametag : MonoBehaviour
{
    public TextMeshProUGUI textNom;

    void Start()
    {
        Canvas c = GetComponent<Canvas>();
        if (c != null) c.sortingOrder = 10;
        transform.localPosition = new Vector3(0, 1.2f, -0.1f);
    }

    public void Configurar(string nom, string infoEquip)
    {
        if (textNom != null)
        {
            string labelEquip = infoEquip.ToUpper();
            if (labelEquip == "A" || labelEquip == "B")
            {
                textNom.text = $"{nom} (EQUIP {labelEquip})";
                textNom.color = (labelEquip == "A") ? Color.cyan : new Color(1f, 0f, 1f); // Cyan o Magenta
            }
            else
            {
                textNom.text = nom;
                textNom.color = TraduirColor(infoEquip);
            }
        }
    }

    private Color TraduirColor(string colorNom)
    {
        if (string.IsNullOrEmpty(colorNom)) return Color.white;
        string c = colorNom.ToLower();
        if (c.Contains("roj") || c.Contains("vermell")) return Color.red;
        if (c.Contains("azul") || c.Contains("blau")) return Color.blue;
        if (c.Contains("verd")) return Color.green;
        if (c.Contains("groc") || c.Contains("amarillo")) return Color.yellow;
        return Color.white;
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }
}
