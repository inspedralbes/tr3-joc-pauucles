## ADDED Requirements

### Requirement: Mapatge de prefabs de skin
El `GameManager` SHALL proporcionar referències individuals per a cadascuna de les 6 skins de personatge.
- Biker
- Cyborg
- GraveRobber
- Punk
- SteamMan
- Woodcutter

#### Scenario: Assignació de prefab Woodcutter
- **WHEN** L'usuari té equipada la skin "Woodcutter".
- **THEN** El `GameManager` retorna el `prefabWoodcutter`.

#### Scenario: Assignació de prefab Punk
- **WHEN** L'usuari té equipada la skin "Punk".
- **THEN** El `GameManager` retorna el `prefabPunk`.

### Requirement: Neteja de prefabs obsolets
El sistema SHALL eliminar qualsevol referència a prefabs de jugador que estiguin lligats directament a un color d'equip (excepte les banderes).

#### Scenario: Intent d'ús de prefabRojo
- **WHEN** El programador revisa el `GameManager.cs`.
- **THEN** La variable `prefabRojo` no ha d'existir ni estar disponible.
