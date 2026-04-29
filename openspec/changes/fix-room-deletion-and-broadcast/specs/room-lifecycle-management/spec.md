## ADDED Requirements

### Requirement: Eliminació per host
El sistema SHALL eliminar completament una sala de la base de dades si el jugador que l'abandona és el `host`.

#### Scenario: Host abandona la sala
- **WHEN** El jugador que és el `host` de la sala envia un missatge `leave_room`.
- **THEN** La sala s'elimina de la base de dades i es notifica a tots els jugadors restants.

### Requirement: Eliminació per sala buida
El sistema SHALL eliminar completament una sala de la base de dades si, després que un jugador l'abandoni, la llista de jugadors (`players`) queda buida.

#### Scenario: Últim jugador abandona la sala
- **WHEN** L'últim jugador d'una sala envia un missatge `leave_room`.
- **THEN** La sala s'elimina de la base de dades.
