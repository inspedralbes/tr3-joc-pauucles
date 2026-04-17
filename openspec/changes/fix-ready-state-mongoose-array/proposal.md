## Why

Actualment, el backend no està persistent correctament l'estat `isReady` dels jugadors dins de l'array de jugadors d'una sala quan es reben els missatges de tipus `READY` via WebSocket. Això és degut a limitacions en com Mongoose detecta canvis interns en els arrays. Aquest problema impedeix que la lògica d'inici de partida s'executi, ja que mai es detecta que tots els jugadors estan llestos.

## What Changes

- **Sincronització Atòmica de READY**: S'utilitzarà `findOneAndUpdate` amb l'operador posicional `$` per forçar l'actualització atòmica de l'estat `isReady` a MongoDB.
- **Validació de Persistència**: S'afegiran logs per verificar que el document retornat per la base de dades conté les dades correctes abans de fer cap broadcast.
- **Sincronització de Sala**: El broadcast `ROOM_UPDATED` es realitzarà utilitzant el document fresc retornat de la base de dades.
- **Inici de Partida Robust**: La lògica d'inici (`checkGameStart`) es basarà en el document actualitzat per assegurar que només s'inicia quan la sala està plena i tots els jugadors tenen `isReady: true`.

## Capabilities

### New Capabilities
- `atomic-player-state-update`: Garanteix actualitzacions consistents i atòmiques de l'estat dels jugadors dins d'una sala.

### Modified Capabilities
- Cap (és una correcció tècnica sobre la infraestructura existent).

## Impact

- **Backend**: Canvis en la gestió d'esdeveniments de `server.js` o el mètode de servei corresponent.
- **Database**: S'assegura que MongoDB reflecteix l'estat real dels jugadors.
- **UX**: Els jugadors veuran el seu estat actualitzat al lobby i la partida començarà automàticament sense retards ni errors de sincronització.
