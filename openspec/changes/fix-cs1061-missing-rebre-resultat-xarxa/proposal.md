## Why

S'ha detectat un error de compilació CS1061 a `MinijocParellsSenarsLogic.cs` perquè s'ha eliminat el mètode `RebreResultatXarxa` que és cridat des d'altres scripts (probablement pel sistema de xarxa per sincronitzar la victòria del rival).

## What Changes

- **Add `RebreResultatXarxa`**: Implementar de nou el mètode públic per gestionar els resultats enviats pel servidor o el sistema de combat.
- **Immediate Defeat on Rival Win**: Si el guanyador rebut no és el jugador local, el joc s'ha d'aturar immediatament, tancar la UI i aplicar la derrota al jugador local.

## Capabilities

### New Capabilities
- Cap.

### Modified Capabilities
- `minijoc-parells-senars-logic`: S'afegeix la capacitat de rebre resultats externs (xarxa) per finalitzar el joc si el rival guanya.

## Impact

- `MinijocParellsSenarsLogic.cs`: S'afegirà el mètode perdut per restaurar la funcionalitat de xarxa i fixar l'error de compilació.
