## ADDED Requirements

### Requirement: Limpieza de Credenciales
El sistema DEBE aplicar el método `.Trim()` a los valores de nombre de usuario y contraseña antes de cualquier procesamiento o envío.

#### Scenario: Credenciales con espacios
- **WHEN** el usuario introduce " usuario " y " pass ".
- **THEN** el sistema DEBE procesar "usuario" y "pass".

### Requirement: Validación de Campos Obligatorios
El sistema DEBE verificar que tanto el nombre de usuario como la contraseña no sean nulos ni consistan únicamente en espacios en blanco antes de proceder con la petición HTTP.

#### Scenario: Campos vacíos
- **WHEN** el usuario intenta iniciar sesión con un campo vacío.
- **THEN** el sistema SHALL interrumpir la operación y registrar un mensaje de advertencia.

### Requirement: Logging Preventivo de Payload
El sistema DEBE imprimir el JSON exacto de la petición en la consola de Unity como una advertencia (`Debug.LogWarning`) inmediatamente antes de iniciar la transmisión.

#### Scenario: Envío de login
- **WHEN** se llama al método de envío de petición para login.
- **THEN** el sistema SHALL imprimir "[MenuManager] Intentant enviar al servidor: ..." seguido del JSON generado.
