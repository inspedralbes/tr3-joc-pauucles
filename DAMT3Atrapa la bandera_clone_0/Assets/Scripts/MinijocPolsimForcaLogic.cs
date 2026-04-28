using UnityEngine;
using UnityEngine.UIElements;

public class MinijocPolsimForcaLogic : MonoBehaviour
{
    private float puntuacioJ1 = 50f;
    private float tempsRestant = 10f;
    private bool jocActiu = false;
    private bool faseRevelacio = false;
    private float tempsRevelacio = 0.5f; // Task 2.1: Revelació ràpida

    private Label textTemps;
    private Label textResultat;
    private VisualElement barraJ1;
    private Button btnPrem;
    private string _winner = "";
    private string _loser = "";

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
    }

    private void OnBtnClicked()
    {
        ActualitzarPuntuacions(1);
    }

    public void IniciarMinijoc()
    {
        puntuacioJ1 = 50f;
        tempsRestant = 10f; // 1) TIMER ÚNICO: Inicia un cop (Task 1.1)
        tempsRevelacio = 0.5f;
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

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
            {
                ActualitzarPuntuacions(1);
            }

            ActualitzarUI();

            // 2) RESOLUCIÓN INSTANTÁNEA: Si algú arriba al límit, s'acaba (Task 2.2)
            if (puntuacioJ1 >= 100f || puntuacioJ1 <= 0f)
            {
                FinalitzarFaseJoc();
            }
        }
        else
        {
            tempsRevelacio -= Time.deltaTime;
            if (tempsRevelacio <= 0)
            {
                jocActiu = false;
                MinijocUIManager.Instance.FinalitzarCombat(_winner, _loser);
            }
        }
    }

    private void ActualitzarPuntuacions(int jugador)
    {
        if (jugador == 1) 
        {
            puntuacioJ1 += 2f;
            if (MenuManager.Instance != null) MenuManager.Instance.EnviarMinijocUpdate("CLICK");
        }
        else puntuacioJ1 -= 2f;

        puntuacioJ1 = Mathf.Clamp(puntuacioJ1, 0f, 100f);
    }

    public void RebreActualitzacioXarxa(string data)
    {
        if (jocActiu && !faseRevelacio && data == "CLICK")
        {
            ActualitzarPuntuacions(2);
            ActualitzarUI();
        }
    }

    public void RebreResultatXarxa(string winner)
    {
    }

    private void ActualitzarUI()
    {
        if (textTemps != null) textTemps.text = $"Temps: {Mathf.Max(0, tempsRestant):F1}s";
        if (barraJ1 != null) barraJ1.style.width = Length.Percent(puntuacioJ1);
    }

    private void FinalitzarFaseJoc()
    {
        if (faseRevelacio) return;
        faseRevelacio = true;
        
        _winner = "Empat";
        _loser = "Empat"; // Task 2.3

        if (puntuacioJ1 > 50) 
        {
            _winner = MinijocUIManager.Instance.jugador1.username;
            _loser = MinijocUIManager.Instance.jugador2.username;
        }
        else if (puntuacioJ1 < 50) 
        {
            _winner = MinijocUIManager.Instance.jugador2.username;
            _loser = MinijocUIManager.Instance.jugador1.username;
        }

        if (textResultat != null) 
            textResultat.text = "¡FIN!";

        // El primer que acaba envia el resultat (Task 2.3)
        if (MenuManager.Instance != null)
        {
            MenuManager.Instance.EnviarMinijocResult(_winner, _loser);
        }
    }
}
