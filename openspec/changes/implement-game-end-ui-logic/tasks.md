## 1. Preparación de GameManager.cs

- [x] 1.1 Añadir directivas `using UnityEngine.UIElements;` y `using UnityEngine.SceneManagement;` a `GameManager.cs`.
- [x] 1.2 Declarar la variable pública `public UIDocument pantallaFinalUI;`.

## 2. Inicialización de la UI

- [x] 2.1 En el método `Start()`, obtener el `rootVisualElement` de `pantallaFinalUI`.
- [x] 2.2 Ocultar el elemento raíz por defecto estableciendo `style.display = DisplayStyle.None;`.
- [x] 2.3 Buscar el botón "BotoTornar" dentro del root y suscribir su evento `clicked` al método `TornarAlMenu`.

## 3. Lógica de Fin de Partida

- [x] 3.1 Refactorizar el método `FinalitzarPartida(bool victoria)` para usar la nueva UI.
- [x] 3.2 Asegurar que se bloquea el movimiento de todos los jugadores estableciendo `potMoure = false`.
- [x] 3.3 Mostrar el root de `pantallaFinalUI` usando `DisplayStyle.Flex`.
- [x] 3.4 Buscar el label "TextResultat" y actualizar su texto según el resultado ("HAS GUANYAT!" o "HAS PERDUT...").
- [x] 3.5 Eliminar la lógica antigua basada en activar/desactivar GameObjects.

## 4. Navegación y Limpieza

- [x] 4.1 Implementar el método `public void TornarAlMenu()`.
- [x] 4.2 Añadir lógica para desconectar la red (ej. llamar a `WebSocketClient.Instance.Disconnect()` si aplica).
- [x] 4.3 Cargar la escena "MenuPrincipal" usando `SceneManager.LoadScene`.
