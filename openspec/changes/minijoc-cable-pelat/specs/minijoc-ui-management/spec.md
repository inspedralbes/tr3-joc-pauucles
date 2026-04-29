## ADDED Requirements

### Requirement: Ampliació de la ruleta de minijocs
El sistema HA D'ampliar el rang de selecció aleatòria per incloure nous minijocs.

#### Scenario: Selecció del minijoc Cable Pelat
- **WHEN** El sistema realitza el `Random.Range` (fins a 7).
- **THEN** Es pot obtenir el valor 6 que activa el minijoc "Cable Pelat".

### Requirement: Activació del contenidor Cable Pelat
El sistema HA D'activar el contenidor UI corresponent al minijoc seleccionat i amagar els altres.

#### Scenario: Activació del contenidor #ContenidorCablePelat
- **WHEN** La ruleta selecciona el cas 6.
- **THEN** S'activa l'element `#ContenidorCablePelat` i es desactiven la resta de contenidors de minijocs.

### Requirement: Inicialització de la lògica del minijoc
El sistema HA DE cercar el component de lògica i cridar al seu mètode d'inicialització UI.

#### Scenario: Inicialització de MinijocCablePelatLogic
- **WHEN** El contenidor `#ContenidorCablePelat` és seleccionat.
- **THEN** El sistema busca el component `MinijocCablePelatLogic` i executa `InicialitzarUI` passant el contenidor arrel.
