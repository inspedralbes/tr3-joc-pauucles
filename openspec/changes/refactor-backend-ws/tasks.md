## 1. Gestió de Dependències

- [x] 1.1 Executar `npm uninstall socket.io` al directori del backend.
- [x] 1.2 Executar `npm install ws` al directori del backend.

## 2. Refactorització del Servidor

- [x] 2.1 Eliminar la importació i l'ús de `socket.io` a `backend/src/server.js`.
- [x] 2.2 Afegir la importació de `ws`: `const WebSocket = require("ws");`.
- [x] 2.3 Inicialitzar el servidor WebSocket compartint el servidor HTTP: `const wss = new WebSocket.Server({ server });`.
- [x] 2.4 Implementar el listener de connexió bàsic amb `wss.on("connection", ...)`.
- [x] 2.5 Afegir logs per a la connexió i desconnexió de clients.

## 3. Verificació

- [x] 3.1 Comprovar que l'API Express segueix funcionant correctament al mateix port.
- [x] 3.2 Verificar que el servidor WebSocket accepta connexions (per exemple, amb una eina de test de WebSockets).
