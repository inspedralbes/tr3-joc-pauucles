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
            if (_uiDocument.rootVisualElement != null)
            {
                _uiDocument.rootVisualElement.style.display = DisplayStyle.None;
            }
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
        
        Debug.Log($"[MinijocUI] Iniciant minijoc sincronitzat (Index: {forcarGameIndex})");

        minijocActiu = true;

        // Obtenir components Player i bloquejar moviment
        _jugador1 = g1.GetComponent<Player>();
        _jugador2 = g2.GetComponent<Player>();

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

        // 3.1 i 3.3: Selecció de joc autoritaria
        _activeMinigameId = (forcarGameIndex > 0) ? forcarGameIndex : Random.Range(1, 7);
        
        string nomJoc = (_activeMinigameId < _nomsMinijocs.Length) ? _nomsMinijocs[_activeMinigameId] : "Desconegut";
        Debug.Log("Ruleta: Toca jugar a " + nomJoc + " (ID: " + _activeMinigameId + ")");

        switch (_activeMinigameId)
        {
            case 1:
                var contPPT = root.Q<VisualElement>("ContenidorPPTLLS");
                if (contPPT != null)
                {
                    contPPT.style.display = DisplayStyle.Flex;
                    MinijocPPTLLSLogic logic = GetComponent<MinijocPPTLLSLogic>() ?? gameObject.AddComponent<MinijocPPTLLSLogic>();
                    Debug.Log("[MinijocUI] Inicialitzant PPTLLS...");
                    logic.InicialitzarUI(root); 
                    logic.IniciarMinijoc(); 
                }
                else ResolverEmpatDirecte();
                break;
            case 2:
                var contParells = root.Q<VisualElement>("ContenidorParellsSenars");
                if (contParells != null)
                {
                    contParells.style.display = DisplayStyle.Flex;
                    MinijocParellsSenarsLogic logic = GetComponent<MinijocParellsSenarsLogic>() ?? gameObject.AddComponent<MinijocParellsSenarsLogic>();
                    Debug.Log("[MinijocUI] Inicialitzant ParellsSenars...");
                    logic.InicialitzarUI(root); 
                    logic.IniciarMinijoc(); 
                }
                else ResolverEmpatDirecte();
                break;
            case 3:
                var contAtura = root.Q<VisualElement>("ContenidorAturaBarra");
                if (contAtura != null)
                {
                    contAtura.style.display = DisplayStyle.Flex;
                    MinijocAturaBarraLogic logic = GetComponent<MinijocAturaBarraLogic>() ?? gameObject.AddComponent<MinijocAturaBarraLogic>();
                    Debug.Log("[MinijocUI] Inicialitzant AturaBarra...");
                    logic.InicialitzarUI(root); 
                    logic.IniciarMinijoc(); 
                }
                else ResolverEmpatDirecte();
                break;
            case 5:
                var contPols = root.Q<VisualElement>("ContenidorPolsForca");
                if (contPols != null)
                {
                    contPols.style.display = DisplayStyle.Flex;
                    MinijocPolsimForcaLogic logic = GetComponent<MinijocPolsimForcaLogic>() ?? gameObject.AddComponent<MinijocPolsimForcaLogic>();
                    Debug.Log("[MinijocUI] Inicialitzant PolsimForca...");
                    logic.InicialitzarUI(root); 
                    logic.IniciarMinijoc(); 
                }
                else ResolverEmpatDirecte();
                break;
            case 6:
                var contAcaparament = root.Q<VisualElement>("ContenidorAcaparamentMirades");
                if (contAcaparament != null)
                {
                    contAcaparament.style.display = DisplayStyle.Flex;
                    MinijocAcaparamentMiradesLogic logic = GetComponent<MinijocAcaparamentMiradesLogic>() ?? gameObject.AddComponent<MinijocAcaparamentMiradesLogic>();
                    
                    // Determinar si som l'atacant o el defensor
                    bool socAtacant = false;
                    if (GameManager.Instance != null && GameManager.Instance.localPlayer != null)
                    {
                        socAtacant = (GameManager.Instance.localPlayer == _atacant);
                    }
                    
                    Debug.Log("[MinijocUI] Inicialitzant AcaparamentMirades (Atacant=" + socAtacant + ")...");
                    logic.SetRole(socAtacant);
                    logic.InicialitzarUI(root); 
                    logic.IniciarMinijoc(); 
                }
                else ResolverEmpatDirecte();
                break;
            default:
                ResolverEmpatDirecte();
                break;
        }
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
    }

    public void FinalitzarCombat(string nomGuanyador)
    {
        Debug.Log("[MinijocUI] Finalitzant combat. Guanyador: " + nomGuanyador);
        
        if (_uiDocument != null && _uiDocument.rootVisualElement != null) 
        {
            var root = _uiDocument.rootVisualElement;
            AmagarTotsElsMinijocs(root);
            root.style.display = DisplayStyle.None;
            Debug.Log("[MinijocUI] UI amagada (None) després del combat.");
        }

        // 3.1 Tancar el GameObject del Manager
        gameObject.SetActive(false);

        // 3.2 Notificar als jugadors del resultat
        
        Player localPlayer = null;
        Player[] allPlayers = Object.FindObjectsByType<Player>(FindObjectsSortMode.None);
        foreach (var p in allPlayers)
        {
            if (p.GetComponent<RemotePlayer>() == null) // El que no té RemotePlayer és el local
            {
                localPlayer = p;
                break;
            }
        }

        // 3. EFECTE DE XOC / EMPENTA (Knockback) per als dos jugadors
        if (_jugador1 != null && _jugador2 != null)
        {
            Player p1 = _jugador1.GetComponent<Player>();
            Player p2 = _jugador2.GetComponent<Player>();
            if (p1 != null && p2 != null)
            {
                p1.AplicarEmpenta(_jugador2.transform.position);
                p2.AplicarEmpenta(_jugador1.transform.position);
            }
        }

        // 4. PROCESSAR RESULTATS LOCALS I VISUALS
        if (nomGuanyador != "Empat")
        {
            // Determinar qui ha guanyat i qui ha perdut
            Player pGuanyador = (nomGuanyador == "Jugador 1") ? _jugador1 : _jugador2;
            Player pPerdedor = (nomGuanyador == "Jugador 1") ? _jugador2 : _jugador1;

            // El guanyador SEMPRE es pot moure
            if (pGuanyador != null) pGuanyador.GuanyarMinijoc();

            // El perdedor rep el càstig
            if (pPerdedor != null)
            {
                if (pPerdedor == localPlayer) pPerdedor.ProcesarDerrota(8f);
                else pPerdedor.AplicarEfecteVisualDerrota(8f);
            }
        }
        else
        {
            // CAS D'EMPAT: Desbloquegem als dos immediatament
            Debug.Log("[MinijocUI] Empat detectat. Desbloquejant ambdós jugadors.");
            if (_jugador1 != null) _jugador1.GuanyarMinijoc();
            if (_jugador2 != null) _jugador2.GuanyarMinijoc();
        }

        bool defensorHaPerdut = false;
        if (nomGuanyador == "Jugador 1" && _defensor == _jugador2) defensorHaPerdut = true;
        else if (nomGuanyador == "Jugador 2" && _defensor == _jugador1) defensorHaPerdut = true;

        if (defensorHaPerdut)
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

        minijocActiu = false;
        if (_jugador1 != null) _jugador1.FinalitzarCombat();
        if (_jugador2 != null) _jugador2.FinalitzarCombat();
    }

    public void HideUI()
    {
        minijocActiu = false;
        if (_jugador1 != null) _jugador1.FinalitzarCombat();
        if (_jugador2 != null) _jugador2.FinalitzarCombat();
        
        if (_uiDocument != null && _uiDocument.rootVisualElement != null) 
        {
            var root = _uiDocument.rootVisualElement;
            AmagarTotsElsMinijocs(root);
            root.style.display = DisplayStyle.None;
            Debug.Log("[MinijocUI] UI amagada (None) manualment/forçadament.");
        }
    }

    // --- PONT DE SINCRONITZACIÓ DE XARXA ---
    public void RebreActualitzacioXarxa(string data)
    {
        if (!minijocActiu) return;
        
        // Passem el missatge a la lògica activa segons l'ID
        switch (_activeMinigameId)
        {
            case 1: GetComponent<MinijocPPTLLSLogic>()?.RebreActualitzacioXarxa(data); break;
            case 2: GetComponent<MinijocParellsSenarsLogic>()?.RebreActualitzacioXarxa(data); break;
            case 3: GetComponent<MinijocAturaBarraLogic>()?.RebreActualitzacioXarxa(data); break;
            case 5: GetComponent<MinijocPolsimForcaLogic>()?.RebreActualitzacioXarxa(data); break;
            case 6: GetComponent<MinijocAcaparamentMiradesLogic>()?.RebreActualitzacioXarxa(data); break;
            // Altres minijocs poden ignorar o implementar segons calgui
        }
    }

    public void RebreResultatXarxa(string winner)
    {
        if (!minijocActiu) return;

        Debug.Log($"[MinijocUI] Rebut resultat de xarxa. Guanyador remot: {winner}");
        
        // En jocs de velocitat, el primer que arriba mana
        switch (_activeMinigameId)
        {
            case 1: GetComponent<MinijocPPTLLSLogic>()?.RebreResultatXarxa(winner); break;
            case 3: GetComponent<MinijocAturaBarraLogic>()?.RebreResultatXarxa(winner); break;
            case 4: GetComponent<MinijocCablePelatLogic>()?.RebreResultatXarxa(winner); break;
            case 5: GetComponent<MinijocPolsimForcaLogic>()?.RebreResultatXarxa(winner); break;
        }
    }
    // ---------------------------------------

    private void ResolverEmpatDirecte() { Debug.Log("Minijoc no disponible. Empat."); HideUI(); }
}
