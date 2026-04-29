## 1. Auditoría y Localización

- [x] 1.1 Localizar el método `InstanciarBanderes` en `GameManager.cs`.
- [x] 1.2 Identificar las referencias a los prefabs de banderas existentes en la clase.

## 2. Implementación de Lógica Robusta

- [x] 2.1 Implementar el método auxiliar `GameObject GetFlagPrefab(string color)` con lógica de switch/mapeo.
- [x] 2.2 Actualizar `InstanciarBanderes` para obtener `teamAColor` y `teamBColor` de `currentRoomData`.
- [x] 2.3 Utilizar `GetFlagPrefab` para seleccionar el prefab del equipo A e instanciarlo.
- [x] 2.4 Asignar `equipPropietari = "A"` a la instancia del equipo A.
- [x] 2.5 Utilizar `GetFlagPrefab` para seleccionar el prefab del equipo B e instanciarlo.
- [x] 2.6 Asignar `equipPropietari = "B"` a la instancia del equipo B.
- [x] 2.7 Añadir logs de depuración para confirmar los colores seleccionados para cada equipo.

## 3. Verificación

- [x] 3.1 Verificar que el script compila sin errores.
- [ ] 3.2 Validar en juego que los dinosaurios tienen el color correcto configurado en el lobby.
- [ ] 3.3 Confirmar que la lógica de captura funciona (la bandera reconoce a su dueño correctamente).
