## Why

Es necesario proporcionar una interfaz visual interactiva para el minijuego PPTLLS que permita a los jugadores resolver enfrentamientos de manera justa y rápida. Al ser un juego multijugador, la solución debe evitar el uso de `Time.timeScale = 0`, asegurando que el resto de la partida continúe mientras los dos jugadores en combate están inmovilizados.

## What Changes

- Implementación de `MinijocUIManager.cs` para gestionar el ciclo de vida de la interfaz del minijuego.
- Actualización de la lógica de colisión para restringir el movimiento (`potMoure = false`) solo a los jugadores implicados.
- Creación de un `UIDocument` específico para el minijuego con fondo semitransparente y los 5 botones de acción (Piedra, Papel, Tijera, Lagarto, Spock).
- Integración con la lógica existente en `MinijocPPTLLS.cs` para procesar resultados.
- Restauración del movimiento (`potMoure = true`) y aplicación de consecuencias (`GuanyaCombat`, `PerdCombat`) al finalizar el enfrentamiento.

## Capabilities

### New Capabilities
- `minijoc-ui-pptlls-interaction`: Gestión de la interfaz de usuario y flujo de interacción para el minijuego PPTLLS.

### Modified Capabilities
- `player-consequences`: Actualización para integrar la inmovilización durante el minijuego y la aplicación de resultados post-combate.

## Impact

- **Player.cs**: Se verá afectado por el control de la variable `potMoure`.
- **MinijocPPTLLS.cs**: Deberá ser invocado por el nuevo gestor de UI.
- **UI Toolkit**: Nuevos assets `.uxml` y configuración de `UIDocument`.
- **Game Flow**: Cambio en cómo se inician y terminan los enfrentamientos entre jugadores.
