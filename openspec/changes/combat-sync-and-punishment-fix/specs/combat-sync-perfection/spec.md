## ADDED Requirements

### Requirement: Autoridad de Inicio del Host
El sistema SHALL restringir la detección de colisiones de combate al Host de la sala para evitar disparos múltiples de minijuegos.

#### Scenario: Detección síncrona
- **WHEN** un jugador detecta una colisión Y el jugador local es el Host
- **THEN** el sistema SHALL activar la UI localmente E informar al resto de la sala mediante red.

### Requirement: Bloqueo de Estado en Combate
El sistema SHALL utilizar banderas de estado para evitar que una sola colisión inicie múltiples instancias de minijuegos.

#### Scenario: Protección contra reentrancia
- **WHEN** una colisión es detectada
- **THEN** el sistema SHALL establecer `enCombate = true` inmediatamente para bloquear cualquier otro intento de combate hasta que se limpie el estado.

### Requirement: Animación de Daño en Derrota
El sistema SHALL proporcionar feedback visual de daño inmediato cuando un jugador pierde un combate.

#### Scenario: Feedback visual
- **WHEN** el método `ProcesarDerrota` es ejecutado
- **THEN** el sistema SHALL disparar el trigger "Hurt" en el componente `Animator`.
