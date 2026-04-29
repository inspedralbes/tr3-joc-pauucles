## Why

El robatori de la bandera actualment utilitza `GameObject.FindGameObjectWithTag("Bandera")`, el qual és poc robust i pot fallar si hi ha múltiples objectes amb el mateix tag o si la referència no es troba correctament en el moment precís. Aquest canvi busca una implementació definitiva i segura cercant directament dins dels fills del jugador que perd el combat.

## What Changes

- **Recerca Local de la Bandera**: S'elimina la cerca global per tag i es substitueix per un bucle `foreach` que recorre els fills del transform del jugador perdedor.
- **Traspàs Jeràrquic**: Un cop trobada la bandera (per tag dins dels fills), es reassigna el pare al jugador guanyador.
- **Reset de Transform**: Es garanteix que la bandera robada tingui la `localPosition` a `(-0.8, 0, 0)` i la `localScale` a `(1, 1, 1)`.
- **Traçabilitat**: S'afegeix un log detallat per confirmar que el robatori s'ha produït amb èxit.

## Capabilities

### New Capabilities
- `flag-theft-loop`: Nova lògica de robatori basada en la iteració de fills per a una major precisió.

### Modified Capabilities
- None.

## Impact

- **MinijocUIManager.cs**: Modificació del mètode `ProcessarResultatCombat`.
- **Robustesa**: Elimina la dependència de mètodes de cerca global costosos i potencialment erronis.
