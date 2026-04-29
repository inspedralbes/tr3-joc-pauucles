## Why

S'ha detectat un bug crític on els jugadors cauen pel terra i surten dels límits de l'escena quan s'activa l'estat "Fantasma" (`isTrigger = true`) durant el càstig de derrota. Això passa perquè, en convertir el collider en trigger, el motor de física de Unity deixa d'aplicar col·lisions amb el terra, però la gravetat segueix estirant el jugador cap avall.

## What Changes

- Modificació de `Player.cs` per gestionar la gravetat durant l'estat fantasma.
- Emmagatzematge del valor original de `gravityScale`.
- Aturada immediata del moviment (`velocity = Vector2.zero`) i desactivació de la gravetat (`gravityScale = 0`) en entrar en estat de derrota.
- Restauració del `gravityScale` original quan el jugador torna a l'estat normal.

## Capabilities

### New Capabilities
- `gravity-safe-ghost-mode`: Garantia que el jugador no caigui pel buit mentre el seu collider està en mode trigger.

### Modified Capabilities
- `ghost-effect`: Actualització de la lògica d'activació per incloure la gestió de gravetat.

## Impact

- **Player.cs**: Nous camps privats per guardar l'estat de la física i modificació de les corrutines de càstig.
- **Physics Engine**: Menys probabilitat de "falling through floor" bugs durant les transicions de combat.
