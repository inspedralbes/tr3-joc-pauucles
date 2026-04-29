## ADDED Requirements

### Requirement: Escala de la bandera en la recollida
El sistema HA DE fixar l'escala de la bandera a `(3, 3, 1)` immediatament després de fer-la filla del jugador (`SetParent`).

#### Scenario: Recollida de bandera amb escala correcta
- **WHEN** el jugador recull la bandera (automàticament o en un robatori)
- **THEN** la bandera HA DE ser reparentada al jugador I la seva `localScale` HA DE ser fixada a `new Vector3(3f, 3f, 1f)`.
