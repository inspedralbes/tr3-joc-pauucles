## 1. Implementació de Microserveis

- [x] 1.1 Crear `backend/src/identity-service.js` extraient la lògica de rutes d'usuari de `server.js`.
- [x] 1.2 Configurar `identity-service.js` per escoltar al port 3001.
- [x] 1.3 Crear `backend/src/game-service.js` extraient la lògica de WebSockets i sales de `server.js`.
- [x] 1.4 Configurar `game-service.js` per escoltar al port 3002.
- [x] 1.5 Verificar que cada servei només instància els repositoris de MongoDB que necessita.

## 2. Configuració d'Entorn i Dependències

- [x] 2.1 Afegir l'script `start:identity` al `package.json`.
- [x] 2.2 Afegir l'script `start:game` al `package.json`.
- [x] 2.3 Actualitzar el fitxer `.env` (si cal) amb els nous ports dels serveis.

## 3. Configuració d'Nginx

- [x] 3.1 Localitzar o crear el fitxer de configuració d'Nginx (ex: `nginx.conf` o `nginx_default.conf`).
- [x] 3.2 Definir els upstreams per a cada servei (3001 i 3002).
- [x] 3.3 Configurar el proxy invers per a `/api/users`.
- [x] 3.4 Configurar el proxy invers per a `/api/games` i `/socket.io`.

## 4. Validació i Neteja

- [x] 4.1 Validar que les peticions d'autenticació funcionen a través de la porta d'enllaç.
- [x] 4.2 Validar que les connexions de joc i WebSockets funcionen correctament.
- [x] 4.3 Deprecar/Eliminar el fitxer `server.js` original un cop estiguin validats els nous serveis. (Renombrat a server.js.old)
