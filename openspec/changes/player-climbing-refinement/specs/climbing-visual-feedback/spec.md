## ADDED Requirements

### Requirement: Feedback visual d'escalada
El sistema ha d'informar a l'Animator sobre l'estat d'escalada del jugador.

#### Scenario: El jugador comença a escalar
- **WHEN** el jugador està a prop d'una escala i prem el control vertical
- **THEN** el paràmetre `isClimbing` de l'Animator s'ha de posar a `true`

#### Scenario: El jugador deixa d'escalar
- **WHEN** el jugador surt de la zona de l'escala
- **THEN** el paràmetre `isClimbing` de l'Animator s'ha de posar a `false`
