## 1. Auditoría de Scripts

- [x] 1.1 Confirmar la accesibilidad de `MinijocUIManager.Instance.ShowUI(Player p1, Player p2)`.
- [x] 1.2 Localizar el bloque de captura de bandera en `Bandera.cs` (dentro de `OnTriggerEnter2D`).

## 2. Integración de Minijuego

- [x] 2.1 En `Bandera.cs`, justo después de `transform.localPosition = ...`, añadir el bloqueo de movimiento: `player.potMoure = false;`.
- [x] 2.2 Llamar a la interfaz de minijuegos: `if (MinijocUIManager.Instance != null) { MinijocUIManager.Instance.ShowUI(player, player); }`.
- [x] 2.3 Insertar comentarios guía sobre la lógica de retorno de bandera (`DeixarDeSeguir`) y reactivación de movimiento (`potMoure = true`) tras la resolución del minijuego.

## 3. Verificación

- [x] 3.1 Verificar que el script compila sin errores.
- [ ] 3.2 Validar que, al capturar la bandera, se abre la interfaz de minijuegos y el jugador queda inmovilizado.
