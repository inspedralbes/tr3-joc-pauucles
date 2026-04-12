## ADDED Requirements

### Requirement: Reseteig d'estat AFK per bloqueig de moviment
El sistema HA DE netejar l'estat d'inactivitat quan el jugador perd la capacitat de moure's (`potMoure = false`).

#### Scenario: Atura el parpelleig en entrar en combat
- **WHEN** La variable `potMoure` passa a ser `false`.
- **THEN** La variable `tempsInactiu` s'assigna a `0f`.
- **THEN** L'alpha del `SpriteRenderer` es restaura a `1f`.

### Requirement: Prevenció d'acumulació de temps inactiu
El sistema HA D'evitar que el comptador de temps inactiu s'incrementi mentre el personatge té el moviment bloquejat.

#### Scenario: El temps no corre durant el combat
- **WHEN** El jugador està en un estat on `potMoure` és `false`.
- **THEN** El sistema no realitza l'increment de `tempsInactiu` mitjançant `Time.deltaTime`.
