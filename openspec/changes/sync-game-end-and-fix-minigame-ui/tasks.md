## 1. Sincronización de Red en GameManager.cs

- [ ] 1.1 Añadir un flag `private bool isGameOver = false;` para evitar ejecuciones duplicadas.
- [ ] 1.2 Modificar `FinalitzarPartida(bool victoria)` para enviar el mensaje `GAME_OVER` vía `WebSocketClient` solo cuando `victoria` es true.
- [ ] 1.3 Crear una clase serializable `GameOverMessage` para la comunicación JSON.
- [ ] 1.4 Implementar la recepción del mensaje `GAME_OVER` en la lógica de red (ej. en `MenuManager.cs` o donde se procesen los mensajes de juego) y llamar a `GameManager.Instance.FinalitzarPartida(false)`.

## 2. Corrección de UI en MinijocUIManager.cs

- [ ] 2.1 En el método `ShowUI`, asegurar que `_backgroundOverlay.style.display = DisplayStyle.Flex;` se ejecute antes de la selección del minijuego.
- [ ] 2.2 Verificar que todos los contenedores de minijuegos individuales se activen correctamente al ser seleccionados.

## 3. Pruebas y Validación

- [ ] 3.1 Verificar en una sesión multijugador que al capturar la bandera el otro jugador recibe la pantalla de derrota.
- [ ] 3.2 Verificar que al iniciar un combate, el fondo oscuro y el minijuego son visibles inmediatamente.
