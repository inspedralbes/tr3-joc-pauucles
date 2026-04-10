## Why

Es vol millorar la l'experiència de desenvolupament i jugabilitat limitant la ruleta als minijocs ja implementats, evitant empats buits. També cal millorar l'accessibilitat mitjançant el suport de teclat per al minijoc AturaBarra i assegurar la visibilitat dels elements de la UI forçant propietats de layout.

## What Changes

- **Limitació de la Ruleta**: La selecció aleatòria de minijocs es restringirà temporalment als IDs 1, 2 i 3.
- **Suport de Teclat (AturaBarra)**: S'implementarà la detecció de la tecla Espai per aturar la fletxa, replicant el comportament del botó físic.
- **Correcció de Visibilitat (ZonaObjectiu)**: Es forçarà `style.top = 0` en posicionar la `ZonaObjectiu` per evitar errors de renderitzat que l'ocultin.

## Capabilities

### New Capabilities
- `uimanager-keyboard-input`: Suport per a entrades de teclat en la gestió de minijocs.

### Modified Capabilities
- `minijoc-selection-roulette`: Restricció del rang de selecció aleatòria.
- `minijoc-atura-barra-mechanics`: Millora en la robustesa visual i interacció de la zona objectiu.

## Impact

- **MinijocUIManager.cs**: Modificació de la lògica de `Random.Range`, addició de detecció d'input a l' `Update` i ajust de les propietats d'estil de la `ZonaObjectiu`.
- **Gameplay**: Els jugadors podran usar l'espai per jugar al minijoc 3, i s'evitaran els minijocs no implementats.
