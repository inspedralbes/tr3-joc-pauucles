## Context

En la arquitectura multijugador basada en WebSockets utilizada para los minijuegos, el Host tiene la autoridad de detectar colisiones y seleccionar el tipo de juego. Sin embargo, el flujo de red actual asume que el servidor devolverá el mensaje de inicio al Host, lo cual no ocurre. Esto rompe la simetría visual y funcional, dejando al Host bloqueado fuera de la interfaz mientras el Cliente remoto ya está participando en el juego.

## Goals / Non-Goals

**Goals:**
- Implementar un disparador local de UI para el Host que elimine la dependencia del eco del servidor.
- Asegurar que la lógica de red sea resiliente ante posibles retransmisiones del mismo mensaje de inicio.

**Non-Goals:**
- Cambiar la lógica de asignación de atacante/defensor.
- Modificar el sistema de comunicación Socket.io subyacente.

## Decisions

- **Invocación de UI en OnCollisionEnter2D**: Se insertará una llamada a `MinijocUIManager.Instance.IniciarMinijoc()` inmediatamente después de la instrucción `MenuManager.Instance.EnviarMinijocStart()` en `Player.cs`. Esto garantiza que el Host no pierda el momento de la colisión.
- **Validación de Estado Activo**: En `MenuManager.cs`, dentro del bloque de procesamiento de `MINIJOC_START`, se envolverá la lógica de apertura en un condicional `if (!MinijocUIManager.Instance.minijocActiu)`. Esta es la forma más sencilla y robusta de manejar duplicados sin necesidad de IDs de transacción complejos.

## Risks / Trade-offs

- [Risk] → Race condition si el mensaje de red llega extremadamente rápido (poco probable dada la latencia de red).
- [Mitigación] → La bandera `minijocActiu` es síncrona en el hilo principal de Unity, lo que previene reentradas accidentales.
- [Risk] → Desfase de frames entre el inicio local del Host y el inicio remoto del Cliente.
- [Mitigación] → El inicio del Host será ligeramente anterior al del Cliente (por milisegundos), lo cual es preferible a que no inicie en absoluto.
