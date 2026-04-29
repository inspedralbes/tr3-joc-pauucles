## ADDED Requirements

### Requirement: Sincronització amb Spawn Forçat de Jugadors
El sistema SHALL assegurar que tots els jugadors actius en una partida siguin visibles per a tots els clients, fins i tot si s'uneixen tard o perden paquets inicials.

#### Scenario: Recepció de PLAYER_MOVE per a jugador desconegut
- **WHEN** un client rep un missatge `PLAYER_MOVE` amb un `username` que no existeix en la seva llista local de jugadors remots
- **THEN** el sistema SHALL instanciar un nou jugador remot per a aquest `username` i afegir-lo a la gestió de xarxa.

### Requirement: Sincronització amb Spawn Forçat de Drons
El sistema SHALL assegurar que els drons siguin visibles i sincronitzats per a tots els clients.

#### Scenario: Recepció de DRONE_MOVE per a dron desconegut
- **WHEN** un client rep un missatge `DRONE_MOVE` per a un `teamId` que no té cap dron instanciat localment
- **THEN** el sistema SHALL instanciar el dron corresponent per a aquest equip.
