## Why

L'ús de `nodemon` en l'script `dev` està provocant reinicis constants del servidor quan es produeixen canvis menors o durant el flux normal de treball, cosa que talla les connexions WebSocket actives amb Unity i dificulta el depurat.

## What Changes

- Es modifica l'script `dev` al fitxer `package.json` de l'arrel.
- Es canvia `nodemon backend/src/server.js` per `node backend/src/server.js`.
- Es desactiva el reinici automàtic per garantir l'estabilitat de les sessions de joc durant el desenvolupament.

## Capabilities

### New Capabilities
<!-- Cap -->

### Modified Capabilities
- `development-workflow`: Es modifica l'entorn d'execució local per evitar reinicis disruptius.

## Impact

- `package.json`: Canvi en la definició de l'script `dev`.
- Flux de treball: Els desenvolupadors hauran de reiniciar el servidor manualment per aplicar canvis en el codi del backend.
- Estabilitat: Es garanteix que les connexions WebSocket es mantinguin estables fins que el servidor s'aturi manualment.
