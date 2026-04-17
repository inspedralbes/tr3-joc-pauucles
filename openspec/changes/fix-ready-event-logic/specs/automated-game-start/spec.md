## ADDED Requirements

### Requirement: Validació d'inici de partida
El sistema SHALL verificar si es compleixen totes les condicions per començar la partida immediatament després de qualsevol actualització de l'estat `READY`.

#### Scenario: Inici de partida automàtic
- **WHEN** el nombre de jugadors a la sala és igual al `maxPlayers` i TOTS els jugadors tenen `isReady: true`.
- **THEN** el sistema canvia l'status de la sala a `playing` i crida a `await room.save()`.

### Requirement: Notificació de PARTIDA_INICIADA
El sistema SHALL notificar a tots els clients quan la partida ha començat oficialment al servidor, enviant les dades de configuració personalitzades.

#### Scenario: Broadcast de PARTIDA_INICIADA
- **WHEN** l'status de la sala passa a `playing`.
- **THEN** el servidor emet el missatge `PARTIDA_INICIADA` per WebSocket incloent el nom d'usuari, l'equip i el color assignat de cada participant.
