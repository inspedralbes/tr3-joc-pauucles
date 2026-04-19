using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class MinijocParellsSenarsLogic : MonoBehaviour
{
    private int _num1, _num2;
    private float tempsRestant = 5f;
    private bool jocActiu = false;
    private bool respostaEsParell;

    public void IniciarMinijoc()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _num1 = Random.Range(1, 50);
        _num2 = Random.Range(1, 50);
        respostaEsParell = ((_num1 + _num2) % 2 == 0);

        var labels = root.Query<Label>().ToList();
        if (labels.Count > 1)
        {
            labels[1].text = $"{_num1} + {_num2}";
        }

        var botons = root.Query<Button>().ToList();
        if (botons.Count >= 2)
        {
            botons[0].clicked -= () => Respon(true);
            botons[0].clicked += () => Respon(true);
            botons[1].clicked -= () => Respon(false);
            botons[1].clicked += () => Respon(false);
        }

        tempsRestant = 5f;
        jocActiu = true;
    }

    public void RebreResultatXarxa(string winner)
    {
        if (jocActiu && winner != "LOCAL_WIN")
        {
            CridarDerrota();
        }
    }

    private void Respon(bool triatParell)
    {
        if (!jocActiu) return;

        jocActiu = false;
        Debug.Log("Boto clicat!");

        bool encertat = (triatParell == respostaEsParell);

        if (encertat)
        {
            Player localPlayer = GetLocalPlayer();
            if (localPlayer != null) localPlayer.GuanyarMinijoc();
        }
        else
        {
            Player localPlayer = GetLocalPlayer();
            if (localPlayer != null) localPlayer.PerdreMinijoc();
        }

        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!jocActiu) return;

        tempsRestant -= Time.deltaTime;
        
        // Opcional: Podríem actualitzar el temps també usant cerca genèrica si calgués, 
        // però l'usuari no ho ha demanat explícitament en aquest turn per Update.
        // Tot i així, per mantenir la UI funcional, intentarem trobar la label de temps (índex 2 normalment).
        var root = GetComponent<UIDocument>().rootVisualElement;
        var labels = root.Query<Label>().ToList();
        if (labels.Count > 2) labels[2].text = tempsRestant.ToString("F1");

        if (tempsRestant <= 0)
        {
            CridarDerrota();
        }
    }

    private void CridarDerrota()
    {
        if (!jocActiu) return;

        jocActiu = false;

        Player localPlayer = GetLocalPlayer();
        if (localPlayer != null) localPlayer.PerdreMinijoc();

        this.gameObject.SetActive(false);
    }

    private Player GetLocalPlayer()
    {
        Player[] allPlayers = Object.FindObjectsByType<Player>(FindObjectsSortMode.None);
        foreach (var p in allPlayers)
        {
            if (p.GetComponent<RemotePlayer>() == null) return p;
        }
        return null;
    }
}
