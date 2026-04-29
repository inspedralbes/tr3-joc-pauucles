## ADDED Requirements

### Requirement: Seguiment dinàmic del jugador
La bandera (Dino) HA DE seguir al jugador que la posseeix de manera física i fluida, mantenint una distància de seguretat per no superposar-se directament.

#### Scenario: Inici del seguiment
- **WHEN** El jugador agafa la bandera mitjançant el mètode `AgafarBandera()`.
- **THEN** La bandera rep la referència del Transform del jugador i comença a moure's cap a ell sense ser-ne "parent".

#### Scenario: Moviment de seguiment
- **WHEN** El jugador es mou pel mapa.
- **THEN** La bandera utilitza `SmoothDamp` per moure's cap a una posició lleugerament endarrerida respecte la direcció del moviment del jugador.

### Requirement: Estats d'animació de la mascota
La mascota HA DE reflectir el seu estat de moviment a través de l'animador.

#### Scenario: Estat de córrer
- **WHEN** La velocitat lineal de la bandera és superior a un llindar mínim (ex: 0.1f).
- **THEN** El paràmetre `isRunning` de l'Animator es posa a `true`.

#### Scenario: Estat de tristesa (Quiet)
- **WHEN** El jugador objectiu del seguiment està quiet o la bandera ha arribat a la seva posició de destí.
- **THEN** El paràmetre `isSad` de l'Animator es posa a `true` i `isRunning` a `false`.

### Requirement: Orientació visual (Flip)
La mascota HA DE mirar cap a la direcció del seu propi moviment per mantenir la coherència visual.

#### Scenario: Gir a l'esquerra
- **WHEN** El moviment horitzontal de la bandera és cap a l'esquerra.
- **THEN** El `localScale` o la propietat `flipX` del SpriteRenderer s'ajusta per mirar a l'esquerra.

#### Scenario: Gir a la dreta
- **WHEN** El moviment horitzontal de la bandera és cap a la dreta.
- **THEN** El `localScale` o la propietat `flipX` del SpriteRenderer s'ajusta per mirar a la dreta.
