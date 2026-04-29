## Why

Actualment el joc només és funcional en local pel que fa al moviment i la visibilitat. Per convertir-lo en un joc multijugador real, cal que els jugadors puguin veure's entre ells, sincronitzar les seves posicions en temps real i que els elements visuals com els Nametags es renderitzin correctament independentment de l'orientació del personatge.

## What Changes

- **Sincronització de Moviment**: Implementació de missatges `PLAYER_MOVE` al backend i lògica de sincronització al client Unity (enviament periòdic de posició i animació).
- **Sistema de Jugadors Remots**: Creació d'un sistema a Unity per instanciar i actualitzar còpies de jugadors remots a partir de les dades del servidor.
- **Correcció Visual de Nametags**: Canvi de la lògica de gir del personatge a Unity per utilitzar `flipX` en lloc de `localScale`, evitant l'efecte mirall en el text del Nametag.
- **Broadcast de Posició**: El servidor ara retransmet les dades de moviment de cada jugador a la resta de participants de la mateixa sala.

## Capabilities

### New Capabilities
- `multiplayer-sync`: Sincronització en temps real de posició, orientació i estat d'animació entre múltiples clients.
- `remote-player-rendering`: Gestió d'instàncies de jugadors no locals (prefabs remots) basada en missatges de xarxa.

### Modified Capabilities
<!-- Cap -->

## Impact

- `backend/src/server.js`: Nou handler per a missatges `PLAYER_MOVE`.
- `Unity Scripts`: Modificació de `PlayerController` (o similar) i creació de `NetworkSync`.
- `Prefabs`: Creació del prefab `JugadorRemot`.
- `GameManager`: Nova lògica d'spawn per a jugadors que ja són a la sala.
