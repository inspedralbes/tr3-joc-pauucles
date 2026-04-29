## ADDED Requirements

### Requirement: Movimiento de Plataformas en Acción
El Agente DEBE responder a acciones discretas para moverse a la izquierda y derecha, preservando la inercia vertical proporcionada por la gravedad.

#### Scenario: Movimiento hacia la derecha
- **WHEN** se recibe un valor de acción discreta de 2
- **THEN** la componente horizontal de la velocidad se establece en `moveSpeed` y la componente vertical mantiene su valor actual.

### Requirement: Lógica de Salto
El Agente DEBE ser capaz de saltar aplicando una fuerza impulsiva hacia arriba cuando se detecte que está en contacto con el suelo.

#### Scenario: Salto exitoso
- **WHEN** se recibe un valor de acción discreta de 3 y la velocidad vertical es menor a 0.05f en valor absoluto
- **THEN** se aplica un impulso vertical mediante `AddForce` y se activa el trigger "Jump" en el Animator.

### Requirement: Sincronización con Animator
El Agente DEBE actualizar dinámicamente el parámetro "Speed" del Animator basándose en su movimiento horizontal efectivo.

#### Scenario: Actualización de animación de correr
- **WHEN** el agente se mueve horizontalmente (moveX != 0)
- **THEN** el parámetro flotante "Speed" del Animator se actualiza con el valor absoluto de la dirección de movimiento.

### Requirement: Control Heurístico de Plataformas
El sistema DEBE permitir controlar manualmente el movimiento lateral y el salto del agente mediante el teclado.

#### Scenario: Entrada de teclado para salto
- **WHEN** el usuario presiona la tecla Espacio o la flecha arriba
- **THEN** se asigna el valor de acción 3 al búfer de acciones discretas del agente.
