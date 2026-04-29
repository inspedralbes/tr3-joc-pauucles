## ADDED Requirements

### Requirement: Actualització reactiva de la llista de sales
El sistema SHALL actualitzar la visualització de les sales disponibles al Lobby de forma immediata en rebre un missatge de xarxa de tipus `ACTUALITZAR_SALES`.

#### Scenario: Recepció de nova llista de sales
- **WHEN** El servidor envia un missatge broadcast `ACTUALITZAR_SALES` amb l'array de sales actualitzat.
- **THEN** El client Unity reconstrueix la llista visual (`ListView`) mostrant el recompte correcte de jugadors i les noves sales.

### Requirement: Sincronització de la sala d'espera (Waiting Room)
El sistema SHALL refrescar la llista de jugadors connectats a la sala actual en rebre un esdeveniment de canvi a la sala (`ROOM_UPDATED`).

#### Scenario: Entrada d'un nou jugador a la sala
- **WHEN** Un segon jugador s'uneix a la sala del creador i el servidor envia `ROOM_UPDATED`.
- **THEN** El creador de la sala veu aparèixer el nom del nou jugador a la llista `llistaJugadorsSala` sense necessitat d'intervenció manual.

### Requirement: Execució de UI al Main Thread
Totes les modificacions del VisualTree d'Unity derivades de missatges de WebSocket SHALL executar-se obligatòriament al fil principal.

#### Scenario: Gestió de fils per a actualitzacions visualitzades
- **WHEN** Es rep un missatge de WebSocket en un fil secundari.
- **THEN** El sistema encapsula la lògica de repintat de la UI a la cua `_executionQueue` perquè sigui processada pel mètode `Update` (Main Thread).
