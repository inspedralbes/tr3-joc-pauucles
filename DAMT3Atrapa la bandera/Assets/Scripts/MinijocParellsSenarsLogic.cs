using UnityEngine;
using UnityEngine.UIElements;

public class MinijocParellsSenarsLogic : MonoBehaviour
{
    private Label _textOperacio;
    private Label _textResultat;
    private Button _btnParells, _btnSenars;

    private int _num1, _num2;
    private bool _faseRevelacio = false;
    private float _tempsRevelacio = 3f;
    private bool _jocActiu = false;
    private string _guanyador = "Empat";

    public void InicialitzarUI(VisualElement root)
    {
        _textOperacio = root.Q<Label>("TextOperacio");
        _textResultat = root.Q<Label>("TextResultatMates");
        _btnParells = root.Q<Button>("BtnParells");
        _btnSenars = root.Q<Button>("BtnSenars");

        if (_btnParells != null) _btnParells.clicked += () => AvaluarJugada(true);
        if (_btnSenars != null) _btnSenars.clicked += () => AvaluarJugada(false);

        if (_textResultat != null) _textResultat.text = "";
    }

    public void IniciarMinijoc()
    {
        _num1 = Random.Range(1, 10);
        _num2 = Random.Range(1, 10);
        
        if (_textOperacio != null) _textOperacio.text = $"{_num1} + {_num2} = ?";
        if (_textResultat != null) _textResultat.text = "";
        
        _faseRevelacio = false;
        _tempsRevelacio = 3f;
        _jocActiu = true;
    }

    private void AvaluarJugada(bool triatParell)
    {
        if (!_jocActiu || _faseRevelacio) return;

        int suma = _num1 + _num2;
        bool esParell = (suma % 2 == 0);
        bool encertat = (triatParell == esParell);

        _faseRevelacio = true;
        _guanyador = encertat ? "Jugador 1" : "Jugador 2";
        
        if (_textResultat != null) 
            _textResultat.text = $"{_num1} + {_num2} = {suma} ({(esParell ? "Parell" : "Senar")}). Guanya {_guanyador}!";
    }

    private void Update()
    {
        if (!_jocActiu || !_faseRevelacio) return;

        _tempsRevelacio -= Time.deltaTime;
        if (_tempsRevelacio <= 0)
        {
            _jocActiu = false;
            MinijocUIManager.Instance.FinalitzarCombat(_guanyador);
        }
    }
}
