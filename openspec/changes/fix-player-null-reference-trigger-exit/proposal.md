## Why

Se ha identificado un `NullReferenceException` recurrente en el script `Player.cs` dentro del método `OnTriggerExit2D`. Esto ocurre cuando el objeto que sale del trigger o sus componentes relacionados son destruidos o nulos en el momento del evento. Este cambio introduce programación defensiva para estabilizar el comportamiento del jugador al salir de zonas interactivas (como escaleras o bases).

## What Changes

- Adición de un "guard clause" al inicio de `OnTriggerExit2D` en `Player.cs`: `if (other == null || other.gameObject == null) return;`.
- Auditoría y protección de accesos a variables internas dentro del método (zonas de escala, referencias a banderas, etc.).
- Asegurar que cualquier acceso a propiedades del objeto `other` o de componentes internos se realice solo tras validar su existencia.

## Capabilities

### New Capabilities
- `stable-trigger-exit-handling`: Manejo robusto y seguro contra nulos en eventos de salida de trigger para el jugador.

### Modified Capabilities
<!-- No requirement changes to existing specs -->

## Impact

- Script `Player.cs`.
- Estabilidad del sistema de detección de zonas (escaleras, captura de banderas).
