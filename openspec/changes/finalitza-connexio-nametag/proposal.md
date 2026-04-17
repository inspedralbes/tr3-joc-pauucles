## Why

Actualment, el lobby no permet confirmar l'estat dels jugadors ni realitza la transició automàtica a la partida amb la identitat correcta (nom, equip, color). Aquest canvi tanca el cicle de connexió i assegura que cada jugador estigui correctament identificat visualment dins de l'escena de joc.

## What Changes

- **Vinculació del botó LLEST**: A `MenuManager.cs`, el botó `#btnConfirmarReady` enviarà el missatge "READY" per WebSocket.
- **Gestió de l'inici de partida**: `WebSocketClient.cs` processarà "PARTIDA_INICIADA", guardarà `username`, `team` i `color` en variables estàtiques i carregarà l'escena "Bosque".
- **Implementació del Nametag**: Nou script `Nametag.cs` per al Canvas del jugador que mostrarà el nom amb el color assignat (traduït de text a `Color` de Unity) i mantindrà la rotació fixa (`Quaternion.identity`).
- **Integració al Jugador**: `Player.cs` configurarà el seu Nametag al `Start` utilitzant les dades estàtiques guardades.

## Capabilities

### New Capabilities
- `game-transition-and-identity`: Gestiona la transició del lobby al joc quan la partida comença i la visualització de la identitat del jugador (nom i color) mitjançant un Nametag.

### Modified Capabilities
- Cap (no hi ha requeriments de negoci existents que canviïn, es tracta d'una implementació tècnica nova).

## Impact

- **Codi**: `MenuManager.cs`, `WebSocketClient.cs`, `Player.cs` i nou fitxer `Nametag.cs`.
- **Assets**: Prefab del jugador (Woodcutter) i l'escena "Bosque".
- **Flux**: Transició automàtica de l'escena de Lobby a l'escena de Joc.
