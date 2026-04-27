## ADDED Requirements

### Requirement: Sincronización de Posición de Drones
El sistema DEBE sincronizar la posición de los drones desde el Host hacia todos los Clientes, manteniendo la integridad visual.

#### Scenario: Movimiento Sincronizado en el Cliente
- **WHEN** el Host envía un mensaje `DRONE_MOVE` con nuevas coordenadas (x, y)
- **THEN** el Cliente DEBE interpolar la posición del dron hacia las nuevas coordenadas manteniendo su eje Z original.

### Requirement: Registro de Drones en Escena
Todos los drones presentes en la escena DEBEN estar registrados en el `GameManager` para permitir su identificación por red.

#### Scenario: Registro al iniciar la escena
- **WHEN** se carga la escena de juego o se instancia un dron
- **THEN** el dron DEBE registrarse en `GameManager.Instance.dronsEscena` tanto en el Host como en el Cliente.

### Requirement: Trazabilidad de Mensajes de Red
El sistema DEBE proporcionar logs claros para depurar la llegada y el procesamiento de mensajes de sincronización de drones.

#### Scenario: Recepción de mensaje de movimiento
- **WHEN** el `MenuManager` recibe un mensaje `DRONE_MOVE`
- **THEN** el sistema DEBE emitir un log indicando si el mensaje se ha procesado correctamente o si el dron no ha sido encontrado.
