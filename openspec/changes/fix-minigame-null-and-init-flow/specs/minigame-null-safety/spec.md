## ADDED Requirements

### Requirement: Validación de Parámetros de Resolución
El sistema SHALL validar que los nombres de usuario del ganador y perdedor no sean nulos ni vacíos antes de proceder con la lógica de resolución de combate.

#### Scenario: Resolución con ganador vacío
- **WHEN** el método `FinalitzarCombat` es llamado con un `winnerUsername` vacío o nulo
- **THEN** el sistema SHALL tratar el resultado como un empate, limpiando el estado de combate sin intentar acceder a referencias de jugadores específicas por ID.

### Requirement: Seguridad de Referencias de Objetos
El sistema SHALL verificar la existencia de las referencias a los objetos `Player` y componentes de UI antes de intentar modificar sus estados o propiedades.

#### Scenario: Referencia a jugador inexistente
- **WHEN** el sistema intenta aplicar una recompensa o castigo a un jugador que ya no se encuentra en la escena
- **THEN** el sistema SHALL abortar la operación silenciosamente para evitar una excepción de puntero nulo.
