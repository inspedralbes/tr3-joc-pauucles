## Context

La resolución de minijuegos depende de la emisión de un mensaje `MINIJOC_RESULT` por parte de cualquiera de los participantes (priorizando la velocidad). Actualmente, la variable `loser` no se asigna correctamente en todos los scripts de lógica, lo que rompe el contrato de red donde el cliente remoto espera saber si ha perdido para aplicar el stun localmente. Además, el componente `Animator` del prefab `Player` ya cuenta con un trigger "Hurt" que no se está utilizando en el flujo de combate.

## Goals / Non-Goals

**Goals:**
- Asegurar que la variable `loser` contenga siempre el nombre del oponente en caso de derrota clara.
- Sincronizar el estado de empate enviando "Empat" en ambos campos de red.
- Integrar la animación de daño en el flujo de `ProcesarDerrota`.

**Non-Goals:**
- Cambiar el sistema de vidas (la reducción de vidas se mantiene igual).
- Modificar el sistema de red Socket.io.

## Decisions

- **Asignación Basada en UIManager**: Se utilizarán las referencias `jugador1` y `jugador2` del `MinijocUIManager` dentro de los scripts de lógica para determinar quién es el oponente del ganador y asignarlo a la variable `_loser`.
- **Uso de "Empat" como Valor Reservado**: El valor "Empat" será tratado por el `MinijocUIManager` para saltar la fase de reducción de vidas y stun, procediendo directamente al desbloqueo de movimiento.
- **Trigger de Animación**: Se llamará a `anim.SetTrigger("Hurt")` inmediatamente al entrar en `ProcesarDerrota` para que el feedback visual coincida con el inicio del stun y el knockback.

## Risks / Trade-offs

- [Risk] → Que el nombre del jugador no esté cargado al momento de resolver.
- [Mitigación] → `MinijocUIManager` inicializa las referencias de los jugadores al inicio del minijuego, asegurando que `username` esté disponible.
- [Risk] → Conflictos con otras animaciones.
- [Mitigación] → El trigger "Hurt" debe tener prioridad en el Animator Controller para interrumpir estados de "Idle" o "Run".
