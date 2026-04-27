## ADDED Requirements

### Requirement: Traçabilitat de Sincronització de Drons
El client SHALL registrar logs detallats quan es rebin actualitzacions de moviment de drons per facilitar el diagnòstic de desincronitzacions.

#### Scenario: Recepció correcta de DRONE_MOVE
- **WHEN** el client rep un paquet JSON amb tipus `DRONE_MOVE`
- **THEN** el sistema SHALL emetre un log amb l'ID de l'equip i la posició rebuda abans d'intentar aplicar-la.

### Requirement: Garantia d'Interpolació Visual
Els drons remots MUST interpolar la seva posició de forma suau cap a l'última posició rebuda per la xarxa.

#### Scenario: Moviment visual de dron remot
- **WHEN** un dron té l'estat `isRemote` activat i ha rebut una `targetPosition`
- **THEN** el sistema SHALL aplicar un `Vector3.Lerp` constant cap a aquesta posició en cada frame de `Update`.
