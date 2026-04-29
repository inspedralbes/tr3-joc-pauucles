## MODIFIED Requirements

### Requirement: Navegació híbrida caminant/levitació
El sistema de navegació de la mascota HA DE ser capaç de canviar dinàmicament entre caminar per terra i levitar en l'aire segons la configuració del terreny i la posició del jugador.

#### Scenario: Transició a Levitació per altura
- **WHEN** La mascota detecta que el jugador es troba a una altura vertical superior a 2 unitats (Y > 2f) respecte la seva posició.
- **THEN** La mascota HA DE desactivar la seva gravetat (`gravityScale = 0`) i moure's directament cap al jugador.

#### Scenario: Transició a Levitació per bloqueig
- **WHEN** El camí horitzontal de la mascota està bloquejat per un obstacle alt (més que un esglaó) I el jugador es troba a l'altre costat.
- **THEN** La mascota HA DE levitar per sobre de l'obstacle per arribar al jugador.

#### Scenario: Retorn al mode Caminar
- **WHEN** La mascota es troba a prop del jugador I està sobre una plataforma sòlida (terra ferm).
- **THEN** La mascota HA DE reactivar la seva gravetat (`gravityScale = 1`).

### Requirement: Lògica de salts restrictiva
La mascota HA DE restringir l'ús de salts físics només per a la navegació immediata sobre petits esglaons, delegant el moviment vertical complex a la levitació.

#### Scenario: Salt d'esglaó petit
- **WHEN** La mascota detecta un obstacle a terra que pot ser superat amb un salt simple I no es requereix levitació.
- **THEN** La mascota realitza un salt físic.
