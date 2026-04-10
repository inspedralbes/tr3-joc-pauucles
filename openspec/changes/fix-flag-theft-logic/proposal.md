## Why

Actualment, la lògica de robatori de bandera no és prou robusta. S'han detectat casos on el robatori s'intenta fer sense que el perdedor realment tingui la bandera, o on la bandera no queda correctament vinculada al jugador (falta el `SetParent` en la recollida normal). Aquest fix assegura que el robatori només es produeixi si es confirma la possessió mitjançant `IsChildOf`, i que tant en robatori com en recollida normal, la bandera quedi correctament jerarquitzada i posicionada.

## What Changes

- **Verificació de Possessió amb IsChildOf**: A `MinijocUIManager.cs`, s'usa `IsChildOf(jugadorPerdedor.transform)` per validar que el perdedor realment porta la bandera abans d'iniciar el robatori.
- **Traspàs Jeràrquic i Visual**: Ús de `SetParent` per al traspàs, fixant `localPosition` a `(-0.8, 0, 0)` i `localScale` a `(1, 1, 1)`.
- **Correcció a Player.cs (Recollida Normal)**: Al mètode `OnTriggerEnter2D` (o on es gestioni la recollida de la bandera del terra), s'afegeix el `SetParent(this.transform)` per garantir que la bandera sigui filla del jugador des del primer moment.
- **Feedback de Robatori**: S'afegeix un `Debug.Log` detallat quan el robatori s'efectua amb èxit.

## Capabilities

### New Capabilities
- `flag-hierarchy-management`: Gestió estricta de la jerarquia (pare/fill) de la bandera per a recollides i robatoris.

### Modified Capabilities
- `flag-theft`: Refinament de la lògica de validació i traspàs de la bandera entre jugadors durant el combat.

## Impact

- **Player.cs**: Actualització de la recollida normal i del mètode de robatori.
- **MinijocUIManager.cs**: Actualització de la lògica de resolució de combat per validar la possessió abans del robatori.
- **Consola**: Nous logs per traçabilitat de robatoris.
