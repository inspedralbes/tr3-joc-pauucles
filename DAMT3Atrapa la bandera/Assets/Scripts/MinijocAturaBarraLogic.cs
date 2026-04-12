using UnityEngine;
using UnityEngine.UIElements;

public class MinijocAturaBarraLogic : MonoBehaviour
{
    private VisualElement _fletxa;
    private VisualElement _zonaObjectiu;
    private Label _textResultat;

    private bool _jocActiu = false;
    private bool _faseRevelacio = false;
    private float _tempsRevelacio = 3f;

    private float _fletxaPos = 0f;
    private float _fletxaSpeed = 400f;
    private float _zonaLeft = 0f;
    private string _guanyador = "Empat";

    public void InicialitzarUI(VisualElement root)
    {
        _fletxa = root.Q<VisualElement>("Fletxa");
        _zonaObjectiu = root.Q<VisualElement>("ZonaObjectiu");
        _textResultat = root.Q<Label>("TextResultatAturaBarra");

        if (_textResultat != null) _textResultat.text = "";
    }

    public void IniciarMinijoc()
    {
        _jocActiu = true;
        _faseRevelacio = false;
        _tempsRevelacio = 3f;
        _fletxaPos = 0f;

        _zonaLeft = Random.Range(10f, 400f);
        if (_zonaObjectiu != null)
        {
            _zonaObjectiu.style.left = _zonaLeft;
            _zonaObjectiu.style.display = DisplayStyle.Flex;
        }
        
        if (_textResultat != null) _textResultat.text = "Atura la fletxa!";
    }

    private void Update()
    {
        if (!_jocActiu) return;

        if (!_faseRevelacio)
        {
            if (_fletxa != null)
            {
                _fletxaPos = Mathf.PingPong(Time.time * _fletxaSpeed, 490f);
                _fletxa.style.left = _fletxaPos;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Aturar();
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
        _guanyador = dins ? "Jugador 1" : "Jugador 2";

        if (_textResultat != null)
        {
            _textResultat.text = dins ? "DINS! Guanya Jugador 1" : "FORA! Guanya Jugador 2";
        }
    }
}
