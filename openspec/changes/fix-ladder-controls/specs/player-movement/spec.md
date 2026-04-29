## ADDED Requirements

### Requirement: Control de entrada para escalada
El sistema DEBE permitir iniciar la escalada si el jugador está en contacto con una escalera (`tocantEscala`) y pulsa la tecla de Salto (Espacio) o la dirección Arriba.

#### Scenario: Iniciar escalada con Espacio
- **WHEN** el jugador está tocando una escalera y pulsa el botón de Salto
- **THEN** el estado del jugador cambia a `escalant`

#### Scenario: Iniciar escalada con Arriba
- **WHEN** el jugador está tocando una escalera y pulsa la dirección Arriba
- **THEN** el estado del jugador cambia a `escalant`

### Requirement: Restricción de salto en escaleras
El sistema NO DEBE permitir el salto normal cuando el jugador está en contacto con una escalera (`tocantEscala`), para reservar el botón de Salto para la acción de escalada.

#### Scenario: Intento de salto en escalera
- **WHEN** el jugador está tocando una escalera y pulsa el botón de Salto
- **THEN** el jugador NO aplica fuerza de salto vertical y entra en estado de escalada

### Requirement: Movimiento vertical en escalera
Cuando el jugador está en estado `escalant`, la velocidad vertical DEBE ser controlada por la entrada del usuario.

#### Scenario: Subir por la escalera
- **WHEN** el jugador está escalando y pulsa Espacio o Arriba
- **THEN** el jugador se mueve hacia arriba con velocidad `climbSpeed`

#### Scenario: Bajar por la escalera
- **WHEN** el jugador está escalando y pulsa Abajo
- **THEN** el jugador se mueve hacia abajo con velocidad `climbSpeed`

#### Scenario: Mantenerse quieto en la escalera
- **WHEN** el jugador está escalando y no pulsa ninguna tecla de dirección vertical ni Salto
- **THEN** la velocidad vertical del jugador DEBE ser 0 (se queda quieto)
