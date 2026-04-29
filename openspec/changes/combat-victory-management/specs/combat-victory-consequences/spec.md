## ADDED Requirements

### Requirement: Determinació de Rols de Combat
El sistema HA DE ser capaç d'identificar quin jugador és l'atacant i quin el defensor en iniciar-se un enfrontament.

#### Scenario: Assignació de Rols per Bandera
- **WHEN** un combat s'inicia entre p1 i p2
- **THEN** si un dels jugadors porta la bandera, aquest HA DE ser assignat com a `defensor` i l'altre com a `atacant`.

### Requirement: Gestió de Conseqüències de Victòria
El sistema HA DE aplicar les regles de joc corresponents un cop es notifica el guanyador del minijoc.

#### Scenario: Derrota del Defensor
- **WHEN** el `defensor` perd el combat (notificat via `FinalitzarCombat`)
- **THEN** la bandera HA DE ser desvinculada del jugador (`SetParent(null)`) i la seva referència HA DE ser netejada.

#### Scenario: Victòria del Defensor
- **WHEN** el `defensor` guanya el combat
- **THEN** la bandera HA DE romandre vinculada al defensor sense canvis.
