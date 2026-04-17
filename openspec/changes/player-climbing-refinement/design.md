## Context

El sistema actual utilitza variables en català per a la lògica d'escalada i no actualitza el booleà d'escalada a l'Animator.

## Goals / Non-Goals

**Goals:**
- Unificar la nomenclatura de variables a l'anglès (`isNearLadder`, `isClimbing`, `defaultGravity`).
- Implementar la detecció d'escala mitjançant triggers.
- Controlar la gravetat de forma dinàmica durant l'escalada.
- Connectar l'estat d'escalada amb l'Animator.

## Decisions

- **Nomenclatura**: Substituir `tocantEscala` per `isNearLadder` i `escalant` per `isClimbing` per mantenir consistència amb la resta del projecte.
- **Detecció**: Utilitzar `OnTriggerEnter2D` i `OnTriggerExit2D` amb el tag "ZonaEscalera".
- **Activació**: L'escalada s'activa si el jugador està a prop de l'escala i detectem input vertical (`Mathf.Abs(verticalInput) > 0.1f`).
- **Física**: Quan `isClimbing` és true, `gravityScale` es posa a 0 i s'aplica velocitat vertical directa.

## Risks / Trade-offs

- **[Risk]** Conflicte amb la lògica de salt si no es neteja correctament l'estat en sortir. → **Mitigation**: Assegurar que `isClimbing` es posa a `false` en el `OnTriggerExit2D`.
