## MODIFIED Requirements

### Requirement: Sincronització de moviment en temps real
El sistema SHALL permetre que un client enviï la seva posició i estat d'animació al servidor i que aquest els retransmeti als altres clients de la mateixa sala.

#### Scenario: Enviament de moviment local
- **WHEN** El jugador local es mou o canvia d'animació.
- **THEN** El client envia un missatge `PLAYER_MOVE` utilitzant la connexió gestionada pel `MenuManager`.

#### Scenario: Recepció de moviment remot
- **WHEN** Es rep un missatge `PLAYER_MOVE` a través del `MenuManager`.
- **THEN** Les dades es redirigeixen al `GameManager` per actualitzar la representació visual del jugador remot corresponent.
