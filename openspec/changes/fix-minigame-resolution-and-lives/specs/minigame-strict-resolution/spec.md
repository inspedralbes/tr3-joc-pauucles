## ADDED Requirements

### Requirement: Validación de Identidad del Perdedor
El sistema SHALL asegurar que solo el jugador perdedor ejecute la lógica de castigo y reducción de vida.

#### Scenario: Resolución de combate con ganador local
- **WHEN** el minijuego finaliza y el jugador local es el ganador
- **THEN** el sistema SHALL restaurar el movimiento del jugador pero NO llamar a `ProcesarDerrota()`.

#### Scenario: Resolución de combate con perdedor local
- **WHEN** el minijuego finaliza y el jugador local es el perdedor
- **THEN** el sistema SHALL llamar a `ProcesarDerrota()` y aplicar el stun correspondiente.

### Requirement: Prevención de Reentrancia en Resolución
El sistema SHALL bloquear intentos secundarios de procesar el mismo resultado de un combate ya concluido.

#### Scenario: Recepción de resultado duplicado
- **WHEN** se recibe un mensaje de resultado pero la bandera `isConcluding` ya es `true`
- **THEN** el sistema SHALL ignorar el mensaje y no procesar de nuevo la lógica de fin de combate.

### Requirement: Limpieza de Estado Post-Combate
El sistema SHALL reiniciar todos los parámetros de combate tras una resolución exitosa.

#### Scenario: Preparación para siguiente encuentro
- **WHEN** un minijuego finaliza completamente
- **THEN** el sistema SHALL limpiar el cooldown de colisión y el estado de stun para permitir nuevos encuentros.
