## Why

Actualmente, el movimiento del `CyborgIA` sobrescribe completamente la velocidad en el eje Y (`rb.linearVelocity = dir * moveSpeed;`). Esto anula el efecto de la gravedad, causando que el agente flote o deje de caer cuando se mueve lateralmente. Es necesario separar el control horizontal del vertical para un comportamiento físico realista.

## What Changes

- Modificación de la lógica de asignación de velocidad en `OnActionReceived`.
- El control de movimiento solo afectará al eje X, respetando la velocidad actual del eje Y (gravedad).
- Soporte para movimiento vertical solo si la acción lo indica explícitamente, pero preservando la inercia de caída.

## Capabilities

### New Capabilities
- `gravity-respecting-movement`: El agente Cyborg puede moverse lateralmente sin anular las fuerzas verticales externas como la gravedad.

### Modified Capabilities
<!-- No se modifican requisitos de capacidades existentes -->

## Impact

- Script `CyborgIA.cs`.
- Comportamiento de navegación del agente (ahora caerá si no hay suelo).
