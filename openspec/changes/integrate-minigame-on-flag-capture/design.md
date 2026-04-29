## Context

La mecánica de captura de bandera en `Bandera.cs` se basa actualmente en un cambio de jerarquía (`transform.SetParent`). Existe un sistema de minijuegos gestionado por `MinijocUIManager.cs` que bloquea el movimiento de los jugadores y presenta desafíos. Este diseño propone vincular ambos sistemas para que la captura desencadene un desafío inmediato.

## Goals / Non-Goals

**Goals:**
- Desencadenar la apertura de la UI de minijuegos tras el `transform.SetParent` en `OnTriggerEnter2D`.
- Bloquear el movimiento del jugador capturador.
- Utilizar la API existente de `MinijocUIManager`.

**Non-Goals:**
- No se modificará el comportamiento interno de los minijuegos.
- No se implementará en esta fase la lógica de resolución (qué pasa si gana/pierde), solo el inicio del flujo.

## Decisions

- **Uso de MinijocUIManager.Instance**: Se utilizará el patrón Singleton ya implementado en `MinijocUIManager` para acceder al método `ShowUI`.
- **Adaptación de ShowUI**: Dado que `ShowUI(Player p1, Player p2)` está diseñado para combates entre dos jugadores, pero la captura de bandera es un evento solitario frente al objeto, se pasará al jugador capturador como ambos parámetros (`ShowUI(player, player)`). Esto asegura la compatibilidad con el código actual que bloquea a ambos participantes.
- **Punto de Inserción**: La lógica se colocará en `Bandera.cs` dentro del bloque `if (!string.IsNullOrEmpty(equipJugador) && equipJugador != equipPropietari)`, justo después de establecer el padre y resetear la posición local.

## Risks / Trade-offs

- **[Riesgo] MinijocUIManager no instanciado** → **[Mitigación]** Realizar una comprobación `if (MinijocUIManager.Instance != null)` antes de la llamada.
- **[Riesgo] Doble activación** → **[Mitigación]** La lógica ya está protegida por `if (player.banderaAgafada == null)`, lo que evita capturas múltiples simultáneas.
