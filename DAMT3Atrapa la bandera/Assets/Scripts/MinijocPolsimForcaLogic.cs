using UnityEngine;
using UnityEngine.UIElements;

public class MinijocPolsimForcaLogic : MonoBehaviour
{
    public float puntuacioJ1 = 50f;
    public float puntuacioJ2 = 50f;
    public float tempsRestant = 10f;
    public bool jocActiu = false;

    private Label textTemps;
    private VisualElement barraJ1;
    private Player p1, p2;

    public void InicialitzarUI(VisualElement root, Player player1, Player player2)
    {
        p1 = player1;
        p2 = player2;
        textTemps = root.Q<Label>("TextTempsPols");
        barraJ1 = root.Q<VisualElement>("BarraJ1Pols");
        Debug.Log("UI de Polsim de Força inicialitzada.");
    }

    public void IniciarMinijoc()
    {
        puntuacioJ1 = 50f;
        puntuacioJ2 = 50f;
        tempsRestant = 10f;
        jocActiu = true;
        
        // Actualització inicial de la UI
        ActualitzarUI();
        
        Debug.Log("Minijoc de Polsim de Força iniciat!");
    }

    void Update()
    {
        if (!jocActiu) return;

        // Gestió del temporitzador
        tempsRestant -= Time.deltaTime;
        if (tempsRestant <= 0)
        {
            FinalitzarMinijoc();
            return;
        }

        // Entrada Jugador 1: Espai o Clic Esquerre
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ActualitzarPuntuacions(1);
        }

        // Entrada Jugador 2: Return o Clic Dret
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(1))
        {
            ActualitzarPuntuacions(2);
        }

        // Actualització visual en cada frame
        ActualitzarUI();
    }

    private void ActualitzarPuntuacions(int jugador)
    {
        if (jugador == 1)
        {
            puntuacioJ1 += 2f;
            puntuacioJ2 -= 2f;
        }
        else
        {
            puntuacioJ2 += 2f;
            puntuacioJ1 -= 2f;
        }

        // Clampeig entre 0 i 100
        puntuacioJ1 = Mathf.Clamp(puntuacioJ1, 0f, 100f);
        puntuacioJ2 = Mathf.Clamp(puntuacioJ2, 0f, 100f);
    }

    private void ActualitzarUI()
    {
        if (textTemps != null)
        {
            textTemps.text = tempsRestant.ToString("F1");
        }

        if (barraJ1 != null)
        {
            barraJ1.style.width = Length.Percent(puntuacioJ1);
        }
    }

    private void FinalitzarMinijoc()
    {
        jocActiu = false;
        tempsRestant = 0;
        
        // Assegurem que l'UI reflecteix el final
        ActualitzarUI();

        string guanyador = "Empat";
        if (puntuacioJ1 > 50) 
        {
            guanyador = "Jugador 1";
            if (p1 != null) p1.WinCombat();
            if (p2 != null) p2.LoseCombat();
        }
        else if (puntuacioJ2 > 50) 
        {
            guanyador = "Jugador 2";
            if (p2 != null) p2.WinCombat();
            if (p1 != null) p1.LoseCombat();
        }

        Debug.Log("Minijoc finalitzat! Guanyador: " + guanyador);
        MinijocUIManager.Instance.FinalitzarCombat(guanyador);
    }
}
