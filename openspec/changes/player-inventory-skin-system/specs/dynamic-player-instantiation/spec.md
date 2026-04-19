## ADDED Requirements

### Requirement: Instanciació basada en skin
El `GameManager` SHALL instanciar el prefab de jugador que correspongui a la `skinEquipada` de l'usuari (tant local com remots).

#### Scenario: Spawn del jugador local amb skin personalitzada
- **WHEN** S'inicia l'escena de joc (Bosque)
- **THEN** El `GameManager` consulta la `skinEquipada` de l'usuari local i instancia el prefab associat a aquest nom
- **THEN** S'hi afegeix el component `NetworkSync` per sincronitzar-ne el moviment

#### Scenario: Spawn de jugadors remots amb skins
- **WHEN** Es rep un missatge de moviment o presència d'un nou jugador remot
- **THEN** El sistema instancia el prefab corresponent a la skin que l'usuari remot té equipada
