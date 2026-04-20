## ADDED Requirements

### Requirement: Detección por Trigger del Dinosaurio
El Agente DEBE ser capaz de detectar y recoger el dinosaurio cuando entra en contacto con su colisionador configurado como Trigger.

#### Scenario: Recogida de dinosaurio mediante Trigger
- **WHEN** el Agente entra en un área Trigger (`OnTriggerEnter2D`) de un objeto con el Tag "Dinosaurio" y `tieneDino` es false
- **THEN** se establece `tieneDino` a true, se añade una recompensa de 0.5f y se emparenta el dinosaurio al Agente centrándolo.

### Requirement: Detección por Trigger de la Base
El Agente DEBE ser capaz de entregar el dinosaurio cuando entra en contacto con el área de la base configurada como Trigger.

#### Scenario: Entrega en base mediante Trigger
- **WHEN** el Agente entra en un área Trigger (`OnTriggerEnter2D`) de un objeto con el Tag "BaseRoja" y `tieneDino` es true
- **THEN** se desvincula el dinosaurio, se añade una recompensa de 1f y se finaliza el episodio exitosamente.

### Requirement: Consistencia entre Colisión y Trigger
El sistema DEBE aplicar la misma lógica de negocio independientemente de si el contacto se produce por una colisión física sólida (`OnCollisionEnter2D`) o por un disparador de área (`OnTriggerEnter2D`).

#### Scenario: Intercambiabilidad de detección
- **WHEN** un dinosaurio es un objeto sólido o un Trigger
- **THEN** el comportamiento del Agente al tocarlo es idéntico en términos de posesión y recompensas.
