## Why

Actualmente, cuando un jugador captura la bandera y la transporta, esta permanece estática visualmente. Añadir animaciones reactivas (caminar cuando se mueve) proporcionará un mejor feedback visual y hará que la "mascota" (bandera) se sienta más viva durante el transporte.

## What Changes

- Implementación de detección de movimiento reactivo en `Bandera.cs` basado en la diferencia de posición entre frames.
- Integración con el componente `Animator` para activar el parámetro `isWalking`.
- Lógica específica para activar estas animaciones solo cuando la bandera tiene un padre (está siendo transportada).

## Capabilities

### New Capabilities
- `reactive-flag-animations`: Sistema de animación reactiva para objetos transportados basado en el desplazamiento del transform.

### Modified Capabilities
<!-- No requirement changes to existing specs -->

## Impact

- Script `Bandera.cs`.
- Animator de la bandera (parámetro `isWalking`).
- Feedback visual de la mecánica de transporte.
