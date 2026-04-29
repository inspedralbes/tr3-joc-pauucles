## ADDED Requirements

### Requirement: Sincronització de moviment en temps real
El sistema SHALL permetre que un client enviï la seva posició i estat d'animació al servidor i que aquest els retransmeti als altres clients de la mateixa sala.

#### Scenario: Enviament de moviment local
- **WHEN** El jugador local es mou o canvia d'animació.
- **THEN** El client envia un missatge `PLAYER_MOVE` amb `x`, `y`, `flipX` i el nom de l'animació cada 100ms.

#### Scenario: Recepció de moviment remot
- **WHEN** El servidor rep un missatge `PLAYER_MOVE`.
- **THEN** El servidor retransmet el missatge a tots els clients connectats que estiguin a la mateixa `roomId`, excepte al remitent.

### Requirement: Orientació visual correcta
El client Unity SHALL utilitzar `SpriteRenderer.flipX` per orientar el personatge lateralment sense afectar l'escala del transform pare.

#### Scenario: Gir a l'esquerra
- **WHEN** El jugador prem la tecla de direcció esquerra.
- **THEN** El personatge mira a l'esquerra activant `flipX = true` al `SpriteRenderer`.
- **THEN** El Nametag (Canvas) manté la seva escala original i no es veu invertit.
