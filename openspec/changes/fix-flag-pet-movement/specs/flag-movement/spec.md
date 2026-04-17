## MODIFIED Requirements

### Requirement: Seguiment dinàmic del jugador
La bandera (Dino) HA DE seguir al jugador que la posseeix de manera física i fluida mitjançant l'aplicació de forces horitzontals, mantenint una distància mínima per evitar la superposició.

#### Scenario: Inici del seguiment
- **WHEN** El jugador agafa la bandera mitjançant el mètode `AgafarBandera()`.
- **THEN** La bandera rep la referència del Transform del jugador i comença a moure's cap a ell de manera independent (sense ser fill del jugador).

#### Scenario: Moviment de seguiment basat en velocitat
- **WHEN** La distància horitzontal entre la bandera i el jugador és superior a `distanciaMinima`.
- **THEN** S'aplica una velocitat horitzontal constant (`velocitatSeguiment`) al Rigidbody2D en la direcció del jugador.

### Requirement: Superació d'obstacles
La mascota HA DE ser capaç de detectar obstacles al seu camí i saltar per sobre d'ells si està a terra.

#### Scenario: Salt d'obstacle
- **WHEN** Un Raycast curt detecta un obstacle (mur o escala) en la direcció del moviment I la mascota està tocant a terra.
- **THEN** S'aplica una força de salt vertical (`forçaSaltDino`) a la velocitat del Rigidbody2D.

## REMOVED Requirements

### Requirement: Estat de tristesa (Quiet)
**Reason**: Simplificació del comportament visual de la mascota per centrar-se en la funcionalitat de moviment i evitar estats d'animació conflictius.
**Migration**: S'utilitzarà principalment `isRunning` basat en el moviment horitzontal real.

### Requirement: Parpelleig AFK del jugador
**Reason**: La gestió de la inactivitat s'ha eliminat per evitar alteracions visuals no desitjades en el color del SpriteRenderer.
**Migration**: Eliminació del bloc de codi corresponent a `Player.cs`.
