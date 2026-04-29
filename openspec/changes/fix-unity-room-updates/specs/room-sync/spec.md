## ADDED Requirements

### Requirement: Deserialització de llista de sales
El client Unity SHALL ser capaç de deserialitzar correctament el missatge JSON de tipus `ACTUALITZAR_SALES` enviat pel backend.
L'estructura de dades ha de tenir una clau `sales` que contingui un array d'objectes `GameData`.

#### Scenario: Recepció de llista de sales
- **WHEN** El servidor envia un missatge amb `type: "ACTUALITZAR_SALES"` i una llista de sales a la clau `sales`.
- **THEN** El client parseja el missatge i actualitza la visualització del Lobby cridant a `ConfigurarLlistaPartides`.

### Requirement: Deserialització d'actualització de sala
El client Unity SHALL ser capaç de deserialitzar correctament el missatge JSON de tipus `ROOM_UPDATED` enviat pel backend.
L'estructura de dades ha de tenir una clau `room` que contingui un objecte `GameData`.

#### Scenario: Recepció d'actualització de sala
- **WHEN** El servidor envia un missatge amb `type: "ROOM_UPDATED"` i les dades de la sala a la clau `room`.
- **THEN** El client parseja el missatge, verifica si correspon a la sala actual (`currentRoomId`) i actualitza la llista de jugadors cridant a `OmplirLlistaJugadors`.

### Requirement: Gestió de missatges en el fil principal
Totes les actualitzacions de la UI derivades dels missatges de WebSocket SHALL executar-se en el fil principal d'Unity utilitzant `EnqueueMainThread`.

#### Scenario: Actualització segura de la UI
- **WHEN** Es rep un missatge de WebSocket (que arriba en un fil secundari).
- **THEN** El client encapsula la crida a la funció de repintat de la UI dins de `EnqueueMainThread`.
