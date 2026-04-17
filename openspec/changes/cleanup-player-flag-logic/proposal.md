## Why

El fitxer `Player.cs` presenta codi redundant, variables sense ús (CS0414) i mètodes de recollida fragmentats que no s'ajusten a la nova estructura de la bandera (Pare/Fill amb Hitbox). Aquesta neteja consolidarà tota la lògica de recollida en un únic punt d'entrada basat en Triggers.

## What Changes

- **Eliminació de variables obsoletes**: Es suprimeix `banderaPortant` per solucionar l'advertència CS0414.
- **Simplificació de col·lisions**: Es retira tota la lògica de detecció de la bandera de `OnCollisionEnter2D`.
- **Consolidació de mètodes**: S'eliminen `AgafarBandera` i `AgafarBanderaAutomàticament` per moure la seva funcionalitat directament a `OnTriggerEnter2D`.
- **Detecció robusta**: S'implementa `GetComponentInParent<Bandera>()` per permetre la detecció des d'objectes fill (Hitbox).
- **Ignorància de col·lisions recursiva**: S'assegura que tots els colliders de la mascota (incloses les hitboxes) ignorin al jugador en ser recollida.

## Capabilities

### New Capabilities
<!-- Cap -->

### Modified Capabilities
- `flag-movement`: Unificació i simplificació del procés de recollida de la bandera.

## Impact

- `Player.cs`: Reducció significativa de codi i millora en la llegibilitat.
- Estabilitat del joc: Eliminació d'estats inconsistents durant la recollida.
