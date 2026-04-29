## ADDED Requirements

### Requirement: Instanciació de banderes per color d'equip
El sistema SHALL instanciar la bandera corresponent al color de cada equip en els seus punts de spawn respectius.

#### Scenario: Banderes en iniciar combat
- **WHEN** El joc s'inicialitza al mètode `Start` del `GameManager`.
- **THEN** Es llegeixen els colors de `teamAColor` i `teamBColor` des del `MenuManager`.
- **THEN** S'instancia la bandera correcta a `PuntSpawn_Equip1` i `PuntSpawn_Equip2`.

### Requirement: Selecció dinàmica de skin de jugador
El sistema SHALL permetre la instanciació d'un prefab de jugador basat en el nom de la skin.

#### Scenario: Spawn de jugador amb skin
- **WHEN** Es crida el mètode `InstanciarJugador`.
- **THEN** El sistema selecciona el prefab (Biker, Cyborg, Woodcutter, etc.) segons el paràmetre `skinName`.
- **THEN** Si no s'especifica cap skin o no es troba, s'utilitza `prefabWoodcutter` per defecte.
