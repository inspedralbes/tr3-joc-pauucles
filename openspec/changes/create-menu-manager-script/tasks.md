## 1. Setup and Initialization

- [x] 1.1 Create the file `DAMT3Atrapa la bandera/Assets/Scripts/MenuManager.cs`.
- [x] 1.2 Implement the `OnEnable()` method and query the root VisualElement from `UIDocument`.
- [x] 1.3 Find and store references to `pantallaLogin`, `pantallaLobby`, `inputNomJugador`, `inputPassword`, `llistaPartides`.
- [x] 1.4 Add null checks for all critical UI elements and log warnings if missing.

## 2. Login Logic Implementation

- [x] 2.1 Find the `btnLogin` button and register a click event.
- [x] 2.2 In the click callback, check if `inputNomJugador` value is not empty.
- [x] 2.3 If valid, save the name to `PlayerPrefs` with the key `nomJugador`.
- [x] 2.4 If valid, hide `pantallaLogin` and show `pantallaLobby` using `style.display`.

## 3. Lobby Logic Implementation

- [x] 3.1 Find the `btnTancarLobby` button and register a click event.
- [x] 3.2 In the click callback, hide `pantallaLobby` and show `pantallaLogin`.
- [x] 3.3 Find the `btnCrearPartida` button and log "Botó Crear Partida detectat!" to the console on click.
- [x] 3.4 Find the `btnUnirsePartida` button and log "Botó Unirse Partida detectat!" to the console on click.

## 4. Verification

- [x] 4.1 Verify by entering a name, clicking login, and checking if the lobby screen appears.
- [x] 4.2 Verify if the name is persisted in `PlayerPrefs` after login.
- [x] 4.3 Verify that clicking "Tancar Lobby" returns the user to the login screen.
- [x] 4.4 Verify that "Crear" and "Unir-se" buttons produce the expected logs in the Unity console.
