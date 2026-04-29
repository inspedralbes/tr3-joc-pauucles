## ADDED Requirements

### Requirement: Game Repository CRUD Validation
La suite de tests SHALL validar que el `GameRepositoryMongo` pot crear una sala, recuperar-la per ID i eliminar-la correctament.

#### Scenario: Create and Fetch Game
- **WHEN** es crida a `create` en el GameRepository i després a `findById`
- **THEN** l'objecte retornat coincideix amb el que s'ha enviat a crear

### Requirement: Result Repository Persistence
La suite de tests SHALL validar que el `ResultRepositoryMongo` guarda els resultats de les partides i permet la seva consulta posterior.

#### Scenario: Save Result
- **WHEN** es guarda un resultat nou
- **THEN** es pot recuperar de la base de dades utilitzant el repositori
