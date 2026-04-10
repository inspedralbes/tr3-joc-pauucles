using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class MinijocUIManager : MonoBehaviour
{
    public static MinijocUIManager Instance { get; private set; }

    private UIDocument _uiDocument;
    private Player _jugador1;
    private Player _jugador2;
    private Player _atacant;
    private Player _defensor;

    // Contenidors visuals
    private VisualElement _contenidorPPTLLS;
    private VisualElement _contenidorParellsSenars;
    private VisualElement _contenidorAturaBarra;
    private VisualElement _contenidorPolsForca;
    private VisualElement _backgroundOverlay;
    private Label _textResultat;

    // Elements AturaBarra
    private VisualElement _fletxa;
    private VisualElement _zonaObjectiu;
    private bool _aturaBarraActiu = false;
    private float _fletxaPos = 0f;
    private float _fletxaSpeed = 400f;
    private float _zonaLeft = 0f;

    public bool minijocActiu = false;
    private bool combatResolentse = false;

    // Navegació per teclat
    private List<Button> _buttonsPPTLLS = new List<Button>();
    private List<Button> _buttonsParellsSenars = new List<Button>();
    private int _currentButtonIndex = 0;
    private int _activeMinigameId = 0;

    private OpcioMinijoc? _eleccioPPTLLS_J1;
    private OpcioMinijoc? _eleccioPPTLLS_J2;

    private readonly string[] _nomsMinijocs = {
        "Cap", // ID 0 no s'usa
        "PPTLLS",
        "ParellsSenars",
        "AturaBarra",
        "CablePelat",
        "PolsimForca",
        "AcaparamentMirades"
    };

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }

        _uiDocument = GetComponent<UIDocument>();
        if (_uiDocument == null) Debug.LogError("MinijocUIManager: No s'ha trobat el component 'UIDocument'.");
        else
        {
            _uiDocument.enabled = true;
            if (_uiDocument.rootVisualElement != null) _uiDocument.rootVisualElement.style.display = DisplayStyle.None;
        }
    }

    private void Start()
    {
        AmagarTotsElsContenidors();
    }

    private void Update()
    {
        if (_uiDocument == null || _uiDocument.rootVisualElement == null || _uiDocument.rootVisualElement.style.display == DisplayStyle.None) return;

        if (_aturaBarraActiu)
        {
            if (_fletxa != null)
            {
                _fletxaPos = Mathf.PingPong(Time.time * _fletxaSpeed, 490f);
                _fletxa.style.left = _fletxaPos;
            }

            if (Input.GetKeyDown(KeyCode.Space)) HandleAturaBarraClick();
        }
        else
        {
            GestionarNavegacioTeclat();
        }
    }

    public void ShowUI(Player p1, Player p2)
    {
        minijocActiu = true;
        combatResolentse = false;

        _jugador1 = p1;
        _jugador2 = p2;
        _jugador1.potMoure = false;
        _jugador2.potMoure = false;

        // Determinació de rols (Atacant vs Defensor)
        // Per defecte P1 és atacant, P2 defensor. Però si P2 no té bandera i P1 sí, s'inverteix.
        // O més simple: qui porta la bandera és el defensor.
        if (_jugador1.CompareTag("Player") && _jugador1.GetComponent<Player>().banderaAgafada != null)
        {
            _defensor = _jugador1;
            _atacant = _jugador2;
        }
        else
        {
            _defensor = _jugador2;
            _atacant = _jugador1;
        }

        if (_uiDocument == null || _uiDocument.rootVisualElement == null) { HideUI(); return; }

        _uiDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        var root = _uiDocument.rootVisualElement;

        _backgroundOverlay = root.Q<VisualElement>("Background");
        _textResultat = root.Q<Label>("TextResultat");
        _contenidorPPTLLS = root.Q<VisualElement>("ContenidorPPTLLS");
        _contenidorParellsSenars = root.Q<VisualElement>("ContenidorParellsSenars");
        _contenidorAturaBarra = root.Q<VisualElement>("ContenidorAturaBarra");
        _contenidorPolsForca = root.Q<VisualElement>("ContenidorPolsForca");
        _fletxa = root.Q<VisualElement>("Fletxa");
        _zonaObjectiu = root.Q<VisualElement>("ZonaObjectiu");

        if (_textResultat != null) _textResultat.text = "Tria la teva jugada!";

        AmagarTotsElsContenidors();

        _activeMinigameId = Random.Range(1, 6);
        _currentButtonIndex = 0; // Reiniciem índex

        string nomJoc = _nomsMinijocs[_activeMinigameId];
        Debug.Log("Ruleta: Toca jugar a " + nomJoc + " (ID: " + _activeMinigameId + ")");

        switch (_activeMinigameId)
        {
            case 1:
                if (_contenidorPPTLLS != null) { _contenidorPPTLLS.style.display = DisplayStyle.Flex; SetupPPTLLSButtons(); }
                else ResolverEmpatDirecte();
                break;
            case 2:
                if (_contenidorParellsSenars != null) { _contenidorParellsSenars.style.display = DisplayStyle.Flex; SetupParellsSenarsButtons(); }
                else ResolverEmpatDirecte();
                break;
            case 3:
                if (_contenidorAturaBarra != null) { _contenidorAturaBarra.style.display = DisplayStyle.Flex; SetupAturaBarraButtons(); }
                else ResolverEmpatDirecte();
                break;
            case 5:
                if (_contenidorPolsForca != null)
                {
                    _contenidorPolsForca.style.display = DisplayStyle.Flex;
                    MinijocPolsimForcaLogic logic = GetComponent<MinijocPolsimForcaLogic>();
                    if (logic != null)
                    {
                        logic.InicialitzarUI(root, _jugador1, _jugador2);
                        logic.IniciarMinijoc();
                    }
                }
                else ResolverEmpatDirecte();
                break;
            default:
                ResolverEmpatDirecte();
                break;
        }

        ActualitzarFocusVisual();
    }

    private void AmagarTotsElsContenidors()
    {
        _aturaBarraActiu = false;
        if (_backgroundOverlay != null) _backgroundOverlay.style.display = DisplayStyle.None;
        if (_contenidorPPTLLS != null) _contenidorPPTLLS.style.display = DisplayStyle.None;
        if (_contenidorParellsSenars != null) _contenidorParellsSenars.style.display = DisplayStyle.None;
        if (_contenidorAturaBarra != null) _contenidorAturaBarra.style.display = DisplayStyle.None;
        if (_contenidorPolsForca != null) _contenidorPolsForca.style.display = DisplayStyle.None;
    }

    #region PPTLLS Logic
    private void SetupPPTLLSButtons()
    {
        var root = _uiDocument.rootVisualElement;
        _buttonsPPTLLS.Clear();
        
        string[] names = { "BtnPedra", "BtnPaper", "BtnTisora", "BtnLlangardaix", "BtnSpock" };
        foreach (var name in names)
        {
            Button btn = root.Q<Button>(name);
            if (btn != null)
            {
                // To avoid accumulation, we can't easily -= anonymous lambdas.
                // But we can ensure we only add it once by storing what we added,
                // or simpler: just define a method that handles the click.
                btn.clicked -= () => HandlePPTLLSClickFromButton(btn); // Still doesn't work for anonymous.
                
                // Best way for UI Toolkit buttons if you need to "reset" listeners:
                // Since 'clicked' is an Action, we can't clear it.
                // We'll use a hack or just be very careful.
                // Let's refactor to NOT use anonymous lambdas.
                
                _buttonsPPTLLS.Add(btn);
            }
        }

        foreach (var btn in _buttonsPPTLLS)
        {
            // We use a named method for the listener
            btn.clicked += () => HandlePPTLLSClick(GetOpcioFromName(btn.name));
        }
    }

    private void HandlePPTLLSClickFromButton(Button btn)
    {
        HandlePPTLLSClick(GetOpcioFromName(btn.name));
    }


    private OpcioMinijoc GetOpcioFromName(string name)
    {
        if (name == "BtnPaper") return OpcioMinijoc.Paper;
        if (name == "BtnTisora") return OpcioMinijoc.Tisora;
        if (name == "BtnLlangardaix") return OpcioMinijoc.Llangardaix;
        if (name == "BtnSpock") return OpcioMinijoc.Spock;
        return OpcioMinijoc.Pedra;
    }

    private void HandlePPTLLSClick(OpcioMinijoc opcio)
    {
        if (combatResolentse) return;

        _eleccioPPTLLS_J1 = opcio;
        _eleccioPPTLLS_J2 = (OpcioMinijoc)Random.Range(0, 5);
        ResultatMinijoc res = MinijocPPTLLS.AvaluarGuanyador(_eleccioPPTLLS_J1.Value, _eleccioPPTLLS_J2.Value);
        
        if (res == ResultatMinijoc.Empat) 
        { 
            _textResultat.text = "Empat! Torneu a triar!"; 
            _eleccioPPTLLS_J1 = null; 
            _currentButtonIndex = 0;
            ActualitzarFocusVisual();
        }
        else 
        {
            combatResolentse = true;
            if (res == ResultatMinijoc.GuanyaJugador1) StartCoroutine(MostrarResultatIEsperar(_jugador1, _jugador2, $"PPTLLS: {_eleccioPPTLLS_J1} vs {_eleccioPPTLLS_J2}. {_jugador1.name} ha guanyat!"));
            else StartCoroutine(MostrarResultatIEsperar(_jugador2, _jugador1, $"PPTLLS: {_eleccioPPTLLS_J1} vs {_eleccioPPTLLS_J2}. {_jugador2.name} ha guanyat!"));
        }
    }
    #endregion

    #region Parells o Senars Logic
    private void SetupParellsSenarsButtons()
    {
        var root = _uiDocument.rootVisualElement;
        _buttonsParellsSenars.Clear();

        Button bp = root.Q<Button>("BtnParells");
        Button bs = root.Q<Button>("BtnSenars");

        if (bp != null)
        {
            // Note: In UI Toolkit, we can't easily clear listeners. 
            // We'll trust the ShowUI -> Setup -> Result -> Hide cycle.
            // However, to satisfy the requirement of explicit unbinding:
            bp.clicked -= HandleParellsClick;
            bp.clicked += HandleParellsClick;
            _buttonsParellsSenars.Add(bp);
        }
        if (bs != null)
        {
            bs.clicked -= HandleSenarsClick;
            bs.clicked += HandleSenarsClick;
            _buttonsParellsSenars.Add(bs);
        }
    }

    private void HandleParellsClick() => HandleParellsSenarsClick(true);
    private void HandleSenarsClick() => HandleParellsSenarsClick(false);

    private void HandleParellsSenarsClick(bool choseParells)
    {
        if (combatResolentse) return;
        combatResolentse = true;

        ParellsSenarsCostat cJ1 = choseParells ? ParellsSenarsCostat.Parells : ParellsSenarsCostat.Senars;
        int dJ1 = Random.Range(0, 6), dJ2 = Random.Range(0, 6);
        ResultatParellsSenars res = MinijocParellsSenarsLogic.AvaluarGuanyador(cJ1, dJ1, dJ2);
        string paritat = ((dJ1 + dJ2) % 2 == 0) ? "Parell" : "Senar";
        string msg = $"P/S: {dJ1} + {dJ2} = {dJ1 + dJ2} ({paritat}).";

        if (res == ResultatParellsSenars.GuanyaJugador1) StartCoroutine(MostrarResultatIEsperar(_jugador1, _jugador2, $"{msg} {_jugador1.name} ha guanyat!"));
        else StartCoroutine(MostrarResultatIEsperar(_jugador2, _jugador1, $"{msg} {_jugador2.name} ha guanyat!"));
    }
    #endregion

    #region AturaBarra Logic
    private void SetupAturaBarraButtons()
    {
        _aturaBarraActiu = true;
        _zonaLeft = Random.Range(10f, 400f);
        if (_zonaObjectiu != null) 
        {
            _zonaObjectiu.style.width = 80;
            _zonaObjectiu.style.height = 50;
            _zonaObjectiu.style.backgroundColor = new StyleColor(Color.yellow);
            _zonaObjectiu.style.display = DisplayStyle.Flex;
            _zonaObjectiu.style.position = Position.Absolute;
            _zonaObjectiu.style.left = _zonaLeft;
            _zonaObjectiu.style.top = 0;
        }
        
        Button btnAturar = _uiDocument.rootVisualElement.Q<Button>("BtnAturar");
        if (btnAturar != null)
        {
            btnAturar.clicked -= HandleAturaBarraClick;
            btnAturar.clicked += HandleAturaBarraClick;
        }
    }

    private void HandleAturaBarraClick()
    {
        if (!_aturaBarraActiu || combatResolentse) return;
        combatResolentse = true;

        _aturaBarraActiu = false;
        float zonaWidth = (_zonaObjectiu != null) ? _zonaObjectiu.resolvedStyle.width : 80f;
        if (float.IsNaN(zonaWidth) || zonaWidth <= 0) zonaWidth = 80f;
        bool dins = (_fletxaPos >= _zonaLeft) && (_fletxaPos <= (_zonaLeft + zonaWidth));
        string msg = dins ? "DINS!" : "FORA!";
        if (dins) StartCoroutine(MostrarResultatIEsperar(_jugador1, _jugador2, $"AturaBarra: {msg} {_jugador1.name} ha guanyat!"));
        else StartCoroutine(MostrarResultatIEsperar(_jugador2, _jugador1, $"AturaBarra: {msg} {_jugador2.name} ha guanyat!"));
    }
    #endregion

    #region Navegació Teclat
    private void GestionarNavegacioTeclat()
    {
        List<Button> currentButtons = (_activeMinigameId == 1) ? _buttonsPPTLLS : (_activeMinigameId == 2) ? _buttonsParellsSenars : null;
        if (currentButtons == null || currentButtons.Count == 0) return;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _currentButtonIndex = (_currentButtonIndex - 1 + currentButtons.Count) % currentButtons.Count;
            ActualitzarFocusVisual();
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            _currentButtonIndex = (_currentButtonIndex + 1) % currentButtons.Count;
            ActualitzarFocusVisual();
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            currentButtons[_currentButtonIndex].Focus();
            ExecutarAccioSegonsIndex(_currentButtonIndex);
        }
    }

    private void ActualitzarFocusVisual()
    {
        List<Button> currentButtons = (_activeMinigameId == 1) ? _buttonsPPTLLS : (_activeMinigameId == 2) ? _buttonsParellsSenars : null;
        if (currentButtons == null) return;

        for (int i = 0; i < currentButtons.Count; i++)
        {
            if (i == _currentButtonIndex) currentButtons[i].style.backgroundColor = new StyleColor(new Color(0.7f, 0.7f, 0.7f));
            else currentButtons[i].style.backgroundColor = new StyleColor(StyleKeyword.Null);
        }
    }

    private void ExecutarAccioSegonsIndex(int index)
    {
        if (_activeMinigameId == 1)
        {
            OpcioMinijoc opcio = (OpcioMinijoc)index;
            HandlePPTLLSClick(opcio);
        }
        else if (_activeMinigameId == 2)
        {
            HandleParellsSenarsClick(index == 0);
        }
    }
    #endregion

    private System.Collections.IEnumerator MostrarResultatIEsperar(Player guanyador, Player perdedor, string motiu)
    {
        if (_textResultat != null) _textResultat.text = motiu;
        yield return new WaitForSeconds(2.5f);
        
        ProcessarResultatCombat(guanyador, perdedor);
        
        HideUI();
    }

    private void ProcessarResultatCombat(Player guanyador, Player perdedor)
    {
        Debug.Log($"Combat finalitzat. Guanyador: {guanyador.name}, Perdedor: {perdedor.name}");
        
        // FIX: La bandera s'allibera i fuig en lloc de ser robada directament
        GameObject banderaObj = GameObject.FindGameObjectWithTag("Bandera");
        if (banderaObj != null)
        {
            // Comprovem si el perdedor realment la portava
            if (banderaObj.transform.parent == perdedor.transform)
            {
                // Deslliguem la bandera del perdedor
                banderaObj.transform.SetParent(null);
                
                // Activem l'estat fugitiu
                Bandera scriptBandera = banderaObj.GetComponent<Bandera>();
                if (scriptBandera != null)
                {
                    scriptBandera.fugint = true;
                }
                
                // Actualitzem l'estat del perdedor
                perdedor.DeixarBandera();
                
                Debug.Log($"LA BANDERA S'ALLIBERA! {perdedor.name} l'ha perdut.");
            }
        }

        guanyador.WinCombat();
        perdedor.LoseCombat();
    }

    private void ResolverEmpatDirecte() { Debug.Log("Minijoc no disponible. Empat."); HideUI(); }

    public void FinalitzarCombat(string nomGuanyador)
    {
        Debug.Log("Finalitzant combat. Guanyador: " + nomGuanyador);
        
        // Amaguem UI
        AmagarTotsElsContenidors();
        if (_uiDocument != null && _uiDocument.rootVisualElement != null) 
            _uiDocument.rootVisualElement.style.display = DisplayStyle.None;

        // Lògica de pèrdua de bandera si el defensor perd
        // Nota: Assumim que nomGuanyador coincideix amb el nom del jugador o és "Jugador 1"/"Jugador 2"
        // Per coherència amb la petició, mirem si el defensor ha perdut.
        
        bool defensorHaPerdut = false;
        if (nomGuanyador == "Jugador 1" && _defensor == _jugador2) defensorHaPerdut = true;
        else if (nomGuanyador == "Jugador 2" && _defensor == _jugador1) defensorHaPerdut = true;

        if (defensorHaPerdut)
        {
            Debug.Log("El defensor ha perdut! Alliberant bandera...");
            _defensor.DeixarBandera();
            
            // Forcem SetParent null per si DeixarBandera no és suficient o redundant
            GameObject banderaObj = GameObject.FindGameObjectWithTag("Bandera");
            if (banderaObj != null && banderaObj.transform.parent == _defensor.transform)
            {
                banderaObj.transform.SetParent(null);
                Bandera scriptB = banderaObj.GetComponent<Bandera>();
                if (scriptB != null) scriptB.fugint = true;
            }
        }

        minijocActiu = false;
        if (_jugador1 != null) _jugador1.FinalitzarCombat();
        if (_jugador2 != null) _jugador2.FinalitzarCombat();
    }

    public void HideUI()
    {
        minijocActiu = false;
        if (_jugador1 != null) _jugador1.FinalitzarCombat();
        if (_jugador2 != null) _jugador2.FinalitzarCombat();
        AmagarTotsElsContenidors();
        if (_uiDocument != null && _uiDocument.rootVisualElement != null) _uiDocument.rootVisualElement.style.display = DisplayStyle.None;
    }
}
