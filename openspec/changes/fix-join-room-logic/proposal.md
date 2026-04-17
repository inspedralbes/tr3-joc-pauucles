## Why

Actualment, la lògica per unir-se a una sala de joc no està completament sincronitzada entre el client d'Unity i el servidor de backend. El servidor no notifica a tots els jugadors quan algú s'uneix, i el client d'Unity no utilitza la petició HTTP correcta per registrar la unió a la base de dades, el que impedeix que el lobby mostri dades reals i actualitzades.

## What Changes

- **Backend (Node.js)**: S'ha de modificar el mètode `join` a `GameController.js` per cridar a `broadcastRoomUpdates()` després d'afegir un jugador, assegurant que tots els clients rebin l'actualització de la sala (per exemple, 2/2 jugadors).
- **Client (Unity)**: S'ha d'implementar una petició HTTP POST a `/api/games/join` al `MenuManager.cs` quan un jugador tria una sala per apuntar-se.
- **Client (Unity)**: Actualització visual immediata de la `llistaJugadorsSala` quan la unió és exitosa, afegint el nom del nou jugador a la llista.

## Capabilities

### New Capabilities
- `room-joining-logic`: Gestiona la sincronització d'unió de jugadors a sales entre el backend i el client d'Unity, incloent l'actualització de la base de dades i notificacions via WebSocket.

### Modified Capabilities
- Cap.

## Impact

- **Backend**: `GameController.js` i qualsevol servei que depengui de l'estat de la sala.
- **Client**: `MenuManager.cs`, visualització del lobby i gestió de l'estat de la sala d'espera.
- **Base de dades**: Els jugadors es registraran correctament a la sala a MongoDB.
