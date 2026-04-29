## Context

El `MinijocUIManager` gestiona la resolució dels combats. Actualment, el tancament prematur en cas d'empat i l'ús de noms genèrics ("J1", "J2") en els missatges de resultat resten claredat i continuïtat a l'experiència de joc. Es proposa una refactorització menor per millorar aquests aspectes visuals i de flux.

## Goals / Non-Goals

**Goals:**
- Implementar un bucle de reintent immediat per als empats en minijocs de selecció.
- Integrar els noms dels GameObjects dels jugadors en les cadenes de text de resultat.
- Reiniciar correctament les variables d'elecció en cas d'empat.

**Non-Goals:**
- Modificar la lògica de victòria/derrota base (PPTLLS o Parells/Senars).
- Canviar l'estètica general dels contenidors de la UI.

## Decisions

- **Control de Flux d'Empat**: En lloc de cridar a `MostrarResultatIEsperar` (que acaba en `HideUI`), es crearà un cas específic per a l'empat que només actualitzi el text i faci el reset de variables. Això manté la UI oberta i els jugadors inmobilitzats (`potMoure = false`).
- **Interpolació de Strings amb `name`**: S'utilitzaran expressions com `${guanyador.name}` per generar els missatges, garantint que el feedback és personalitzat segons el personatge que estigui jugant (ex: "Circle", "Square", etc.).
- **Reset de Variables d'Elecció**: Es garantirà que `_eleccioPPTLLS_J1` i similars es posin a `null` immediatament després de detectar l'empat per permetre que els callbacks dels botons tornin a ser efectius.

## Risks / Trade-offs

- **[Risk] Bucle d'empats infinit**: Els jugadors podrien empatar moltes vegades seguides. -> **[Mitigation]**: És part de la mecànica del joc (com en un PPT real), no bloqueja el motor de joc ja que només afecta als dos jugadors en combat.
- **[Risk] Noms de jugadors massa llargs**: Si un GameObject té un nom molt llarg, podria desbordar el Label. -> **[Mitigation]**: S'assumeix que els noms són curts (tipus de forma o ID de jugador). Si calgués, es podria limitar la mida del text en el Label.
