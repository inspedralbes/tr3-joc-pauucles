using UnityEngine;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    private VisualElement pantallaLogin;
    private VisualElement pantallaLobby;
    private TextField inputNomJugador;
    private TextField inputPassword;
    private ListView llistaPartides;

    private Button btnLogin;
    private Button btnCrearPartida;
    private Button btnUnirsePartida;
    private Button btnTancarLobby;

    private void OnEnable()
    {
        UIDocument uiDoc = GetComponent<UIDocument>();
        if (uiDoc == null)
        {
            Debug.LogError("UIDocument component not found on the GameObject!");
            return;
        }

        VisualElement root = uiDoc.rootVisualElement;

        // Find Screen Containers
        pantallaLogin = root.Q<VisualElement>("pantallaLogin");
        pantallaLobby = root.Q<VisualElement>("pantallaLobby");

        // Find Input Fields
        inputNomJugador = root.Q<TextField>("inputNomJugador");
        inputPassword = root.Q<TextField>("inputPassword");

        // Find Buttons
        btnLogin = root.Q<Button>("btnLogin");
        btnCrearPartida = root.Q<Button>("btnCrearPartida");
        btnUnirsePartida = root.Q<Button>("btnUnirsePartida");
        btnTancarLobby = root.Q<Button>("btnTancarLobby");

        // Find ListView
        llistaPartides = root.Q<ListView>("llistaPartides");

        // Null Checks and Callbacks
        if (btnLogin != null)
        {
            btnLogin.clicked += OnLoginClicked;
        }
        else Debug.LogWarning("btnLogin not found!");

        if (btnTancarLobby != null)
        {
            btnTancarLobby.clicked += OnTancarLobbyClicked;
        }
        else Debug.LogWarning("btnTancarLobby not found!");

        if (btnCrearPartida != null)
        {
            btnCrearPartida.clicked += () => Debug.Log("Iniciant creació de sala...");
        }
        else Debug.LogWarning("btnCrearPartida not found!");

        if (btnUnirsePartida != null)
        {
            btnUnirsePartida.clicked += () => Debug.Log("Intentant unir-se a la sala seleccionada...");
        }
        else Debug.LogWarning("btnUnirsePartida not found!");

        if (pantallaLogin == null) Debug.LogWarning("pantallaLogin not found!");
        if (pantallaLobby == null) Debug.LogWarning("pantallaLobby not found!");
        if (inputNomJugador == null) Debug.LogWarning("inputNomJugador not found!");
    }

    private void OnLoginClicked()
    {
        if (inputNomJugador != null && !string.IsNullOrEmpty(inputNomJugador.value))
        {
            // Save name to PlayerPrefs
            PlayerPrefs.SetString("nomJugador", inputNomJugador.value);
            PlayerPrefs.Save();

            // Transition to Lobby
            if (pantallaLogin != null) pantallaLogin.style.display = DisplayStyle.None;
            if (pantallaLobby != null) pantallaLobby.style.display = DisplayStyle.Flex;
        }
        else
        {
            Debug.LogWarning("Input nom jugador is empty!");
        }
    }

    private void OnTancarLobbyClicked()
    {
        // Transition back to Login
        if (pantallaLobby != null) pantallaLobby.style.display = DisplayStyle.None;
        if (pantallaLogin != null) pantallaLogin.style.display = DisplayStyle.Flex;
    }
}
