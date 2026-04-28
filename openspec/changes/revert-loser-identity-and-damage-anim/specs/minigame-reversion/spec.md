## ADDED Requirements

### Requirement: Eliminación de Feedback Visual de Daño
El sistema SHALL retirar cualquier disparador de animación de daño durante el proceso de derrota del jugador.

#### Scenario: Derrota sin animación Hurt
- **WHEN** un jugador ejecuta el método `ProcesarDerrota`
- **THEN** el sistema NO SHALL disparar el trigger "Hurt" ni realizar cambios de color adicionales fuera de la rutina de stun estándar.

### Requirement: Resolución de Combate Simplificada
El sistema SHALL revertir a la lógica de resolución donde la identidad del perdedor no es validada estrictamente por el `MinijocUIManager`.

#### Scenario: Resolución sin filtro de identidad
- **WHEN** un minijuego finaliza
- **THEN** el sistema SHALL restaurar la lógica anterior de `FinalitzarCombat` y permitir el envío de resultados sin validación forzada de la variable `loser`.

### Requirement: Sincronización de Red Estándar
El sistema SHALL utilizar el flujo de mensajes `MINIJOC_RESULT` original sin manejo especial para cadenas "Empat" en los campos de participantes.

#### Scenario: Envío de resultado por red
- **WHEN** un minijuego termina
- **THEN** el sistema envía el mensaje de red siguiendo el formato previo a la última actualización, permitiendo campos vacíos si no se determina un perdedor explícito.
