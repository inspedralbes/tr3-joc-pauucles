using UnityEngine;
using UnityEngine.UIElements;

public class MinijocAcaparamentMiradesLogic : MonoBehaviour
{
    private Label _textTemps;
    private Label _textResultat;
    private Button _btnAmunt, _btnAvall, _btnEsquerra, _btnDreta;

    private float _tempsRestant = 5f;
    private float _tempsRevelacio = 3f;
    private bool _faseRevelacio = false;
    private bool _jocActiu = false;

    private string _eleccioJ1 = "Cap";
    private string _eleccioJ2 = "Cap";
    private string _guanyador = "Empat";

    public void InicialitzarUI(VisualElement root)
    {
        _textTemps = root.Q<Label>("TextTempsMirades");
        _textResultat = root.Q<Label>("TextResultatMirades");

        _btnAmunt = root.Q<Button>("BtnAmunt");
        _btnAvall = root.Q<Button>("BtnAvall");
        _btnEsquerra = root.Q<Button>("BtnEsquerra");
        _btnDreta = root.Q<Button>("BtnDreta");

        if (_btnAmunt != null) _btnAmunt.clicked += () => RegistrarTriar("Amunt");
        if (_btnAvall != null) _btnAvall.clicked += () => RegistrarTriar("Avall");
        if (_btnEsquerra != null) _btnEsquerra.clicked += () => RegistrarTriar("Esquerra");
        if (_btnDreta != null) _btnDreta.clicked += () => RegistrarTriar("Dreta");

        if (_textResultat != null) _textResultat.text = "";
    }

    public void IniciarMinijoc()
    {
        _tempsRestant = 5f;
        _tempsRevelacio = 3f;
        _faseRevelacio = false;
        _jocActiu = true;
        _eleccioJ1 = "Cap";
        _eleccioJ2 = "Cap";
        
        if (_textResultat != null) _textResultat.text = "";
    }

    private void RegistrarTriar(string direccio)
    {
        if (!_jocActiu || _faseRevelacio) return;
        _eleccioJ1 = direccio;
    }

    private void Update()
    {
        if (!_jocActiu) return;

        if (!_faseRevelacio)
        {
            _tempsRestant -= Time.deltaTime;
            if (_textTemps != null) _textTemps.text = $"Temps: {Mathf.Max(0, _tempsRestant):F1}s";

            // Keyboard Input (W/A/S/D)
            if (_eleccioJ1 == "Cap")
            {
                if (Input.GetKeyDown(KeyCode.W)) _eleccioJ1 = "Amunt";
                else if (Input.GetKeyDown(KeyCode.S)) _eleccioJ1 = "Avall";
                else if (Input.GetKeyDown(KeyCode.A)) _eleccioJ1 = "Esquerra";
                else if (Input.GetKeyDown(KeyCode.D)) _eleccioJ1 = "Dreta";
            }

            // Keyboard Input (Arrows) for J2
            if (_eleccioJ2 == "Cap")
            {
                if (Input.GetKeyDown(KeyCode.UpArrow)) _eleccioJ2 = "Amunt";
                else if (Input.GetKeyDown(KeyCode.DownArrow)) _eleccioJ2 = "Avall";
                else if (Input.GetKeyDown(KeyCode.LeftArrow)) _eleccioJ2 = "Esquerra";
                else if (Input.GetKeyDown(KeyCode.RightArrow)) _eleccioJ2 = "Dreta";
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
        _faseRevelacio = true;
        
        // Random if not chosen
        if (_eleccioJ1 == "Cap") _eleccioJ1 = "Amunt"; 
        if (_eleccioJ2 == "Cap") _eleccioJ2 = "Avall";

        _guanyador = "Empat";
        bool oposat = false;
        if (_eleccioJ1 == "Amunt" && _eleccioJ2 == "Avall") oposat = true;
        else if (_eleccioJ1 == "Avall" && _eleccioJ2 == "Amunt") oposat = true;
        else if (_eleccioJ1 == "Esquerra" && _eleccioJ2 == "Dreta") oposat = true;
        else if (_eleccioJ1 == "Dreta" && _eleccioJ2 == "Esquerra") oposat = true;

        if (oposat) _guanyador = "Jugador 2";

        if (_textResultat != null)
            _textResultat.text = $"J1:{_eleccioJ1} vs J2:{_eleccioJ2}. Guanya {_guanyador}!";
    }
}
