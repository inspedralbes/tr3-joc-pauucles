## 1. API Configuration and Authentication Update

- [x] 1.1 Update `baseUrl` to `http://localhost:3000/api` in `MenuManager.cs`.
- [x] 1.2 Modify `RegistrarUsuari` to call `EnviarPeticio("/users/register", json)`.
- [x] 1.3 Modify `FerLogin` to call `EnviarPeticio("/users/login", json)`.

## 2. UI Toolkit Integration for Game Creation

- [x] 2.1 Add private fields for `popUpCrearSala`, `dropdownEquip1`, `dropdownEquip2`, `dropdownJugadors`, `btnConfirmarSala`, `btnTancarPopUp`, and `btnCrearPartida`.
- [x] 2.2 In `OnEnable`, use `root.Q<T>` to find and assign all new UI elements.
- [x] 2.3 Bind `btnCrearPartida.clicked` to show `popUpCrearSala` (`DisplayStyle.Flex`).
- [x] 2.4 Bind `btnTancarPopUp.clicked` to hide `popUpCrearSala` (`DisplayStyle.None`).

## 3. Game Creation Logic Implementation

- [x] 3.1 Define the `[System.Serializable] public class CreateGameData` with fields `teamAColor`, `teamBColor`, and `maxPlayers`.
- [x] 3.2 Implement the `CrearNovaSala()` method to handle the creation flow.
- [x] 3.3 Add validation in `CrearNovaSala()`: if `dropdownEquip1.value == dropdownEquip2.value`, issue `Debug.LogWarning` and return.
- [x] 3.4 Implement payload serialization and call `EnviarPeticio("/games/create", json)` in `CrearNovaSala()`.
- [x] 3.5 Bind `btnConfirmarSala.clicked` to call `CrearNovaSala()`.

## 4. Verification

- [x] 4.1 Verify login and registration still work with the updated endpoints using Unity Console.
- [x] 4.2 Verify the "Crear Partida" button correctly toggles pop-up visibility.
- [x] 4.3 Test validation by selecting identical colors and confirming a warning appears.
- [x] 4.4 Confirm a successful `/games/create` request is sent with correct JSON data.
