## ADDED Requirements

### Requirement: Persistencia de la Velocidad Vertical
El sistema de movimiento del agente DEBE preservar la velocidad vertical actual del `Rigidbody2D` para permitir que las fuerzas externas (como la gravedad) sigan actuando sobre él.

#### Scenario: El agente cae mientras se mueve hacia la derecha
- **WHEN** el agente recibe una acción para moverse a la derecha (acción 4) y se encuentra en el aire
- **THEN** la velocidad horizontal cambia según `moveSpeed`, pero la velocidad vertical del eje Y mantiene el valor actual descendente calculado por la gravedad.

### Requirement: Control de Movimiento Lateral Exclusivo
En el contexto de un entorno con gravedad, las acciones horizontales del agente NO DEBEN interferir con su estado de caída o reposo vertical.

#### Scenario: El agente se mueve hacia la izquierda en el suelo
- **WHEN** el agente recibe una acción para moverse a la izquierda (acción 3) y está en reposo en el suelo
- **THEN** la velocidad horizontal cambia según `-moveSpeed` y la velocidad vertical permanece cercana a cero.

### Requirement: Estabilidad de la Componente Y en Reposo
El sistema DEBE evitar que el agente "flote" o se mantenga estático en el aire al aplicar cualquier acción lateral.

#### Scenario: El agente deja de moverse lateralmente
- **WHEN** el agente recibe la acción de reposo (acción 0) o no recibe acciones horizontales
- **THEN** la componente X de la velocidad se establece en cero y la componente Y sigue respondiendo a la gravedad de forma ininterrumpida.
