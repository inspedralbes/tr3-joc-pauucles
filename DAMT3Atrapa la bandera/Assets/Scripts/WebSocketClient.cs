using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class WebSocketClient : MonoBehaviour
{
    public static string Username;
    public static string Team;
    public static string ColorName;
    public static string LocalUsername;

    private ClientWebSocket ws = new ClientWebSocket();
    private CancellationTokenSource cts = new CancellationTokenSource();
    private string serverUrl = "ws://localhost:3000";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private string pendingUsername;
    private string pendingTeam;
    private bool hasPendingData = false;
    private bool shouldStartGame = false;

    async void Start()
    {
        try
        {
            await ws.ConnectAsync(new Uri(serverUrl), cts.Token);
            Debug.Log("Connexió WebSocket establerta amb " + serverUrl);
            _ = ReceiveLoop();
        }
        catch (Exception e)
        {
            Debug.LogError("Error en connectar WebSocket: " + e.Message);
        }
    }

    private async Task ReceiveLoop()
    {
        byte[] buffer = new byte[1024 * 4];
        while (ws.State == WebSocketState.Open)
        {
            var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), cts.Token);
            if (result.MessageType == WebSocketMessageType.Close)
            {
                await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, cts.Token);
            }
            else
            {
                string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                ProcessMessage(message);
            }
        }
    }

    private void ProcessMessage(string json)
    {
        try
        {
            // Intentem processar PARTIDA_INICIADA primer
            PartidaIniciadaMessage startMsg = JsonUtility.FromJson<PartidaIniciadaMessage>(json);
            if (startMsg != null && startMsg.type == "PARTIDA_INICIADA")
            {
                // Només processem si el missatge és per a nosaltres
                if (startMsg.username == LocalUsername)
                {
                    Debug.Log("Iniciant partida per WebSocket!");
                    Username = startMsg.username;
                    Team = startMsg.team;
                    ColorName = startMsg.color;
                    shouldStartGame = true;
                    Debug.Log($"La meva partida ha començat! Equip: {Team}, Color: {ColorName}");
                }
                return;
            }

            GameStartMessage msg = JsonUtility.FromJson<GameStartMessage>(json);
            if (msg != null && msg.type == "game_start")
            {
                pendingUsername = msg.username;
                pendingTeam = msg.team;
                hasPendingData = true;
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning("Error processant missatge JSON: " + e.Message);
        }
    }

    void Update()
    {
        if (shouldStartGame)
        {
            shouldStartGame = false;
            SceneManager.LoadScene("Bosque");
        }

        if (hasPendingData)
        {
            hasPendingData = false;
            InicialitzarJugadorReal();
        }
    }

    private void InicialitzarJugadorReal()
    {
        Player player = UnityEngine.Object.FindFirstObjectByType<Player>();
        if (player != null)
        {
            player.InicialitzarJugador(pendingUsername, pendingTeam);
            Debug.Log($"Jugador inicialitzat des de WebSocket: {pendingUsername} ({pendingTeam})");
        }
        else
        {
            Debug.LogWarning("No s'ha trobat el component Player per inicialitzar.");
        }
    }

    private async void OnDestroy()
    {
        cts.Cancel();
        if (ws != null && ws.State == WebSocketState.Open)
        {
            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "App tancada", CancellationToken.None);
        }
        if (ws != null) ws.Dispose();
    }
}

[Serializable]
public class GameStartMessage
{
    public string type;
    public string username;
    public string team;
}

[Serializable]
public class PartidaIniciadaMessage
{
    public string type;
    public string username;
    public string team;
    public string color;
}
