using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class MinijocParellsSenarsLogic : MonoBehaviour
{
    private Label _textNums, _textResultat, _textTemps;
    private Button _btnParell, _btnSenar;
    private int _num1, _num2;
    private float _tempsRestant = 10f;
    private bool jocActiu = false;
    private bool respostaEsParell;
    
    private bool? _eleccioJ1; // Local
    private bool? _eleccioJ2; // Rival

    public void InicialitzarUI(VisualElement root)
    {
        _textNums = root.Q<Label>("TextOperacio");
        _textTemps = root.Q<Label>("TextTempsMates");
        _textResultat = root.Q<Label>("TextResultatMates");
        _btnParell = root.Q<Button>("BtnParells");
        _btnSenar = root.Q<Button>("BtnSenars");

        _btnParell.clicked -= () => Respon(true); _btnParell.clicked += () => Respon(true);
        _btnSenar.clicked -= () => Respon(false); _btnSenar.clicked += () => Respon(false);
    }

    public void IniciarMinijoc()
    {
        if (MenuManager.Instance != null && !string.IsNullOrEmpty(MenuManager.Instance.currentRoomId))
        {
            int seed = MenuManager.Instance.currentRoomId.GetHashCode();
            Random.InitState(seed);
        }

        _num1 = Random.Range(15, 80);
        _num2 = Random.Range(15, 80);
        
        jocActiu = true;
        _tempsRestant = 10f; // 1) TIMER ÚNICO: Inicia un cop (Task 1.1)
        _eleccioJ1 = null;
        _eleccioJ2 = null;
        ActualitzarUI();
        Debug.Log($"[ParellsSenars] Mates preparades: {_num1} + {_num2}");
    }

    private void ActualitzarUI()
    {
        if (_textNums != null)
        {
            if (_num1 == 0 && _num2 == 0) _textNums.text = "Sincronitzant...";
            else _textNums.text = $"{_num1} + {_num2}";
        }
        
        respostaEsParell = ((_num1 + _num2) % 2 == 0);
        if (_textTemps != null) _textTemps.text = "Calcula!";
    }

    public void RebreActualitzacioXarxa(string data)
    {
        if (!jocActiu) return;

        if (data.StartsWith("CHOICE:"))
        {
            _eleccioJ2 = (data.Split(':')[1] == "1");
            Debug.Log("[ParellsSenars] Rival ha escollit.");
        }
    }

    private void Respon(bool triatParell)
    {
        if (!jocActiu || _eleccioJ1 != null) return;

        _eleccioJ1 = triatParell;
        if (MenuManager.Instance != null) MenuManager.Instance.EnviarMinijocUpdate("CHOICE:" + (triatParell ? "1" : "0"));
    }

    private void Update()
    {
        if (!jocActiu) return;

        // 1) TIMER ÚNICO: El temps corre sempre (Task 1.1)
        _tempsRestant -= Time.deltaTime;
        if (_textTemps != null) _textTemps.text = $"Temps: {Mathf.Max(0, _tempsRestant):F1}s";

        // 2) RESOLUCIÓN INSTANTÁNEA (Task 2.2)
        if (_tempsRestant <= 0 || (_eleccioJ1 != null && _eleccioJ2 != null))
        {
            Resoldre();
        }
    }

    private void Resoldre()
    {
        if (!jocActiu) return;
        jocActiu = false;

        bool localCorrecte = (_eleccioJ1 == respostaEsParell);
        bool rivalCorrecte = (_eleccioJ2 == respostaEsParell);

        if (_eleccioJ1 == null) localCorrecte = false;
        if (_eleccioJ2 == null) rivalCorrecte = false;

        string winner = "Empat";
        string loser = "Empat"; // Task 2.3

        if (localCorrecte && !rivalCorrecte)
        {
            winner = MinijocUIManager.Instance.jugador1.username;
            loser = MinijocUIManager.Instance.jugador2.username;
        }
        else if (!localCorrecte && rivalCorrecte)
        {
            winner = MinijocUIManager.Instance.jugador2.username;
            loser = MinijocUIManager.Instance.jugador1.username;
        }

        if (winner == "Empat" && (localCorrecte || rivalCorrecte))
        {
            IniciarMinijoc();
        }
        else
        {
            if (MenuManager.Instance != null)
            {
                MenuManager.Instance.EnviarMinijocResult(winner, loser);
            }
            MinijocUIManager.Instance.FinalitzarCombat(winner, loser);
        }
    }
}
