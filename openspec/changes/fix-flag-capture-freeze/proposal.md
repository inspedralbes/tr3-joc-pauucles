## Why

Esta actualización soluciona un bloqueo (freeze) que ocurre en el momento exacto de la captura de la bandera. Actualmente, la bandera procesa múltiples colisiones simultáneamente y detiene el movimiento del jugador, lo que interrumpe el flujo del juego.

## What Changes

- **Control de Colisiones**: Se añade una cláusula de salida rápida en `OnTriggerEnter2D` de `Bandera.cs` para evitar el procesamiento redundante una vez que la bandera ya tiene un padre.
- **Movimiento del Jugador**: Se elimina la lógica que desactivaba la variable `potMoure` del jugador durante la captura, permitiendo que el jugador siga moviéndose.
- **Simplificación de Lógica**: Se eliminan las llamadas a minijuegos durante la captura de la bandera, dejando el proceso como una acción puramente visual y jerárquica.

## Capabilities

### New Capabilities
- `flag-capture-optimization`: Optimización de la lógica de colisión y captura de la bandera para evitar bloqueos y simplificar la integración con el jugador.

### Modified Capabilities
- Ninguna.

## Impact

- `Bandera.cs`: Modificación de la lógica de colisión y captura.
- Experiencia de usuario: Eliminación de bloqueos y pausas innecesarias en el movimiento durante la captura.
