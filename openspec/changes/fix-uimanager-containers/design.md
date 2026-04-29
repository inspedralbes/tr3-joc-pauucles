## Context

El `MinijocUIManager` està tenint problemes per gestionar la visibilitat de les interfícies de diferents minijocs. S'han detectat casos on PPTLLS i ParellsSenars es mostren simultàniament, o on el codi no troba els contenidors per errors tipogràfics o de lògica de cerca. A més, cal reajustar els IDs de la ruleta per activar el joc de Parells o Senars quan surti l'ID 2.

## Goals / Non-Goals

**Goals:**
- Centralitzar l'ocultació de contenidors en un únic mètode.
- Corregir les queries UQuery per usar noms de contenidors exactes.
- Assignar el minijoc "Parells o Senars" a l'ID 2 de la ruleta.
- Eliminar el mecanisme de "fallback tie" per al joc 2.

**Non-Goals:**
- Canviar l'estètica dels menús.
- Implementar la lògica dels minijocs 3, 4, 5 o 6.

## Decisions

- **Mètode AmagarTotsElsContenidors**: Aquest mètode iterarà o accedirà directament a les referències `_contenidorPPTLLS` i `_contenidorParellsSenars` per posar el seu estil a `display: none`. Es cridarà tant a l'inici de `ShowUI` com al final de `HideUI`.
- **Reassignació d'IDs**: S'actualitzarà l'array `_nomsMinijocs` i el `switch` de `ShowUI` per reflectir que l'ID 2 és "ParellsSenars".
- **Queries Estrictes**: S'assegurarà que el `rootVisualElement` és consultat només quan l'objecte està actiu, i es verificaran les claus exactes del fitxer UXML.

## Risks / Trade-offs

- **[Risk] Sync amb UXML**: Si el fitxer UXML encara té noms diferents als especificats, el log d'error seguirà apareixent. -> **[Mitigation]**: S'ha de verificar el fitxer `.uxml` manualment o mitjançant l'agent si hi ha accés.
