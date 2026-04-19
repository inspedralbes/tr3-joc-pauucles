## Why

Actualment, el sistema de banderes no distingeix entre l'equip propietari i l'atacant, permetent que un jugador interactuï amb la seva pròpia bandera. A més, el Nametag del jugador local no es mostra correctament perquè no s'assigna el nom d'usuari al component visual corresponent.

## What Changes

- **Filtratge de Col·lisions**: Modificació de `Bandera.cs` per ignorar les col·lisions si l'equip del jugador coincideix amb `equipPropietari`.
- **Assignació de Nametag**: Actualització de `GameManager.cs` per buscar el component `TextMeshPro` dins dels fills del jugador local i assignar-li el `userId` o `username` de la sessió actual.

## Capabilities

### New Capabilities
<!-- Cap -->

### Modified Capabilities
- `team-aware-flag-collisions`: Es refina la lògica per garantir que el filtratge d'equips sigui efectiu.
- `enhanced-local-identity`: S'actualitza el mecanisme d'identificació del jugador local.

## Impact

- `Bandera.cs`: Canvi en la lògica de detecció de col·lisions.
- `GameManager.cs`: Canvi en la configuració visual del jugador local.
- Experiència de joc: Consistència en les interaccions amb les banderes i visibilitat correcta del propi nom.
