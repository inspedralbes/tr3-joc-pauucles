## ADDED Requirements

### Requirement: Validación de parámetro de entrada en Trigger Exit
El sistema DEBE verificar que el parámetro `Collider2D other` y su `gameObject` asociado NO sean nulos al inicio del evento `OnTriggerExit2D`.

#### Scenario: Parámetro de entrada nulo
- **WHEN** se dispara un evento `OnTriggerExit2D` Y `other` o `other.gameObject` son nulos.
- **THEN** el sistema SHALL interrumpir la ejecución del método inmediatamente sin lanzar errores.

### Requirement: Acceso seguro a componentes del objeto saliente
El sistema DEBE validar la existencia del objeto y sus propiedades antes de realizar comparaciones de etiquetas (Tags) o acceder a sus componentes.

#### Scenario: Objeto válido saliendo
- **WHEN** un objeto válido sale del trigger.
- **THEN** el sistema SHALL proceder con las comprobaciones de lógica de juego (escaleras, banderas, etc.).

### Requirement: Protección de referencias internas del jugador
El sistema DEBE asegurar que cualquier variable de estado del jugador (como referencias a la bandera capturada) sea validada antes de ser manipulada durante el evento de salida.

#### Scenario: Referencia interna nula
- **WHEN** el sistema intenta acceder a una variable interna del jugador (ej: `banderaAgafada`) que es nula.
- **THEN** el sistema SHALL omitir la operación y continuar con el resto de la lógica de salida.
