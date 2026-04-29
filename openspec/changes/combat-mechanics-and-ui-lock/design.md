## Context

S'ha detectat que la interfície del minijoc pot aparèixer en moments no desitjats o barrejar referències si no es bloqueja adequadament des de l'inici. A més, el flux de combat actual no penalitza suficientment el perdedor ni premia el guanyador, especialment pel que fa a la possessió de la bandera.

## Goals / Non-Goals

**Goals:**
- Garantir que la UI estigui completament bloquejada (`display: None`) fins que s'iniciï un combat.
- Implementar un càstig de derrota que immobilitzi el perdedor.
- Permetre que el guanyador robe la bandera si el perdedor la portava.

**Non-Goals:**
- Canviar el sistema de detecció de col·lisions.
- Implementar nous minijocs en aquest canvi.

## Decisions

- **Bloqueig del Root Element**: En lloc de confiar només en l'ocultació de contenidors fills, s'actuarà directament sobre el `rootVisualElement` del `UIDocument` per assegurar un bloqueig total i immediat en `Awake`.
- **Mètode AplicarCastigDerrota**: Es crearà un mètode a `Player.cs` que gestioni l'estat d'immobilitat (`potMoure = false`) i apliqui els efectes visuals/temporals de la derrota.
- **Mètode RobarBandera**: Aquesta funció centralitzarà el traspàs de la referència de la bandera i l'ajust de la jerarquia del Transform en Unity, assegurant que el guanyador prengui el control del set de la bandera.
- **Separació de Responsabilitats**: El `MinijocUIManager` decidirà qui guanya i qui perd, però delegarà les conseqüències físiques als objectes `Player` mitjançant crides a mètodes específics.

## Risks / Trade-offs

- **[Risk] Bloqueig visual permanent**: Si la UI es posa a `display: None` i hi ha un error en `ShowUI`, el jugador no veurà res. -> **[Mitigation]**: S'ha d'assegurar que el canvi a `Flex` sigui la primera acció amb èxit en `ShowUI`.
- **[Risk] Traspàs de bandera fallit**: Si la bandera té scripts que depenen del parell original. -> **[Mitigation]**: S'ha de verificar la lògica del Transform i assegurar que el guanyador es converteix en el nou "parent" de la bandera.
