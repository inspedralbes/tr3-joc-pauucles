## 1. Modificació de la Lògica de Negoci (Backend)

- [x] 1.1 Modificar `backend/src/services/GameService.js` en el mètode `leaveGame`:
    - [x] 1.1.1 Detectar si el jugador que surt és el `host`.
    - [x] 1.1.2 Eliminar la sala de la base de dades si el host surt O si la llista de jugadors queda buida.
    - [x] 1.1.3 Retornar un objecte o indicador per notificar l'eliminació.

## 2. Refactorització de Broadcast (Backend)

- [x] 2.1 Revisar `backend/src/controllers/GameController.js`:
    - [x] 2.1.1 Assegurar que `broadcastRoomUpdates` no exclou cap client (itera per tots els clients a `wss.clients`).
    - [x] 2.1.2 Revisar `broadcastToRoom` per gestionar el cas en què la sala ha estat eliminada (notificar als que quedaven).
- [x] 2.2 Revisar `backend/src/server.js`:
    - [x] 2.2.1 Assegurar que el broadcast de `ACTUALITZAR_SALES` es crida en tots els punts de sortida rellevants (especialment quan una sala s'elimina).

## 3. Verificació (Opcional)

- [x] 3.1 Verificar des de dos clients d'Unity que el Lobby s'actualitza globalment quan es tanca una sala.
- [x] 3.2 Verificar que si el host marxa de la sala d'espera, la sala desapareix per a tots els altres.
