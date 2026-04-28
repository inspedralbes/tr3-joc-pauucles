## ADDED Requirements

### Requirement: Sincronización Determinista de Perdedores
El sistema SHALL garantizar que cada mensaje de resultado de minijuego (`MINIJOC_RESULT`) identifique correctamente tanto al ganador como al perdedor.

#### Scenario: Resolución con ganador definido
- **WHEN** un minijuego finaliza y se determina un ganador claro
- **THEN** el sistema envía un mensaje de red que contiene el nombre de usuario del ganador Y el nombre de usuario del oponente como perdedor.

#### Scenario: Resolución de empate
- **WHEN** un minijuego finaliza en empate o error mutuo
- **THEN** el sistema envía un mensaje de red indicando "Empat" tanto en el campo del ganador como en el del perdedor.

### Requirement: Feedback Visual de Daño en Jugador
El sistema SHALL proporcionar una respuesta visual inmediata cuando un jugador pierde un minijuego y recibe daño.

#### Scenario: Ejecución de animación Hurt
- **WHEN** un jugador ejecuta el método `ProcesarDerrota`
- **THEN** el sistema SHALL disparar el trigger "Hurt" en el componente `Animator` antes de aplicar el estado de stun.
