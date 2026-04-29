## MODIFIED Requirements

### Requirement: Inici de seguiment de la bandera
El sistema HA DE garantir que la bandera, en ser recollida, es mantingui com un objecte físic independent que segueix al jugador, evitant caigudes per falta de detecció de terra.

#### Scenario: Recollida física correcta
- **WHEN** El mètode `AgafarBandera` és cridat des de `Player.cs`.
- **THEN** La bandera HA DE tenir el seu `parent` a nul, el seu `bodyType` a `Dynamic` i HA D'iniciar la seva pròpia lògica de seguiment mitjançant l'script `Bandera`.
