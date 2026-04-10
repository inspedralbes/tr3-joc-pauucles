## 1. Configuración de UI Toolkit

- [x] 1.1 Crear el asset UXML (`MinijocPPTLLS.uxml`) con un panel negro semitransparente.
- [x] 1.2 Añadir los 5 botones con los IDs exactos: `BtnPedra`, `BtnPaper`, `BtnTisora`, `BtnLlangardaix` y `BtnSpock`.
- [x] 1.3 Configurar el `UIDocument` en la escena o como prefab para que esté listo para activarse.

## 2. Implementación de MinijocUIManager.cs

- [x] 2.1 Crear el script `MinijocUIManager.cs` heredando de `MonoBehaviour`.
- [x] 2.2 Implementar el método para buscar los botones mediante `Query<Button>()`.
- [x] 2.3 Registrar los eventos `clicked` de cada botón para que envíen la elección a `MinijocPPTLLS.cs`.
- [x] 2.4 Crear métodos `ShowUI()` y `HideUI()` para controlar la visibilidad del `UIDocument`.

## 3. Integración con Player.cs y Lógica de Combate

- [x] 3.1 Modificar el sistema de colisiones para detectar el choque entre dos jugadores.
- [x] 3.2 Implementar la inmovilización de ambos jugadores estableciendo `potMoure = false`.
- [x] 3.3 Integrar la llamada a `GuanyaCombat()` y `PerdCombat()` tras recibir el resultado de `MinijocPPTLLS.cs`.
- [x] 3.4 Asegurar que el estado `potMoure = true` se restaura siempre al cerrar la UI, incluso en caso de empate (donde se reinicia la UI).

## 4. Validación y Pruebas

- [x] 4.1 Verificar que la colisión inmoviliza a los dos jugadores correctamente sin pausar el resto del juego.
- [x] 4.2 Probar que los 5 botones ejecutan la lógica de PPTLLS y muestran el resultado esperado.
- [x] 4.3 Confirmar que tras una victoria/derrota, la UI se cierra y los jugadores pueden volver a moverse.
- [x] 4.4 Validar el comportamiento del empate (la UI permanece abierta para una nueva elección).
