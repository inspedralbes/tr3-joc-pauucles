## Why

La lógica actual de colisión de la bandera no es suficientemente robusta, lo que provoca inconsistencias al detectar jugadores o determinar equipos. Este cambio busca hacer que la detección sea "a prueba de balas" y asegurar que la bandera se enganche correctamente a los jugadores del equipo contrario.

## What Changes

- Reescritura de `OnTriggerEnter2D` en `Bandera.cs` para una detección más fiable.
- Añadir logs de depuración para rastrear detecciones de colisión (`[Bandera] Xoc detectat amb...`).
- Implementar obtención segura del equipo del jugador (vía script de jugador, NetworkSync o MenuManager).
- Añadir logs de depuración para la comparación de equipos (`[Bandera] Equip Jugador: ... vs Equip Bandera: ...`).
- Implementar lógica de captura: si los equipos son diferentes, la bandera se convierte en hija del transform del jugador y se resetea su posición local.
- Mantener intacto el método `DeixarDeSeguir()`.

## Capabilities

### New Capabilities
- `flag-capture-mechanics`: Lógica robusta de colisión y captura de bandera basada en la diferencia de equipos.

### Modified Capabilities
<!-- No requirement changes to existing specs -->

## Impact

- Script `Bandera.cs`.
- Mecánica de juego de captura de bandera (interacción jugador-bandera).
