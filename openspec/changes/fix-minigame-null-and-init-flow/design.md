## Context

El sistema de minijuegos utiliza una arquitectura descentralizada donde los clientes se notifican entre sí para iniciar y finalizar combates. La lógica de resolución en `MinijocUIManager.cs` depende de referencias a objetos de escena que pueden ser volátiles (ej. jugadores que mueren o se desconectan), lo que provoca errores de referencia nula. Además, el flujo de inicio actual puede dejar al Host sin feedback visual si este no procesa su propio mensaje de red.

## Goals / Non-Goals

**Goals:**
- Asegurar que `FinalitzarCombat` sea a prueba de fallos mediante guardas de nulos.
- Unificar el flujo de inicio de minijuegos para que el Host y los Clientes sigan la misma ruta de ejecución (basada en el mensaje `MINIJOC_START`).
- Manejar empates de forma segura sin excepciones.

**Non-Goals:**
- Rediseñar el sistema de comunicación WebSocket.
- Implementar nuevos minijuegos.

## Decisions

- **Validación de Identificadores**: Se utilizará `string.IsNullOrEmpty` al inicio de cualquier método que dependa de nombres de usuario recibidos por red para determinar ganadores o perdedores.
- **Autoridad de Inicio Vía Red**: Aunque el Host sea quien detecte la colisión y emita el mensaje, no abrirá la UI localmente de forma inmediata. Esperará a que el mensaje regrese del servidor y sea procesado por el listener de `MINIJOC_START`. Esto garantiza que el `gameIndex` y los participantes sean exactamente los mismos en todas las pantallas.
- **Manejo de Empates**: Si el mensaje de resultado llega con `winner` vacío, el sistema activará una rama de limpieza de estado que simplemente desbloquea a los jugadores sin aplicar penalizaciones de vida ni efectos visuales de derrota.

## Risks / Trade-offs

- [Risk] → Retraso mínimo (milisegundos) en el Host al esperar su propio mensaje.
- [Mitigación] → La ganancia en consistencia lógica y sincronización temporal supera el impacto visual despreciable.
- [Risk] → Pérdida de mensajes de red que dejen a los jugadores bloqueados.
- [Mitigación] → El sistema de limpieza estática `Player.LimpiarEstadoCombate` puede ser llamado externamente o mediante un timeout de seguridad si es necesario.
