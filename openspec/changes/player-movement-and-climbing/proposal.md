## Why

Implementar un sistema de navegación básico para el jugador que permita el movimiento horizontal, el salto y la capacidad de subir escaleras, mejorando la jugabilidad y la interacción con el entorno del bosque.

## What Changes

- **Variables de Movimiento**: Incorporación de `moveSpeed` (5f), `jumpForce` (7f) y `climbSpeed` (4f) para el control del personaje.
- **Física del Jugador**: Referencia y gestión de `Rigidbody2D` para aplicar fuerzas y controlar la gravedad durante el escalado.
- **Movimiento Horizontal**: Implementación de `Input.GetAxisRaw("Horizontal")` y rotación visual mediante la escala local en X.
- **Sistema de Salto**: Lógica de salto condicional (solo cuando no se escala y la velocidad vertical es nula).
- **Interacción con Escaleras**: Detección de zonas de escaleras mediante triggers (`ZonaEscalera`) y control de gravedad (`gravityScale`) para permitir el ascenso/descenso.

## Capabilities

### New Capabilities
- `player-navigation`: Define los requisitos de movimiento horizontal, salto y escalado para el personaje controlado por el usuario.

### Modified Capabilities
- Ninguna.

## Impact

- `Assets/Scripts/Player.cs`: Modificación integral de la lógica de movimiento.
- `Assets/Scenes/Bosque.unity`: Requiere que las escaleras tengan el Tag "ZonaEscalera" y un `Collider2D` configurado como Trigger.
