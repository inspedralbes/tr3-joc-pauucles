## Why

Actualment, el joc s'inicia amb dades genèriques per als jugadors. Per oferir una experiència més personalitzada i integrada amb la Sala d'Espera (Waiting Room), cal un sistema que rebi les dades reals de la sessió (nom d'usuari i equip) mitjançant una connexió WebSocket i les apliqui als personatges del joc.

## What Changes

- **Nou script `WebSocketClient.cs`**: Implementació d'un client WebSocket que connecta amb el servidor local.
- **Sincronització de sessió**: Recepció de missatges d'inici de partida amb les dades del jugador (username, team).
- **Integració amb el jugador**: Crida al nou mètode d'inicialització del personatge per configurar la seva identitat visual (Nametag) i lògica (Equip).
- **Actualització de `Player.cs`**: Addició del mètode `InicialitzarJugador` per rebre i aplicar les dades de sessió.

## Capabilities

### New Capabilities
- `websocket-communication`: Capacitat de connectar-se a un servidor WebSocket i processar missatges JSON asíncronament.

### Modified Capabilities
- `player-initialization`: Actualització de la capacitat d'inicialització per incloure dades externes de sessió.

## Impact

- `WebSocketClient.cs`: Nou script que gestiona la comunicació.
- `Player.cs`: Addició del mètode `InicialitzarJugador`.
- Nametag UI: Ara mostrarà el nom d'usuari real rebut del servidor.
- Unity Project: Caldrà assegurar-se que el servidor WebSocket estigui actiu a `ws://localhost:3000`.
