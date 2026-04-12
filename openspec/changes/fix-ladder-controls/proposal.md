## Why

La experiencia de juego actual para subir escaleras es limitada, ya que solo permite el uso de las teclas de dirección verticales. Añadir la barra espaciadora como opción para subir mejora la accesibilidad y la fluidez del movimiento, permitiendo que los jugadores utilicen controles de salto familiares para iniciar la escalada.

## What Changes

- **Modificación de la activación de escalada**: Ahora se puede empezar a escalar pulsando la tecla de Salto (Espacio) además de la flecha Arriba.
- **Restricción de salto en escaleras**: Se deshabilita el salto normal cuando el jugador está en contacto con una escalera para evitar saltos accidentales cuando se pretende escalar con la barra espaciadora.
- **Control refinado en FixedUpdate**: 
  - Subir: Tecla de Salto o flecha Arriba.
  - Bajar: Flecha Abajo.
  - Estático: Si no se pulsa ninguna de las anteriores, el jugador se mantiene fijo en la escalera (velocidad vertical 0).

## Capabilities

### New Capabilities
- `player-movement`: Define las reglas generales de movimiento, salto y escalada del jugador.

### Modified Capabilities
- Ninguna: No existen especificaciones previas para el movimiento del jugador que requieran cambios en los requisitos de nivel de especificación.

## Impact

- **Player.cs**: Cambios en los métodos `Update` y `FixedUpdate`.
- **Gameplay**: Mejora en la precisión del control vertical en zonas de escaleras.
