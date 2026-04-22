using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using NativeWebSocket;

public class WebSocketClient : MonoBehaviour
{
    public static WebSocketClient Instance;

    public static string Username;
    public static string Team;
    public static string ColorName;
    public static string LocalUsername;
    public static string RoomId;

    private WebSocket websocket;
    private string serverUrl = "ws://204.168.215.211/api/";

    // Cua d'execució per al fil principal
    private readonly Queue<Action> _executionQueue = new Queue<Action>();

    public void EnqueueMainThread(Action action)
    {
        lock (_executionQueue)
        {
            _executionQueue.Enqueue(action);
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // DESACTIVADO PARA EVITAR CUELGUES (DEADLOCKS) DEL EDITOR.
        // La conexión real ya se gestiona en MenuManager.cs.
        // Si pruebas la escena Bosque directamente, no intentará conectar 
        // y podrás moverte y probar sin que explote Unity.
    }

    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        if (websocket != null)
        {
            websocket.DispatchMessageQueue();
        }
#endif

        lock (_executionQueue)
        {
            while (_executionQueue.Count > 0)
            {
                _executionQueue.Dequeue().Invoke();
            }
        }
    }

    public async void SendText(string text)
    {
        if (websocket != null && websocket.State == WebSocketState.Open)
        {
            await websocket.SendText(text);
        }
    }

    public bool IsConnected()
    {
        return websocket != null && websocket.State == WebSocketState.Open;
    }

    private void ProcessMessage(string json)
    {
        // TOTA la lògica de Lobby i Moviment s'ha mogut a MenuManager.cs
        // per garantir la sincronització amb la UI i el fil principal.
        // Aquest script només manté la connexió base si fos necessari, 
        // però actualment el MenuManager gestiona el seu propi socket.
        
        /*
        try
        {
            if (json.Contains("\"type\":\"PLAYER_MOVE\"")) { ... }
            ...
        }
        catch (Exception e) { ... }
        */
    }

    public async void Disconnect()
    {
        if (websocket != null)
        {
            await websocket.Close();
            Debug.Log("[WebSocketClient] Connexió tancada manualment.");
        }
    }

    private async void OnApplicationQuit()
    {
        if (websocket != null)
        {
            await websocket.Close();
        }
    }
}

[Serializable]
public class PartidaIniciadaMessage
{
    public string type;
    public string username;
    public string team;
    public string color;
    public string roomId;
}
