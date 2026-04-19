## Why

Actualment, el joc no instancia les banderes corresponents als colors dels equips triats a la sala. Per a una experiència competitiva completa, cal que cada equip tingui la seva bandera visualment identificada i posicionada correctament a l'escena de combat.

## What Changes

- **GameManager (Unity)**:
    - Addició de 4 variables públiques per als prefabs de banderes: `banderaBlava`, `banderaVermella`, `banderaGroga` i `banderaVerda`.
    - Implementació del mètode `InstanciarBanderes()` que selecciona el prefab basant-se en els colors de la sala.
    - Lògica de posicionament a `PuntSpawn_Equip1` i `PuntSpawn_Equip2` amb un offset de +2 en l'eix X.
- **MenuManager (Unity)**:
    - Emmagatzematge de les dades completes de la sala actual (`currentRoomData`) per permetre l'accés als colors d'equip des del `GameManager`.

## Capabilities

### New Capabilities
- `flag-instantiation`: Selecció i instanciació dinàmica de banderes basades en dades de xarxa.

### Modified Capabilities
- `color-based-spawn`: S'estén per incloure la lògica d'accessibilitat a les dades de la sala (colors d'equip).

## Impact

- `GameManager.cs`: Nova funcionalitat d'instanciació d'objectes estàtics/dinàmics de partida.
- `MenuManager.cs`: Nova variable pública per exposar l'estat de la sala.
- Escena de Joc: Aparició de les banderes en iniciar la partida.
