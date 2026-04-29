## Context

El sistema de combate en este proyecto es altamente reactivo y depende de la sincronización de colisiones 2D que a menudo genera redundancias (triggers disparados múltiples veces en milisegundos). Al delegar la autoridad de red, es vital tener un candado de estado robusto y una validación de identidad local para evitar que el ganador sufra el castigo del perdedor por una mala interpretación de los mensajes de red.

## Goals / Non-Goals

**Goals:**
- Implementar un bloqueo de estado en `Player.cs` para colisiones.
- Centralizar la apertura síncrona de minijuegos desde el Host.
- Asegurar que el perdedor local sea el único que procese el daño.
- Integrar feedback visual mediante animaciones de daño.

**Non-Goals:**
- Rediseñar el motor de red WebSocket.
- Modificar las mecánicas de juego de los minijuegos individuales.

## Decisions

- **Bandera de Estado `enCombate`**: Se añade un mutex lógico a nivel de clase `Player`. Al detectar colisión válida, se activa inmediatamente, bloqueando cualquier otro procesamiento de colisión hasta que la limpieza de combate lo resetee.
- **Apertura Atómica**: El Host abrirá su UI local (`IniciarMinijoc`) ANTES de llamar a `EnviarMinijocStart`. Esto garantiza que no haya retraso visual para el iniciador y que los parámetros del juego se definan en la fuente de verdad.
- **Validación de Perdedor Local**: En `MinijocUIManager.FinalitzarCombat`, se comparará el `loserUsername` recibido por red con el nombre de usuario local. Esta es la defensa definitiva contra stuns accidentales.
- **Trigger de Animación "Hurt"**: Se integrará en el método `ProcesarDerrota`, disparándose siempre que se reduzca una vida, proporcionando una respuesta visual inmediata sincronizada con el stun.

## Risks / Trade-offs

- [Risk] → Que el estado `enCombate` quede bloqueado si hay un error de red crítico.
- [Mitigación] → La función `LimpiarEstadoCombate` resetea todas las banderas para todos los jugadores locales, asegurando que la escena vuelva a un estado jugable.
- [Risk] → Desincronización de animaciones si hay latencia extrema.
- [Mitigación] → La animación se dispara localmente al procesar la derrota, asegurando que el perdedor siempre vea su propio daño en el momento justo.
