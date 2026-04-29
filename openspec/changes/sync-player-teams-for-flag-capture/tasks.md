## 1. Preparación del Componente Jugador

- [x] 1.1 Añadir la variable `public string equip;` al script `Player.cs`.
- [x] 1.2 Asegurar que `Player.cs` compile correctamente.

## 2. Sincronización en GameManager

- [x] 2.1 Implementar el método auxiliar `GetTeamFromRoomData(string username)` en `GameManager.cs` que busque el equipo en `MenuManager.Instance.currentRoomData.players`.
- [x] 2.2 En `ConfigurarLocalPlayerVisuals()`, asignar el equipo al `localPlayer` usando el método auxiliar.
- [x] 2.3 En `UpdateRemotePlayer()`, asignar el equipo al nuevo `RemotePlayer` instanciado (a través de su componente `Player`).
- [x] 2.4 Añadir logs de depuración para confirmar que se están asignando los equipos correctamente.

## 3. Actualización de Bandera y Verificación

- [x] 3.1 Modificar `OnTriggerEnter2D` en `Bandera.cs` para obtener el equipo directamente: `string equipJugador = player.equip;`.
- [x] 3.2 Simplificar la lógica de comparación de equipos usando la variable sincronizada.
- [x] 3.3 Verificar que el proyecto compila sin errores.
- [ ] 3.4 Validar el comportamiento: los aliados no deben poder capturar su propia bandera y los enemigos sí.
