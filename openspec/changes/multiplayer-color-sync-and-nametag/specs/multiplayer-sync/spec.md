## MODIFIED Requirements

### Requirement: Sincronització de moviment en temps real
El sistema SHALL permetre que un client enviï la seva posició i estat d'animació al servidor i que aquest els retransmeti als altres clients de la mateixa sala.

#### Scenario: Transmissió del bit de gir
- **WHEN** El jugador local canvia d'orientació.
- **THEN** El missatge `PLAYER_MOVE` inclou el valor de `flipX`.
- **THEN** El client receptor aplica `flipX` al `SpriteRenderer` del jugador remot corresponent sense modificar l'escala.
