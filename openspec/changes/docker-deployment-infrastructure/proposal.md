## Why

Actualment el desplegament del sistema és manual i depèn de la configuració de l'entorn local, el que pot provocar inconsistències entre desenvolupament i producció. Aquesta infraestructura Docker permetrà unificar el desplegament dels microserveis de backend i el client WebGL sota un entorn aïllat i escalable.

## What Changes

- **Contenirització del Backend**: Creació d'un `Dockerfile` per als serveis Node.js.
- **Orquestració de Serveis**: Definició d'un `docker-compose.yml` que aixeca els microserveis `identity` i `game`.
- **Gateway de Redireccionament**: Configuració de Nginx com a contenidor per servir el joc WebGL i fer de proxy invers cap als serveis interns.
- **Unificació d'Accés**: Centralització de totes les peticions externes en un únic punt d'entrada (Nginx).

## Capabilities

### New Capabilities
- `dockerized-infrastructure`: Definició de la imatge base i execució de contenidors per al backend.
- `orchestrated-deployment`: Gestió del cicle de vida de múltiples contenidors i la seva xarxa interna.
- `web-hosting-proxy`: Capacitat de servir contingut estàtic i enrutar trànsit d'API dinàmicament.

### Modified Capabilities
- `foundations`: S'amplien els requeriments de desplegament per incloure la suportabilitat de contenidors.

## Impact

- `backend/Dockerfile`: Nou arxiu per a la construcció d'imatges de Node.js.
- `docker-compose.yml`: Nou arxiu d'orquestració a l'arrel.
- `nginx_default.conf`: Actualització de la configuració per a l'entorn de Docker.
- Pipeline de CI/CD: Es podrà automatitzar el desplegament basat en imatges.
