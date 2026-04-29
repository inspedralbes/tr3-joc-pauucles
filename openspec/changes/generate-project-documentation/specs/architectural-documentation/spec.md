## ADDED Requirements

### Requirement: Repository Pattern Explanation
El fitxer `PATTERN_REPOSITORY.md` SHALL detallar la implementació del patró Repository, explicant la separació entre la interfície i les implementacions concretes.

#### Scenario: Code Example Presence
- **WHEN** es llegeix el document del patró
- **THEN** s'han de trobar fragments de codi que mostrin la versió "In-Memory" i la versió "Mongo"

### Requirement: Service Domain Separation
La documentació SHALL explicar la decisió de separar el backend en serveis d'identitat i de joc.

#### Scenario: Architectural Clarity
- **WHEN** un nou integrant llegeix la documentació
- **THEN** ha d'entendre per què s'utilitzen ports diferents i quina és la responsabilitat de cada servei
