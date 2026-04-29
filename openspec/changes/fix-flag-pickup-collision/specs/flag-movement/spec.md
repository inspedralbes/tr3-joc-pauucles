## MODIFIED Requirements

### Requirement: Seguiment dinàmic del jugador
La bandera (Dino) HA DE seguir al jugador que la posseeix de manera física i fluida mitjançant l'aplicació de forces horitzontals, mantenint una distància mínima per evitar la superposició, i HA DE mantenir el seu collider actiu per evitar caigudes del mapa.

#### Scenario: Inici del seguiment amb col·lisió selectiva
- **WHEN** El jugador agafa la bandera mitjançant el mètode `AgafarBanderaAutomàticament()`.
- **THEN** El sistema HA D'ignorar la col·lisió entre el jugador i la bandera (`Physics2D.IgnoreCollision`) però HA DE mantenir el collider de la bandera habilitat.

#### Scenario: Moviment de seguiment basat en velocitat
- **WHEN** La distància horitzontal entre la bandera i el jugador és superior a `distanciaMinima`.
- **THEN** S'aplica una velocitat horitzontal constant (`velocitatSeguiment`) al Rigidbody2D en la direcció del jugador.

### Requirement: Superació d'obstacles
La mascota HA DE ser capaç de detectar obstacles al seu camí i saltar per over d'ells si està a terra.

#### Scenario: Salt d'obstacle
- **WHEN** Un Raycast curt detecta un obstacle (mur o escala) en la direcció del moviment I la mascota està tocant a terra.
- **THEN** S'aplica una força de salt vertical (`forçaSaltDino`) a la velocitat del Rigidbody2D.
