## Why

Actualment, l'inici de la partida no garanteix que tots els clients rebin la informació necessària per transicionar a l'escena de joc ('Bosque') amb la seva identitat correctament configurada (equip i color). Aquest canvi tanca el cicle de sincronització entre el servidor Node.js i el client Unity per assegurar un començament de partida robust i coherent.

## What Changes

- **Backend (WebSockets)**: Implementació de l'enviament del missatge `PARTIDA_INICIADA` quan es detecta que tots els jugadors estan llestos i l'estat de la sala passa a `playing`.
- **Sincronització de Dades**: El servidor enviarà a cada client un missatge personalitzat que inclou exactament els camps `username`, `team` i `color` (derivat de `teamAColor` o `teamBColor`).
- **Frontend (Unity - WebSocketClient.cs)**: Actualització de la lògica de recepció per processar `PARTIDA_INICIADA`, emmagatzemar les dades del jugador i disparar la càrrega de l'escena de forma segura des del fil principal.

## Capabilities

### New Capabilities
- `game-start-synchronization`: Gestiona la notificació d'inici de partida des del servidor cap a tots els clients, assegurant que cada jugador rep la seva configuració d'equip i color.

### Modified Capabilities
- Cap.

## Impact

- **Backend**: `GameController.js` i la gestió de missatges a `server.js`.
- **Frontend**: `WebSocketClient.cs` a Unity.
- **Flux de Joc**: Pas automatitzat del Lobby a l'escena 'Bosque'.
