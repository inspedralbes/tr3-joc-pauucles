## ADDED Requirements

### Requirement: Disparador d'inici de partida
El servidor SHALL canviar l'status de la sala a `playing` quan es compleixin les condicions de consens i capacitat.

#### Scenario: Tots els jugadors llestos
- **WHEN** el nombre de jugadors de la sala arriba al `maxPlayers` i tots tenen l'estat `isReady: true`.
- **THEN** el sistema persisteix l'estat `playing` a MongoDB i emet la notificació d'inici.

### Requirement: Notificació d'inici sincronitzada
El sistema SHALL enviar a cada client les seves dades individuals de sessió un cop s'inicia la partida per permetre la configuració local.

#### Scenario: Recepció de PARTIDA_INICIADA
- **WHEN** la partida comença al backend.
- **THEN** el servidor envia el missatge JSON amb el tipus `PARTIDA_INICIADA`, incloent `username`, `team` i `color`.

### Requirement: Gestió visual i de flux a Unity
El client d'Unity SHALL reaccionar al missatge d'inici amagant la interfície i carregant l'escena de joc de forma asíncrona des del fil principal.

#### Scenario: Transició d'escena fluida
- **WHEN** `WebSocketClient.cs` processa `PARTIDA_INICIADA`.
- **THEN** s'enregistra un log, s'activa el flag `shouldStartGame`, el `MenuManager.cs` amaga tota la UI i finalment es carrega l'escena "Bosque".
