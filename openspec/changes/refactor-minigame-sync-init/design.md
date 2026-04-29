## Context

Actualmente, el inicio de los minijuegos en `Player.cs` es inconsistente, ya que utiliza una lógica de "soyMaster" basada en orden alfabético que a veces choca con la realidad del Host del servidor. Esto provoca que la UI aparezca en momentos distintos o no aparezca en absoluto para uno de los clientes.

## Goals / Non-Goals

**Goals:**
- Garantizar que ambos jugadores inicien el minijuego simultáneamente.
- Delegar la selección del minijuego únicamente al Host de la sala.
- Eliminar race conditions en el inicio de combates.

**Non-Goals:**
- Rediseñar la lógica interna de los minijuegos individuales.
- Cambiar el sistema de validación de resultados finales.

## Decisions

- **Detección Restringida al Host**: En `OnCollisionEnter2D`, se añadirá la guarda `if (!MenuManager.Instance.IsHost()) return;`. Esto asegura que el evento de red solo se dispare una vez por encuentro, desde la fuente de verdad.
- **Protocolo START_MINIGAME**: Se definirá una clase `MinigameStartMessage` en el sistema de red que contenga los nombres de usuario de los dos jugadores y el índice del juego.
- **Congelamiento Síncrono**: Al recibir el mensaje, se buscará a los dos jugadores en la escena mediante sus IDs. Solo el jugador local congelará su movimiento si su ID coincide con uno de los participantes del mensaje.
- **Apertura de UI vía Listener**: El `MenuManager` o `GameManager` será el encargado de llamar a `MinijocUIManager.Instance.IniciarMinijoc()` tras procesar el mensaje entrante, eliminando esta responsabilidad de `Player.cs`.

## Risks / Trade-offs

- [Risk] → Latencia en el inicio del minijuego para el jugador que detectó la colisión.
- [Mitigación] → La consistencia lógica compensa el pequeño retraso visual (milisegundos) de esperar la vuelta del servidor.
- [Risk] → El Host podría no detectar la colisión si hay desincronización física.
- [Mitigación] → El Host tiene autoridad física sobre los objetos de red, por lo que su detección es la única válida para el estado del juego.
