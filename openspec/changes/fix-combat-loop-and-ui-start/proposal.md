## Why

Actualment, la interfície d'usuari dels minijocs és visible immediatament en iniciar el joc, cosa que genera una mala experiència d'usuari. A més, existeix un problema de col·lisions infinites on els jugadors tornen a entrar en combat a l'instant després de finalitzar-ne un, ja que els seus colliders encara es toquen.

## What Changes

- Assegurar que la UI comenci neta cridant a `AmagarTotsElsContenidors()` en el `Start()` de `MinijocUIManager.cs`.
- Implementació d'un sistema de cooldown per als combats a `Player.cs` mitjançant un booleà `potCombatre` i una corrutina.
- Addició del mètode `FinalitzarCombat()` a `Player.cs` per gestionar el retorn del moviment i l'inici del cooldown de combat.
- Actualització de `MinijocUIManager.cs` per utilitzar `FinalitzarCombat()` dels jugadors en lloc de manipular les seves variables de moviment directament.
- Restricció de l'activació de minijocs en `OnCollisionEnter2D` de `Player.cs` basada en l'estat de `potCombatre`.

## Capabilities

### New Capabilities
- `combat-cooldown`: Sistema per evitar enfrontaments consecutius immediats entre jugadors.

### Modified Capabilities
- `uimanager-initialization-safety`: Millora de l'estat inicial de la UI.
- `uimanager-persistent-state`: Actualització de la lògica de tancament de la UI.

## Impact

- **MinijocUIManager.cs**: Canvi en la inicialització (`Start`) i en la lògica de tancament (`HideUI`).
- **Player.cs**: Nous membres (`potCombatre`, `FinalitzarCombat`, corrutina de cooldown) i modificació de la lògica de col·lisió.
- **Game Flow**: Millora en la fluïdesa del joc en evitar bucles de combat infinits.
