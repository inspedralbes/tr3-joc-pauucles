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
    private float _tempsRevelacio = 3f;

    private float _tempsRestant = 10f;
    private float _fletxaPos = 0f;
    private float _fletxaSpeed = 400f;
    private float _zonaLeft = 0f;
    private string _guanyador = "Empat";
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
        _tempsRevelacio = 3f;
        _fletxaPos = 0f;
        _tempsAcumulat = 0f;
        _tempsRestant = 10f;

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
                _guanyador = "Jugador 2";
                _faseRevelacio = true;
                if (_textResultat != null) _textResultat.text = "TEMPS EXHAURIT!";
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

    public void Aturar()
    {
        if (!_jocActiu || _faseRevelacio) return;

        float zonaWidth = (_zonaObjectiu != null) ? _zonaObjectiu.resolvedStyle.width : 80f;
        if (float.IsNaN(zonaWidth) || zonaWidth <= 0) zonaWidth = 80f;

        bool dins = (_fletxaPos >= _zonaLeft) && (_fletxaPos <= (_zonaLeft + zonaWidth));
        
        _faseRevelacio = true;
        
        if (dins)
        {
            _guanyador = "Jugador 1";
            if (_textResultat != null) _textResultat.text = "DINS! Guanyes tu!";
            if (MenuManager.Instance != null) MenuManager.Instance.EnviarMinijocResult("RIVAL_WIN");
        }
        else
        {
            // VICTORIA INSTANTÀNEA PER AL RIVAL SI FALLES
            _guanyador = "Jugador 2";
            if (_textResultat != null) _textResultat.text = "FORA! Guanya el rival!";
            if (MenuManager.Instance != null) MenuManager.Instance.EnviarMinijocResult("LOCAL_WIN"); // El rival rebrà que és local win per a ell
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
                Debug.Log($"[AturaBarra] Zona sincronitzada: {_zonaLeft}");
            }
        }
    }

    public void RebreResultatXarxa(string winner)
    {
        if (!_jocActiu || _faseRevelacio) return;

        // Si el rival ens diu que ha guanyat, nosaltres perdem immediatament
        if (winner == "RIVAL_WIN")
        {
            _faseRevelacio = true;
            _guanyador = "Jugador 2"; // Per nosaltres el guanyador és el rival

            if (_textResultat != null)
            {
                _textResultat.text = "EL RIVAL HA ESTAT MÉS RÀPID!";
            }
        }
    }
}
