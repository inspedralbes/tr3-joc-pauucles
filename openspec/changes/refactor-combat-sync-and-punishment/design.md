## Context

El sistema de combate en este proyecto es altamente reactivo y depende de la sincronización de colisiones 2D que a menudo genera redundancias (triggers disparados múltiples veces en milisegundos). Al delegar la apertura del minijuego a la red, se introduce una latencia que debe ser mitigada mediante un candado de estado persistente y una resolución determinista basada en nombres de usuario únicos.

## Goals / Non-Goals

**Goals:**
- Implementar un bloqueo de estado en `Player.cs` para colisiones.
- Centralizar la apertura síncrona de minijuegos desde el Host.
- Asegurar que los perdedores y ganadores se identifiquen correctamente en toda la red.
- Integrar feedback visual (animación) en el flujo de derrota.

**Non-Goals:**
- Cambiar el sistema de colisiones de Unity a un sistema basado en rayos.
- Rediseñar el motor de red WebSocket.

## Decisions

- **Bandera `enCombate`**: Se añade a la clase `Player`. Al detectar colisión, si es falsa, se pone a verdadera inmediatamente. Esto actúa como un "mutex" lógico para las físicas de Unity.
- **Apertura Atómica**: El Host abrirá su UI local (`IniciarMinijoc`) antes de llamar a `EnviarMinijocStart`. Esto elimina la sensación de retraso para el Host y asegura que la señal de red se emita con los parámetros ya validados localmente.
- **Validación de Identidad Local**: En `FinalitzarCombat`, se comparará `loserUsername == miUsername`. Esta es la decisión de diseño más importante para evitar que el ganador sufra stuns accidentales por mensajes de red mal dirigidos o duplicados.
- **Trigger "Hurt"**: Se asume que el `Animator` tiene este trigger. Se llamará mediante código justo antes de la rutina de stun para sincronizar el feedback visual con el bloqueo de movimiento.

## Risks / Trade-offs

- [Risk] → Que el estado `enCombate` se quede bloqueado permanentemente.
- [Mitigación] → La función `LimpiarEstadoCombate` debe ser llamada obligatoriamente en `HideUI` y `FinalitzarCombat` para resetear todas las banderas.
- [Risk] → Desincronización de animaciones si el perdedor tiene alta latencia.
- [Mitigación] → El trigger de animación se ejecuta localmente en el cliente perdedor al procesar el resultado, garantizando consistencia local.
