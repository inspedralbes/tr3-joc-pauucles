## Why

El mecanisme actual de recollida manual (prémer 'E' o 'RightControl') resulta menys fluid i pot causar errors si el jugador no prem la tecla en el moment precís del contacte. La recollida automàtica millora el flux de joc assegurant que la bandera s'agafi instantàniament en tocar-la.

## What Changes

- **Eliminació de variables de proximitat**: Es borraran `aPropDeBandera` i `banderaPropera` de `Player.cs`.
- **Eliminació de la recollida manual**: Es borrarà la funció `RecollirBanderaManualment` i la lògica de detecció de tecles a l'`Update`.
- **Implementació de recollida automàtica**: S'afegirà lògica a `OnTriggerEnter2D` i `OnCollisionEnter2D` per agafar la bandera immediatament en el contacte.
- **Correcció d'estat de la bandera**: S'assegurarà que en agafar-la, l'estat `fugint` de la bandera sigui `false` i el seu collider es desactivi.
- **BREAKING**: Les tecles E i RightControl ja no serviran per recollir la bandera manualment.

## Capabilities

### New Capabilities
- `automatic-flag-pickup`: La bandera s'ha d'unir al jugador immediatament en entrar en contacte (Trigger o Col·lisió), desactivant el seu collider i posicionant-la correctament.

### Modified Capabilities
- Cap (No hi ha especificacions prèvies de recollida de bandera en `openspec/specs/`).

## Impact

- `Player.cs`: Simplificació del codi eliminant la lògica manual i afegint gestors de col·lisió automàtics.
- Gameplay: Jugabilitat més ràpida i intuïtiva per als jugadors.
