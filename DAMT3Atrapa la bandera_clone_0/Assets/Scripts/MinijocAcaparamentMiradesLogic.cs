using UnityEngine;
using UnityEngine.UIElements;

public class MinijocAcaparamentMiradesLogic : MonoBehaviour
{
    private Label _textTemps;
    private Label _textResultat;
    private Button _btnAmunt, _btnAvall, _btnEsquerra, _btnDreta;

    private float _tempsRestant = 10f;
    private float _tempsRevelacio = 3f;
    private bool _faseRevelacio = false;
    private bool _jocActiu = false;

    private string _eleccioJ1 = "Cap";
    private string _eleccioJ2 = "Cap";
    private string _guanyador = "Empat";
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
        _tempsRestant = 10f;
        _tempsRevelacio = 3f;
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
            // El temps (10s) NOMÉS corre quan algú ja ha triat
            bool algunTriat = (_eleccioJ1 != "Cap" || _eleccioJ2 != "Cap");

            if (algunTriat)
            {
                _tempsRestant -= Time.deltaTime;
                if (_textTemps != null) _textTemps.text = $"Temps: {Mathf.Max(0, _tempsRestant):F1}s";
            }
            else
            {
                if (_textTemps != null) _textTemps.text = "Esperant la primera acció...";
            }

            // Keyboard Input (W/A/S/D) for J1
            if (_eleccioJ1 == "Cap")
            {
                if (Input.GetKeyDown(KeyCode.W)) RegistrarTriar("Amunt");
                else if (Input.GetKeyDown(KeyCode.S)) RegistrarTriar("Avall");
                else if (Input.GetKeyDown(KeyCode.A)) RegistrarTriar("Esquerra");
                else if (Input.GetKeyDown(KeyCode.D)) RegistrarTriar("Dreta");
            }

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
                MinijocUIManager.Instance.FinalitzarCombat(_guanyador);
            }
        }
    }

    private void FinalitzarFaseEleccio()
    {
        if (_faseRevelacio) return;
        _faseRevelacio = true;
        
        // Si no s'ha triat, penalització (per exemple, triar la contrària a la del rival o default)
        string resultatEspecial = "";
        if (_eleccioJ1 == "Cap" && _eleccioJ2 != "Cap") resultatEspecial = "Has trigat massa!";
        else if (_eleccioJ1 != "Cap" && _eleccioJ2 == "Cap") resultatEspecial = "El rival ha trigat massa!";

        // Random if not chosen
        if (_eleccioJ1 == "Cap") _eleccioJ1 = "Amunt"; 
        if (_eleccioJ2 == "Cap") _eleccioJ2 = "Avall";

        // Lògica de victòria: Si coincideixen, l'atacant guanya
        bool coincideixen = (_eleccioJ1 == _eleccioJ2);

        if (coincideixen)
        {
            // Si jo sóc l'atacant i coincideixo -> Guanyo jo (J1)
            // Si el rival és l'atacant i coincideix -> Guanya ell (J2)
            _guanyador = _sócAtacant ? "Jugador 1" : "Jugador 2";
        }
        else
        {
            // Si no coincideixen, el defensor guanya
            _guanyador = _sócAtacant ? "Jugador 2" : "Jugador 1";
        }

        if (_textResultat != null)
        {
            if (!string.IsNullOrEmpty(resultatEspecial)) _textResultat.text = resultatEspecial;
            else _textResultat.text = $"TU:{_eleccioJ1} vs RIVAL:{_eleccioJ2}. Guanya {_guanyador}!";
        }
    }
}
