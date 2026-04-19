using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;
using NativeWebSocket;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    private VisualElement pantallaLogin;
    private VisualElement pantallaLobby;
    private VisualElement pantallaSalaEspera;
    private ListView llistaPartides;
    private ListView llistaJugadorsSala;
    private string baseUrl = "http://localhost:3000/api";
    private string currentRoomId;
    public string userId;
    public GameData currentRoomData;
    public string currentSkin = "Woodcutter";
    public WebSocket websocket;

    // Cua d'execució per al fil principal
    private readonly Queue<Action> _executionQueue = new Queue<Action>();

    // UI Inventari
    private VisualElement pantallaInventari;
    private ListView llistaSkins;
    private Label labelSkinActual;
    private Button btnAnarSkins;
    private Button btnEquiparSkin;
    private Button btnTancarInventari;
    private string[] skinsDisponibles = { "Woodcutter", "GraveRobber", "SteamMan" };

    public void EnqueueMainThread(Action action)
    {
        lock (_executionQueue)
        {
            _executionQueue.Enqueue(action);
        }
    }

    [System.Serializable]
    public class SkinUpdateData
    {
        public string username;
        public string skinName;
    }

    [System.Serializable]
    public class RoomListMessage
    {
        public string type;
        public GameData[] sales;
    }

    [System.Serializable]
    public class RoomUpdateMessage
    {
        public string type;
        public GameData room;
    }

    private void Awake()
    {
        // 1.1, 1.2 i 1.3: Implementació estricta del patró Singleton
        if (Instance != null && Instance != this)
        {
            Debug.Log("[MenuManager] Instància duplicada detectada, destruint...");
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        // Registrar callback per quan es carreguen escenes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MenuPrincipal")
        {
            Debug.Log("[MenuManager] Escena MenuPrincipal detectada. Re-vinculant UI.");
            
            // 2.2: Refrescar la referència al UIDocument abans de res
            UIDocument uiDoc = GetComponent<UIDocument>();
            if (uiDoc == null) uiDoc = FindFirstObjectByType<UIDocument>();

            if (uiDoc != null && uiDoc.rootVisualElement != null)
            {
                VincularEsdevenimentsUI();
                ActualitzarVisibilitatSegonsSessio();
            }
            else
            {
                Debug.LogWarning("[MenuManager] No s'ha trobat cap UIDocument vàlid a l'escena 'MenuPrincipal'.");
            }
        }
    }

    public void NetejarEstatTornada()
    {
        Debug.Log("[MenuManager] Netejant estat de sala anterior.");
        currentRoomId = "";
        currentRoomData = null;
    }

    async void Start()
    {
        websocket = new WebSocket("ws://localhost:3000");

        websocket.OnOpen += () =>
        {
            EnqueueMainThread(() => Debug.Log("Connexió WebSocket pura establerta!"));
        };

        websocket.OnError += (e) =>
        {
            EnqueueMainThread(() => Debug.Log("Error WebSocket: " + e));
        };

        websocket.OnClose += (e) =>
        {
            EnqueueMainThread(() => Debug.Log("WebSocket desconnectat"));
        };

        websocket.OnMessage += (bytes) =>
        {
            var message = System.Text.Encoding.UTF8.GetString(bytes);
            AlRebreActualitzacioSales(message);
        };

        await websocket.Connect();

        // Verificació de sessió existent per evitar pantalla blava en tornar del joc
        ActualitzarVisibilitatSegonsSessio();
    }

    private void ActualitzarVisibilitatSegonsSessio()
    {
        // 2.1: Comprovar si tenim dades d'usuari i referències vàlides
        bool autenticat = !string.IsNullOrEmpty(userId) || !string.IsNullOrEmpty(WebSocketClient.LocalUsername);
        
        // Sincronitzar si un és buit però l'altre no
        if (string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(WebSocketClient.LocalUsername))
            userId = WebSocketClient.LocalUsername;
        else if (string.IsNullOrEmpty(WebSocketClient.LocalUsername) && !string.IsNullOrEmpty(userId))
            WebSocketClient.LocalUsername = userId;

        // 1.4: Assegurar que el root del UIDocument és visible
        var uiDoc = GetComponent<UIDocument>();
        if (uiDoc != null && uiDoc.rootVisualElement != null)
        {
            uiDoc.rootVisualElement.style.display = DisplayStyle.Flex;
        }

        // 1.3: Bloc de "Force Reset" per a panells secundaris
        if (popUpCrearSala != null) popUpCrearSala.style.display = DisplayStyle.None;
        if (pantallaSalaEspera != null) pantallaSalaEspera.style.display = DisplayStyle.None;
        if (pantallaInventari != null) pantallaInventari.style.display = DisplayStyle.None;

        // 2.2: Lògica de commutació per a panells principals
        if (pantallaLogin != null && pantallaLobby != null)
        {
            if (autenticat)
            {
                pantallaLogin.style.display = DisplayStyle.None;
                pantallaLobby.style.display = DisplayStyle.Flex;
                Debug.Log("[MenuManager] Usuari ja autenticat, mostrant Lobby.");
                
                // 2.2: Refrescar llista de sales si ja estem loguejats
                StartCoroutine(ObtenirPartides());
            }
            else
            {
                pantallaLogin.style.display = DisplayStyle.Flex;
                pantallaLobby.style.display = DisplayStyle.None;
                Debug.Log("[MenuManager] Cap sessió activa, mostrant Login.");
            }
        }
        else
        {
            Debug.LogWarning("[MenuManager] No s'han trobat les referències de les pantalles Login/Lobby en inicialitzar.");
        }
    }

    private void ActualitzarUIJugadorsSala()
    {
        // 2.2: Obtenir el rootVisualElement actualitzat
        var uiDoc = GetComponent<UIDocument>();
        if (uiDoc == null || uiDoc.rootVisualElement == null) return;
        var root = uiDoc.rootVisualElement;

        Debug.Log("[MenuManager] Forçant refresc de la llista de jugadors.");

        // 2.3 i 2.4: Buscar l'element i reconstruir la llista
        if (currentRoomData != null && currentRoomData.players != null)
        {
            // Actualitzem el ListView si existeix
            if (llistaJugadorsSala == null) llistaJugadorsSala = root.Q<ListView>("llistaJugadorsSala");
            
            if (llistaJugadorsSala != null)
            {
                OmplirLlistaJugadors(currentRoomData.players);
            }
            else
            {
                // Fallback: si l'usuari té un Label genèric anomenat "llistaJugadors"
                Label labelLlista = root.Q<Label>("llistaJugadors");
                if (labelLlista != null)
                {
                    string textLlista = "";
                    foreach (var p in currentRoomData.players)
                    {
                        textLlista += $"Jugador: {p.username} {(p.isReady ? "(Llest)" : "(Esperant)")}\n";
                    }
                    labelLlista.text = textLlista;
                }
            }
        }
    }

    private void AlRebreActualitzacioSales(string dadesJSON)
    {
        try
        {
            // Intentem processar PLAYER_MOVE
            if (dadesJSON.Contains("\"type\":\"PLAYER_MOVE\""))
            {
                NetworkSync.PlayerMoveMessage moveMsg = JsonUtility.FromJson<NetworkSync.PlayerMoveMessage>(dadesJSON);
                if (moveMsg != null && moveMsg.username != WebSocketClient.LocalUsername)
                {
                    // --- HACK Z: SINCRONITZACIÓ DE DERROTA ---
                    if (moveMsg.z == 999f)
                    {
                        Debug.Log("[SISTEMA] El rival ha enviat senyal de victòria (Z=999). Aplicant derrota local...");
                        EnqueueMainThread(() =>
                        {
                            // Tancar la UI si està oberta
                            var managers = Resources.FindObjectsOfTypeAll<MinijocUIManager>();
                            if (managers.Length > 0) managers[0].gameObject.SetActive(false);
                            
                            // Aplicar Stun al jugador local
                            if (GameManager.Instance != null && GameManager.Instance.localPlayer != null)
                            {
                                GameManager.Instance.localPlayer.PerdreMinijoc();
                            }
                        });
                        moveMsg.z = 0f; // Reset per evitar problemes visuals
                    }
                    // -----------------------------------------

                    EnqueueMainThread(() => {
                        if (GameManager.Instance != null)
                        {
                            GameManager.Instance.UpdateRemotePlayer(moveMsg);
                        }
                    });
                }
                return;
            }

            // Intentem processar com a llista de sales primer
            if (dadesJSON.Contains("\"type\":\"ACTUALITZAR_SALES\""))
            {
                RoomListMessage listMsg = JsonUtility.FromJson<RoomListMessage>(dadesJSON);
                if (listMsg != null && listMsg.sales != null)
                {
                    EnqueueMainThread(() =>
                    {
                        ConfigurarLlistaPartides(listMsg.sales);
                        Debug.Log("Llista de sales actualitzada per WebSocket");
                    });
                }
                return;
            }

            // Intentem processar com a actualització de sala específica
            if (dadesJSON.Contains("\"type\":\"ROOM_UPDATED\""))
            {
                RoomUpdateMessage updateMsg = JsonUtility.FromJson<RoomUpdateMessage>(dadesJSON);
                if (updateMsg != null)
                {
                    // Si la sala és null, vol dir que s'ha eliminat
                    if (updateMsg.room == null || string.IsNullOrEmpty(updateMsg.room.roomId))
                    {
                        EnqueueMainThread(() =>
                        {
                            Debug.Log("La sala actual ha estat eliminada. Tornant al Lobby.");
                            if (pantallaSalaEspera != null) pantallaSalaEspera.style.display = DisplayStyle.None;
                            if (pantallaLobby != null) pantallaLobby.style.display = DisplayStyle.Flex;
                            currentRoomId = null;
                            currentRoomData = null;
                            StartCoroutine(ObtenirPartides());
                        });
                    }
                    else if (updateMsg.room.roomId == currentRoomId)
                    {
                        currentRoomData = updateMsg.room;
                        EnqueueMainThread(() =>
                        {
                            OmplirLlistaJugadors(updateMsg.room.players);
                            
                            // Forçar refresc de la UI de la sala
                            ActualitzarUIJugadorsSala();

                            // Neteja de jugadors remots que ja no hi són a la sala
                            if (GameManager.Instance != null)
                            {
                                List<string> toRemove = new List<string>();
                                foreach (var kvp in GameManager.Instance.remotePlayers)
                                {
                                    bool trobat = false;
                                    foreach (var p in updateMsg.room.players)
                                    {
                                        if (p.username == kvp.Key) { trobat = true; break; }
                                    }
                                    if (!trobat) toRemove.Add(kvp.Key);
                                }
                                foreach (var name in toRemove) GameManager.Instance.RemoveRemotePlayer(name);
                            }

                            Debug.Log("Llista de jugadors actualitzada per ROOM_UPDATED");
                        });
                    }
                }
                return;
            }

            // Intentem processar GAME_OVER
            if (dadesJSON.Contains("\"type\":\"GAME_OVER\""))
            {
                GameOverMessage goMsg = JsonUtility.FromJson<GameOverMessage>(dadesJSON);
                if (goMsg != null)
                {
                    EnqueueMainThread(() =>
                    {
                        if (GameManager.Instance != null)
                        {
                            bool victoriaPerEquip = GameManager.Instance.EsDelMeuEquip(goMsg.winner);
                            GameManager.Instance.FinalitzarPartida(victoriaPerEquip);
                        }
                    });
                }
                return;
            }

            // --- SINCRONITZACIÓ DE MINIJOCS ---
            if (dadesJSON.Contains("\"type\":\"MINIJOC_UPDATE\""))
            {
                MinigameUpdateMessage updateMsg = JsonUtility.FromJson<MinigameUpdateMessage>(dadesJSON);
                if (updateMsg != null && updateMsg.username != userId)
                {
                    EnqueueMainThread(() =>
                    {
                        if (MinijocUIManager.Instance != null)
                        {
                            MinijocUIManager.Instance.RebreActualitzacioXarxa(updateMsg.data);
                        }
                    });
                }
                return;
            }

            if (dadesJSON.Contains("\"type\":\"MINIJOC_RESULT\""))
            {
                MinigameResultMessage resultMsg = JsonUtility.FromJson<MinigameResultMessage>(dadesJSON);
                if (resultMsg != null && resultMsg.username != userId)
                {
                    EnqueueMainThread(() =>
                    {
                        if (MinijocUIManager.Instance != null)
                        {
                            MinijocUIManager.Instance.RebreResultatXarxa(resultMsg.winner);
                        }
                    });
                }
                return;
            }

            if (dadesJSON.Contains("\"type\":\"MINIJOC_START\""))
            {
                MinigameStartMessage startMsg = JsonUtility.FromJson<MinigameStartMessage>(dadesJSON);
                if (startMsg != null)
                {
                    // Comprovar si l'usuari local està implicat
                    bool localImplicat = (startMsg.p1 == userId || startMsg.p1 == WebSocketClient.LocalUsername || 
                                         startMsg.p2 == userId || startMsg.p2 == WebSocketClient.LocalUsername);

                    if (localImplicat)
                    {
                        EnqueueMainThread(() =>
                        {
                            // 2.2 Recerca robusta del manager (inclús inactiu)
                            // En aquest patró estricte, TOTHOM (Host i Client) utilitza aquest camí
                            var managers = Resources.FindObjectsOfTypeAll<MinijocUIManager>();
                            if (managers.Length > 0)
                            {
                                var ui = managers[0];
                                
                                Debug.Log("[SISTEMA] Rebut MINIJOC_START confirmant per xarxa. Activant UI sincronitzada...");
                                ui.gameObject.SetActive(true);

                                // Buscar els GameObjects dels lluitadors per passar-los al manager
                                GameObject g1 = GameObject.Find(startMsg.p1);
                                GameObject g2 = GameObject.Find(startMsg.p2);

                                if (g1 != null && g2 != null)
                                {
                                    // 2.3 Inicialitzar amb l'índex EXACTE rebut de la xarxa
                                    ui.IniciarMinijoc(g1, g2, startMsg.gameIndex);
                                }
                                else
                                {
                                    Debug.LogError("[SISTEMA] Error crític: No s'han trobat els GameObjects dels jugadors per nom.");
                                }
                            }
                            else
                            {
                                Debug.LogError("[SISTEMA] Error crític: No s'ha trobat el MinijocUIManager a l'escena.");
                            }
                        });
                    }
                }
                return;
            }
            // ---------------------------------

            // Intentem processar PARTIDA_INICIADA
            if (dadesJSON.Contains("\"type\":\"PARTIDA_INICIADA\""))
            {
                PartidaIniciadaMsg msg = JsonUtility.FromJson<PartidaIniciadaMsg>(dadesJSON);
                if (msg != null)
                {
                    // Si el missatge és per a nosaltres, guardem les dades i canviem d'escena
                    if (msg.username == userId)
                    {
                        WebSocketClient.Username = msg.username;
                        WebSocketClient.Team = msg.team;
                        WebSocketClient.ColorName = msg.color;
                        Debug.Log($"Dades de partida guardades per a {msg.username}: Equip={msg.team}, Color={msg.color}");

                        EnqueueMainThread(() =>
                        {
                            UIDocument ui = GetComponent<UIDocument>();
                            if (ui != null && ui.rootVisualElement != null)
                            {
                                ui.rootVisualElement.style.display = DisplayStyle.None;
                            }
                            Debug.Log("UI amagada i carregant escena Bosque...");
                            SceneManager.LoadScene("Bosque");
                        });
                    }
                }
                return;
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error en processar missatge WebSocket: " + e.Message + "\nJSON: " + dadesJSON);
        }
    }

    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        if (websocket != null)
        {
            websocket.DispatchMessageQueue();
        }
#endif

        // Executar accions de la cua al fil principal
        lock (_executionQueue)
        {
            while (_executionQueue.Count > 0)
            {
                _executionQueue.Dequeue().Invoke();
            }
        }
    }

    private async void OnApplicationQuit()
    {
        if (websocket != null)
        {
            await websocket.Close();
        }
    }

    // Referències UI Toolkit per a la creació de sala
    private VisualElement popUpCrearSala;
    private DropdownField dropdownEquip1;
    private DropdownField dropdownEquip2;
    private DropdownField dropdownJugadors;
    private Button btnConfirmarSala;
    private Button btnCancelarSala;
    private Button btnCrearPartida;
    private Button btnTancarSalaEspera;
    private Button btnConfirmarReady;
    private Button btnUnirsePartida;
    private Button btnActualitzarSales;

    [System.Serializable]
    public class PlayerData
    {
        public string username;
        public string team;
        public bool isReady;
        public string skin;
    }

    [System.Serializable]
    public class JoinGameData
    {
        public string roomId;
        public string username;
        public string team; // Necessari segons el backend
    }

    [System.Serializable]
    public class GameData
    {
        public string roomId;
        public string host;
        public string teamAColor;
        public string teamBColor;
        public int maxPlayers;
        public PlayerData[] players;
        public string status;
    }

    [System.Serializable]
    public class GameListWrapper
    {
        public GameData[] games;
    }

    [System.Serializable]
    public class AuthData
    {
        public string username;
        public string password;
    }

    [System.Serializable]
    public class LoginResponse
    {
        public string id;
        public string username;
        public string skinEquipada;
    }

    [System.Serializable]
    public class CreateGameData
    {
        public string host;
        public string teamAColor;
        public string teamBColor;
        public int maxPlayers;
    }

    [System.Serializable]
    public class LeaveRoomMessage
    {
        public string type = "leave_room";
        public string roomId;
        public string username;
    }

    [System.Serializable]
    public class ReadyMessage
    {
        public string type = "READY";
        public string roomId;
        public string username;
    }

    [System.Serializable]
    public class GameOverMessage
    {
        public string type = "GAME_OVER";
        public string roomId;
        public string winner;
    }

    [System.Serializable]
    public class PartidaIniciadaMsg
    {
        public string type;
        public string username;
        public string team;
        public string color;
    }

    [System.Serializable]
    public class MinigameUpdateMessage
    {
        public string type = "MINIJOC_UPDATE";
        public string roomId;
        public string username;
        public string data;
    }

    [System.Serializable]
    public class MinigameResultMessage
    {
        public string type = "MINIJOC_RESULT";
        public string roomId;
        public string username;
        public string winner;
    }

    [System.Serializable]
    public class MinigameStartMessage
    {
        public string type = "MINIJOC_START";
        public int gameIndex;
        public string p1;
        public string p2;
    }

    public void EnviarMinijocUpdate(string data)
    {
        if (websocket != null && websocket.State == WebSocketState.Open && currentRoomId != null)
        {
            MinigameUpdateMessage msg = new MinigameUpdateMessage
            {
                roomId = currentRoomId,
                username = userId,
                data = data
            };
            websocket.SendText(JsonUtility.ToJson(msg));
        }
    }

    public void EnviarMinijocResult(string winner)
    {
        if (websocket != null && websocket.State == WebSocketState.Open && currentRoomId != null)
        {
            MinigameResultMessage msg = new MinigameResultMessage
            {
                roomId = currentRoomId,
                username = userId,
                winner = winner
            };
            websocket.SendText(JsonUtility.ToJson(msg));
        }
    }

    private void OnEnable()
    {
        VincularEsdevenimentsUI();
    }

    private void VincularEsdevenimentsUI()
    {
        var uiDoc = GetComponent<UIDocument>();
        if (uiDoc == null || uiDoc.rootVisualElement == null)
        {
            Debug.LogWarning("[MenuManager] No s'ha trobat l'UIDocument o el rootVisualElement a l'escena.");
            return;
        }

        var root = uiDoc.rootVisualElement;

        // Cercar pantalles pel seu nom exacte a l'UXML
        pantallaLogin = root.Q<VisualElement>("pantallaLogin");
        pantallaLobby = root.Q<VisualElement>("pantallaLobby");
        pantallaSalaEspera = root.Q<VisualElement>("pantallaSalaEspera");
        pantallaInventari = root.Q<VisualElement>("pantallaInventari");
        popUpCrearSala = root.Q<VisualElement>("popUpCrearSala");

        // Robust null-checks
        if (pantallaLogin == null) Debug.LogWarning("[MenuManager] No s'ha trobat 'pantallaLogin' a l'UXML.");
        if (pantallaLobby == null) Debug.LogWarning("[MenuManager] No s'ha trobat 'pantallaLobby' a l'UXML.");
        if (pantallaSalaEspera == null) Debug.LogWarning("[MenuManager] No s'ha trobat 'pantallaSalaEspera' a l'UXML.");
        if (pantallaInventari == null) Debug.LogWarning("[MenuManager] No s'ha trobat 'pantallaInventari' a l'UXML.");
        if (popUpCrearSala == null) Debug.LogWarning("[MenuManager] No s'ha trobat 'popUpCrearSala' a l'UXML.");

        llistaPartides = root.Q<ListView>("llistaPartides");
        llistaJugadorsSala = root.Q<ListView>("llistaJugadorsSala");
        llistaSkins = root.Q<ListView>("llistaSkins");
        labelSkinActual = root.Q<Label>("labelSkinActual");

        if (pantallaSalaEspera != null)
        {
            pantallaSalaEspera.style.display = DisplayStyle.None;
        }

        if (pantallaInventari != null)
        {
            pantallaInventari.style.display = DisplayStyle.None;
        }

        if (llistaPartides != null)
        {
            llistaPartides.makeItem = () => new Label();
            llistaPartides.bindItem = (element, i) =>
            {
                if (llistaPartides.itemsSource == null || i >= llistaPartides.itemsSource.Count) return;
                var game = llistaPartides.itemsSource[i] as GameData;
                if (game != null)
                    (element as Label).text = $"Sala: {game.roomId} - Jugadors: {game.players.Length}/{game.maxPlayers}";
            };
        }

        if (llistaSkins != null)
        {
            llistaSkins.makeItem = () => new Label();
            llistaSkins.bindItem = (element, i) =>
            {
                if (skinsDisponibles == null || i >= skinsDisponibles.Length) return;
                (element as Label).text = skinsDisponibles[i];
                (element as Label).style.color = new StyleColor(Color.white);
            };
            llistaSkins.itemsSource = skinsDisponibles;
        }

        TextField inputNom = root.Q<TextField>("inputNomJugador");
        TextField inputPass = root.Q<TextField>("inputPassword");
        Button btnReg = root.Q<Button>("btnRegistre");
        Button btnLog = root.Q<Button>("btnLogin");
        Button btnTancar = root.Q<Button>("btnTancar");
        Button btnTancarLobby = root.Q<Button>("btnTancarLobby");

        // Inicialització UI Creació de Sala
        popUpCrearSala = root.Q<VisualElement>("popUpCrearSala");
        dropdownEquip1 = root.Q<DropdownField>("dropdownEquip1");
        dropdownEquip2 = root.Q<DropdownField>("dropdownEquip2");
        dropdownJugadors = root.Q<DropdownField>("dropdownJugadors");
        btnConfirmarSala = root.Q<Button>("btnConfirmarSala");
        btnCancelarSala = root.Q<Button>("btnCancelarSala");
        btnCrearPartida = root.Q<Button>("btnCrearPartida");
        btnTancarSalaEspera = root.Q<Button>("btnTancarSalaEspera");
        btnConfirmarReady = root.Q<Button>("btnConfirmarReady");
        btnUnirsePartida = root.Q<Button>("btnUnirsePartida");
        btnActualitzarSales = root.Q<Button>("btnActualitzarSales");
        btnAnarSkins = root.Q<Button>("btnAnarSkins");
        btnEquiparSkin = root.Q<Button>("btnEquiparSkin");
        btnTancarInventari = root.Q<Button>("btnTancarInventari");

        // 1.3: Usar -= abans de += per evitar duplicitats
        if (btnReg != null) { btnReg.clicked -= () => RegistrarUsuari(inputNom?.value, inputPass?.value); btnReg.clicked += () => RegistrarUsuari(inputNom?.value, inputPass?.value); }
        if (btnLog != null) { btnLog.clicked -= () => FerLogin(inputNom?.value, inputPass?.value); btnLog.clicked += () => FerLogin(inputNom?.value, inputPass?.value); }
        if (btnTancar != null) { btnTancar.clicked -= () => Application.Quit(); btnTancar.clicked += () => Application.Quit(); }
        
        if (btnTancarLobby != null)
        {
            btnTancarLobby.clicked -= TornarALoginAction;
            btnTancarLobby.clicked += TornarALoginAction;
        }

        if (btnCrearPartida != null) { btnCrearPartida.clicked -= ObrirCrearSalaAction; btnCrearPartida.clicked += ObrirCrearSalaAction; }
        if (btnCancelarSala != null) { btnCancelarSala.clicked -= TancarCrearSalaAction; btnCancelarSala.clicked += TancarCrearSalaAction; }
        if (btnConfirmarSala != null) { btnConfirmarSala.clicked -= CrearNovaSala; btnConfirmarSala.clicked += CrearNovaSala; }
        if (btnActualitzarSales != null) { btnActualitzarSales.clicked -= ObtenirPartidesAction; btnActualitzarSales.clicked += ObtenirPartidesAction; }

        if (btnUnirsePartida != null)
        {
            btnUnirsePartida.clicked -= UnirsePartidaAction;
            btnUnirsePartida.clicked += UnirsePartidaAction;
        }

        if (btnAnarSkins != null) { btnAnarSkins.clicked -= ObrirInventariAction; btnAnarSkins.clicked += ObrirInventariAction; }
        if (btnTancarInventari != null) { btnTancarInventari.clicked -= TancarInventariAction; btnTancarInventari.clicked += TancarInventariAction; }

        if (btnEquiparSkin != null)
        {
            btnEquiparSkin.clicked -= EquiparSkinAction;
            btnEquiparSkin.clicked += EquiparSkinAction;
        }

        if (btnConfirmarReady != null)
        {
            btnConfirmarReady.clicked -= ConfirmarReadyAction;
            btnConfirmarReady.clicked += ConfirmarReadyAction;
        }

        if (btnTancarSalaEspera != null)
        {
            btnTancarSalaEspera.clicked -= TancarSalaEsperaAction;
            btnTancarSalaEspera.clicked += TancarSalaEsperaAction;
        }
    }

    // Wrappers per a les accions per poder desvincular-les correctament si cal, o simplement usar anònimes si es desitja
    private void TornarALoginAction() { if (pantallaLobby != null) pantallaLobby.style.display = DisplayStyle.None; if (pantallaLogin != null) pantallaLogin.style.display = DisplayStyle.Flex; }
    private void ObrirCrearSalaAction() { if (popUpCrearSala != null) popUpCrearSala.style.display = DisplayStyle.Flex; }
    private void TancarCrearSalaAction() { if (popUpCrearSala != null) popUpCrearSala.style.display = DisplayStyle.None; }
    private void ObtenirPartidesAction() { StartCoroutine(ObtenirPartides()); }
    private void UnirsePartidaAction() { if (llistaPartides != null && llistaPartides.selectedItem != null) { GameData selectedGame = llistaPartides.selectedItem as GameData; UnirseAPartida(selectedGame.roomId); } else { Debug.LogWarning("Selecciona una partida primer."); } }
    private void ObrirInventariAction() { if (pantallaInventari != null) pantallaInventari.style.display = DisplayStyle.Flex; }
    private void TancarInventariAction() { if (pantallaInventari != null) pantallaInventari.style.display = DisplayStyle.None; }
    private void EquiparSkinAction() { if (llistaSkins != null && llistaSkins.selectedItem != null) { string skinSelected = llistaSkins.selectedItem as string; EquiparSkin(skinSelected); } }
    private void ConfirmarReadyAction() { if (websocket != null && websocket.State == WebSocketState.Open && currentRoomId != null) { ReadyMessage msg = new ReadyMessage { roomId = currentRoomId, username = userId }; string json = JsonUtility.ToJson(msg); websocket.SendText(json); Debug.Log("Enviant READY per a la sala: " + currentRoomId); } }
    private void TancarSalaEsperaAction()
    {
        if (websocket != null && websocket.State == WebSocketState.Open && currentRoomId != null)
        {
            LeaveRoomMessage msg = new LeaveRoomMessage { roomId = currentRoomId, username = userId };
            string json = JsonUtility.ToJson(msg);
            websocket.SendText(json);
            Debug.Log("Enviant leave_room per a la sala: " + currentRoomId);
        }
        if (pantallaSalaEspera != null) pantallaSalaEspera.style.display = DisplayStyle.None;
        if (pantallaLobby != null) pantallaLobby.style.display = DisplayStyle.Flex;
        currentRoomId = null;
        StartCoroutine(RefrescarLobbyAmbRetard());
    }

    public void EquiparSkin(string skinName)
    {
        SkinUpdateData data = new SkinUpdateData { username = userId, skinName = skinName };
        string json = JsonUtility.ToJson(data);
        StartCoroutine(EnviarPeticioUpdateSkin(json, skinName));
    }

    private IEnumerator EnviarPeticioUpdateSkin(string jsonPayload, string skinName)
    {
        string url = baseUrl + "/users/skin";
        UnityWebRequest request = new UnityWebRequest(url, "PUT");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonPayload);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Skin actualitzada correctament: " + skinName);
            currentSkin = skinName;
            if (labelSkinActual != null) labelSkinActual.text = "EQUIPADA: " + skinName;
        }
        else
        {
            Debug.LogError("Error al actualitzar skin: " + request.error);
        }
    }

    public void UnirseAPartida(string roomId)
    {
        string teamToJoin = "A";
        
        // Auto-balanç: cercar dades de la sala seleccionada per comptar jugadors per equip
        if (llistaPartides != null && llistaPartides.itemsSource != null)
        {
            GameData[] games = llistaPartides.itemsSource as GameData[];
            if (games != null)
            {
                foreach (var game in games)
                {
                    if (game.roomId == roomId)
                    {
                        int countA = 0;
                        int countB = 0;
                        foreach (var p in game.players)
                        {
                            string t = p.team.ToLower();
                            if (t.Contains("1") || t == "a" || t == "rojo" || t == "vermell") countA++;
                            else countB++;
                        }
                        
                        if (countA > countB) teamToJoin = "B";
                        else if (countB > countA) teamToJoin = "A";
                        else teamToJoin = (UnityEngine.Random.value > 0.5f) ? "A" : "B"; // Aleatori si estan empatats
                        
                        Debug.Log($"[MenuManager] Auto-balanç: Equip A={countA}, Equip B={countB}. Assignant a: {teamToJoin}");
                        break;
                    }
                }
            }
        }

        JoinGameData data = new JoinGameData
        {
            roomId = roomId,
            username = userId,
            team = teamToJoin
        };

        string json = JsonUtility.ToJson(data);
        StartCoroutine(EnviarPeticioJoin(json, roomId));
    }

    private IEnumerator EnviarPeticioJoin(string jsonPayload, string roomId)
    {
        string url = baseUrl + "/games/join";
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonPayload);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Unió a sala exitosa: " + request.downloadHandler.text);
            currentRoomId = roomId;
            WebSocketClient.RoomId = roomId;

            if (pantallaLobby != null) pantallaLobby.style.display = DisplayStyle.None;
            if (pantallaSalaEspera != null)
            {
                var labelCodi = pantallaSalaEspera.Q<Label>("codeLabel");
                if (labelCodi != null) labelCodi.text = "CODI: " + currentRoomId;
                pantallaSalaEspera.style.display = DisplayStyle.Flex;
            }

            // Actualització visual immediata de la llista de jugadors
            GameData gameData = JsonUtility.FromJson<GameData>(request.downloadHandler.text);
            currentRoomData = gameData;
            if (gameData != null && gameData.players != null)
            {
                OmplirLlistaJugadors(gameData.players);
            }
        }
        else
        {
            Debug.LogError("Error en unir-se a la sala: " + request.error + " - " + request.downloadHandler.text);
        }
    }

    public void CrearNovaSala()
    {
        if (dropdownEquip1 == null || dropdownEquip2 == null || dropdownJugadors == null) return;

        if (dropdownEquip1.value == dropdownEquip2.value)
        {
            Debug.LogWarning("Els equips han de tenir colors diferents.");
            return;
        }

        int maxPlayers;
        if (!int.TryParse(dropdownJugadors.value, out maxPlayers))
        {
            maxPlayers = 4; // Valor por defecto si falla el parseo
        }

        CreateGameData data = new CreateGameData
        {
            host = userId,
            teamAColor = dropdownEquip1.value,
            teamBColor = dropdownEquip2.value,
            maxPlayers = maxPlayers
        };

        string json = JsonUtility.ToJson(data);
        StartCoroutine(EnviarPeticio("/games/create", json));
    }

    public void RegistrarUsuari(string usuari, string password)
    {
        if (usuari != null) usuari = usuari.Trim();
        if (password != null) password = password.Trim();

        if (string.IsNullOrEmpty(usuari) || string.IsNullOrEmpty(password))
        {
            Debug.LogWarning("[MenuManager] Intent de registre fallit: camps buits.");
            return;
        }

        AuthData data = new AuthData { username = usuari, password = password };
        string json = JsonUtility.ToJson(data);
        Debug.LogWarning($"[MenuManager] Intentant enviar al servidor (Registre): {json}");
        StartCoroutine(EnviarPeticio("/users/register", json));
    }

    public void FerLogin(string usuari, string password)
    {
        if (usuari != null) usuari = usuari.Trim();
        if (password != null) password = password.Trim();

        if (string.IsNullOrEmpty(usuari) || string.IsNullOrEmpty(password))
        {
            Debug.LogWarning("[MenuManager] Intent de login fallit: camps buits.");
            return;
        }

        AuthData data = new AuthData { username = usuari, password = password };
        string json = JsonUtility.ToJson(data);
        Debug.LogWarning($"[MenuManager] Intentant enviar al servidor (Login): {json}");
        StartCoroutine(EnviarPeticio("/users/login", json));
    }

    private IEnumerator ObtenirPartides()
    {
        string url = baseUrl + "/games/list";
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;
            // Hack per a JsonUtility: envoltar l'array en un objecte
            string wrappedJson = "{\"games\":" + json + "}";
            GameListWrapper wrapper = JsonUtility.FromJson<GameListWrapper>(wrappedJson);

            if (wrapper != null && wrapper.games != null)
            {
                ConfigurarLlistaPartides(wrapper.games);
            }
            else
            {
                ConfigurarLlistaPartides(new GameData[0]);
            }
        }
        else
        {
            Debug.LogError("Error al obtenir partides: " + request.error);
            ConfigurarLlistaPartides(new GameData[0]);
        }
    }

    private IEnumerator RefrescarLobbyAmbRetard()
    {
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(ObtenirPartides());
    }

    private void ConfigurarLlistaPartides(GameData[] games)
    {
        if (llistaPartides == null) return;

        // Neteja obligatòria per evitar duplicats
        llistaPartides.itemsSource = null;
        llistaPartides.Rebuild();

        llistaPartides.itemsSource = games;
        llistaPartides.Rebuild();
    }

    private void OmplirLlistaJugadors(PlayerData[] players)
    {
        if (llistaJugadorsSala == null) return;

        // Neteja obligatòria per evitar duplicats
        llistaJugadorsSala.itemsSource = null;
        llistaJugadorsSala.Rebuild();

        llistaJugadorsSala.makeItem = () =>
        {
            Label label = new Label();
            label.style.color = new StyleColor(Color.white);
            return label;
        };

        llistaJugadorsSala.bindItem = (element, i) =>
        {
            if (players == null || i >= players.Length) return;
            var p = players[i];
            (element as Label).text = $"Jugador: {p.username} {(p.isReady ? "(Llest)" : "(Esperant)")}";
        };

        llistaJugadorsSala.itemsSource = players;
    }

    private IEnumerator EnviarPeticio(string endpoint, string jsonPayload)
    {
        string url = baseUrl + endpoint;
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonPayload);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Peticio exitosa: " + request.downloadHandler.text);

            if (endpoint == "/users/login")
            {
                LoginResponse response = JsonUtility.FromJson<LoginResponse>(request.downloadHandler.text);
                if (response != null)
                {
                    userId = response.username; // Guardem el username per utilitzar-lo en els missatges
                    WebSocketClient.LocalUsername = userId; // Sincronitzem amb el WebSocketClient
                    currentSkin = response.skinEquipada;
                    if (labelSkinActual != null) labelSkinActual.text = "EQUIPADA: " + currentSkin;
                    Debug.Log("User username guardat: " + userId);
                }

                // 1.2, 1.3 i 1.4: Forçar canvi de UI i loguejar
                Debug.Log("[MenuManager] Canviant UI a Lobby després de Login exitós");
                ActualitzarVisibilitatSegonsSessio();
                
                // Fallback manual per seguretat
                if (pantallaLogin != null) pantallaLogin.style.display = DisplayStyle.None;
                if (pantallaLobby != null) pantallaLobby.style.display = DisplayStyle.Flex;
            }

            if (endpoint == "/games/create")
            {
                GameData gameData = JsonUtility.FromJson<GameData>(request.downloadHandler.text);
                currentRoomData = gameData;
                if (gameData != null)
                {
                    currentRoomId = gameData.roomId;
                    Debug.Log("Partida creada amb roomId: " + currentRoomId);
                }

                if (popUpCrearSala != null) popUpCrearSala.style.display = DisplayStyle.None;
                if (pantallaLobby != null) pantallaLobby.style.display = DisplayStyle.None;
                if (pantallaSalaEspera != null)
                {
                    pantallaSalaEspera.style.display = DisplayStyle.None;
                    var labelCodi = pantallaSalaEspera.Q<Label>("codeLabel");
                    if (labelCodi != null) labelCodi.text = "CODI: " + currentRoomId;
                    pantallaSalaEspera.style.display = DisplayStyle.Flex;
                }
                
                if (gameData != null && gameData.players != null)
                {
                    OmplirLlistaJugadors(gameData.players);
                }

                StartCoroutine(ObtenirPartides());
            }
        }
        else
        {
            Debug.LogError("Error en la peticio: " + request.error + " - " + request.downloadHandler.text);
        }
    }
}
