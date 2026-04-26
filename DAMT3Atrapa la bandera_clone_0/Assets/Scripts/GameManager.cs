// ##########################################
// GAME MANAGER - VERSION LIMPIA Y DIRECTA
// ##########################################
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UIDocument pantallaFinalUI;
    
    [Header("Prefabs Skins")]
    public GameObject prefabBiker; public GameObject prefabCyborg; public GameObject prefabGraveRobber;
    public GameObject prefabPunk; public GameObject prefabSteamMan; public GameObject prefabWoodcutter;
    
    [Header("Prefabs Banderes")]
    public GameObject banderaBlava; public GameObject banderaVermella;
    public GameObject banderaGroga; public GameObject banderaVerda;
    public List<SkinMapping> skinsDisponibles;
    [System.Serializable] public struct SkinMapping { public string nomSkin; public GameObject prefab; }

    public Player localPlayer;
    public Dictionary<string, RemotePlayer> remotePlayers = new Dictionary<string, RemotePlayer>();
    private bool jocFinalitzat = false;

    void Awake() { if (Instance == null) Instance = this; }

    void Start()
    {
        jocFinalitzat = false;
        if (pantallaFinalUI != null) pantallaFinalUI.rootVisualElement.style.display = DisplayStyle.None;
        
        // 1. Crear Jugador
        if (localPlayer == null) InstanciarLocalPlayer();
        
        // 2. Col·locar-lo al seu lloc i posar banderes
        ConfigurarPartida();
    }

    void ConfigurarPartida()
    {
        if (localPlayer == null) return;

        // Determinar Equip
        string team = GetTeamFromRoomData(WebSocketClient.Username);
        localPlayer.equip = team;
        
        // Nametag
        Nametag n = localPlayer.GetComponentInChildren<Nametag>();
        if (n != null) n.Configurar(WebSocketClient.Username, team);

        // Anar al Spawn
        GameObject spawn = GameObject.Find("PuntSpawn_Equip" + (team == "A" ? "1" : "2"));
        if (spawn != null) {
            localPlayer.transform.position = spawn.transform.position;
            var rb = localPlayer.GetComponent<Rigidbody2D>();
            if (rb != null) rb.linearVelocity = Vector2.zero;
        }

        // Posar Banderes (si no hi són ja)
        if (Object.FindObjectsByType<Bandera>(FindObjectsSortMode.None).Length == 0) {
            InstanciarBanderes();
        }
    }

    public void InstanciarBanderes()
    {
        if (MenuManager.Instance?.currentRoomData == null) return;
        var room = MenuManager.Instance.currentRoomData;

        GameObject s1 = GameObject.Find("PuntSpawn_Equip1");
        GameObject s2 = GameObject.Find("PuntSpawn_Equip2");

        if (s1 != null) {
            GameObject fA = Instantiate(GetFlagPrefab(room.teamAColor), s1.transform.position + new Vector3(1.5f, 0, 0), Quaternion.identity);
            fA.GetComponent<Bandera>().equipPropietari = "A";
        }
        if (s2 != null) {
            GameObject fB = Instantiate(GetFlagPrefab(room.teamBColor), s2.transform.position + new Vector3(1.5f, 0, 0), Quaternion.identity);
            fB.GetComponent<Bandera>().equipPropietari = "B";
        }
    }

    public string GetTeamFromRoomData(string username)
    {
        if (MenuManager.Instance?.currentRoomData?.players == null) return "A";
        foreach (var p in MenuManager.Instance.currentRoomData.players) {
            if (p.username.Equals(username, System.StringComparison.OrdinalIgnoreCase)) {
                string t = p.team.ToUpper();
                if (t == "A" || t == "1") return "A";
                if (t == "B" || t == "2") return "B";
                return (MenuManager.Instance.currentRoomData.players[0].username == username) ? "A" : "B";
            }
        }
        return "A";
    }

    public GameObject GetFlagPrefab(string color) {
        if (string.IsNullOrEmpty(color)) return banderaBlava;
        string c = color.ToLower();
        if (c.Contains("azul") || c.Contains("blau")) return banderaBlava;
        if (c.Contains("roj") || c.Contains("vermell")) return banderaVermella;
        if (c.Contains("groc") || c.Contains("amarillo")) return banderaGroga;
        if (c.Contains("verd")) return banderaVerda;
        return banderaBlava;
    }

    void InstanciarLocalPlayer()
    {
        string skin = PlayerPrefs.GetString("skinEquipada", "Woodcutter");
        GameObject prefab = GetPrefabPerSkin(skin);
        GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        localPlayer = go.GetComponent<Player>();
        ActualitzarSeguimentCamera(go.transform);
    }

    public GameObject GetPrefabPerSkin(string s) {
        if (skinsDisponibles != null) foreach (var m in skinsDisponibles) if (m.nomSkin == s) return m.prefab;
        if (s == "Biker") return prefabBiker; if (s == "Cyborg") return prefabCyborg;
        if (s == "GraveRobber") return prefabGraveRobber; if (s == "Punk") return prefabPunk;
        if (s == "SteamMan") return prefabSteamMan;
        return prefabWoodcutter;
    }

    public void UpdateRemotePlayer(NetworkSync.PlayerMoveMessage msg)
    {
        if (remotePlayers.ContainsKey(msg.username)) remotePlayers[msg.username].UpdateStatus(msg);
        else {
            GameObject prefab = GetPrefabPerSkin(msg.skin); 
            GameObject go = Instantiate(prefab, new Vector3(msg.x, msg.y, 0), Quaternion.identity);
            go.AddComponent<RemotePlayer>().Configurar(msg.username);
            Player p = go.GetComponent<Player>();
            string eq = GetTeamFromRoomData(msg.username);
            if (p != null) p.equip = eq;
            Nametag n = go.GetComponentInChildren<Nametag>();
            if (n != null) n.Configurar(msg.username, eq);
            remotePlayers.Add(msg.username, go.GetComponent<RemotePlayer>());
        }
    }

    public void FinalitzarPartida(bool victoria) {
        if (jocFinalitzat) return; jocFinalitzat = true;
        if (pantallaFinalUI != null) {
            var r = pantallaFinalUI.rootVisualElement; r.style.display = DisplayStyle.Flex;
            Label t = r.Q<Label>("TextResultat");
            if (t != null) { t.text = victoria ? "HAS GUANYAT!" : "HAS PERDUT..."; t.style.color = victoria ? Color.green : Color.red; }
        }
        if (victoria && MenuManager.Instance?.websocket != null) {
            MenuManager.GameOverMessage m = new MenuManager.GameOverMessage { type = "GAME_OVER", roomId = MenuManager.Instance.currentRoomData?.roomId ?? "", winner = MenuManager.Instance.userId };
            MenuManager.Instance.websocket.SendText(JsonUtility.ToJson(m));
        }
    }

    public void RemoveRemotePlayer(string u) { if (remotePlayers.ContainsKey(u)) { Destroy(remotePlayers[u].gameObject); remotePlayers.Remove(u); } }
    public bool EsDelMeuEquip(string u) { return localPlayer != null && localPlayer.equip == GetTeamFromRoomData(u); }
    void ActualitzarSeguimentCamera(Transform t) { GameObject v = GameObject.Find("CM vcam1"); if (v != null) { var c = v.GetComponent("CinemachineVirtualCamera"); if(c!=null) { var f = c.GetType().GetProperty("Follow"); f?.SetValue(c, t); } } }
    public void TornarAlMenu() { if (WebSocketClient.Instance != null) WebSocketClient.Instance.Disconnect(); SceneManager.LoadScene("MenuPrincipal"); }
}
