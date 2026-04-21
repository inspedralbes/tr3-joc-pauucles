using UnityEngine;
using UnityEngine.UIElements;

public class MinijocPolsimForcaLogic : MonoBehaviour
{
    private float puntuacioJ1 = 50f;
    private float tempsRestant = 10f;
    private bool jocActiu = false;
    private bool faseRevelacio = false;
    private float tempsRevelacio = 3f;

    private Label textTemps;
    private Label textResultat;
    private VisualElement barraJ1;
    private Button btnPrem;
    private string _guanyador = "Empat";

    public void InicialitzarUI(VisualElement root)
    {
        textTemps = root.Q<Label>("TextTempsPols");
        textResultat = root.Q<Label>("TextResultatPols");
        barraJ1 = root.Q<VisualElement>("BarraJ1Pols");
        btnPrem = root.Q<Button>("BtnPrem");

        if (btnPrem != null) 
        {
            btnPrem.clicked -= OnBtnClicked;
            btnPrem.clicked += OnBtnClicked;
        }

        if (textResultat != null) textResultat.text = "";
        Debug.Log($"UI de Polsim de Força inicialitzada. Botó={btnPrem != null}");
    }

    private void OnBtnClicked()
    {
        Debug.Log("[PolsimForca] Botó Click detectat!");
        ActualitzarPuntuacions(1);
    }

    public void IniciarMinijoc()
    {
        puntuacioJ1 = 50f;
        tempsRestant = 10f;
        tempsRevelacio = 3f;
        jocActiu = true;
        faseRevelacio = false;
        
        ActualitzarUI();
        if (textResultat != null) textResultat.text = "Prem ràpid!";
    }

    void Update()
    {
        if (!jocActiu) return;

        if (!faseRevelacio)
        {
            tempsRestant -= Time.deltaTime;
            if (tempsRestant <= 0)
            {
                FinalitzarFaseJoc();
                return;
            }

            // Entrada Jugador Local: Qualsevol tecla d'acció (Espai, Return o Clic)
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
            {
                ActualitzarPuntuacions(1);
            }

            ActualitzarUI();
        }
        else
        {
            tempsRevelacio -= Time.deltaTime;
            if (tempsRevelacio <= 0)
            {
                jocActiu = false;
                MinijocUIManager.Instance.FinalitzarCombat(_guanyador);
            }
        }
    }

    private void ActualitzarPuntuacions(int jugador)
    {
        if (jugador == 1) 
        {
            puntuacioJ1 += 2f;
            // Envia clic local al rival
            if (MenuManager.Instance != null) MenuManager.Instance.EnviarMinijocUpdate("CLICK");
        }
        else puntuacioJ1 -= 2f;

        puntuacioJ1 = Mathf.Clamp(puntuacioJ1, 0f, 100f);
    }

    public void RebreActualitzacioXarxa(string data)
    {
        if (jocActiu && !faseRevelacio && data == "CLICK")
        {
            // El rival ha fet clic, nosaltres perdem terreny (per nosaltres el rival és el jugador 2)
            ActualitzarPuntuacions(2);
            ActualitzarUI();
        }
    }

    public void RebreResultatXarxa(string winner)
    {
        // En aquest joc el resultat es calcula per temps, però per seguretat:
        if (jocActiu && !faseRevelacio && winner == "RIVAL_WIN")
        {
            puntuacioJ1 = 0;
            FinalitzarFaseJoc();
        }
    }

    private void ActualitzarUI()
    {
        if (textTemps != null) textTemps.text = $"Temps: {Mathf.Max(0, tempsRestant):F1}s";
        if (barraJ1 != null) barraJ1.style.width = Length.Percent(puntuacioJ1);
    }

    private void FinalitzarFaseJoc()
    {
        faseRevelacio = true;
        
        _guanyador = "Empat";
        if (puntuacioJ1 > 55) _guanyador = "Jugador 1";
        else if (puntuacioJ1 < 45) _guanyador = "Jugador 2";

        if (textResultat != null) 
            textResultat.text = $"Final! Guanya {_guanyador}!";
    }
}
