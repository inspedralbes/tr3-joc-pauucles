## Why

Cal una gestió clara de qui guanya i qui perd els combats per aplicar les conseqüències mecàniques adequades, especialment la pèrdua de la bandera per part del defensor. Això permet que el flux de joc sigui coherent i que les accions de combat tinguin un impacte real en el món del joc.

## What Changes

- **Seguiment de Rols**: Afegir variables `atacant` i `defensor` a `MinijocUIManager.cs` per identificar els jugadors involucrats.
- **Registre de Rols en Inici**: Modificar `ShowUI` per assignar els jugadors als rols corresponents basant-se en l'ordre de col·lisió o propietat de la bandera.
- **Processament de Finalització**: Implementar `FinalitzarCombat(string guanyador)` que amagui la UI i gestioni la lògica de victòria/derrota.
- **Lògica de Desvinculació de Bandera**: Si el defensor perd, la bandera s'ha de desenganxar (`SetParent(null)`) i s'ha de netejar la referència del jugador.

## Capabilities

### New Capabilities
- `combat-victory-consequences`: El sistema ha de ser capaç de determinar les conseqüències d'un combat (com la pèrdua de la bandera) basant-se en el guanyador notificat.

### Modified Capabilities
- Cap.

## Impact

- `MinijocUIManager.cs`: Nous mètodes i variables de control de combat.
- `Player.cs`: Interacció amb la bandera durant la finalització del combat.
