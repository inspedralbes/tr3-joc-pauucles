## MODIFIED Requirements

### Requirement: Alliberament de la bandera
El sistema HA DE permetre l'alliberament controlat de la bandera, assegurant que tant el jugador com la mascota aturin les seves lògiques de seguiment i moviments associats.

#### Scenario: Aturar seguiment de la mascota
- **WHEN** El mètode `DeixarDeSeguir` és cridat a `Bandera.cs`.
- **THEN** La referència `targetSeguiment` HA DE ser nul·la i la velocitat horitzontal del Rigidbody2D HA DE ser zero.

#### Scenario: Alliberament de referència del jugador
- **WHEN** El mètode `DeixarBandera` és cridat a `Player.cs`.
- **THEN** El sistema HA DE notificar a la mascota que deixi de seguir i HA DE posar la referència `banderaAgafada` a nul.
