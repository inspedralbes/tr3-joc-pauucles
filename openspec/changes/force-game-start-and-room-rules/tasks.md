## 1. Backend (Lògica de Sales i Lobby)

- [x] 1.1 Modificar `listWaitingGames` al `GameService.js` (o repositori) per filtrar per `{ status: "waiting" }`.
- [x] 1.2 Actualitzar el controlador de desconnexió i `LEAVE_ROOM` a `server.js` per aplicar la regla d'eliminació de sala només si és el `host`.
- [x] 1.3 Utilitzar l'operador `$pull` de Mongoose per treure convidats de l'array `players` sense esborrar la sala.

## 2. Backend (Inici de Partida)

- [x] 2.1 Refinar la validació de READY al backend: si tots els jugadors estan llestos i la sala plena, posar `status: "playing"` i desar.
- [x] 2.2 Implementar el broadcast individualitzat del missatge `PARTIDA_INICIADA` (amb username, equip i color) a cada jugador.

## 3. Unity (Frontend)

- [x] 3.1 Actualitzar `WebSocketClient.cs`: afegir el log "Iniciant partida per WebSocket!" al rebre `PARTIDA_INICIADA`.
- [x] 3.2 Sincronitzar la càrrega de l'escena "Bosque" a l'Update de `WebSocketClient` mitjançant el flag `shouldStartGame`.
- [x] 3.3 Modificar `MenuManager.cs` per processar l'inici de partida amagant l'arrel de la UI (`root.style.display = DisplayStyle.None`).

## 4. Verificació

- [x] 4.1 Confirmar que una sala en joc deixa d'aparèixer a la llista de partides d'altres jugadors.
- [x] 4.2 Validar que en marxar un convidat la sala segueix viva per al host.
- [x] 4.3 Validar que el canvi d'escena i l'ocultació de la UI ocorren en paral·lel per a tots els jugadors.
