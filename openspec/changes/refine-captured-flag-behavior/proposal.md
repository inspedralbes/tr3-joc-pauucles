## Why

La bandera capturada actualmente carece de un comportamiento visual pulido al ser transportada. Este cambio perfecciona las animaciones de movimiento, sincroniza la orientación (flipX) con el jugador que la lleva y ajusta su posición local para que actúe como una mascota real que sigue al jugador de forma natural.

## What Changes

- Implementación de detección de movimiento reactivo más preciso (umbral de 0.002f).
- Sincronización automática del `flipX` de la bandera con el `SpriteRenderer` del jugador.
- Ajuste dinámico de la posición local en el eje X según la orientación del jugador para mantener a la bandera siempre en el lado correcto.
- Fijación de la posición local en el eje Y a 0 para asegurar que la bandera "toque el suelo".

## Capabilities

### New Capabilities
- `captured-flag-mascot-behavior`: Comportamiento visual avanzado para la bandera capturada, incluyendo sincronización de orientación y posicionamiento dinámico reactivo.

### Modified Capabilities
<!-- No requirement changes to existing specs -->

## Impact

- Script `Bandera.cs`.
- Feedback visual de la captura y transporte de banderas.
- Jerarquía de objetos en tiempo de ejecución (relación Jugador-Bandera).
