## 1. Seguridad de Nulos en MinijocUIManager

- [x] 1.1 Localizar el método `FinalitzarCombat` en `MinijocUIManager.cs`.
- [x] 1.2 Añadir guarda inicial: `if (string.IsNullOrEmpty(winnerUsername)) { ... }` para manejar empates o resultados inválidos.
- [x] 1.3 Implementar verificaciones de nulidad antes de acceder a `GameManager.Instance`, `localPlayer` y las referencias de jugadores participantes.
- [x] 1.4 Validar la existencia del componente `NetworkSync` en la bandera antes de intentar modificar sus propiedades.

## 2. Refactorización de Inicio (Flujo Host)

- [x] 2.1 En `MenuManager.cs`, localizar el procesamiento del mensaje `MINIJOC_START`.
- [x] 2.2 Asegurar que la lógica de búsqueda de GameObjects y llamada a `IniciarMinijoc` se ejecute siempre que el usuario local sea uno de los participantes, independientemente de si es Host o Cliente.
- [x] 2.3 Eliminar cualquier redundancia que impida al Host abrir su propia UI tras enviar el mensaje.

## 3. Gestión de Empates y Errores

- [x] 3.1 Actualizar el envío de `MINIJOC_RESULT` en los scripts de lógica de minijuegos para asegurar que `winner` no sea nulo (enviar cadena vacía o "Empat").
- [x] 3.2 Verificar que el cierre de la UI y la restauración del movimiento funcionen correctamente incluso cuando no hay un ganador definido.

## 4. Validación

- [x] 4.1 Probar una colisión donde el Host sea el defensor y verificar que su interfaz se abra correctamente.
- [x] 4.2 Simular un empate (tiempo agotado sin acciones) y verificar que no hay errores de consola en ningún cliente.
