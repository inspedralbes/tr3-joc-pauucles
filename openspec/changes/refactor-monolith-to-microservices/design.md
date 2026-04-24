## Context

El projecte utilitza actualment un servidor Node.js monolític a `backend/src/server.js` que gestiona tant l'autenticació com la lògica de joc en temps real (WebSockets). Tenim Nginx configurat però volem aprofitar-lo per actuar com a porta d'enllaç entre microserveis separats.

## Goals / Non-Goals

**Goals:**
- Separar el domini d'identitat (REST) del domini de joc (WebSockets/REST).
- Implementar rutes de proxy invers a Nginx per unificar l'accés.
- Permetre l'arrencada independent de cada servei mitjançant scripts de NPM.

**Non-Goals:**
- Implementar comunicació entre serveis (IPC) en aquesta fase; els serveis romandran aïllats per ara.
- Canviar el motor de base de dades (MongoDB es manté).

## Decisions

### 1. Divisió de Serveis
- **Decisió**: Crear `identity-service.js` i `game-service.js`.
- **Racional**: Permet que cada servei instanciï només els controladors i repositoris que realment utilitza, reduint la càrrega de memòria i millorant la claredat del codi.

### 2. Configuració de Ports
- **Decisió**: Port 3001 per a Identity, 3002 per a Game.
- **Racional**: Convenció estàndard per a sistemes de microserveis locals per evitar col·lisions.

### 3. Configuració d'Nginx
- **Decisió**: Utilitzar `proxy_pass` per redirigir peticions basades en el prefix de la URL (`/api/users/` vs `/api/games/`).
- **Racional**: És la forma més eficient i transparent per al client (Unity) de consumir una API distribuïda.

## Risks / Trade-offs

- **[Risc] Desconnexions de WebSocket per timeout d'Nginx** → **Mitigació**: Configurar adequadament `proxy_read_timeout` i headers d'upgrade.
- **[Risc] Duplicitat de codi de connexió a DB** → **Mitigació**: Seguir utilitzant `db.js` com a mòdul compartit importat per ambdós serveis.
