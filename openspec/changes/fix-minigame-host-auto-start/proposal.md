## Why

Actualmente, cuando el Host detecta una colisión entre jugadores y envía el mensaje de inicio de minijuego (`MINIJOC_START`) a través del WebSocket, este no se inicia localmente en su propia pantalla de forma inmediata. Debido a que el servidor de WebSocket no realiza un "echo" (reenvío del mensaje al propio remitente), el Host se queda esperando indefinidamente una orden que nunca llega, mientras que el Cliente sí recibe la orden e inicia el juego. Esto genera una desincronización crítica y una mala experiencia de usuario para el Host.

## What Changes

- **Auto-inicio en Host**: El Host llamará a la función de inicio de minijuego localmente en el momento en que detecte la colisión y decida el juego a realizar, sin esperar la respuesta del servidor.
- **Prevención de Doble Inicio**: Se añadirá una guarda en el Gestor de Red (`MenuManager.cs`) para que, en caso de recibir un mensaje `MINIJOC_START` por red, se compruebe si el minijuego ya está activo localmente antes de intentar abrirlo de nuevo.
- **Sincronización Determinista**: Se asegura que el Host y el Cliente operen bajo los mismos parámetros (participantes y tipo de juego) desde el primer instante.

## Capabilities

### New Capabilities
- `host-minigame-instant-start`: Capacidad del Host para iniciar minijuegos localmente de forma inmediata tras la detección de colisión, asegurando simetría temporal con el cliente remoto.

### Modified Capabilities
- Ninguna.

## Impact

- `Player.cs`: Modificación en `OnCollisionEnter2D` para disparar la UI local tras el envío del mensaje de red.
- `MenuManager.cs`: Inserción de una comprobación de estado activo (`minijocActiu`) en el listener de mensajes de minijuego.
- Estabilidad: Resolución del bloqueo visual del Host durante los encuentros de combate.
