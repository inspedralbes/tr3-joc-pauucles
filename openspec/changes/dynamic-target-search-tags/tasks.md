## 1. Modificación de Visibilidad y Estructura

- [x] 1.1 Cambiar la visibilidad de `targetDinosaurio` y `baseDestino` de `public` a `private` en `CyborgIA.cs`.
- [x] 1.2 Implementar el método privado `TrobarMesProper(string tag)` que devuelva un `Transform`.

## 2. Lógica de Búsqueda Dinámica

- [x] 2.1 En `TrobarMesProper`, usar `GameObject.FindGameObjectsWithTag(tag)` para obtener los candidatos.
- [x] 2.2 Implementar el bucle de iteración para encontrar el objeto más cercano usando `Vector2.Distance`.
- [x] 2.3 Actualizar `OnEpisodeBegin()` para llamar a `TrobarMesProper` para "Dinosaurio" y "Base" antes de cualquier otra lógica.

## 3. Seguridad y Observaciones

- [x] 3.1 Añadir comprobaciones de nulidad para `targetDinosaurio` y `baseDestino` en `CollectObservations`.
- [x] 3.2 Si son nulos, añadir `Vector3.zero` al sensor y realizar un return temprano del método.
- [x] 3.3 Verificar que el posicionamiento aleatorio en `OnEpisodeBegin` solo ocurra si el objetivo no es nulo.
