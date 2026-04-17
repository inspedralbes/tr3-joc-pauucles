## ADDED Requirements

### Requirement: Actualització de l'estat d'animació del jugador
El sistema ha d'actualitzar els paràmetres de l'Animator del jugador basant-se en la seva velocitat actual i si està tocant el terra.

#### Scenario: El jugador es mou horitzontalment
- **WHEN** la velocitat horitzontal del Rigidbody2D (`Mathf.Abs(rb.linearVelocity.x)`) és superior a 0.1
- **THEN** el paràmetre `isRunning` de l'Animator s'ha de posar a `true`

#### Scenario: El jugador està quiet horitzontalment
- **WHEN** la velocitat horitzontal del Rigidbody2D (`Mathf.Abs(rb.linearVelocity.x)`) és inferior o igual a 0.1
- **THEN** el paràmetre `isRunning` de l'Animator s'ha de posar a `false`

#### Scenario: El jugador salta o cau
- **WHEN** el valor de `rb.linearVelocity.y` canvia
- **THEN** el paràmetre `yVelocity` de l'Animator s'ha d'actualitzar amb aquest valor

#### Scenario: El jugador toca el terra
- **WHEN** la variable `isGrounded` és `true`
- **THEN** el paràmetre `isGrounded` de l'Animator s'ha de posar a `true`

#### Scenario: El jugador està a l'aire
- **WHEN** la variable `isGrounded` és `false`
- **THEN** el paràmetre `isGrounded` de l'Animator s'ha de posar a `false`
