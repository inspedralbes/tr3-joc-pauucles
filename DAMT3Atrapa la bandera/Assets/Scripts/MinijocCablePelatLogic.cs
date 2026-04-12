using UnityEngine;
using UnityEngine.UIElements;

public class MinijocCablePelatLogic : MonoBehaviour
{
    private bool enCurs = false;

    public void InicialitzarUI(VisualElement root)
    {
        VisualElement zonaInici = root.Q<VisualElement>("#ZonaInici");
        VisualElement zonaMeta = root.Q<VisualElement>("#ZonaMeta");
        VisualElement fonsPerill = root.Q<VisualElement>("#FonsPerill");

        if (zonaInici != null)
        {
            zonaInici.RegisterCallback<PointerEnterEvent>(evt => 
            {
                enCurs = true;
                Debug.Log("Cable iniciat!");
            });
        }

        if (zonaMeta != null)
        {
            zonaMeta.RegisterCallback<PointerEnterEvent>(evt => 
            {
                if (enCurs)
                {
                    enCurs = false;
                    Debug.Log("Minijoc Cable Pelat: Victòria Jugador 1");
                    MinijocUIManager.Instance.FinalitzarCombat("Jugador 1");
                }
            });
        }

        if (fonsPerill != null)
        {
            fonsPerill.RegisterCallback<PointerEnterEvent>(evt => 
            {
                if (enCurs)
                {
                    enCurs = false;
                    Debug.Log("Minijoc Cable Pelat: Derrota! Guanya Jugador 2");
                    MinijocUIManager.Instance.FinalitzarCombat("Jugador 2");
                }
            });
        }
    }
}
