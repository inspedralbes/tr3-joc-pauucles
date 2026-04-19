## ADDED Requirements

### Requirement: Gestión de la Interfaz de Fin de Partida
El sistema SHALL gestionar la visibilidad y el contenido de la pantalla final de la partida utilizando UI Toolkit.

#### Scenario: Visualización de Victoria
- **WHEN** El método `FinalitzarPartida` es llamado con `victoria` en true
- **THEN** El movimiento del jugador `potMoure` se establece en false
- **THEN** El panel de UI `pantallaFinalUI` se hace visible
- **THEN** El texto del elemento "TextResultat" cambia a "HAS GUANYAT!"

#### Scenario: Visualización de Derrota
- **WHEN** El método `FinalitzarPartida` es llamado con `victoria` en false
- **THEN** El movimiento del jugador `potMoure` se establece en false
- **THEN** El panel de UI `pantallaFinalUI` se hace visible
- **THEN** El texto del elemento "TextResultat" cambia a "HAS PERDUT..."

### Requirement: Navegación de Retorno al Menú
El sistema SHALL permitir al jugador desconectarse de la red y volver al menú principal desde la pantalla final.

#### Scenario: Clic en Botón Volver
- **WHEN** El usuario hace clic en el botón "BotoTornar"
- **THEN** Se ejecuta la lógica de desconexión de red
- **THEN** Se carga la escena con nombre "MenuPrincipal"
