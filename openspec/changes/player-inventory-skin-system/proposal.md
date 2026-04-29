## Why

Actualment tots els jugadors utilitzen el mateix aspecte visual (skin) per defecte. Per millorar la personalització i el compromís del jugador, és necessari un sistema d'inventari on els usuaris puguin triar i equipar diferents aspectes que es reflecteixin tant en el lobby com durant la partida multijugador.

## What Changes

- **Backend (Persistència)**:
    - Actualització del model `User` per incloure la skin equipada.
    - Nou endpoint API per actualitzar la skin de l'usuari.
- **Frontend (Lobby/Menú)**:
    - Integració del botó "INVENTARI" a la UI Toolkit.
    - Implementació d'un panell de selecció de skins amb vista prèvia o llista d'opcions.
    - Sincronització de la selecció amb el backend.
- **Frontend (Partida)**:
    - Lògica d'instanciació de jugadors basada en la skin seleccionada (local i remots).
    - Mapeig de noms de skin a Prefabs d'Unity al `GameManager`.

## Capabilities

### New Capabilities
- `player-skin-selection`: Permet a l'usuari triar i guardar el seu aspecte visual preferit.
- `dynamic-player-instantiation`: Sistema per spawnear el prefab correcte basant-se en l'estat de l'usuari des del backend.

### Modified Capabilities
- `user-profile`: S'amplia per gestionar la skin equipada.

## Impact

- `backend/src/models/User.js`: Nou camp `skinEquipada`.
- `backend/src/routes/userRoutes.js` & `UserController.js`: Nou endpoint `PUT /api/users/skin`.
- `MenuManager.cs`: Gestió de la UI d'inventari i crides API.
- `GameManager.cs`: Substitució del prefab únic per una col·lecció de prefabs de skin.
- `NetworkSync.cs`: S'ha d'assegurar que la skin es transmet o es coneix per tots els clients.
