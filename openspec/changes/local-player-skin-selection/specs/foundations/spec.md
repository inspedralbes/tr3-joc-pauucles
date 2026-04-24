## ADDED Requirements

### Requirement: Unified Player Spawn Flow
Tota instanciació de jugador SHALL centralitzar-se en un mètode que verifiqui els paràmetres de personalització abans de crear l'objecte a l'escena.

#### Scenario: Spawn call
- **WHEN** es crida a la funció de spawn
- **THEN** s'ha d'executar la cerca de skin abans de l' `Instantiate`
