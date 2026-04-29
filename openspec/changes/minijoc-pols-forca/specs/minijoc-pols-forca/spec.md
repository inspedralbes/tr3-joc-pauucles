## ADDED Requirements

### Requirement: Lògica d'Interacció J1
El sistema HA DE detectar les entrades del Jugador 1 per sumar puntuació a J1 i restar-la a J2.

#### Scenario: Pulsació J1 (Teclat o Ratolí)
- **WHEN** `Input.GetKeyDown(KeyCode.Space)` O `Input.GetMouseButtonDown(0)` és detectat
- **THEN** la `puntuacioJ1` HA DE sumar 2, la `puntuacioJ2` HA DE restar 2, i ambdós valors s'HAN DE clampejar entre 0 i 100.

### Requirement: Lògica d'Interacció J2
El sistema HA DE detectar les entrades del Jugador 2 per sumar puntuació a J2 i restar-la a J1.

#### Scenario: Pulsació J2 (Teclat o Ratolí)
- **WHEN** `Input.GetKeyDown(KeyCode.Return)` O `Input.GetMouseButtonDown(1)` és detectat
- **THEN** la `puntuacioJ2` HA DE sumar 2, la `puntuacioJ1` HA DE restar 2, i ambdós valors s'HAN DE clampejar entre 0 i 100.

### Requirement: Gestió del Temps
El sistema HA DE gestionar un compte enrere de 10 segons i finalitzar el joc quan arribi a zero.

#### Scenario: Finalització per Temps
- **WHEN** el `tempsRestant` arriba a 0 o menys
- **THEN** el `jocActiu` HA DE passar a `false` i s'HA DE notificar el guanyador basant-se en quina puntuació és superior a 50.
