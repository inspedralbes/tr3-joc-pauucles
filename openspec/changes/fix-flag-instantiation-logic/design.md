## Context

El script `GameManager.cs` es responsable de poblar la escena de juego tras la transición desde el lobby. La lógica actual de instanciación de banderas (objetos `Bandera`) presenta inconsistencias en la selección de colores, lo que afecta a la jugabilidad y la claridad visual. El `MenuManager` mantiene la "fuente de verdad" sobre la configuración de la sala.

## Goals / Non-Goals

**Goals:**
- Centralizar la lógica de selección de prefabs de banderas por color.
- Asegurar que el color visual del dinosaurio instanciado coincida con el configurado para el equipo A y B.
- Validar la inicialización de las propiedades del script `Bandera`.

**Non-Goals:**
- No se modificará el sistema de spawn de banderas (posiciones).
- No se cambiarán los prefabs existentes, solo su selección.

## Decisions

- **Mapeo por String**: Se implementará el método auxiliar `GameObject GetFlagPrefab(string color)` que traduzca strings como "Azul", "Blau", "Red", "Vermell" al objeto `banderaBlava`, `banderaVermella`, etc. Esto desacopla la obtención de datos de la instanciación física.
- **Uso de currentRoomData**: Se accederá a los campos `teamAColor` y `teamBColor` directamente para evitar mapeos manuales basados en el host o el orden de entrada.
- **Inicialización Post-Instancia**: Se utilizará `go.GetComponent<Bandera>()` inmediatamente después de `Instantiate` para inyectar el valor de `equipPropietari` ("A" o "B").

## Risks / Trade-offs

- **[Riesgo] Strings de color inconsistentes** → **[Mitigación]** El switch/mapeo utilizará `.ToLower()` y `Contains()` para manejar variaciones menores en el nombre de los colores (ej: "azul" vs "Azul").
- **[Riesgo] Acceso a MenuManager nulo** → **[Mitigación]** Añadir una guard clause al inicio de `InstanciarBanderes` que registre un error claro si los datos de la sala no están disponibles.
