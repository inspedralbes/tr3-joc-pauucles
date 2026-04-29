## Why

El backend envia actualitzacions de la llista de sales i de l'estat de les sales mitjançant WebSockets, però el client Unity no està processant correctament aquests missatges. Això es deu a una discrepància entre els noms de les claus JSON enviades pel servidor (`sales`, `room`) i les que el client espera (`games`, `game`), i a la manca de lògica de parseig per a aquests missatges específics.

## What Changes

- Modificació de les estructures de dades de deserialització a Unity per coincidir amb el format del backend.
- Implementació de la lògica de processament de missatges `ACTUALITZAR_SALES` al client.
- Implementació de la lògica de processament de missatges `ROOM_UPDATED` al client.
- Connexió dels missatges rebuts amb les funcions existents de repintat de la UI (Lobby i Sala d'Espera).

## Capabilities

### New Capabilities
- `room-sync`: Sincronització en temps real de la llista de sales i de l'estat d'una sala específica entre el backend i el client Unity.

### Modified Capabilities
<!-- Cap -->

## Impact

- `MenuManager.cs`: Canvis en el mètode de processament de missatges i estructures de dades internes.
- UI d'Unity: El Lobby i la Sala d'Espera es refrescaran automàticament sense intervenció de l'usuari.
- Protocol de comunicació: Es formalitza la dependència del client Unity respecte al format JSON definit al backend.
