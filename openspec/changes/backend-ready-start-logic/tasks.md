## 1. Actualització del Servei (GameService)

- [x] 1.1 Modificar `joinGame` a `GameService.js` per implementar l'assignació d'equips A/B (o Vermell/Blau) automàtica.
- [x] 1.2 Actualitzar el mètode que gestiona el READY per marcar `isReady: true` a la base de dades.
- [x] 1.3 Crear un mètode `checkGameStart` que verifiqui si tots els jugadors estan llestos i la sala està plena.
- [x] 1.4 Implementar el canvi d'status a `playing` quan s'inicia la partida.

## 2. Gestió de WebSockets (server.js i GameController)

- [x] 2.1 Actualitzar el listener de `READY` a `server.js` per invocar la validació d'inici de partida.
- [x] 2.2 Implementar l'mètode `broadcastGameStart` a `GameController.js` que enviï el missatge `PARTIDA_INICIADA`.
- [x] 2.3 Assegurar que `PARTIDA_INICIADA` inclou `username`, `team` i `color` (mapejat segons l'equip).

## 3. Verificació i Proves

- [ ] 3.1 Provar la unió d'un segon jugador i verificar que l'equip assignat és el contrari del host.
- [ ] 3.2 Simular el missatge `READY` per a ambdós jugadors i verificar que es rep `PARTIDA_INICIADA`.
- [ ] 3.3 Comprovar a MongoDB que l'status de la sala passa a `playing`.
