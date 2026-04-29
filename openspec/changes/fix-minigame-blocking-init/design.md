## Context

Actualmente, el sistema de minijuegos en `Player.cs` utiliza una lógica de "Master" que provoca que solo uno de los dos jugadores involucrados en una colisión inicie la interfaz de inmediato. El otro jugador ("Client") debe esperar a recibir un mensaje `MINIJOC_START` vía WebSocket, lo que genera un retraso visual molesto y da la impresión de que el juego se ha bloqueado.

## Goals / Non-Goals

**Goals:**
- Proporcionar feedback visual instantáneo (UI del minijuego) a ambos jugadores en el momento exacto del contacto.
- Eliminar la dependencia del Host para la apertura de la interfaz.
- Prevenir ejecuciones redundantes de lógica de colisión.

**Non-Goals:**
- Cambiar la autoridad del Host para la validación de resultados finales.
- Rediseñar el sistema de red de los minijuegos.

## Decisions

- **Cálculo Determinista del Juego**: Ambos jugadores realizarán el mismo cálculo aleatorio basado en un elemento común (por ejemplo, el nombre del jugador que actúa como "Master" alfabético) para asegurar que ambos abran el mismo minijuego sin consultarse por red.
- **Función `IniciarMinijuegoLocal()`**: Se encapsulará la lógica de bloqueo de movimiento (`potMoure = false`), detención de físicas (`rb.linearVelocity = Vector2.zero`) y apertura de UI en un método que será llamado inmediatamente tras detectar la colisión válida.
- **Detección Unidireccional de Mensaje**: Solo el "Master" enviará el mensaje `MINIJOC_START` al servidor para informar al resto de la sala (espectadores u otros drones), pero ninguno de los dos combatientes esperará a este mensaje para comenzar.
- **Guardas de Estado**: Se reforzará la comprobación `if (!potCombatre)` al inicio de `OnCollisionEnter2D` para evitar que el log se sature de intentos fallidos mientras se está en medio de un combate o stun.

## Risks / Trade-offs

- [Risk] → Desincronización de juego seleccionado si el generador de números aleatorios no coincide.
- [Mitigación] → Utilizar el nombre del "Master" como semilla (`Random.InitState`) antes de elegir el índice del juego.
- [Risk] → Doble activación si ambos detectan la colisión en frames ligeramente distintos.
- [Mitigación] → El uso de `ultimXoc` (timestamp estático) y el flag `potCombatre` bloquearán ejecuciones secundarias en un margen de 3 segundos.
