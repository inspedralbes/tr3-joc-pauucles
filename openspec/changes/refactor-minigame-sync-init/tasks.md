## 1. Refactorización de Player.cs (Detección Host)

- [x] 1.1 Modificar `OnCollisionEnter2D` para incluir la guarda `if (!MenuManager.Instance.IsHost()) return;`.
- [x] 1.2 Eliminar la lógica de "SoyMaster" alfabética y el inicio inmediato de la UI en el cliente.
- [x] 1.3 Asegurar que el Host solo emita el mensaje `START_MINIGAME` y no abra la UI localmente de forma directa (esperará a su propio mensaje).

## 2. Implementación de Listener de Red (Gestor de Red)

- [x] 2.1 Definir el manejador para el mensaje `START_MINIGAME` en `MenuManager.cs` o `GameManager.cs`.
- [x] 2.2 Implementar la búsqueda de los objetos `Player` involucrados (atacante y defensor) por su ID/Username.
- [x] 2.3 Llamar a `MinijocUIManager.Instance.IniciarMinijoc()` desde el listener para ambos clientes.

## 3. Validación y Limpieza

- [x] 3.1 Eliminar la función obsoleta `IniciarMinijuegoLocal()` si existe en `Player.cs`.
- [x] 3.2 Verificar en una sesión multijugador que la UI aparece exactamente al mismo tiempo en ambos clientes tras el choque.
