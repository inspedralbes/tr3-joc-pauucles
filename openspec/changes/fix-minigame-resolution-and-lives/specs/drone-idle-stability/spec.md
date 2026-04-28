## ADDED Requirements

### Requirement: Inmovilización del Dron en Reposo
El sistema SHALL forzar al dron a un estado estático cuando su objetivo primario esté en la base.

#### Scenario: Dinosaurio en base
- **WHEN** el dinosaurio se encuentra en la base (`A_Salvo`) y el dron no lo transporta
- **THEN** el sistema SHALL establecer la velocidad del `Rigidbody2D` a cero y desactivar el componente de toma de decisiones.

### Requirement: Temporizador de Minijuego Absoluto
El sistema SHALL prohibir el reinicio del temporizador local ante actualizaciones de red externas.

#### Scenario: Recepción de actualización de minijuego
- **WHEN** se recibe un mensaje de actualización de estado del minijuego desde otro cliente
- **THEN** el sistema SHALL sincronizar los datos de juego pero NO reiniciar el tiempo restante del temporizador.
