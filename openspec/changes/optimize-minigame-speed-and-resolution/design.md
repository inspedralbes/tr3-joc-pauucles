## Context

El sistema de minijuegos actual delega gran parte de la resolución al agotamiento del tiempo, lo que introduce esperas innecesarias para los jugadores. Además, la lógica de red permite que el ganador sufra castigos por mensajes de red tardíos o mal segmentados. Esta optimización centraliza la autoridad en el Host para una resolución instantánea.

## Goals / Non-Goals

**Goals:**
- Implementar una resolución inmediata basada en el primer evento de éxito/fallo.
- Eliminar la latencia visual de la UI tras finalizar un minijuego.
- Asegurar que solo el perdedor reciba el castigo.

**Non-Goals:**
- Rediseñar el gameplay de los minijuegos existentes.
- Cambiar la duración total máxima de los minijuegos.

## Decisions

- **Timer Estático**: El timer se gestionará como una corrutina o en `Update` sin variables de reset. Si la corrutina termina sin una bandera de `gameResolved`, el Host forzará la resolución comparando los estados actuales de ambos jugadores.
- **Mensajes de Resolución Directos**: Se crearán eventos específicos (ej. `MINIGAME_RESULT`) que el Host enviará a ambos clientes en cuanto se detecte una condición de fin. Estos mensajes contendrán `winnerId`, `loserId` y el `type` de resolución.
- **Stun Selectivo**: El script `Player` (o el manejador de combate) solo procesará el efecto de stun si el `loserId` del mensaje de red coincide con su `localPlayerId`.
- **Cierre Agresivo de UI**: Se llamará a `HideMinigameUI()` inmediatamente antes de enviar o procesar el mensaje de red de resultado, reduciendo el "tiempo muerto" percibido.

## Risks / Trade-offs

- [Risk] → Latencia de red provocando que el Host reciba mensajes fuera de orden.
- [Mitigación] → El Host tiene la autoridad absoluta. El primer mensaje que llegue al Host es el que define la realidad del servidor.
- [Risk] → Cierre de UI antes de que el jugador vea el "Feedback" de victoria/derrota.
- [Mitigación] → Se puede incluir un pequeño delay de 0.5s visual o una animación de transición rápida antes de ocultar la UI completamente.
