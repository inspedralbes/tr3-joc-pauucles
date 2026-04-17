## 1. Backend (Node.js)

- [x] 1.1 Modificar `backend/src/controllers/GameController.js`: localitzar el mètode `join`.
- [x] 1.2 Afegir la crida a `this.broadcastRoomUpdates()` al final del mètode `join` (després del `save` exitós).

## 2. Client Unity (C#)

- [x] 2.1 Modificar `DAMT3Atrapa la bandera/Assets/Scripts/MenuManager.cs`: localitzar la lògica d'unir-se a una sala a la llista de partides.
- [x] 2.2 Implementar la petició HTTP POST a `/api/games/join` utilitzant `UnityWebRequest` enviant un JSON amb `roomId` i `username`.
- [x] 2.3 Actualitzar la UI: a la resposta exitosa del POST, afegir el nom de l'usuari a `llistaJugadorsSala` i mostrar la pantalla de sala d'espera.

## 3. Verificació i Proves

- [x] 3.1 Provar la unió d'un segon jugador des d' Unity i verificar que el primer jugador rep l'actualització de la sala (2/2).
- [x] 3.2 Verificar que el segon jugador apareix correctament a la llista de la sala d'espera immediatament després d'unir-se.
- [x] 3.3 Validar que el comptador de sales al lobby s'actualitza per a tots els clients via WebSocket.
