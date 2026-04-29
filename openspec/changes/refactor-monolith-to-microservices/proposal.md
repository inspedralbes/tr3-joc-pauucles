## Why

L'arquitectura monolítica actual dificulta l'escalabilitat independent i el manteniment de les diferents funcionalitats del sistema (autenticació vs. joc). Aquesta refactorització permetrà separar les responsabilitats en microserveis dedicats, millorant la robustesa i facilitant el desplegament individual.

## What Changes

- **BREAKING**: El servidor centralitzat `server.js` es descompone en serveis independents. Les peticions directes al port 3000 deixaran de funcionar un cop s'implementi el proxy.
- **Divisió de Serveis**: Creació d' `identity-service.js` (Port 3001) per a rutes d'usuari i `game-service.js` (Port 3002) per a joc i WebSockets.
- **Scripts de NPM**: Nous scripts al `package.json` per gestionar l'arrencada de cada microservei.
- **Configuració de Proxy Invers**: Implementació/Actualització de `nginx.conf` per centralitzar el trànsit i redirigir-lo als serveis interns.

## Capabilities

### New Capabilities
- `microservices-architecture`: Estructura base per a la gestió de múltiples serveis Node.js.
- `reverse-proxy-routing`: Capa d'enrutament mitjançant Nginx per unificar l'API sota una única entrada.

### Modified Capabilities
- `foundations`: Actualització de la infraestructura base del sistema.

## Impact

- `backend/src/server.js`: Serà reemplaçat/dividit pels nous serveis.
- `package.json`: S'afegiran nous scripts d'arrencada.
- `nginx.conf`: Nou punt de configuració crítica per a la connectivitat del sistema.
