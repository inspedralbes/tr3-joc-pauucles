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

    public Player jugador1 => _jugador1;
    public Player jugador2 => _jugador2;
    public Player atacant => _atacant;
    public Player defensor => _defensor;

    // Contenidors visuals
    private VisualElement _contenidorPPTLLS;
    private VisualElement _contenidorParellsSenars;
    private VisualElement _contenidorAturaBarra;
    private VisualElement _contenidorPolsForca;
    private VisualElement _contenidorAcaparamentMirades;
    private VisualElement _backgroundOverlay;
    private Label _textResultat;

    public bool minijocActiu = false;
    private int _activeMinigameId = 0;
    private bool _combatAcabat = false;
    public bool combatAcabat { get => _combatAcabat; set => _combatAcabat = value; }

    // Historial per evitar repeticions (Task: no repetir el mateix minijoc)
    private static List<int> _historialJocs = new List<int>();
    private const int MAX_HISTORIAL = 3; 

    private readonly string[] _nomsMinijocs = {
        "Cap", // ID 0 no s'usa
        "PPTLLS",
        "ParellsSenars",
        "AturaBarra",
        "Cap", // El 4 era CablePelat, el buidem
        "PolsimForca",
        "AcaparamentMirades"
    };

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }

        // 1.1 i 1.2: Obtenir referència al component UIDocument
        _uiDocument = GetComponent<UIDocument>();

        // 1.3: Comprovar si el component existeix i avisar si no
        if (_uiDocument == null)
        {
            Debug.LogError("[MinijocUI] Error: No s'ha trobat el component 'UIDocument' a MinijocUIManager.");
        }
        else
        {
            _uiDocument.enabled = true;
            _uiDocument.sortingOrder = 100; // Forçar que estigui per sobre de tot
            
            minijocActiu = false; // FORÇAR RESET AL COMENÇAR
            
            if (_uiDocument.visualTreeAsset == null)
                Debug.LogError("[MinijocUI] CRÍTIC: El UIDocument no té cap VisualTreeAsset (UXML) assignat!");
            
            if (_uiDocument.panelSettings == null)
                Debug.LogWarning("[MinijocUI] Alerta: El UIDocument no té PanelSettings. Podria no renderitzar-se.");

            if (_uiDocument.rootVisualElement != null)
            {
                _uiDocument.rootVisualElement.style.display = DisplayStyle.None;
            }
            Debug.Log($"[MinijocUI] UIDocument preparat. SortOrder: {_uiDocument.sortingOrder}, Actiu: {minijocActiu}");
        }
    }



    private void Start()
    {
        if (_uiDocument != null) AmagarTotsElsMinijocs(_uiDocument.rootVisualElement);
    }

    public void IniciarMinijoc(GameObject g1, GameObject g2, int forcarGameIndex = -1)
    {
        if (_uiDocument == null) return;
        
        // 3.2 Reset de visibilitat estricte abans de res
        var root = _uiDocument.rootVisualElement;
        if (root == null) return;
        
        AmagarTotsElsMinijocs(root);
        root.style.display = DisplayStyle.Flex;
        gameObject.SetActive(true);
        this.enabled = true;
        
        Debug.Log($"[MinijocUI] Iniciant minijoc sincronitzat (Index: {forcarGameIndex}). Root Display: {root.style.display}");

        // --- ESTILITZACIÓ PROCEDURAL (Task 3.1 i 3.2) ---
        Color fonsFosc = new Color(0, 0, 0, 0.85f);
        
        // 3.1 Aplicar fons a todos los contenedores de minijuego (Noms corregits)
        string[] contenidors = { "ContenidorPPTLLS", "ContenidorParellsSenars", "ContenidorAturaBarra", "ContenidorPolsForca", "ContenidorAcaparamentMirades" };
        foreach (var nom in contenidors)
        {
            VisualElement c = root.Q<VisualElement>(nom);
            if (c != null) c.style.backgroundColor = fonsFosc;
        }

        // 3.2 Estilitzar botons de forma global
        root.Query<Button>().ForEach(btn => {
            btn.style.backgroundColor = Color.black;
            btn.style.color = Color.white;
            btn.style.minWidth = 100;
            btn.style.minHeight = 50;
            btn.style.borderTopWidth = 1;
            btn.style.borderBottomWidth = 1;
            btn.style.borderLeftWidth = 1;
            btn.style.borderRightWidth = 1;
            btn.style.borderTopColor = Color.white;
            btn.style.borderBottomColor = Color.white;
            btn.style.borderLeftColor = Color.white;
            btn.style.borderRightColor = Color.white;
        });
        // ------------------------------------------------

        minijocActiu = true;
        _combatAcabat = false; // Task 5.2: RESET CRÍTIC per a següents partides

        // Obtenir components Player i bloquejar moviment
        _jugador1 = g1.GetComponent<Player>();
        _jugador2 = g2.GetComponent<Player>();

        // Fix preventiu: Assegurar que els noms estiguin omplerts (especialment per a remots)
        if (_jugador1 != null && string.IsNullOrEmpty(_jugador1.username)) 
            _jugador1.username = _jugador1.gameObject.name;
        if (_jugador2 != null && string.IsNullOrEmpty(_jugador2.username)) 
            _jugador2.username = _jugador2.gameObject.name;

        if (_jugador1 != null) _jugador1.potMoure = false;
        if (_jugador2 != null) _jugador2.potMoure = false;

        if (_jugador1 != null && _jugador1.CompareTag("Player") && _jugador1.banderaAgafada != null)
        {
            _defensor = _jugador1;
            _atacant = _jugador2;
        }
        else
        {
            _defensor = _jugador2;
            _atacant = _jugador1;
        }

        _backgroundOverlay = root.Q<VisualElement>("Background");
        if (_backgroundOverlay != null) _backgroundOverlay.style.display = DisplayStyle.Flex;
        
        _textResultat = root.Q<Label>("TextResultat");
        if (_textResultat != null) _textResultat.text = "Iniciant combat...";

        // 3.1 i 3.3: Selecció de joc autoritaria (Amb rotació sense repeticions)
        if (forcarGameIndex > 0)
        {
            _activeMinigameId = forcarGameIndex;
        }
        else
        {
            // Intentar triar un joc que no estigui a l'historial recent
            int[] jocsDisponibles = { 1, 2, 3, 5, 6 };
            List<int> possibles = new List<int>();
            foreach (int j in jocsDisponibles) if (!_historialJocs.Contains(j)) possibles.Add(j);

            if (possibles.Count > 0) _activeMinigameId = possibles[Random.Range(0, possibles.Count)];
            else _activeMinigameId = jocsDisponibles[Random.Range(0, jocsDisponibles.Length)];
        }

        // Actualitzar historial
        _historialJocs.Add(_activeMinigameId);
        if (_historialJocs.Count > MAX_HISTORIAL) _historialJocs.RemoveAt(0);
        
        string nomJoc = (_activeMinigameId < _nomsMinijocs.Length) ? _nomsMinijocs[_activeMinigameId] : "Desconegut";
        Debug.Log($"[MinijocUI] Preparant joc: {nomJoc} (ID: {_activeMinigameId})");

        switch (_activeMinigameId)
        {
            case 1:
                var contPPT = root.Q<VisualElement>("ContenidorPPTLLS");
                if (contPPT != null)
                {
                    contPPT.style.display = DisplayStyle.Flex;
                    MinijocPPTLLSLogic logic = GetComponent<MinijocPPTLLSLogic>() ?? gameObject.AddComponent<MinijocPPTLLSLogic>();
                    logic.enabled = true; // Task 6.1: Activar només aquest
                    Debug.Log("[MinijocUI] Inicialitzant PPTLLS...");
                    logic.InicialitzarUI(root); 
                    logic.IniciarMinijoc(); 
                }
                else { Debug.LogError("[MinijocUI] CRÍTIC: ContenidorPPTLLS no trobat!"); ResolverEmpatDirecte(); }
                break;
            case 2:
                var contParells = root.Q<VisualElement>("ContenidorParellsSenars");
                if (contParells != null)
                {
                    contParells.style.display = DisplayStyle.Flex;
                    MinijocParellsSenarsLogic logic = GetComponent<MinijocParellsSenarsLogic>() ?? gameObject.AddComponent<MinijocParellsSenarsLogic>();
                    logic.enabled = true; // Task 6.1: Activar només aquest
                    Debug.Log("[MinijocUI] Inicialitzant ParellsSenars...");
                    logic.InicialitzarUI(root); 
                    logic.IniciarMinijoc(); 
                }
                else { Debug.LogError("[MinijocUI] CRÍTIC: ContenidorParellsSenars no trobat!"); ResolverEmpatDirecte(); }
                break;
            case 3:
                var contAtura = root.Q<VisualElement>("ContenidorAturaBarra");
                if (contAtura != null)
                {
                    contAtura.style.display = DisplayStyle.Flex;
                    MinijocAturaBarraLogic logic = GetComponent<MinijocAturaBarraLogic>() ?? gameObject.AddComponent<MinijocAturaBarraLogic>();
                    logic.enabled = true; // Task 6.1: Activar només aquest
                    Debug.Log("[MinijocUI] Inicialitzant AturaBarra...");
                    logic.InicialitzarUI(root); 
                    logic.IniciarMinijoc(); 
                }
                else { Debug.LogError("[MinijocUI] CRÍTIC: ContenidorAturaBarra no trobat!"); ResolverEmpatDirecte(); }
                break;
            case 5:
                var contPols = root.Q<VisualElement>("ContenidorPolsForca");
                if (contPols == null) contPols = root.Q<VisualElement>("ContenidorPolsimForca"); // Fallback per typo
                if (contPols != null)
                {
                    contPols.style.display = DisplayStyle.Flex;
                    MinijocPolsimForcaLogic logic = GetComponent<MinijocPolsimForcaLogic>() ?? gameObject.AddComponent<MinijocPolsimForcaLogic>();
                    logic.enabled = true; // Task 6.1: Activar només aquest
                    Debug.Log("[MinijocUI] Inicialitzant PolsimForca...");
                    logic.InicialitzarUI(root); 
                    logic.IniciarMinijoc(); 
                }
                else { Debug.LogError("[MinijocUI] CRÍTIC: ContenidorPolsForca no trobat!"); ResolverEmpatDirecte(); }
                break;
            case 6:
                var contAcaparament = root.Q<VisualElement>("ContenidorAcaparamentMirades");
                if (contAcaparament == null) contAcaparament = root.Q<VisualElement>("ContenidorAcaparament"); // Fallback per typo
                if (contAcaparament != null)
                {
                    contAcaparament.style.display = DisplayStyle.Flex;
                    MinijocAcaparamentMiradesLogic logic = GetComponent<MinijocAcaparamentMiradesLogic>() ?? gameObject.AddComponent<MinijocAcaparamentMiradesLogic>();
                    logic.enabled = true; // Task 6.1: Activar només aquest
                    
                    bool socAtacant = (GameManager.Instance != null && GameManager.Instance.localPlayer != null) ? (GameManager.Instance.localPlayer == _atacant) : false;
                    
                    Debug.Log("[MinijocUI] Inicialitzant AcaparamentMirades (Atacante=" + socAtacant + ")...");
                    logic.SetRole(socAtacant);
                    logic.InicialitzarUI(root); 
                    logic.IniciarMinijoc(); 
                }
                else { Debug.LogError("[MinijocUI] CRÍTIC: ContenidorAcaparamentMirades no trobat!"); ResolverEmpatDirecte(); }
                break;
            default:
                ResolverEmpatDirecte();
                break;
        }
        
        Debug.Log($"[MinijocUI] Combat preparat i mostrat: {_atacant.username} vs {_defensor.username}. Joc: {_activeMinigameId}");
    }

    private void AmagarTotsElsMinijocs(VisualElement root)
    {
        if (root == null) return;

        string[] contenedores = { 
            "ContenidorPPTLLS", 
            "ContenidorParellsSenars", 
            "ContenidorAturaBarra", 
            "ContenidorPolsForca", 
            "ContenidorAcaparamentMirades",
            "Background"
        };

        foreach (var id in contenedores)
        {
            var el = root.Q<VisualElement>(id);
            if (el != null) el.style.display = DisplayStyle.None;
        }

        // Task 6.1: APAGAR TOTS ELS SCRIPTS DE LÒGICA per evitar interferències (EL BUG DELS FANTASMES)
        if (GetComponent<MinijocPPTLLSLogic>() != null) GetComponent<MinijocPPTLLSLogic>().enabled = false;
        if (GetComponent<MinijocParellsSenarsLogic>() != null) GetComponent<MinijocParellsSenarsLogic>().enabled = false;
        if (GetComponent<MinijocAturaBarraLogic>() != null) GetComponent<MinijocAturaBarraLogic>().enabled = false;
        if (GetComponent<MinijocPolsimForcaLogic>() != null) GetComponent<MinijocPolsimForcaLogic>().enabled = false;
        if (GetComponent<MinijocAcaparamentMiradesLogic>() != null) GetComponent<MinijocAcaparamentMiradesLogic>().enabled = false;
    }

    public void FinalitzarCombat(string winnerUsername, string loserUsername)
    {
        // Task 3.2: Guarda de reentrancia
        if (!minijocActiu || _combatAcabat) return;
        _combatAcabat = true;
        
        Debug.Log($"[MinijocUI] Finalitzant combat. Guanyador: {winnerUsername}, Perdedor: {loserUsername}");
        
        // 5.1 LIMPIEZA DE UI INMEDIATA
        if (_uiDocument != null && _uiDocument.rootVisualElement != null) 
        {
            var root = _uiDocument.rootVisualElement;
            AmagarTotsElsMinijocs(root);
            root.style.display = DisplayStyle.None;
        }

        gameObject.SetActive(false);

        // 3. EFECTE DE XOC / EMPENTA (Knockback Selectiu)
        if (_jugador1 != null && _jugador2 != null && winnerUsername != "Empat")
        {
            Player pGuanyador = (winnerUsername == _jugador1.username) ? _jugador1 : _jugador2;
            Player pPerdedor = (winnerUsername == _jugador1.username) ? _jugador2 : _jugador1;

            // El perdedor rep un gran empujón
            pPerdedor.AplicarEmpenta(pGuanyador.transform.position);
            
            // El guanyador rep un empujón mini o res (opcional: pGuanyador.AplicarEmpenta(pPerdedor.transform.position, 5f))
            Debug.Log($"[Combat] Knockback aplicat a {pPerdedor.username}. {pGuanyador.username} es manté estable.");
        }
        else if (_jugador1 != null && _jugador2 != null)
        {
            // En cas d'empat, empenta a tots dos
            _jugador1.AplicarEmpenta(_jugador2.transform.position);
            _jugador2.AplicarEmpenta(_jugador1.transform.position);
        }

        // 4. PROCESSAR RESULTATS (Task 3.3: Filtre estricte d'identitat local)
        string miNombre = (GameManager.Instance != null && GameManager.Instance.localPlayer != null) 
                          ? GameManager.Instance.localPlayer.username 
                          : WebSocketClient.LocalUsername;

        if (winnerUsername != "Empat")
        {
            // El guanyador local es desbloqueja
            if (string.Equals(winnerUsername, miNombre, System.StringComparison.OrdinalIgnoreCase))
            {
                if (GameManager.Instance != null && GameManager.Instance.localPlayer != null)
                    GameManager.Instance.localPlayer.GuanyarMinijoc();
            }
            // El perdedor local processa derrota (vides + stun + animació)
            else if (string.Equals(loserUsername, miNombre, System.StringComparison.OrdinalIgnoreCase))
            {
                if (GameManager.Instance != null && GameManager.Instance.localPlayer != null)
                    GameManager.Instance.localPlayer.ProcesarDerrota(8f);
            }

            // Sync visual de Stun per als remots (perquè vegin el stun de l'altre)
            Player pPerdedor = (_jugador1 != null && _jugador1.username == loserUsername) ? _jugador1 : _jugador2;
            if (pPerdedor != null && pPerdedor.username != miNombre)
            {
                pPerdedor.AplicarEfecteVisualDerrota(8f);
            }
            
            // Si el defensor ha perdut, ha de deixar la bandera (Només si som el defensor)
            if (pPerdedor == _defensor && _defensor != null && _defensor.username == miNombre)
            {
                _defensor.DeixarBandera();
                GameObject banderaObj = GameObject.FindGameObjectWithTag("Bandera");
                if (banderaObj != null && banderaObj.transform.parent == _defensor.transform)
                {
                    banderaObj.transform.SetParent(null);
                    Bandera scriptB = banderaObj.GetComponent<Bandera>();
                    if (scriptB != null) scriptB.fugint = true;
                }
            }
        }
        else
        {
            // CAS D'EMPAT: Desbloquegem localment si estem implicats
            if (_jugador1 != null && _jugador1.username == miNombre) _jugador1.GuanyarMinijoc();
            if (_jugador2 != null && _jugador2.username == miNombre) _jugador2.GuanyarMinijoc();
        }

        // Limpieza de estado post-combate
        Player.LimpiarEstadoCombate();

        minijocActiu = false;
        if (_jugador1 != null) _jugador1.FinalitzarCombat();
        if (_jugador2 != null) _jugador2.FinalitzarCombat();
    }

    public void HideUI()
    {
        minijocActiu = false;
        _combatAcabat = false; // Task 3.5: Reset
        Player.LimpiarEstadoCombate();

        if (_jugador1 != null) _jugador1.FinalitzarCombat();
        if (_jugador2 != null) _jugador2.FinalitzarCombat();
        
        if (_uiDocument != null && _uiDocument.rootVisualElement != null) 
        {
            var root = _uiDocument.rootVisualElement;
            AmagarTotsElsMinijocs(root);
            root.style.display = DisplayStyle.None;
        }
    }

    // --- PONT DE SINCRONITZACIÓ DE XARXA ---
    public void RebreActualitzacioXarxa(string data)
    {
        if (!minijocActiu) return;
        
        switch (_activeMinigameId)
        {
            case 1: GetComponent<MinijocPPTLLSLogic>()?.RebreActualitzacioXarxa(data); break;
            case 2: GetComponent<MinijocParellsSenarsLogic>()?.RebreActualitzacioXarxa(data); break;
            case 3: GetComponent<MinijocAturaBarraLogic>()?.RebreActualitzacioXarxa(data); break;
            case 5: GetComponent<MinijocPolsimForcaLogic>()?.RebreActualitzacioXarxa(data); break;
            case 6: GetComponent<MinijocAcaparamentMiradesLogic>()?.RebreActualitzacioXarxa(data); break;
        }
    }

    public void RebreResultatXarxa(string winner, string loser)
    {
        if (!minijocActiu) return;

        Debug.Log($"[MinijocUI] Rebut resultat de xarxa. Guanyador: {winner}, Perdedor: {loser}");
        FinalitzarCombat(winner, loser);
    }
    // ---------------------------------------

    private void ResolverEmpatDirecte() { 
        Debug.LogWarning("[MinijocUI] ResolverEmpatDirecte cridat! El minijoc es tancarà immediatament.");
        HideUI(); 
    }
}
