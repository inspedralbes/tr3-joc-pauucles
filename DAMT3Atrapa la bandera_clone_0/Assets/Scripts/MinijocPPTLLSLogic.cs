using UnityEngine;
using UnityEngine.UIElements;

public class MinijocPPTLLSLogic : MonoBehaviour
{
    private Label _textTemps;
    private Label _textResultat;
    private Button _btnPedra, _btnPaper, _btnTisora, _btnLlangardaix, _btnSpock;

    private float _tempsRestant = 10f;
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

        Debug.Log($"[PPTLLS] Inicialitzant UI. Pedra={(_btnPedra != null)}, Paper={(_btnPaper != null)}, Tisora={(_btnTisora != null)}, Llang={(_btnLlangardaix != null)}, Spock={(_btnSpock != null)}");

        if (_btnPedra != null) { _btnPedra.clicked -= OnPedra; _btnPedra.clicked += OnPedra; }
        if (_btnPaper != null) { _btnPaper.clicked -= OnPaper; _btnPaper.clicked += OnPaper; }
        if (_btnTisora != null) { _btnTisora.clicked -= OnTisora; _btnTisora.clicked += OnTisora; }
        if (_btnLlangardaix != null) { _btnLlangardaix.clicked -= OnLlangardaix; _btnLlangardaix.clicked += OnLlangardaix; }
        if (_btnSpock != null) { _btnSpock.clicked -= OnSpock; _btnSpock.clicked += OnSpock; }

        if (_textResultat != null) _textResultat.text = "";
    }

    private void OnPedra() { Debug.Log("[PPTLLS] Click: Pedra"); RegistrarTriar(OpcioMinijoc.Pedra); }
    private void OnPaper() { Debug.Log("[PPTLLS] Click: Paper"); RegistrarTriar(OpcioMinijoc.Paper); }
    private void OnTisora() { Debug.Log("[PPTLLS] Click: Tisora"); RegistrarTriar(OpcioMinijoc.Tisora); }
    private void OnLlangardaix() { Debug.Log("[PPTLLS] Click: Llangardaix"); RegistrarTriar(OpcioMinijoc.Llangardaix); }
    private void OnSpock() { Debug.Log("[PPTLLS] Click: Spock"); RegistrarTriar(OpcioMinijoc.Spock); }

    public void IniciarMinijoc()
    {
        _tempsRestant = 10f;
        _tempsRevelacio = 3f;
        _faseRevelacio = false;
        jocActiu = true;
        _eleccioJ1 = null;
        _eleccioJ2 = null;
        if (_textResultat != null) _textResultat.text = "";
        if (_textTemps != null) _textTemps.text = "Tria una opció!";
    }

    private void RegistrarTriar(OpcioMinijoc opcio)
    {
        Debug.Log($"[PPTLLS] Botó Click detectat: {opcio}");
        if (!jocActiu || _faseRevelacio || _eleccioJ1 != null) {
            Debug.Log($"[PPTLLS] Clic ignorat. Actiu={jocActiu}, FaseRev={_faseRevelacio}, JaTriat={(_eleccioJ1 != null)}");
            return;
        }
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
                Debug.Log($"[PPTLLS] Rebut rival.");
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
            // 1) TIMER ÚNICO: El temps corre des de l'inici (Task 1.1)
            _tempsRestant -= Time.deltaTime;
            if (_textTemps != null) _textTemps.text = $"Temps: {Mathf.Max(0, _tempsRestant):F1}s";

            // Resolem si tenim les dues eleccions O s'ha acabat el temps (Task 2.2)
            if (_tempsRestant <= 0 || (_eleccioJ1 != null && _eleccioJ2 != null))
            {
                FinalitzarFaseEleccio();
            }
        }
        else
        {
            // 2) RESOLUCIÓN INSTANTÁNEA: Reduïm la revelació al mínim o zero per anar ràpid (Task 2.1)
            _tempsRevelacio -= Time.deltaTime;
            if (_tempsRevelacio <= 0 || (_eleccioJ1 != null && _eleccioJ2 != null))
            {
                ResultatMinijoc res = MinijocPPTLLS.AvaluarGuanyador(_eleccioJ1 ?? OpcioMinijoc.Pedra, _eleccioJ2 ?? OpcioMinijoc.Pedra);
                
                if (res == ResultatMinijoc.Empat)
                {
                    Debug.Log("[PPTLLS] EMPAT! Reiniciant minijoc...");
                    IniciarMinijoc(); 
                }
                else
                {
                    jocActiu = false;
                    
                    string localName = WebSocketClient.LocalUsername;
                    string rivalName = (MinijocUIManager.Instance.jugador1.username == localName) 
                                       ? MinijocUIManager.Instance.jugador2.username 
                                       : MinijocUIManager.Instance.jugador1.username;

                    string winner = (res == ResultatMinijoc.GuanyaJugador1) ? localName : rivalName;
                    string loser = (res == ResultatMinijoc.GuanyaJugador1) ? rivalName : localName;

                    // Notificar al servidor (Task 1.1 y 2.3) - Només el Host envia el resultat
                    if (MenuManager.Instance != null && MenuManager.Instance.IsHost())
                    {
                        MenuManager.Instance.EnviarMinijocResult(winner, loser);
                    }

                    MinijocUIManager.Instance.FinalitzarCombat(winner, loser);
                }
            }
        }
    }

    private void FinalitzarFaseEleccio()
    {
        if (_faseRevelacio) return;
        _faseRevelacio = true;

        string resultatEspecial = "";
        if (_eleccioJ1 == null && _eleccioJ2 != null) resultatEspecial = "Has trigat massa! Guanya el rival.";
        else if (_eleccioJ1 != null && _eleccioJ2 == null) resultatEspecial = "El rival ha trigat massa! Guanyes tu.";

        if (_eleccioJ1 == null) _eleccioJ1 = OpcioMinijoc.Pedra;
        if (_eleccioJ2 == null) _eleccioJ2 = OpcioMinijoc.Pedra;

        if (_textResultat != null)
        {
            if (!string.IsNullOrEmpty(resultatEspecial)) _textResultat.text = resultatEspecial;
            else _textResultat.text = $"TU: {_eleccioJ1} vs RIVAL: {_eleccioJ2}";
        }
    }
}
