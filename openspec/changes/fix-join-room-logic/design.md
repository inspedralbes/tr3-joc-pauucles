## Context

El sistema actual de gestió de sales pateix d'una manca de sincronització. Quan un jugador s'uneix a una sala a través del frontend d'Unity, aquesta acció no sempre queda registrada correctament al backend o no es notifica via WebSocket als altres participants, causant que el lobby mostri informació desactualitzada o que el segon jugador no s'afegeixi a la llista visual de la sala d'espera.

## Goals / Non-Goals

**Goals:**
- Assegurar que cada unió a una sala invoqui una actualització via WebSocket per a tots els clients connectats.
- Implementar la petició HTTP POST `join` des d'Unity per persistir la unió al servidor.
- Garantir que la llista de jugadors a Unity s'actualitzi immediatament després d'unir-se.

**Non-Goals:**
- No es modificarà el sistema d'autenticació ni la creació de sales.
- No es tractarà la lògica de "Ready" ni l'inici de partida en aquest disseny.

## Decisions

- **Estratègia de Sincronització (Backend)**: Al `GameController.js`, s'ha decidit cridar a `broadcastRoomUpdates()` dins del mètode `join` immediatament després que la base de dades confirmi la inclusió del jugador. Això aprofita la infraestructura existent de WebSockets per actualitzar el comptador de sales (ex: "1/2" a "2/2") a tots els jugadors del lobby.
- **Comunicació Unity -> Backend**: S'utilitzarà `UnityWebRequest` a `MenuManager.cs` per enviar un objecte JSON amb el `roomId` i `username`. S'ha triat POST sobre GET per ser més semàntic per a accions que modifiquen dades al servidor.
- **Actualització de la UI (Frontend)**: En lloc d'esperar a la següent actualització de WebSocket, s'afegirà el nom del jugador a la `llistaJugadorsSala` localment un cop la petició HTTP POST retorni amb èxit. Això millora la sensació de resposta (responsiveness) del joc.

## Risks / Trade-offs

- **[Risc] Sobrecàrrega de WebSockets** -> **[Mitigació]** `broadcastRoomUpdates()` només envia el resum de les sales, no tota la informació de la partida, mantenint el payload petit.
- **[Risc] Condició de carrera (Race Condition)** -> **[Mitigació]** El servidor verifica el límit de jugadors (`maxPlayers`) abans de permetre la unió i fer el broadcast.
