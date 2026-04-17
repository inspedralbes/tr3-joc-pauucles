## Why

Actualment, quan un jugador crea una sala nova, la resta de jugadors que es troben al 'LOBBY' no reben cap notificació i han de refrescar manualment (o esperar a un interval) per veure la nova sala disponible. Això perjudica l'experiència d'usuari i la rapidesa per començar partides.

## What Changes

- **Backend (Node.js)**: Al mètode de creació de partides (GameController.js), s'afegirà un broadcast per WebSocket immediatament després d'un `save` exitós a MongoDB.
- **Broadcast**: El missatge serà de tipus `ACTUALITZAR_SALES` i contindrà la llista actualitzada de totes les sales amb status `waiting`.
- **Frontend (Unity)**: Els clients que ja escolten aquest missatge veuran la llista actualitzada de forma reactiva.

## Capabilities

### New Capabilities
- `realtime-room-discovery`: Permet que els jugadors al lobby descobreixin noves sales de joc de forma immediata mitjançant actualitzacions per WebSockets.

### Modified Capabilities
- Cap.

## Impact

- **Backend**: `GameController.js` o el servei de gestió de partides.
- **Frontend**: El lobby de Unity respondrà de forma immediata a la creació de sales per part d'altres usuaris.
- **WebSocket**: S'incrementa lleugerament el trànsit de missatges broadcast per assegurar la consistència del lobby.
