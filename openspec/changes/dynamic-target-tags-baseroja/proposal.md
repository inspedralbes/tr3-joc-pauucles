## Why

Se requiere ajustar la búsqueda dinámica de objetivos en `CyborgIA` para utilizar los identificadores de tag exactos de la escena ("Dinosaurio" y "BaseRoja"). Esto asegura que el agente localice los objetos correctos en el entorno de juego actual.

## What Changes

- Mantenimiento de `targetDinosaurio` y `baseDestino` como variables `private`.
- Implementación de la lógica de búsqueda `TrobarMesProper` para seleccionar el objeto más cercano por tag.
- Configuración de `OnEpisodeBegin` para usar los tags "Dinosaurio" y "BaseRoja".
- Refuerzo de la seguridad en `CollectObservations` para evitar excepciones de referencia nula.

## Capabilities

### New Capabilities
- `dynamic-target-discovery-baseroja`: Capacidad del agente para localizar dinámicamente el dinosaurio y la base roja más cercana utilizando tags específicos.

### Modified Capabilities
<!-- No se modifican capacidades de especificación existentes -->

## Impact

- Script `CyborgIA.cs`.
- Requisito de que los objetos en la escena tengan asignados los tags "Dinosaurio" y "BaseRoja".
