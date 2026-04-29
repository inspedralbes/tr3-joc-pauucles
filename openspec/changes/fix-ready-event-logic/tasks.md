## 1. Backend (Logica de READY)

- [x] 1.1 Assegurar que `setReady` a `GameService.js` retorna l'objecte actualitzat des de MongoDB.
- [x] 1.2 Refinar `checkGameStart` a `GameService.js` per realitzar un `update` atòmic de l'status a `playing`.
- [x] 1.3 Revisar el broadcast de `ROOM_UPDATED` a `server.js` per assegurar-se que ocorre DESPRÉS del guardat.

## 2. Backend (Inici de Partida)

- [x] 2.1 Verificar que el broadcast `PARTIDA_INICIADA` inclou tota la informació necessària (username, team, color).
- [x] 2.2 Afegir logs al servidor per confirmar el canvi d'estat de la sala a `playing`.

## 3. Verificació

- [ ] 3.1 Provar amb dos clients: posar ambdós a READY i confirmar la transició automàtica.
- [ ] 3.2 Verificar a MongoDB que l'array de jugadors té `isReady: true` per a tothom i que la sala està en `playing`.
