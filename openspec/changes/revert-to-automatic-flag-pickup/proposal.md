## Why

La recollida manual de la bandera per botó ha resultat ser menys intuïtiva o fluida del que s'esperava per al ritme del joc. Es desitja revertir aquest comportament a una recollida automàtica per contacte físic, assegurant que la bandera s'enganxi al jugador de forma instantània i redundant tant per col·lisió com per trigger.

## What Changes

- **Eliminació de Lògica Manual**: Es suprimeixen les variables `aPropDeBandera`, `banderaPropera` i la funció `RecollirBanderaManualment` a `Player.cs`. També es neteja l'input de tecles d'acció a l'`Update`.
- **Recollida Automàtica Redundant**:
    - S'implementa la recollida directa dins d'`OnTriggerEnter2D`.
    - S'implementa la recollida directa dins d'`OnCollisionEnter2D`.
- **Estat de la Bandera**: En ambdós casos, es desactiva el collider de la bandera un cop recollida i s'atura el seu estat fugitiu.

## Capabilities

### New Capabilities
- `automatic-flag-pickup`: Implementació de la recollida de bandera per contacte directe (col·lisió/trigger) amb desactivació de física immediata.

### Modified Capabilities
- `manual-flag-pickup`: **REMOVAL** - S'elimina la capacitat de recollir la bandera mitjançant un botó d'acció.

## Impact

- **Player.cs**: Simplificació del codi eliminant estats de proximitat i afegint lògica de recollida atòmica.
- **Gameplay**: La bandera es recull immediatament en tocar-la, sense necessitat de prémer cap tecla.
