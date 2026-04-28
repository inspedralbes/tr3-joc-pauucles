using UnityEngine;
using UnityEngine.UIElements;

public class MinijocAcaparamentMiradesLogic : MonoBehaviour
{
    private Label _textTemps;
    private Label _textResultat;
    private Button _btnAmunt, _btnAvall, _btnEsquerra, _btnDreta;

    private float _tempsRestant = 10f;
    private float _tempsRevelacio = 0.5f; // Task 2.1: Revelació ràpida
    private bool _faseRevelacio = false;
    private bool _jocActiu = false;

    private string _eleccioJ1 = "Cap";
    private string _eleccioJ2 = "Cap";
    private string _winner = "";
    private string _loser = "";
    private bool _sócAtacant = false;

    public void SetRole(bool atacant)
    {
        _sócAtacant = atacant;
    }

    public void InicialitzarUI(VisualElement root)
    {
        _textTemps = root.Q<Label>("TextTempsMirades");
        _textResultat = root.Q<Label>("TextResultatMirades");

        _btnAmunt = root.Q<Button>("BtnAmunt");
        _btnAvall = root.Q<Button>("BtnAvall");
        _btnEsquerra = root.Q<Button>("BtnEsquerra");
        _btnDreta = root.Q<Button>("BtnDreta");

        if (_btnAmunt != null) { _btnAmunt.clicked -= OnAmunt; _btnAmunt.clicked += OnAmunt; }
        if (_btnAvall != null) { _btnAvall.clicked -= OnAvall; _btnAvall.clicked += OnAvall; }
        if (_btnEsquerra != null) { _btnEsquerra.clicked -= OnEsquerra; _btnEsquerra.clicked += OnEsquerra; }
        if (_btnDreta != null) { _btnDreta.clicked -= OnDreta; _btnDreta.clicked += OnDreta; }

        if (_textResultat != null) _textResultat.text = "";
    }

    private void OnAmunt() { RegistrarTriar("Amunt"); }
    private void OnAvall() { RegistrarTriar("Avall"); }
    private void OnEsquerra() { RegistrarTriar("Esquerra"); }
    private void OnDreta() { RegistrarTriar("Dreta"); }

    public void IniciarMinijoc()
    {
        _tempsRestant = 10f; // 1) TIMER ÚNICO: Inicia un cop (Task 1.1)
        _tempsRevelacio = 0.5f;
        _faseRevelacio = false;
        _jocActiu = true;
        _eleccioJ1 = "Cap";
        _eleccioJ2 = "Cap";
        
        if (_textResultat != null)
        {
            if (_sócAtacant) _textResultat.text = "Atacant: On miraràs?";
            else _textResultat.text = "Defensor: Mira on l'atacant!";
        }
    }

    public void RebreActualitzacioXarxa(string data)
    {
        if (_jocActiu && !_faseRevelacio && data.StartsWith("CHOICE:"))
        {
            _eleccioJ2 = data.Substring(7);
            Debug.Log($"[AcaparamentMirades] Elecció rival rebuda.");
        }
    }

    private void RegistrarTriar(string direccio)
    {
        if (!_jocActiu || _faseRevelacio || _eleccioJ1 != "Cap") return;
        _eleccioJ1 = direccio;
        
        if (MenuManager.Instance != null)
        {
            MenuManager.Instance.EnviarMinijocUpdate("CHOICE:" + direccio);
        }
    }

    private void Update()
    {
        if (!_jocActiu) return;

        if (!_faseRevelacio)
        {
            _tempsRestant -= Time.deltaTime;
            if (_textTemps != null) _textTemps.text = $"Temps: {Mathf.Max(0, _tempsRestant):F1}s";

            if (_eleccioJ1 == "Cap")
            {
                if (Input.GetKeyDown(KeyCode.W)) RegistrarTriar("Amunt");
                else if (Input.GetKeyDown(KeyCode.S)) RegistrarTriar("Avall");
                else if (Input.GetKeyDown(KeyCode.A)) RegistrarTriar("Esquerra");
                else if (Input.GetKeyDown(KeyCode.D)) RegistrarTriar("Dreta");
            }

            // 2) RESOLUCIÓN INSTANTÁNEA (Task 2.2)
            if (_tempsRestant <= 0 || (_eleccioJ1 != "Cap" && _eleccioJ2 != "Cap"))
            {
                FinalitzarFaseEleccio();
            }
        }
        else
        {
            _tempsRevelacio -= Time.deltaTime;
            if (_tempsRevelacio <= 0)
            {
                _jocActiu = false;
                MinijocUIManager.Instance.FinalitzarCombat(_winner, _loser);
            }
        }
    }

    private void FinalitzarFaseEleccio()
    {
        if (_faseRevelacio) return;
        _faseRevelacio = true;
        
        if (_eleccioJ1 == "Cap") _eleccioJ1 = "Amunt"; 
        if (_eleccioJ2 == "Cap") _eleccioJ2 = "Avall";

        bool coincideixen = (_eleccioJ1 == _eleccioJ2);

        // REGLA: Si l'adiví (defensor) encerta, guanya l'adiví. Si falla, guanya el que mirava (atacant).
        bool guanyaJ1 = (_sócAtacant != coincideixen);

        // Task 2.3: Identitats reals per a xarxa
        if (_eleccioJ1 == "Cap" && _eleccioJ2 == "Cap")
        {
            _winner = "Empat";
            _loser = "Empat";
        }
        else if (guanyaJ1)
        {
            _winner = MinijocUIManager.Instance.jugador1.username;
            _loser = MinijocUIManager.Instance.jugador2.username;
        }
        else
        {
            _winner = MinijocUIManager.Instance.jugador2.username;
            _loser = MinijocUIManager.Instance.jugador1.username;
        }

        if (_textResultat != null) _textResultat.text = "¡FI!";

        // El primer que acaba envia el resultat (Task 2.3)
        if (MenuManager.Instance != null)
        {
            MenuManager.Instance.EnviarMinijocResult(_winner, _loser);
        }
    }
}
