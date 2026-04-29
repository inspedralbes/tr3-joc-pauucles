## 1. Definición de Estructura y Variables

- [x] 1.1 Asegurar que `targetDinosaurio` y `baseDestino` sean de visibilidad `private` en `CyborgIA.cs`.
- [x] 1.2 Implementar el método `private Transform TrobarMesProper(string tag)` para la lógica de selección por proximidad.

## 2. Lógica de Búsqueda Dinámica

- [x] 2.1 En `TrobarMesProper`, usar `GameObject.FindGameObjectsWithTag(tag)` e iterar para devolver el transform más cercano al agente.
- [x] 2.2 Actualizar `OnEpisodeBegin()` para asignar `targetDinosaurio` usando el tag "Dinosaurio".
- [x] 2.3 Actualizar `OnEpisodeBegin()` para asignar `baseDestino` usando el tag "BaseRoja".

## 3. Seguridad y Observaciones

- [x] 3.1 Añadir validación de nulidad para `targetDinosaurio` y `baseDestino` al inicio de `CollectObservations`.
- [x] 3.2 Si cualquiera es nulo, añadir `Vector3.zero` al sensor para las tres posiciones esperadas y el flag de dinosaurio, y realizar un return temprano.
- [x] 3.3 Asegurar que las llamadas a colisión y posicionamiento aleatorio validen que las referencias no sean nulas.
