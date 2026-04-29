using UnityEngine;
using UnityEngine.UIElements;

public class MinijocAturaBarraLogic : MonoBehaviour
{
    private VisualElement _fletxa;
    private VisualElement _zonaObjectiu;
    private Label _textResultat;
    private Button _btnAturar;

    private bool _jocActiu = false;
    private bool _faseRevelacio = false;
    private float _tempsRevelacio = 0.5f; // Task 2.1: Revelació més ràpida

    private float _tempsRestant = 10f;
    private float _fletxaPos = 0f;
    private float _fletxaSpeed = 400f;
    private float _zonaLeft = 0f;
    private string _winner = "";
    private string _loser = "";
    private float _tempsAcumulat = 0f;
    private Label _textTemps;

    public void InicialitzarUI(VisualElement root)
    {
        _fletxa = root.Q<VisualElement>("Fletxa");
        _zonaObjectiu = root.Q<VisualElement>("ZonaObjectiu");
        _textResultat = root.Q<Label>("TextResultatAturaBarra");
        _btnAturar = root.Q<Button>("BtnAturar");
        _textTemps = root.Q<Label>("TextTempsAtura");

        if (_btnAturar != null) { _btnAturar.clicked -= Aturar; _btnAturar.clicked += Aturar; }

        if (_zonaObjectiu != null)
        {
            _zonaObjectiu.style.position = Position.Absolute;
            _zonaObjectiu.style.backgroundColor = new StyleColor(Color.yellow);
            _zonaObjectiu.style.width = 80f;
            _zonaObjectiu.style.height = Length.Percent(100);
            _zonaObjectiu.style.top = 0;
            _zonaObjectiu.style.display = DisplayStyle.Flex;
        }

        if (_fletxa != null)
        {
            _fletxa.style.position = Position.Absolute;
            _fletxa.style.backgroundColor = new StyleColor(Color.red);
            _fletxa.style.width = 5f;
            _fletxa.style.height = Length.Percent(100);
            _fletxa.style.top = 0;
            _fletxa.style.display = DisplayStyle.Flex;
        }

        if (_textResultat != null) _textResultat.text = "";
    }

    public void IniciarMinijoc()
    {
        _jocActiu = true;
        _faseRevelacio = false;
        _tempsRevelacio = 0.5f;
        _fletxaPos = 0f;
        _tempsAcumulat = 0f;
        _tempsRestant = 10f; // 1) TIMER ÚNICO: Inicia un cop (Task 1.1)

        _zonaLeft = Random.Range(50f, 400f);
        ActualitzarZonaUI();
        if (_textResultat != null) _textResultat.text = "Atura la fletxa!";
    }

    private void ActualitzarZonaUI()
    {
        if (_zonaObjectiu != null)
        {
            _zonaObjectiu.style.left = new StyleLength(_zonaLeft);
            _zonaObjectiu.style.display = DisplayStyle.Flex;
        }
    }

    private void Update()
    {
        if (!_jocActiu) return;

        if (!_faseRevelacio)
        {
            _tempsRestant -= Time.deltaTime;
            if (_textTemps != null) _textTemps.text = $"Temps: {Mathf.Max(0, _tempsRestant):F1}s";

            if (_fletxa != null)
            {
                _tempsAcumulat += Time.deltaTime;
                _fletxaPos = Mathf.PingPong(_tempsAcumulat * _fletxaSpeed, 490f);
                _fletxa.style.left = new StyleLength(_fletxaPos);
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
            {
                Aturar();
            }

            if (_tempsRestant <= 0)
            {
                // Task 2.3: Identitats reals per a vides i stun
                _winner = MinijocUIManager.Instance.jugador2.username;
                _loser = MinijocUIManager.Instance.jugador1.username;
                _faseRevelacio = true;
                if (_textResultat != null) _textResultat.text = "TEMPS EXHAURIT!";
                ResoldreXarxa();
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

    public void Aturar()
    {
        if (!_jocActiu || _faseRevelacio) return;

        float zonaWidth = (_zonaObjectiu != null) ? _zonaObjectiu.resolvedStyle.width : 80f;
        if (float.IsNaN(zonaWidth) || zonaWidth <= 0) zonaWidth = 80f;

        bool dins = (_fletxaPos >= _zonaLeft) && (_fletxaPos <= (_zonaLeft + zonaWidth));
        
        _faseRevelacio = true;
        
        if (dins)
        {
            // Guanya el local (Task 2.3)
            _winner = MinijocUIManager.Instance.jugador1.username;
            _loser = MinijocUIManager.Instance.jugador2.username;
            if (_textResultat != null) _textResultat.text = "DINS! Guanyes tu!";
        }
        else
        {
            // Guanya el rival (Task 2.3)
            _winner = MinijocUIManager.Instance.jugador2.username;
            _loser = MinijocUIManager.Instance.jugador1.username;
            if (_textResultat != null) _textResultat.text = "FORA! Guanya el rival!";
        }
        ResoldreXarxa();
    }

    private void ResoldreXarxa()
    {
        // 2) RESOLUCIÓN INSTANTÁNEA: Només el Host envia el resultat per evitar duplicats
        if (MenuManager.Instance != null && MenuManager.Instance.IsHost())
        {
            MenuManager.Instance.EnviarMinijocResult(_winner, _loser);
        }
    }

    public void RebreActualitzacioXarxa(string data)
    {
        if (_jocActiu && data.StartsWith("ZONA:"))
        {
            if (float.TryParse(data.Substring(5), out float novaZona))
            {
                _zonaLeft = novaZona;
                ActualitzarZonaUI();
            }
        }
    }

    public void RebreResultatXarxa(string winner)
    {
        // PPTLLS no ho usava, però en AturaBarra sí per a la sincronització de velocitat
    }
}
