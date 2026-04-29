## Why

Actualmente el script `CyborgIA` requiere asignar manualmente los objetivos (`targetDinosaurio` y `baseDestino`) en el inspector. Esto limita la escalabilidad del entrenamiento y la flexibilidad de la escena. Al usar Tags para la búsqueda dinámica, el agente podrá encontrar sus objetivos automáticamente al inicio de cada episodio, incluso si estos son instanciados dinámicamente.

## What Changes

- Modificación de la visibilidad de `targetDinosaurio` y `baseDestino` de `public` a `private`.
- Implementación de un método de búsqueda dinámica basado en Tags y proximidad.
- Actualización de `OnEpisodeBegin()` para realizar la búsqueda automática.
- Refuerzo de la seguridad en `CollectObservations` para manejar casos donde los objetivos no sean encontrados.

## Capabilities

### New Capabilities
- `dynamic-target-discovery`: Capacidad del agente para localizar dinámicamente sus objetivos en la escena basándose en Tags y proximidad física.

### Modified Capabilities
<!-- No se modifican capacidades de especificación existentes de nivel superior -->

## Impact

- Script `CyborgIA.cs`.
- Configuración de la escena en Unity: se requiere que los objetos relevantes tengan los Tags "Dinosaurio" y "Base".
