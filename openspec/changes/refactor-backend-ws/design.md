## Context

L'aplicació actual utilitza `socket.io` per a la comunicació en temps real. El projecte requereix una transició a WebSockets purs (`ws`) per a una comunicació més lleugera i compatible amb el protocol estàndard.

## Goals / Non-Goals

**Goals:**
- Substituir completament `socket.io` per la llibreria `ws` al backend.
- Assegurar que el servidor WebSocket comparteixi el mateix port que el servidor Express.
- Proporcionar una base per a la gestió de connexions `ws` (open, close).

**Non-Goals:**
- No es refactoritzarà la lògica de negoci del joc ni de l'API REST existent.
- No s'implementarà la part de client (Unity/Frontend) en aquesta fase, encara que s'ha de considerar el canvi de protocol.

## Decisions

- **Llibreria `ws`**: S'ha escollit `ws` per ser l'estàndard de la indústria en Node.js per a WebSockets purs, oferint alt rendiment i poc consum de memòria.
- **Servidor Compartit**: S'adjuntarà el servidor WebSocket al servidor HTTP existent (`express`) per evitar problemes de CORS i mantenir un sol port obert.

## Risks / Trade-offs

- **[Risk] Incompatibilitat amb clients actuals** → **Mitigation**: Caldrà actualitzar els clients Unity per utilitzar una llibreria de WebSockets compatible amb el protocol pur (en lloc de `socket.io-client`).
- **[Trade-off] Perduda de funcionalitats de `socket.io`** (com ara auto-reconnexió, sales per defecte, etc.) → **Mitigation**: Aquestes funcionalitats s'hauran de gestionar manualment si es requereixen en el futur.

## Migration Plan

1. Desinstal·lar `socket.io`.
2. Instal·lar `ws`.
3. Modificar `server.js` per inicialitzar el `wss` compartint el servidor HTTP.
4. Afegir listeners bàsics de connexió i desconnexió per a debug.
