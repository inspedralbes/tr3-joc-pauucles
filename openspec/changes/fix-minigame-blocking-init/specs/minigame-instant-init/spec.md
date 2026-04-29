## ADDED Requirements

### Requirement: Inicio de Minijuego Descentralizado e Instantáneo
El sistema DEBE activar la interfaz de minijuego de forma local e inmediata para ambos jugadores involucrados en una colisión, sin depender de la recepción previa de un mensaje de red.

#### Scenario: Activación por colisión
- **WHEN** un jugador detecta una colisión con otro jugador enemigo.
- **THEN** el sistema DEBE llamar inmediatamente a la función `IniciarMinijuegoLocal()`, bloquear el movimiento del jugador y mostrar la interfaz de minijuego seleccionada.

### Requirement: Prevención de Triggers Redundantes
El sistema DEBE ignorar nuevas colisiones si el jugador ya se encuentra en un estado que impide el combate.

#### Scenario: Jugador ocupado
- **WHEN** un jugador recibe un evento de colisión pero ya está en un minijuego, bajo efecto de stun o en periodo de cooldown.
- **THEN** el sistema DEBE ignorar el evento de colisión y no realizar ninguna acción de inicio de minijuego adicional.

### Requirement: Persistencia de Autoridad del Host para Resultados
Aunque el inicio sea local, el Host DEBE mantener la autoridad final sobre la validación de los resultados.

#### Scenario: Validación de fin de juego
- **WHEN** el minijuego iniciado localmente finaliza.
- **THEN** el sistema DEBE seguir el flujo de envío de resultados al Host para su validación y posterior aplicación de efectos globales (stuns/recompensas).
