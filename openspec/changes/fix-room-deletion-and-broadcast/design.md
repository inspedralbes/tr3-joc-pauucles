## Context

El sistema de sales actual no gestiona correctament l'abandonament del host, deixant sales òrfenes. A més, les notificacions de canvis en la llista de sales no arriben a tots els jugadors que estan al Lobby si el broadcast té algun filtre implícit o explícit.

## Goals / Non-Goals

**Goals:**
- Implementar l'auto-neteja de sales al `GameService.js`.
- Assegurar un broadcast 100% global per a la llista de sales.
- Eliminar qualsevol filtre de destinatari en les notificacions del Lobby.

**Non-Goals:**
- Canviar el mètode de persistència (seguir usant Mongoose/MongoDB).
- Afegir funcionalitat de reassignació de host (si el host marxa, la sala mor).

## Decisions

### 1. Lògica d'eliminació centralitzada a GameService
Es modificarà `leaveGame` per retornar `null` (o un indicador d'eliminació) si la sala s'ha esborrat.
- **Racional:** Centralitzar la lògica de negoci del cicle de vida de la sala al servei facilita el manteniment i el testing.

### 2. Broadcast global a GameController
S'assegurarà que el mètode `broadcastRoomUpdates` utilitzi `this.wss.clients.forEach` sense condicions addicionals més enllà de l'estat del socket (`WebSocket.OPEN`).
- **Racional:** La llista de sales és una informació pública per a tots els jugadors al Lobby, per tant el broadcast ha de ser total.

### 3. Revisió de server.js
Es revisarà com es criden els mètodes de broadcast des del listener de missatges de `server.js` per assegurar que s'executen en el moment correcte (especialment després d'esborrar una sala).

## Risks / Trade-offs

- **[Risk]** Si hi ha molts clients connectats, un broadcast global podria saturar el servidor si hi ha moltes creacions/eliminacions seguides. -> **Mitigation:** El volum esperat de sales i jugadors per a aquest projecte és baix; si creix, s'hauria de considerar un sistema de *throttling* o habitacions (*rooms*) de socket.io si acabéssim migrant-hi.
- **[Trade-off]** L'eliminació de la sala si el host marxa és radical (no hi ha traspàs de host). -> **Mitigation:** És el comportament esperat pel disseny actual del TR3.
