## Why

L'script `NetworkSync` falla perquè intenta accedir a una instància de `WebSocketClient` que no és la que realment gestiona la connexió. La connexió WebSocket activa es troba a `MenuManager.cs`, però aquesta es perd en canviar d'escena cap al "Bosque" i no és accessible de forma global.

## What Changes

- **Singleton MenuManager**: Es converteix `MenuManager.cs` en un Singleton i se li afegeix `DontDestroyOnLoad`.
- **WebSocket Públic**: Es fa pública la variable `websocket` a `MenuManager` per permetre l'accés des d'altres scripts.
- **Redirecció de NetworkSync**: Es modifica `NetworkSync.cs` perquè utilitzi `MenuManager.Instance.websocket` per enviar dades de moviment.
- **Handler de Moviment**: Es centralitza la recepció de missatges `PLAYER_MOVE` a `MenuManager.cs` i es connecta amb el `GameManager`.

## Capabilities

### New Capabilities
- `centralized-websocket-management`: Gestió centralitzada i persistent de la connexió WebSocket a través de múltiples escenes d'Unity.

### Modified Capabilities
- `multiplayer-sync`: Es modifica la forma en què els missatges de moviment són enviats i rebuts per utilitzar el nou gestor centralitzat.

## Impact

- `MenuManager.cs`: Canvis estructurals (Singleton, persistència) i de lògica de recepció.
- `NetworkSync.cs`: Canvi en la referència de la connexió.
- `WebSocketClient.cs`: Aquest script podria quedar obsolet o ser refactoritzat per ser integrat completament a `MenuManager`.
