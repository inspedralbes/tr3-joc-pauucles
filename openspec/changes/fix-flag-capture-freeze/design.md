## Context

Actualmente, al capturar una bandera en `Bandera.cs`, se ejecutan varias acciones que pueden causar un bloqueo o "freeze" visual y lógico:
1. Se procesan múltiples colisiones de `OnTriggerEnter2D` simultáneamente.
2. Se bloquea el movimiento del jugador (`potMoure = false`).
3. Se inicia un minijuego (`MinijocUIManager`), lo que detiene el flujo principal.

## Goals / Non-Goals

**Goals:**
- Evitar que la bandera procese colisiones una vez capturada.
- Mantener al jugador en movimiento durante la captura.
- Simplificar la captura de la bandera a un evento puramente jerárquico y visual.

**Non-Goals:**
- Modificar la lógica de retorno de la bandera (fuera de la captura inicial).
- Rediseñar el sistema de minijuegos (solo se elimina su invocación desde la bandera).

## Decisions

- **Cláusula de Salvaguarda**: Se añade `if (transform.parent != null) return;` al inicio de `OnTriggerEnter2D`. Esto garantiza que si la bandera ya está siendo transportada (tiene un padre), no procesará nuevos eventos de disparo (triggers) con el suelo, bases u otros jugadores.
- **Eliminación de Bloqueo de Movimiento**: Se elimina la línea `player.potMoure = false;`. El jugador debe conservar su autonomía de movimiento tras capturar la bandera.
- **Eliminación de Minijuegos en Captura**: Se elimina el bloque que llama a `MinijocUIManager.Instance.ShowUI`. La captura pasa a ser instantánea y jerárquica.

## Risks / Trade-offs

- [Riesgo] → La bandera podría quedar "huérfana" si el jugador se desconecta o muere sin una lógica de soltado robusta.
- [Mitigación] → Se asume que existe lógica en otros componentes (como `Player.cs` o el sistema de red) para gestionar la pérdida de la bandera. Este cambio se centra exclusivamente en el momento de la captura.
