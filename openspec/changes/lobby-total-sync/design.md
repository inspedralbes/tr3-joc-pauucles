## Context

Actualment, el backend gestiona la llista de sales de forma global (`room_list`), però no informa detalladament dels canvis interns d'una sala (com quan un jugador es posa "Llest" o marxa) de forma reactiva. El client d'Unity depèn de peticions manuals o actualitzacions parcials que no garanteixen la sincronització total entre tots els jugadors d'una mateixa sala.

## Goals / Non-Goals

**Goals:**
- Implementar un broadcast de `ROOM_UPDATED` cada vegada que l'estat intern d'una sala canvia.
- Centralitzar la lògica de `LEAVE_ROOM` al backend per garantir la neteja de la base de dades i la notificació als altres jugadors.
- Assegurar que la UI d'Unity reflecteixi els canvis d'estat de tots els jugadors de forma immediata.

**Non-Goals:**
- No es modificarà la lògica de joc (combat, moviments) en aquest disseny.
- No es canviarà el protocol de comunicació (es manté WebSocket pur sobre `ws`).

## Decisions

- **Event `ROOM_UPDATED`**: El servidor enviarà un missatge de tipus `ROOM_UPDATED` que contindrà l'objecte `GameData` complet de la sala afectada. Els clients d'Unity filtraran aquest missatge: si el `roomId` coincideix amb la sala actual del jugador, es repintarà la llista de jugadors.
- **Lògica de `LEAVE_ROOM`**: Aquesta lògica es mourà de `server.js` a un mètode dedicat al backend (possiblement al `GameController` o `GameService`) per poder ser cridada tant per missatges WebSocket com per peticions HTTP si calgués. Si el nombre de jugadors arriba a 0, la sala s'eliminarà físicament de MongoDB.
- **Sincronització de l'estat `READY`**: S'afegirà un handler al backend per al missatge `READY`. Aquest actualitzarà el flag `isReady` del jugador a MongoDB i immediatament dispararà un `ROOM_UPDATED`.
- **Interfície d'Unity**: Es modificarà `MenuManager.cs` per processar el nou tipus de missatge. La funció `OmplirLlistaJugadors` s'adaptarà per incloure visualment l'estat de preparació llegit des de l'objecte `PlayerData`.

## Risks / Trade-offs

- **[Risc] Volum de broadcasts** → **[Mitigació]** Tot i que fem broadcast a tots els clients connectats (per la simplicitat actual de la implementació de `ws`), el payload és petit. En el futur es podrien implementar "rooms" reals al servidor WebSocket per segmentar el trànsit.
- **[Risc] Condicions de carrera en tancar la sala** → **[Mitigació]** El backend verificarà l'existència de la sala abans d'intentar eliminar-la o modificar-la en rebre `LEAVE_ROOM`.
