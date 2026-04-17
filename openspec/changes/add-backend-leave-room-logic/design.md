## Context

El servidor WebSocket ja està inicialitzat i compartint el port amb Express. No obstant això, el backend només escolta els esdeveniments de connexió i desconnexió del socket, però no processa missatges enviats pels clients per realitzar accions de gestió de sales en temps real.

## Goals / Non-Goals

**Goals:**
- Estendre la funcionalitat de `wss` per processar missatges JSON del client.
- Implementar la sortida d'un jugador d'una sala específica mitjançant el seu nom d'usuari i l'ID de la sala.
- Garantir la neteja de la base de dades eliminant sales sense jugadors.

**Non-Goals:**
- No s'implementarà cap sistema de "rooms" avançat de WebSockets (com el de socket.io). La gestió serà estrictament a través de l'estat en la base de dades.
- No es canviarà el protocol de comunicació.

## Decisions

- **Missatges JSON**: S'utilitzarà el format JSON per a la comunicació. El client haurà d'enviar missatges amb un camp `type` per identificar l'acció.
- **Accés Directe al Model `Game`**: Per simplicitat i coherència amb la refactorització anterior, es realitzarà el `require` del model `Game` i l'operació de base de dades directament dins del listener del servidor, garantint que la lògica de persistència es mantingui actualitzada en temps real.

## Risks / Trade-offs

- **[Risk] Sincronització de l'estat** → **Mitigation**: Com que les operacions són asíncrones (`await`), es garanteix que l'estat de la base de dades sigui coherent abans de respondre o processar el següent pas.
- **[Trade-off] Càrrega a la base de dades** → **Mitigation**: Tot i que cada sortida implica una operació de BD, per a l'escala actual del projecte no suposa un problema de rendiment.

## Migration Plan

1. Actualitzar el listener `connection` a `server.js`.
2. Afegir el listener `message` a cada instància de `ws`.
3. Integrar la lògica de filtratge de jugadors i eliminació de sales buides.
