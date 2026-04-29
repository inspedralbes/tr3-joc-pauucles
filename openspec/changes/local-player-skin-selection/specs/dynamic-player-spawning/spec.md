## ADDED Requirements

### Requirement: Skin-to-Prefab Mapping
El sistema SHALL permetre configurar una llista de mapejos entre noms de skins i prefabs des de l'inspector d'Unity.

#### Scenario: Mapping defined
- **WHEN** el desenvolupador afegeix una entrada a `skinsDisponibles`
- **THEN** s'ha de poder assignar un string (nom) i un GameObject (prefab)

### Requirement: Dynamic Instantiation
El sistema SHALL instanciar el prefab que coincideixi amb la skin desada al moment d'iniciar el jugador local.

#### Scenario: Correct prefab instantiated
- **WHEN** la skin desada és "GraveRobber" i existeix un mapeig per a aquest nom
- **THEN** s'ha d'instanciar el prefab de "GraveRobber" en lloc del prefab base

### Requirement: Camera Target Assignment
El sistema SHALL assignar l'objecte instanciat dinàmicament com a objectiu de la càmera de seguiment.

#### Scenario: Camera follows player
- **WHEN** el jugador s'instancia
- **THEN** el component de càmera (ex: Cinemachine Virtual Camera) ha d'actualitzar el seu camp `Follow` o `LookAt` amb el nou objecte
