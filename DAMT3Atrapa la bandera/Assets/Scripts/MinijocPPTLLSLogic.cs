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
    private bool jocActiu = false;

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

        if (_btnPedra != null) { _btnPedra.clicked -= () => RegistrarTriar(OpcioMinijoc.Pedra); _btnPedra.clicked += () => RegistrarTriar(OpcioMinijoc.Pedra); }
        if (_btnPaper != null) { _btnPaper.clicked -= () => RegistrarTriar(OpcioMinijoc.Paper); _btnPaper.clicked += () => RegistrarTriar(OpcioMinijoc.Paper); }
        if (_btnTisora != null) { _btnTisora.clicked -= () => RegistrarTriar(OpcioMinijoc.Tisora); _btnTisora.clicked += () => RegistrarTriar(OpcioMinijoc.Tisora); }
        if (_btnLlangardaix != null) { _btnLlangardaix.clicked -= () => RegistrarTriar(OpcioMinijoc.Llangardaix); _btnLlangardaix.clicked += () => RegistrarTriar(OpcioMinijoc.Llangardaix); }
        if (_btnSpock != null) { _btnSpock.clicked -= () => RegistrarTriar(OpcioMinijoc.Spock); _btnSpock.clicked += () => RegistrarTriar(OpcioMinijoc.Spock); }

        if (_textResultat != null) _textResultat.text = "";
    }

    public void IniciarMinijoc()
    {
        _tempsRestant = 5f;
        _tempsRevelacio = 3f;
        _faseRevelacio = false;
        jocActiu = true;
        _eleccioJ1 = null;
        _eleccioJ2 = null;
        if (_textResultat != null) _textResultat.text = "";
        if (_textTemps != null) _textTemps.text = "Tria!";
    }

    private void RegistrarTriar(OpcioMinijoc opcio)
    {
        if (!jocActiu || _faseRevelacio || _eleccioJ1 != null) return;
        _eleccioJ1 = opcio;
        
        // Envia l'elecció local al rival
        if (MenuManager.Instance != null) MenuManager.Instance.EnviarMinijocUpdate("CHOICE:" + (int)opcio);
        
        if (_textTemps != null) _textTemps.text = "Esperant rival...";
    }

    public void RebreActualitzacioXarxa(string data)
    {
        if (jocActiu && !_faseRevelacio && data.StartsWith("CHOICE:"))
        {
            if (int.TryParse(data.Split(':')[1], out int opcioId))
            {
                _eleccioJ2 = (OpcioMinijoc)opcioId;
                Debug.Log($"[PPTLLS] Rebut rival: {_eleccioJ2}");
            }
        }
    }

    public void RebreResultatXarxa(string winner)
    {
        // No s'usa normalment en PPTLLS perquè es calcula localment sincronitzat
    }

    private void Update()
    {
        if (!jocActiu) return;

        if (!_faseRevelacio)
        {
            _tempsRestant -= Time.deltaTime;
            if (_textTemps != null && _eleccioJ1 == null) _textTemps.text = $"Temps: {Mathf.Max(0, _tempsRestant):F1}s";

            // Resolquem si tenim les dues eleccions O s'ha acabat el temps
            if (_tempsRestant <= 0 || (_eleccioJ1 != null && _eleccioJ2 != null))
            {
                FinalitzarFaseEleccio();
            }
        }
        else
        {
            _tempsRevelacio -= Time.deltaTime;
            if (_tempsRevelacio <= 0)
            {
                jocActiu = false;
                ResultatMinijoc res = MinijocPPTLLS.AvaluarGuanyador(_eleccioJ1 ?? OpcioMinijoc.Pedra, _eleccioJ2 ?? OpcioMinijoc.Pedra);
                string guanyadorStr = "Empat";
                if (res == ResultatMinijoc.GuanyaJugador1) guanyadorStr = "Jugador 1";
                else if (res == ResultatMinijoc.GuanyaJugador2) guanyadorStr = "Jugador 2";

                MinijocUIManager.Instance.FinalitzarCombat(guanyadorStr);
            }
        }
    }

    private void FinalitzarFaseEleccio()
    {
        if (_faseRevelacio) return;
        _faseRevelacio = true;

        // Si algú no ha triat, assignem Pedra per defecte (o aleatori)
        if (_eleccioJ1 == null) _eleccioJ1 = OpcioMinijoc.Pedra;
        if (_eleccioJ2 == null) _eleccioJ2 = OpcioMinijoc.Pedra;

        if (_textResultat != null)
        {
            _textResultat.text = $"TU: {_eleccioJ1} vs RIVAL: {_eleccioJ2}";
        }
    }
}
