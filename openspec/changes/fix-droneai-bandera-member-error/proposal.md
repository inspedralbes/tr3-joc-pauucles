## Why

El script `DroneAI.cs` presenta un error de compilación CS1061 debido al acceso a un miembro inexistente (`teamId`) en la clase `Bandera`. Este cambio corrige la referencia para utilizar el nombre correcto del miembro (`equipPropietari`) definido en `Bandera.cs`.

## What Changes

- **Corrección de Referencia**: Se cambia el acceso de `b.teamId` a `b.equipPropietari` dentro del método `BuscarDinosaurioEquipo` en `DroneAI.cs`.

## Capabilities

### New Capabilities
- Ninguna.

### Modified Capabilities
- Ninguna (es una corrección de implementación).

## Impact

- `DroneAI.cs`: Se resuelve el error de compilación, permitiendo que el dron localice correctamente la bandera de su equipo.
