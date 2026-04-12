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

    public void ShowUI(Player p1, Player p2)
    {
        minijocActiu = true;

        _jugador1 = p1;
        _jugador2 = p2;
        _jugador1.potMoure = false;
        _jugador2.potMoure = false;

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
        _contenidorAcaparamentMirades = root.Q<VisualElement>("ContenidorAcaparamentMirades");

        if (_textResultat != null) _textResultat.text = "Iniciant combat...";

        AmagarTotsElsContenidors();

        _activeMinigameId = Random.Range(1, 7);
        string nomJoc = _nomsMinijocs[_activeMinigameId];
        Debug.Log("Ruleta: Toca jugar a " + nomJoc + " (ID: " + _activeMinigameId + ")");

        switch (_activeMinigameId)
        {
            case 1:
                if (_contenidorPPTLLS != null)
                {
                    _contenidorPPTLLS.style.display = DisplayStyle.Flex;
                    MinijocPPTLLSLogic logic = GetComponent<MinijocPPTLLSLogic>();
                    if (logic != null) { logic.InicialitzarUI(root); logic.IniciarMinijoc(); }
                }
                else ResolverEmpatDirecte();
                break;
            case 2:
                if (_contenidorParellsSenars != null)
                {
                    _contenidorParellsSenars.style.display = DisplayStyle.Flex;
                    MinijocParellsSenarsLogic logic = GetComponent<MinijocParellsSenarsLogic>();
                    if (logic != null) { logic.InicialitzarUI(root); logic.IniciarMinijoc(); }
                }
                else ResolverEmpatDirecte();
                break;
            case 3:
                if (_contenidorAturaBarra != null)
                {
                    _contenidorAturaBarra.style.display = DisplayStyle.Flex;
                    MinijocAturaBarraLogic logic = GetComponent<MinijocAturaBarraLogic>();
                    if (logic != null) { logic.InicialitzarUI(root); logic.IniciarMinijoc(); }
                }
                else ResolverEmpatDirecte();
                break;
            case 5:
                if (_contenidorPolsForca != null)
                {
                    _contenidorPolsForca.style.display = DisplayStyle.Flex;
                    MinijocPolsimForcaLogic logic = GetComponent<MinijocPolsimForcaLogic>();
                    if (logic != null) { logic.InicialitzarUI(root); logic.IniciarMinijoc(); }
                }
                else ResolverEmpatDirecte();
                break;
            case 6:
                if (_contenidorAcaparamentMirades != null)
                {
                    _contenidorAcaparamentMirades.style.display = DisplayStyle.Flex;
                    MinijocAcaparamentMiradesLogic logic = GetComponent<MinijocAcaparamentMiradesLogic>();
                    if (logic != null) { logic.InicialitzarUI(root); logic.IniciarMinijoc(); }
                }
                else ResolverEmpatDirecte();
                break;
            default:
                ResolverEmpatDirecte();
                break;
        }
    }

    private void AmagarTotsElsContenidors()
    {
        if (_backgroundOverlay != null) _backgroundOverlay.style.display = DisplayStyle.None;
        if (_contenidorPPTLLS != null) _contenidorPPTLLS.style.display = DisplayStyle.None;
        if (_contenidorParellsSenars != null) _contenidorParellsSenars.style.display = DisplayStyle.None;
        if (_contenidorAturaBarra != null) _contenidorAturaBarra.style.display = DisplayStyle.None;
        if (_contenidorPolsForca != null) _contenidorPolsForca.style.display = DisplayStyle.None;
        if (_contenidorAcaparamentMirades != null) _contenidorAcaparamentMirades.style.display = DisplayStyle.None;
    }

    public void FinalitzarCombat(string nomGuanyador)
    {
        Debug.Log("Finalitzant combat. Guanyador: " + nomGuanyador);
        
        AmagarTotsElsContenidors();
        if (_uiDocument != null && _uiDocument.rootVisualElement != null) 
            _uiDocument.rootVisualElement.style.display = DisplayStyle.None;

        if (nomGuanyador == "Empat")
        {
            if (_atacant != null && _defensor != null)
            {
                Rigidbody2D rbAtacant = _atacant.GetComponent<Rigidbody2D>();
                Rigidbody2D rbDefensor = _defensor.GetComponent<Rigidbody2D>();
                if (rbAtacant != null && rbDefensor != null)
                {
                    Vector2 dirAtacant = (_atacant.transform.position - _defensor.transform.position).normalized;
                    if (dirAtacant == Vector2.zero) dirAtacant = Vector2.left;
                    rbAtacant.AddForce(dirAtacant * 10f, ForceMode2D.Impulse);
                    rbDefensor.AddForce(-dirAtacant * 10f, ForceMode2D.Impulse);
                }
            }
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
        AmagarTotsElsContenidors();
        if (_uiDocument != null && _uiDocument.rootVisualElement != null) _uiDocument.rootVisualElement.style.display = DisplayStyle.None;
    }

    private void ResolverEmpatDirecte() { Debug.Log("Minijoc no disponible. Empat."); HideUI(); }
}
