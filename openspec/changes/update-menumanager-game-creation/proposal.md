## Why

The `MenuManager` needs to be updated to support game room creation and use the corrected API base URL and endpoints. This change enables players to configure and launch new game sessions from the lobby UI.

## What Changes

- **Update API Configuration**: Change `baseUrl` to `http://localhost:3000/api` and update registration/login endpoints to `/users/register` and `/users/login`.
- **UI Toolkit Integration**: Add references and initialization for new UI elements: `popUpCrearSala`, `dropdownEquip1`, `dropdownEquip2`, `dropdownJugadors`, `btnConfirmarSala`, `btnTancarPopUp`, and `btnCrearPartida`.
- **Game Creation Logic**:
    - Implement a `CreateGameData` serializable class to hold game configuration.
    - Add logic to show/hide the game creation pop-up.
    - Implement `CrearNovaSala()` to validate team selection and send a creation request to `/games/create`.

## Capabilities

### New Capabilities
- `game-room-management`: Management of game rooms, including creation, configuration (teams, player limits), and API integration for persistence.

### Modified Capabilities
<!-- No existing capabilities are being modified as the current specs focus on minigame logic. -->

## Impact

- **Affected Code**: `MenuManager.cs` will be significantly expanded with new UI references and logic.
- **API**: New reliance on `/games/create` endpoint.
- **UI**: The UI Document must contain the specified elements (`popUpCrearSala`, etc.) for the script to function.
