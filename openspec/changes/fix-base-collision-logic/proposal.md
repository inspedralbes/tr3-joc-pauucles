## Why

Actualmente, las colisiones entre jugadores y bases (Puntos de Spawn) no discriminan por equipo, lo que provoca que los enemigos se queden bloqueados o activen lógicas de entrega incorrectas al pasar por encima de una base contraria. Este cambio asegura un flujo de movimiento fluido para los intrusos y restringe la mecánica de entrega de bandera exclusivamente a la base aliada del jugador, añadiendo además el desafío de un minijuego para completar la captura.

## What Changes

- Identificación del equipo de la base mediante el nombre del objeto (`PuntSpawn_Equip1` para Equipo A, `Equip2` para Equipo B).
- Filtrado de colisiones: si un jugador entra en una base que no pertenece a su equipo, la interacción se ignora.
- Mecánica de entrega: solo si el jugador está en su base aliada y transporta una bandera enemiga, se bloquea su movimiento (`potMoure = false`) y se inicia el minijuego de validación.

## Capabilities

### New Capabilities
- `base-interaction-mechanics`: Lógica de filtrado de equipos y validación de entrega de bandera en bases.

### Modified Capabilities
<!-- No requirement changes to existing specs -->

## Impact

- Script `Player.cs`.
- Prefabs de bases (Punts de Spawn).
- Flujo de victoria/puntuación (entrega de banderas).
