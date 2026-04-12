using UnityEngine;
using UnityEngine.UIElements;

public class MinijocPPTLLSLogic : MonoBehaviour
{
    private Label _textTemps;
    private Label _textResultat;
    private Button _btnPedra, _btnPaper, _btnTisora, _btnLlangardaix, _btnSpock;

    private float _tempsRestant = 5f;
    private float _tempsRevelacio = 3f;
    private bool _faseRevelacio = false;
    private bool _jocActiu = false;

    private OpcioMinijoc? _eleccioJ1;
    private OpcioMinijoc? _eleccioJ2;

    public void InicialitzarUI(VisualElement root)
    {
        _textTemps = root.Q<Label>("TextTempsPPTLLS");
        _textResultat = root.Q<Label>("TextResultatPPTLLS");

        _btnPedra = root.Q<Button>("BtnPedra");
        _btnPaper = root.Q<Button>("BtnPaper");
        _btnTisora = root.Q<Button>("BtnTisora");
        _btnLlangardaix = root.Q<Button>("BtnLlangardaix");
        _btnSpock = root.Q<Button>("BtnSpock");

        if (_btnPedra != null) _btnPedra.clicked += () => RegistrarTriar(OpcioMinijoc.Pedra);
        if (_btnPaper != null) _btnPaper.clicked += () => RegistrarTriar(OpcioMinijoc.Paper);
        if (_btnTisora != null) _btnTisora.clicked += () => RegistrarTriar(OpcioMinijoc.Tisora);
        if (_btnLlangardaix != null) _btnLlangardaix.clicked += () => RegistrarTriar(OpcioMinijoc.Llangardaix);
        if (_btnSpock != null) _btnSpock.clicked += () => RegistrarTriar(OpcioMinijoc.Spock);

        if (_textResultat != null) _textResultat.text = "";
    }

    public void IniciarMinijoc()
    {
        _tempsRestant = 5f;
        _tempsRevelacio = 3f;
        _faseRevelacio = false;
        _jocActiu = true;
        _eleccioJ1 = null;
        _eleccioJ2 = null;
        if (_textResultat != null) _textResultat.text = "";
        if (_textTemps != null) _textTemps.text = "Tria!";
    }

    private void RegistrarTriar(OpcioMinijoc opcio)
    {
        if (!_jocActiu || _faseRevelacio) return;
        _eleccioJ1 = opcio;
        // Optionally show immediate feedback that a choice was made, 
        // but task says "Al final del temps, mostra el resultat".
    }

    private void Update()
    {
        if (!_jocActiu) return;

        if (!_faseRevelacio)
        {
            _tempsRestant -= Time.deltaTime;
            if (_textTemps != null) _textTemps.text = $"Temps: {Mathf.Max(0, _tempsRestant):F1}s";

            if (_tempsRestant <= 0 || _eleccioJ1 != null)
            {
                FinalitzarFaseEleccio();
            }
        }
        else
        {
            _tempsRevelacio -= Time.deltaTime;
            // if (_textTemps != null) _textTemps.text = $"Revelació: {Mathf.Max(0, _tempsRevelacio):F1}s";

            if (_tempsRevelacio <= 0)
            {
                _jocActiu = false;
                ResultatMinijoc res = MinijocPPTLLS.AvaluarGuanyador(_eleccioJ1 ?? (OpcioMinijoc)Random.Range(0, 5), _eleccioJ2 ?? OpcioMinijoc.Pedra);
                string guanyadorStr = "Empat";
                if (res == ResultatMinijoc.GuanyaJugador1) guanyadorStr = "Jugador 1";
                else if (res == ResultatMinijoc.GuanyaJugador2) guanyadorStr = "Jugador 2";

                MinijocUIManager.Instance.FinalitzarCombat(guanyadorStr);
            }
        }
    }

    private void FinalitzarFaseEleccio()
    {
        _faseRevelacio = true;
        _eleccioJ2 = (OpcioMinijoc)Random.Range(0, 5);
        if (_eleccioJ1 == null) _eleccioJ1 = (OpcioMinijoc)Random.Range(0, 5); // Random if time out

        if (_textResultat != null)
        {
            _textResultat.text = $"J1: {_eleccioJ1} vs J2: {_eleccioJ2}";
        }
    }
}
