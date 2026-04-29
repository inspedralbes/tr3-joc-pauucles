## Why

Actualment, els jugadors que s'uneixen a una partida ja iniciada o després que el creador hagi carregat l'escena no veuen les banderes (dinosaures) correctament perquè s'instancien abans que les dades de la sala s'hagin sincronitzat via WebSocket. A més, el Nametag del jugador local no es mostra correctament amb el seu nom d'usuari, i l'escala visual dels dinosaures no és consistent.

## What Changes

- **Sincronització de Dades**: El `GameManager` esperarà a que la connexió WebSocket estigui establerta i les dades de la sala estiguin disponibles abans d'instanciar les banderes.
- **Corrutina de Spawn**: Substitució de la crida directa a `InstanciarBanderes` al `Start` per una corrutina que utilitza `WaitUntil`.
- **Nametag Local**: Actualització de la lògica de visuals del jugador local per assignar el `username` del `MenuManager` al component de text fill.
- **Escalabilitat Visual**: Ajust automàtic de l'escala dels prefabs de les banderes instanciades per garantir una visualització correcta (triplicada o quadruplicada).

## Capabilities

### New Capabilities
- `late-join-visibility`: Garanteix que els elements crítics de la partida (banderes) siguin visibles per a tothom, independentment del moment d'unió.
- `enhanced-local-identity`: Sincronització immediata de la identitat visual (nom) del jugador local.

### Modified Capabilities
<!-- Cap -->

## Impact

- `GameManager.cs`: Canvi en el flux d'inicialització i gestió de visuals.
- `MenuManager.cs`: Cal que el camp `username` sigui accessible públicament.
- Experiència de joc: Consistència visual absoluta entre tots els clients de la mateixa sala.
