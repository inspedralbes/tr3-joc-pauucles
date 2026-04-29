## Why

El sistema actual de inicio de minijuegos depende excesivamente de la validación del Host (Master) antes de dar feedback visual a los jugadores. Esto provoca una sensación de "lag" o cuelgue cuando dos jugadores colisionan, ya que esperan una señal de red para activar la interfaz. Este cambio busca descentralizar el inicio visual del minijuego para que la respuesta sea instantánea, mejorando la fluidez y la experiencia de usuario.

## What Changes

- **Inicio Descentralizado**: Se elimina la restricción de esperar al Host para abrir la UI del minijuego. Ambos jugadores activarán su interfaz localmente nada más detectar la colisión.
- **Estado de Protección**: Se implementan comprobaciones estrictas para ignorar nuevas colisiones si el jugador ya está participando en un minijuego, está en cooldown o bajo efecto de stun.
- **Congelación Local**: Al colisionar, el jugador ejecutará una función local que bloquea su movimiento de inmediato.

## Capabilities

### New Capabilities
- `minigame-instant-init`: Lógica de inicio de minijuego basada en detección local inmediata con sincronización de estado para evitar redundancias.

### Modified Capabilities
- Ninguna.

## Impact

- `Player.cs`: Refactorización de `OnTriggerEnter2D` y la lógica de inicio de combate.
- `MinijocUIManager.cs`: Asegurar que el inicio del minijuego pueda ser disparado localmente sin romper la sincronización posterior de resultados.
- Experiencia de Juego: Eliminación de la latencia percibida en el inicio de los combates.
