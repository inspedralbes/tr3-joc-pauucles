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

    [System.Serializable]
    public struct SkinMapping
    {
        public string nomSkin;
        public GameObject prefab;
    }

    [Header("Configuració de Skins")]
    public List<SkinMapping> skinsDisponibles;

    [Header("Prefabs per Skin (Obsolet - Usar llista)")]
    public GameObject prefabBiker;
    public GameObject prefabCyborg;
    public GameObject prefabGraveRobber;
    public GameObject prefabPunk;
    public GameObject prefabSteamMan;
    public GameObject prefabWoodcutter;

    public Player localPlayer;
    public Dictionary<string, RemotePlayer> remotePlayers = new Dictionary<string, RemotePlayer>();
    private bool banderesInstanciades = false;

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

        if (!banderesInstanciades)
        {
            banderesInstanciades = true;
            Debug.Log("[GameManager] Instantciant banderes locals...");
            InstanciarBanderes();
        }
    }

    void InstanciarLocalPlayer()
    {
        // 2.3: Lectura de skin desada amb fallback a Woodcutter
        string skin = PlayerPrefs.GetString("skinEquipada", "Woodcutter");
        string username = "Jugador";
        
        if (MenuManager.Instance != null) 
        {
            username = !string.IsNullOrEmpty(MenuManager.Instance.userId) ? MenuManager.Instance.userId : "Jugador";
        }

        GameObject prefab = GetPrefabPerSkin(skin);
        Debug.Log($"[GameManager] Instanciant LOCAL PLAYER amb skin: {skin}");
        
        GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        localPlayer = go.GetComponent<Player>();
        
        // 3.2: Actualització de càmera (Cinemachine fallback)
        ActualitzarSeguimentCamera(go.transform);

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

    void ActualitzarSeguimentCamera(Transform target)
    {
        // Intentar trobar Cinemachine Virtual Camera (via reflexió o cerca de tipus si està el package)
        // Com que no sabem si el package està instal·lat, busquem per nom o component genèric
        GameObject vcam = GameObject.Find("CM vcam1") ?? GameObject.FindGameObjectWithTag("MainCamera");
        if (vcam != null)
        {
            // Si és MainCamera i té un script de follow personalitzat, caldria assignar-lo.
            // Si és Cinemachine, normalment s'assigna al component CinemachineVirtualCamera.
            var cinemachineComponent = vcam.GetComponent("CinemachineVirtualCamera");
            if (cinemachineComponent != null)
            {
                var followProp = cinemachineComponent.GetType().GetProperty("Follow");
                var lookAtProp = cinemachineComponent.GetType().GetProperty("LookAt");
                followProp?.SetValue(cinemachineComponent, target);
                lookAtProp?.SetValue(cinemachineComponent, target);
                Debug.Log("[GameManager] Càmera Cinemachine actualitzada amb el nou target.");
            }
        }
    }

    public GameObject GetPrefabPerSkin(string skinName)
    {
        if (string.IsNullOrEmpty(skinName)) skinName = "Woodcutter";

        // 3.1: Cerca a la llista de skins disponibles
        if (skinsDisponibles != null)
        {
            foreach (var mapping in skinsDisponibles)
            {
                if (mapping.nomSkin == skinName && mapping.prefab != null)
                {
                    return mapping.prefab;
                }
            }
        }

        // Fallback als camps individuals (obsolets)
        if (skinName == "Biker") return prefabBiker;
        if (skinName == "Cyborg") return prefabCyborg;
        if (skinName == "GraveRobber") return prefabGraveRobber;
        if (skinName == "Punk") return prefabPunk;
        if (skinName == "SteamMan") return prefabSteamMan;
        if (skinName == "Woodcutter") return prefabWoodcutter;
        
        return prefabWoodcutter; // Defecte final
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
