## Why

Quan el jugador recull la bandera, aquesta es converteix en filla del jugador (`SetParent`). Si l'escala del jugador és diferent de 1, la bandera hereta aquesta escala, el que pot provocar que s'encongeixi o es deformi visualment. És necessari fixar l'escala de la bandera manualment per mantenir la seva mida original.

## What Changes

- **Ajust d'escala en la recollida**: Es modificarà la funció `AgafarBandera` (o `AgafarBanderaAutomàticament`) per assignar un `localScale` de `(3, 3, 1)` a la bandera immediatament després de fer-la filla del jugador.

## Capabilities

### New Capabilities
- `flag-pickup-scale-fix`: El sistema ha de garantir que la bandera mantingui la seva mida visual correcta (`3x3`) quan és transportada per un jugador, independentment de l'escala del pare.

### Modified Capabilities
- Cap.

## Impact

- `Player.cs`: Modificació de la lògica de recollida per incloure la correcció d'escala.
