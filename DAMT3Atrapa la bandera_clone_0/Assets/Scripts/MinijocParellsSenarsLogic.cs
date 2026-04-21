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
        // SISTEMA DE SEMILLA PARA SINCRONIZACIÓN INSTANTÁNEA
        // Usamos el roomId como semilla para que ambos generen lo mismo sin red
        if (MenuManager.Instance != null && !string.IsNullOrEmpty(MenuManager.Instance.currentRoomId))
        {
            int seed = MenuManager.Instance.currentRoomId.GetHashCode();
            Random.InitState(seed);
            Debug.Log($"[ParellsSenars] Usant llavor de sala ({MenuManager.Instance.currentRoomId}) per a sincronització instantània.");
        }

        _num1 = Random.Range(15, 80);
        _num2 = Random.Range(15, 80);
        
        jocActiu = true;
        _tempsRestant = 10f;
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
        if (_textTemps != null) _textTemps.text = (_num1 == 0) ? "..." : "Calcula!";
    }

    public void RebreActualitzacioXarxa(string data)
    {
        if (!jocActiu) return;

        if (data.StartsWith("NUMS:"))
        {
            string[] parts = data.Substring(5).Split(',');
            _num1 = int.Parse(parts[0]);
            _num2 = int.Parse(parts[1]);
            ActualitzarUI();
        }
        else if (data.StartsWith("CHOICE:"))
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

        bool algunTriat = (_eleccioJ1 != null || _eleccioJ2 != null);

        if (algunTriat)
        {
            _tempsRestant -= Time.deltaTime;
            if (_textTemps != null) _textTemps.text = $"Temps: {Mathf.Max(0, _tempsRestant):F1}s";
        }

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

        string guanyador = "Empat";
        if (localCorrecte && !rivalCorrecte) guanyador = "Jugador 1";
        else if (!localCorrecte && rivalCorrecte) guanyador = "Jugador 2";

        if (guanyador == "Empat" && (localCorrecte || rivalCorrecte))
        {
            // Si tots dos encerten, reiniciem per desempatar
            IniciarMinijoc();
        }
        else
        {
            MinijocUIManager.Instance.FinalitzarCombat(guanyador);
        }
    }

    private Player GetLocalPlayer()
    {
        Player[] allPlayers = Object.FindObjectsByType<Player>(FindObjectsSortMode.None);
        foreach (var p in allPlayers)
        {
            if (p.GetComponent<RemotePlayer>() == null) return p;
        }
        return null;
    }
}
