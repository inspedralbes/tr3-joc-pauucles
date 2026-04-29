## ADDED Requirements

### Requirement: Detecció d'equip per al posicionament
El sistema SHALL identificar a quin equip pertany el jugador local consultant les dades de sessió emmagatzemades a `WebSocketClient`.

#### Scenario: Lectura de dades de sessió
- **WHEN** s'inicia el `GameManager` a l'escena 'Bosque'.
- **THEN** el sistema recupera la cadena de text de l'equip (ex: "Equip 1" o "Equip 2").

### Requirement: Localització de punts de spawn
El sistema SHALL ser capaç de trobar tots els punts de spawn disponibles a l'escena actual filtrant per l'equip corresponent.

#### Scenario: Cerca d'objectes per nom/tag
- **WHEN** el `GameManager` s'executa.
- **THEN** es genera una llista d'objectes transform que continguin "SpawnEquip1" per al primer equip o "SpawnEquip2" per al segon.

### Requirement: Assignació de posició aleatòria
El sistema SHALL moure el personatge principal a una de les posicions vàlides trobades, triada a l'atzar per evitar solapaments constants.

#### Scenario: Teletransport al punt triat
- **WHEN** es disposa de la llista de punts i s'ha identificat el jugador ( Woodcutter ).
- **THEN** el sistema tria un índex aleatori de la llista i iguala la posició del jugador a la del punt de spawn seleccionat.
