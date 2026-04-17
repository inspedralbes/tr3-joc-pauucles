## Why

Actualment, el sistema de lobby permet que sales que ja han començat segueixin apareixent a la llista global, i la gestió de sortides no diferencia correctament entre el host i els convidats, cosa que pot deixar sales "òrfenes" o eliminar-les prematurament. A més, falta tancar el cicle de comunicació perquè tots els clients s'assabentin de l'inici de la partida i carreguin l'escena corresponent de forma sincronitzada.

## What Changes

- **Filtratge de Sales (Backend)**: El missatge `ACTUALITZAR_SALES` (o `room_list`) només enviarà sales amb estat `waiting`.
- **Regles de Sortida (Backend)**: En rebre `LEAVE_ROOM` o en desconnectar-se, el servidor només eliminarà la sala si qui marxa és el `host`. Si marxa un convidat, s'utilitzarà l'operador `$pull` per treure'l de l'array `players`.
- **Flux d'Inici (Backend)**: Quan tots els jugadors d'una sala plena estiguin `isReady: true`, l'estat canviarà a `playing` i s'enviarà un missatge individualitzat `PARTIDA_INICIADA` amb les dades d'identitat (nom, equip, color).
- **Integració Unity (Frontend)**: 
    - `WebSocketClient.cs` processarà `PARTIDA_INICIADA` per guardar dades i carregar l'escena "Bosque".
    - `MenuManager.cs` amagarà la interfície d'usuari en rebre la confirmació d'inici per evitar interferències visuals durant la càrrega.

## Capabilities

### New Capabilities
- `room-lifecycle-rules`: Defineix les condicions de permanència i eliminació de sales segons el rol del jugador (host vs convidat).
- `synchronized-game-transition`: Garanteix que tots els clients d'una sala comencin la partida simultàniament en rebre el senyal del servidor.

### Modified Capabilities
- Cap (refinament tècnic del sistema de sales existent).

## Impact

- **Backend**: Canvis a `GameService.js` i `server.js` per a la lògica de filtratge i eliminació selectiva.
- **Frontend**: `WebSocketClient.cs` i `MenuManager.cs` per a la transició d'escena i gestió de la UI.
- **Base de Dades**: Millor integritat de la col·lecció de sales al MongoDB.
