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
    private VisualElement pantallaLogin;
    private VisualElement pantallaLobby;
    private VisualElement pantallaSalaEspera;
    private ListView llistaPartides;
    private ListView llistaJugadorsSala;
    private string baseUrl = "http://localhost:3000/api";
    private string userId;
    private string currentRoomId;
    private WebSocket websocket;

    // Cua d'execució per al fil principal
    private readonly Queue<Action> _executionQueue = new Queue<Action>();

    public void EnqueueMainThread(Action action)
    {
        lock (_executionQueue)
        {
            _executionQueue.Enqueue(action);
        }
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
    }

    private void AlRebreActualitzacioSales(string dadesJSON)
    {
        try
        {
            // Intentem processar com a llista de sales primer
            RoomListMessage listMsg = JsonUtility.FromJson<RoomListMessage>(dadesJSON);
            if (listMsg != null && listMsg.type == "ACTUALITZAR_SALES")
            {
                EnqueueMainThread(() =>
                {
                    ConfigurarLlistaPartides(listMsg.sales);
                    Debug.Log("Llista de sales actualitzada per WebSocket");
                });
                return;
            }

            // Intentem processar com a actualització de sala específica
            RoomUpdateMessage updateMsg = JsonUtility.FromJson<RoomUpdateMessage>(dadesJSON);
            if (updateMsg != null && updateMsg.type == "ROOM_UPDATED")
            {
                if (updateMsg.room != null && updateMsg.room.roomId == currentRoomId)
                {
                    EnqueueMainThread(() =>
                    {
                        OmplirLlistaJugadors(updateMsg.room.players);
                        Debug.Log("Llista de jugadors actualitzada per ROOM_UPDATED");
                    });
                }
                return;
            }

            // Intentem processar PARTIDA_INICIADA
            if (dadesJSON.Contains("PARTIDA_INICIADA"))
            {
                PartidaIniciadaMsg msg = JsonUtility.FromJson<PartidaIniciadaMsg>(dadesJSON);
                if (msg != null && msg.type == "PARTIDA_INICIADA")
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
                            var root = GetComponent<UIDocument>().rootVisualElement;
                            if (root != null) root.style.display = DisplayStyle.None;
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
            Debug.LogError("Error en processar missatge WebSocket: " + e.Message);
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
    public class PartidaIniciadaMsg
    {
        public string type;
        public string username;
        public string team;
        public string color;
    }

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        pantallaLogin = root.Q<VisualElement>("pantallaLogin");
        pantallaLobby = root.Q<VisualElement>("pantallaLobby");
        pantallaSalaEspera = root.Q<VisualElement>("pantallaSalaEspera");
        llistaPartides = root.Q<ListView>("llistaPartides");
        llistaJugadorsSala = root.Q<ListView>("llistaJugadorsSala");

        if (pantallaSalaEspera != null)
        {
            pantallaSalaEspera.style.display = DisplayStyle.None;
        }

        if (llistaPartides != null)
        {
            llistaPartides.makeItem = () => new Label();
            llistaPartides.bindItem = (element, i) =>
            {
                var game = llistaPartides.itemsSource[i] as GameData;
                (element as Label).text = $"Sala: {game.roomId} - Jugadors: {game.players.Length}/{game.maxPlayers}";
            };
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

        if (btnReg != null)
        {
            btnReg.clicked += () => RegistrarUsuari(inputNom.value, inputPass.value);
        }

        if (btnLog != null)
        {
            btnLog.clicked += () => FerLogin(inputNom.value, inputPass.value);
        }

        if (btnTancar != null)
        {
            btnTancar.clicked += () => Application.Quit();
        }

        if (btnTancarLobby != null)
        {
            btnTancarLobby.clicked += () =>
            {
                pantallaLobby.style.display = DisplayStyle.None;
                pantallaLogin.style.display = DisplayStyle.Flex;
            };
        }

        if (btnCrearPartida != null)
        {
            btnCrearPartida.clicked += () => popUpCrearSala.style.display = DisplayStyle.Flex;
        }

        if (btnCancelarSala != null)
        {
            btnCancelarSala.clicked += () => popUpCrearSala.style.display = DisplayStyle.None;
        }

        if (btnConfirmarSala != null)
        {
            btnConfirmarSala.clicked += () => CrearNovaSala();
        }

        if (btnActualitzarSales != null)
        {
            btnActualitzarSales.clicked += () => StartCoroutine(ObtenirPartides());
        }

        if (btnUnirsePartida != null)
        {
            btnUnirsePartida.clicked += () =>
            {
                if (llistaPartides.selectedItem != null)
                {
                    GameData selectedGame = llistaPartides.selectedItem as GameData;
                    UnirseAPartida(selectedGame.roomId);
                }
                else
                {
                    Debug.LogWarning("Selecciona una partida primer.");
                }
            };
        }

        if (btnConfirmarReady != null)
        {
            btnConfirmarReady.clicked += () =>
            {
                if (websocket != null && websocket.State == WebSocketState.Open && currentRoomId != null)
                {
                    ReadyMessage msg = new ReadyMessage
                    {
                        roomId = currentRoomId,
                        username = userId
                    };
                    string json = JsonUtility.ToJson(msg);
                    websocket.SendText(json);
                    Debug.Log("Enviant READY per a la sala: " + currentRoomId);
                }
            };
        }

        if (btnTancarSalaEspera != null)
        {
            btnTancarSalaEspera.clicked += () =>
            {
                // Notificar al servidor que el jugador abandona la sala
                if (websocket != null && websocket.State == WebSocketState.Open && currentRoomId != null)
                {
                    LeaveRoomMessage msg = new LeaveRoomMessage
                    {
                        roomId = currentRoomId,
                        username = userId
                    };
                    string json = JsonUtility.ToJson(msg);
                    websocket.SendText(json);
                    Debug.Log("Enviant leave_room per a la sala: " + currentRoomId);
                }

                pantallaSalaEspera.style.display = DisplayStyle.None;
                pantallaLobby.style.display = DisplayStyle.Flex;
                currentRoomId = null;
                StartCoroutine(RefrescarLobbyAmbRetard());
            };
        }
    }

    public void UnirseAPartida(string roomId)
    {
        JoinGameData data = new JoinGameData
        {
            roomId = roomId,
            username = userId,
            team = "Espectador" // O qualsevol valor per defecte, el backend de vegades ho requereix
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

            pantallaLobby.style.display = DisplayStyle.None;
            if (pantallaSalaEspera != null)
            {
                var labelCodi = pantallaSalaEspera.Q<Label>("codeLabel");
                if (labelCodi != null) labelCodi.text = "CODI: " + currentRoomId;
                pantallaSalaEspera.style.display = DisplayStyle.Flex;
            }

            // Actualització visual immediata de la llista de jugadors
            GameData gameData = JsonUtility.FromJson<GameData>(request.downloadHandler.text);
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
        AuthData data = new AuthData { username = usuari, password = password };
        string json = JsonUtility.ToJson(data);
        StartCoroutine(EnviarPeticio("/users/register", json));
    }

    public void FerLogin(string usuari, string password)
    {
        AuthData data = new AuthData { username = usuari, password = password };
        string json = JsonUtility.ToJson(data);
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
                    Debug.Log("User username guardat: " + userId);
                }

                pantallaLogin.style.display = DisplayStyle.None;
                pantallaLobby.style.display = DisplayStyle.Flex;
                StartCoroutine(ObtenirPartides());
            }

            if (endpoint == "/games/create")
            {
                GameData gameData = JsonUtility.FromJson<GameData>(request.downloadHandler.text);
                if (gameData != null)
                {
                    currentRoomId = gameData.roomId;
                    Debug.Log("Partida creada amb roomId: " + currentRoomId);
                }

                popUpCrearSala.style.display = DisplayStyle.None;
                pantallaLobby.style.display = DisplayStyle.None;
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
