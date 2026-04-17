## Why

L'actual implementació de l'esdeveniment `READY` al servidor Node.js és inestable o incompleta, el que provoca que els canvis d'estat dels jugadors no es persisteixin correctament a MongoDB o no es notifiquin a temps a la resta de clients. Això impedeix que la partida s'iniciï de forma automàtica quan tots els jugadors estan preparats.

## What Changes

- **Sincronització de READY**: El servidor buscarà la sala i el jugador a MongoDB, actualitzarà `isReady: true` i realitzarà un `await room.save()` immediat per garantir la persistència.
- **Broadcast de Sala**: Després de guardar, s'emetrà un missatge `ROOM_UPDATED` a tots els clients perquè Unity actualitzi visualment l'estat dels jugadors.
- **Detecció d'Inici de Partida**: El servidor verificarà si la sala està plena i tots els jugadors estan llestos.
- **Transició a Partida**: Si es compleixen les condicions, l'status de la sala canviarà a `playing`, es tornarà a guardar, i s'emetrà un broadcast `PARTIDA_INICIADA` amb la configuració de cada jugador (nom, equip i color).

## Capabilities

### New Capabilities
- `reliable-ready-sync`: Garanteix que l'estat de preparació dels jugadors es gestioni de forma atòmica i persistent al backend.
- `automated-game-start`: Implementa el disparador automàtic per començar la partida basat en el consens dels jugadors a la sala.

### Modified Capabilities
- Cap.

## Impact

- **Backend**: Canvis a `server.js` i/o controladors de WebSocket per gestionar la seqüència de READY i inici.
- **Database**: Actualització en temps real de l'estat dels documents a MongoDB.
- **Frontend**: Unity rebrà dades fiables per carregar l'escena 'Bosque'.
