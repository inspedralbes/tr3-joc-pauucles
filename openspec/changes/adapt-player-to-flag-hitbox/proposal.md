## Why

S'ha modificat l'estructura del Prefab de la bandera per incloure un fill amb un collider tipus Trigger que actua com a "Hitbox". Això requereix que el jugador actualitzi com detecta la bandera i com ignora les seves col·lisions físiques per evitar conflictes.

## What Changes

- **Detecció de la bandera**: S'actualitza `OnTriggerEnter2D` per detectar la bandera mitjançant `GetComponentInParent`, permetent que el tag estigui en un objecte fill.
- **Gestió de col·lisions**: S'actualitza `AgafarBandera` per buscar tots els colliders en els fills de la bandera i aplicar `IgnoreCollision` a cadascun d'ells.
- **Manteniment del comportament físic**: Es conserva la lògica de desvinculació (`SetParent(null)`) i el mode `Dynamic` del Rigidbody2D.

## Capabilities

### New Capabilities
<!-- Cap -->

### Modified Capabilities
- `flag-movement`: Adaptació de la detecció i la ignorància de col·lisions per a estructures de prefabs amb múltiples colliders o fills.

## Impact

- `Player.cs`: Canvis en `OnTriggerEnter2D` i `AgafarBandera`.
- Interacció física: Millora en la robustesa de la recollida de la bandera.
