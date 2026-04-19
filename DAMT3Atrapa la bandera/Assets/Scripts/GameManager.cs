using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UIDocument pantallaFinalUI;
    
    [Header("Prefabs de Banderes")]
    public GameObject banderaBlava;
    public GameObject banderaVermella;
    public GameObject banderaGroga;
    public GameObject banderaVerda;

    [Header("Prefabs per Skin")]
    public GameObject prefabBiker;
    public GameObject prefabCyborg;
    public GameObject prefabGraveRobber;
    public GameObject prefabPunk;
    public GameObject prefabSteamMan;
    public GameObject prefabWoodcutter;

    public Player localPlayer;
    public Dictionary<string, RemotePlayer> remotePlayers = new Dictionary<string, RemotePlayer>();

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        // Inicialització de la UI de fin de partida
        if (pantallaFinalUI != null)
        {
            var root = pantallaFinalUI.rootVisualElement;
            root.style.display = DisplayStyle.None;

            // 3.2: Subscripció robusta a tots els botons que es diguin 'BotoTornar'
            root.Query<Button>("BotoTornar").ToList().ForEach(btn => {
                btn.clicked -= TornarAlMenu; // Evitar duplicats si es crida més d'un cop
                btn.clicked += TornarAlMenu;
            });
        }

        // Instanciem el jugador local amb la seva skin triada
        if (localPlayer == null)
        {
            InstanciarLocalPlayer();
        }

        if (localPlayer != null)
        {
            AssignarSpawn();
            ConfigurarLocalPlayerVisuals();
            StartCoroutine(SpawnAmbRetard());
            
            if (localPlayer.GetComponent<NetworkSync>() == null)
            {
                localPlayer.gameObject.AddComponent<NetworkSync>();
            }
        }
        else
        {
            Debug.LogError("[GameManager] No s'ha trobat el component Player a l'escena.");
        }
    }

    public void RemoveRemotePlayer(string username)
    {
        if (remotePlayers.ContainsKey(username))
        {
            RemotePlayer rp = remotePlayers[username];
            if (rp != null)
            {
                Destroy(rp.gameObject);
            }
            remotePlayers.Remove(username);
            Debug.Log($"[GameManager] Jugador remot eliminat: {username}");
        }
    }

    private System.Collections.IEnumerator SpawnAmbRetard()
    {
        // Esperem un temps fix per donar temps a la xarxa a sincronitzar-se
        yield return new UnityEngine.WaitForSeconds(0.5f);

        Debug.Log("[GameManager] Intentant instanciar banderes...");
        InstanciarBanderes();
    }

    void InstanciarLocalPlayer()
    {
        string skin = "Woodcutter";
        string username = "Jugador";
        if (MenuManager.Instance != null) 
        {
            skin = MenuManager.Instance.currentSkin;
            username = !string.IsNullOrEmpty(MenuManager.Instance.userId) ? MenuManager.Instance.userId : "Jugador";
        }

        GameObject prefab = GetPrefabPerSkin(skin);
        // Instanciem temporalment a zero, AssignarSpawn el mourà al lloc correcte
        GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        localPlayer = go.GetComponent<Player>();
        
        // Configuració del Nametag (TextMeshPro en els fills)
        TMPro.TextMeshPro nameText = go.GetComponentInChildren<TMPro.TextMeshPro>();
        if (nameText != null)
        {
            nameText.text = username;
        }
        else
        {
            Debug.LogWarning("[GameManager] No s'ha trobat el component TMPro.TextMeshPro per al Nametag al LocalPlayer.");
        }

        Debug.Log($"[GameManager] LocalPlayer instanciat amb skin: {skin} i nom: {username}");
    }

    public GameObject GetPrefabPerSkin(string skinName)
    {
        if (string.IsNullOrEmpty(skinName)) return prefabWoodcutter;

        if (skinName == "Biker") return prefabBiker;
        if (skinName == "Cyborg") return prefabCyborg;
        if (skinName == "GraveRobber") return prefabGraveRobber;
        if (skinName == "Punk") return prefabPunk;
        if (skinName == "SteamMan") return prefabSteamMan;
        if (skinName == "Woodcutter") return prefabWoodcutter;
        
        return prefabWoodcutter; // Defecte
    }

    public void InstanciarBanderes()
    {
        if (MenuManager.Instance == null || MenuManager.Instance.currentRoomData == null)
        {
            Debug.LogWarning("[GameManager] No s'han pogut instanciar les banderes: MenuManager o roomData nuls.");
            return;
        }

        var room = MenuManager.Instance.currentRoomData;
        
        // Cerca de punts de spawn
        Transform spawn1 = null;
        Transform spawn2 = null;
        Transform[] allTransforms = UnityEngine.Object.FindObjectsByType<Transform>(UnityEngine.FindObjectsSortMode.None);
        foreach (Transform t in allTransforms)
        {
            if (t.name == "PuntSpawn_Equip1") spawn1 = t;
            if (t.name == "PuntSpawn_Equip2") spawn2 = t;
        }

        // Instanciació Bandera Equip A
        if (spawn1 != null)
        {
            GameObject prefabA = GetFlagPrefab(room.teamAColor);
            if (prefabA != null)
            {
                GameObject flagGO = Instantiate(prefabA, spawn1.position + new Vector3(2f, 0f, 0f), Quaternion.identity);
                flagGO.transform.localScale = new Vector3(4f, 4f, 1f);
                Bandera flagScript = flagGO.GetComponent<Bandera>();
                if (flagScript != null) flagScript.equipPropietari = "A";
                Debug.Log($"[GameManager] Bandera Equip A ({room.teamAColor}) instanciada.");
            }
        }

        // Instanciació Bandera Equip B
        if (spawn2 != null)
        {
            GameObject prefabB = GetFlagPrefab(room.teamBColor);
            if (prefabB != null)
            {
                GameObject flagGO = Instantiate(prefabB, spawn2.position + new Vector3(2f, 0f, 0f), Quaternion.identity);
                flagGO.transform.localScale = new Vector3(4f, 4f, 1f);
                Bandera flagScript = flagGO.GetComponent<Bandera>();
                if (flagScript != null) flagScript.equipPropietari = "B";
                Debug.Log($"[GameManager] Bandera Equip B ({room.teamBColor}) instanciada.");
            }
        }
    }

    public GameObject GetFlagPrefab(string color)
    {
        if (string.IsNullOrEmpty(color)) return banderaBlava; // Fallback
        
        string c = color.ToLower();
        if (c.Contains("azul") || c.Contains("blau") || c.Contains("blue")) return banderaBlava;
        if (c.Contains("roj") || c.Contains("vermell") || c.Contains("red")) return banderaVermella;
        if (c.Contains("amarillo") || c.Contains("groc") || c.Contains("yellow")) return banderaGroga;
        if (c.Contains("verd") || c.Contains("green")) return banderaVerda;
        
        return banderaBlava; // Por defecto si no coincide nada
    }

    void ConfigurarLocalPlayerVisuals()
    {
        if (localPlayer != null && !string.IsNullOrEmpty(WebSocketClient.Username))
        {
            // El color ja hauria de venir del prefab instanciat,
            // però ens assegurem que el nametag tingui el nom.
            localPlayer.InicialitzarJugador(WebSocketClient.Username, WebSocketClient.Team);

            // Assignar equip al localPlayer
            localPlayer.equip = GetTeamFromRoomData(WebSocketClient.Username);
            Debug.Log($"[GameManager] Equip assignat a LocalPlayer: {localPlayer.equip}");

            // Sincronització extra del Nametag (Cerca exhaustiva de component de text)
            var nameText = localPlayer.GetComponentInChildren<TMPro.TextMeshPro>();
            UnityEngine.UI.Text legacyText = null;

            if (nameText == null)
            {
                legacyText = localPlayer.GetComponentInChildren<UnityEngine.UI.Text>();
            }

            // Fallback: buscar un GameObject anomenat "Nametag"
            if (nameText == null && legacyText == null)
            {
                Transform nametagTransform = localPlayer.transform.Find("Nametag") ?? localPlayer.transform.Find("Visuals/Nametag");
                if (nametagTransform != null)
                {
                    nameText = nametagTransform.GetComponent<TMPro.TextMeshPro>();
                    if (nameText == null) legacyText = nametagTransform.GetComponent<UnityEngine.UI.Text>();
                }
            }

            if (MenuManager.Instance != null && !string.IsNullOrEmpty(MenuManager.Instance.userId))
            {
                if (nameText != null)
                {
                    nameText.text = MenuManager.Instance.userId;
                    Debug.Log($"[GameManager] Nametag (TMP) actualitzat: {MenuManager.Instance.userId}");
                }
                else if (legacyText != null)
                {
                    legacyText.text = MenuManager.Instance.userId;
                    Debug.Log($"[GameManager] Nametag (Legacy) actualitzat: {MenuManager.Instance.userId}");
                }
            }
        }
    }

    public void UpdateRemotePlayer(NetworkSync.PlayerMoveMessage msg)
    {
        // --- HACK SINCRONITZACIÓ EIX X ---
        if (msg.x >= 9000f)
        {
            Debug.Log("[GameManager] Senyal de victòria rival detectat (X >= 9000). Finalitzant minijoc local.");
            
            // 2.3 Tancar UI de minijocs
            if (MinijocUIManager.Instance != null)
            {
                MinijocUIManager.Instance.gameObject.SetActive(false);
            }

            // 2.4 Buscar jugador local i aplicar derrota
            if (localPlayer == null)
            {
                GameObject lpGo = GameObject.FindGameObjectWithTag("Player");
                if (lpGo != null) localPlayer = lpGo.GetComponent<Player>();
            }

            if (localPlayer != null)
            {
                localPlayer.PerdreMinijoc();
            }

            // 2.5 Return immediat
            return;
        }
        // ---------------------------------

        if (remotePlayers.ContainsKey(msg.username))
        {
            remotePlayers[msg.username].UpdateStatus(msg);
        }
        else
        {
            // Instanciar nou jugador remot
            GameObject prefab = GetPrefabPerSkin(msg.skin); 
            GameObject go = Instantiate(prefab, new Vector3(msg.x, msg.y, 0), Quaternion.identity);
            RemotePlayer rp = go.AddComponent<RemotePlayer>();
            
            if (go.GetComponent<NetworkSync>() == null)
            {
                go.AddComponent<NetworkSync>();
            }
            
            // Assignar equip al component Player remot
            Player pScript = go.GetComponent<Player>();
            if (pScript != null)
            {
                pScript.equip = GetTeamFromRoomData(msg.username);
                Debug.Log($"[GameManager] Equip assignat a jugador remot {msg.username}: {pScript.equip}");
            }

            rp.Configurar(msg.username);
            remotePlayers.Add(msg.username, rp);
            Debug.Log($"[GameManager] Nou jugador remot registrat: {msg.username}");
        }
    }

    private string GetTeamFromRoomData(string username)
    {
        if (MenuManager.Instance == null || MenuManager.Instance.currentRoomData == null || MenuManager.Instance.currentRoomData.players == null) return "";

        foreach (var p in MenuManager.Instance.currentRoomData.players)
        {
            if (p.username == username)
            {
                if (string.IsNullOrEmpty(p.team)) return "";
                string t = p.team.ToLower();
                if (t.Contains("1") || t == "a" || t == "rojo" || t == "vermell") return "A";
                return "B";
            }
        }
        return "";
    }

    public bool EsDelMeuEquip(string username)
    {
        if (localPlayer == null) return false;
        string winnerTeam = GetTeamFromRoomData(username);
        return localPlayer.equip == winnerTeam;
    }

    void AssignarSpawn()
    {
        string team = WebSocketClient.Team;
        if (string.IsNullOrEmpty(team)) team = "Rojo";

        string tLower = team.ToLower();
        string targetName = (tLower == "1" || tLower == "a" || tLower == "rojo" || tLower == "vermell") ? "PuntSpawn_Equip1" : "PuntSpawn_Equip2";
        
        List<Transform> validSpawns = new List<Transform>();
        Transform[] allTransforms = UnityEngine.Object.FindObjectsByType<Transform>(UnityEngine.FindObjectsSortMode.None);

        foreach (Transform t in allTransforms)
        {
            if (t.name == targetName) validSpawns.Add(t);
        }

        if (validSpawns.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, validSpawns.Count);
            localPlayer.transform.position = validSpawns[randomIndex].position;
        }
        else
        {
            Debug.LogError($"[GameManager] No s'ha trobat cap spawn: {targetName}");
        }
    }

    public void FinalitzarPartida(bool victoria)
    {
        Debug.Log($"[GameManager] Finalitzant partida. Victòria local: {victoria}");

        // 1) Bloquejar moviment de tots els jugadors
        Player[] allPlayers = UnityEngine.Object.FindObjectsByType<Player>(UnityEngine.FindObjectsSortMode.None);
        foreach (Player p in allPlayers)
        {
            p.potMoure = false;
        }

        // 2) Mostrar la UI de fi de partida
        if (pantallaFinalUI != null)
        {
            var root = pantallaFinalUI.rootVisualElement;
            root.style.display = DisplayStyle.Flex;

            Label textResultat = root.Q<Label>("TextResultat");
            if (textResultat != null)
            {
                textResultat.text = victoria ? "HAS GUANYAT!" : "HAS PERDUT...";
            }
        }
        else
        {
            Debug.LogError("[GameManager] No s'ha assignat el component pantallaFinalUI.");
        }

        // Enviar esdeveniment 'GAME_OVER' pel WebSocket a l'altre jugador
        if (victoria && MenuManager.Instance != null && MenuManager.Instance.websocket != null)
        {
            string currentRoomId = "";
            if (MenuManager.Instance.currentRoomData != null)
            {
                currentRoomId = MenuManager.Instance.currentRoomData.roomId;
            }

            MenuManager.GameOverMessage msg = new MenuManager.GameOverMessage
            {
                type = "GAME_OVER",
                roomId = currentRoomId,
                winner = MenuManager.Instance.userId
            };
            string json = JsonUtility.ToJson(msg);
            MenuManager.Instance.websocket.SendText(json);
            Debug.Log($"[GameManager] Missatge GAME_OVER enviat a sala '{currentRoomId}': {json}");
        }
    }

    public void TornarAlMenu()
    {
        Debug.Log("[GameManager] Botó premut, tornant al menú principal...");
        
        // Desconnectar la xarxa
        if (WebSocketClient.Instance != null)
        {
            WebSocketClient.Instance.Disconnect();
        }

        // 2.2: Netejar estat del menú abans de carregar l'escena
        if (MenuManager.Instance != null)
        {
            MenuManager.Instance.NetejarEstatTornada();
        }
        
        SceneManager.LoadScene("MenuPrincipal");
    }
}
