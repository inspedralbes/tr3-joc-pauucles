## Why

La lògica d'escalada actual utilitza noms de variables en català (`tocantEscala`, `escalant`, `originalGravity`) que no segueixen les noves convencions del projecte. A més, cal integrar el feedback visual de l'escalada a l'Animator.

## What Changes

- Refactorització de noms de variables: `tocantEscala` -> `isNearLadder`, `escalant` -> `isClimbing`, `originalGravity` -> `defaultGravity`.
- Refinament de la lògica de detecció i activació de l'escalada mitjançant `OnTriggerEnter2D` i `OnTriggerExit2D`.
- Actualització del paràmetre `isClimbing` de l'Animator.
- Ajust de la física de moviment vertical durant l'escalada.

## Capabilities

### New Capabilities
- `climbing-visual-feedback`: Implementació del paràmetre `isClimbing` a l'Animator per reflectir l'estat d'escalada del jugador.

### Modified Capabilities
- Cap.

## Impact

- **Codi**: Modificació de `Player.cs`.
- **Unity**: Requereix un paràmetre `isClimbing` (bool) a l'Animator Controller del Player.
