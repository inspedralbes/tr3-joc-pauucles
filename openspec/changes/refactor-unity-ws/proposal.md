## Why

Després de refactoritzar el backend per utilitzar WebSockets purs (`ws`), és necessari actualitzar el client Unity per mantenir la compatibilitat. La llibreria anterior de SocketIO ja no és compatible amb el nou protocol de comunicació del servidor.

## What Changes

- Substitució de la llibreria `com.itisnajim.socketiounity` per `NativeWebSocket` al `manifest.json`.
- Refactorització de `MenuManager.cs` per eliminar la dependència de SocketIO i utilitzar `NativeWebSocket`.
- Canvi de la lògica de connexió per utilitzar el protocol WebSocket pur (`ws://`).
- **BREAKING**: Qualsevol funcionalitat que depengui estrictament de l'abstracció d'esdeveniments de SocketIO al client s'haurà de reimplementar o adaptar al flux de missatges de `NativeWebSocket`.

## Capabilities

### New Capabilities
- `unity-native-websocket-integration`: Integració i gestió de la comunicació per WebSockets purs dins de l'entorn Unity utilitzant `NativeWebSocket`.

### Modified Capabilities
- Cap (La lògica de negoci del joc es manté, només canvia el transport de dades).

## Impact

- `DAMT3Atrapa la bandera/Packages/manifest.json`: Canvi de dependències del projecte Unity.
- `DAMT3Atrapa la bandera/Assets/Scripts/MenuManager.cs`: Refactorització completa de la capa de comunicació.
- Flux de dades en temps real: Caldrà assegurar que la cua de missatges es processi correctament al `Update()` de Unity.
