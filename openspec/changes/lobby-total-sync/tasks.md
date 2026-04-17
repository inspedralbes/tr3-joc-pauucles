## 1. Backend (Node.js)

- [x] 1.1 Implementar mètode `toggleReady` a `GameService.js` per actualitzar `isReady` a MongoDB.
- [x] 1.2 Implementar mètode `leaveGame` a `GameService.js` que gestioni la sortida d'un jugador i l'eliminació de la sala si queda buida.
- [x] 1.3 Crear mètode `broadcastToRoom` a `GameController.js` per enviar el missatge `ROOM_UPDATED` amb dades detallades.
- [x] 1.4 Actualitzar `server.js` per gestionar els missatges `READY` i `leave_room` usant els nous mètodes del servei i controller.
- [x] 1.5 Afegir crida a `broadcastToRoom` després de cada `join`, `leave` o `READY`.

## 2. Frontend (Unity)

- [x] 2.1 Afegir la classe serialitzable `RoomUpdateMessage` a `MenuManager.cs`.
- [x] 2.2 Modificar `AlRebreActualitzacioSales` a `MenuManager.cs` per processar també el tipus `ROOM_UPDATED`.
- [x] 2.3 Actualitzar el mètode `OmplirLlistaJugadors` a `MenuManager.cs` per mostrar "(Llest)" o "(Esperant)".
- [x] 2.4 Verificar que el botó `btnTancarSalaEspera` a `MenuManager.cs` envia correctament el missatge `leave_room` i torna al lobby.

## 3. Verificació

- [ ] 3.1 Provar que en prémer "Llest" un jugador, l'altre ho veu immediatament a la seva pantalla.
- [ ] 3.2 Provar que en marxar un jugador, desapareix de la llista per als altres.
- [ ] 3.3 Verificar que si tots marxem, la sala ja no apareix a la llista global de sales.
