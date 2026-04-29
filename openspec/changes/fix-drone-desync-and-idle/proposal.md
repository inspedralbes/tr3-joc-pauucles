## Why

El dron presenta problemas de desincronización entre el Host y los Clientes, además de un comportamiento errático cuando no tiene un objetivo activo. Estas mejoras buscan estabilizar el comportamiento del dron mediante un estado de reposo preciso, una política de "títere" más estricta en los clientes y una gestión de red temporal para el dinosaurio transportado para evitar interferencias.

## What Changes

- **Reposo Preciso (DroneAI.cs)**: Cuando el dinosaurio está en la base (A_Salvo), el dron anulará la entrada de la IA, detendrá su física y flotará suavemente hacia su base.
- **Modo Títere Estricto (DroneNetworkSync.cs)**: Los clientes remotos desactivarán o destruirán activamente todos los componentes de ML-Agents para evitar que el dron intente actuar localmente, convirtiéndolo en un objeto puramente visual.
- **Secuestro de Red del Dinosaurio (DroneAI.cs)**: Al capturar el dinosaurio, el dron desactivará el script de sincronización de red de este para tener el control total de su posición durante el transporte, reactivándolo al soltarlo.

## Capabilities

### New Capabilities
- `drone-reliable-sync`: Sistema de sincronización y estados de reposo de alta fidelidad para agentes IA multijugador.

### Modified Capabilities
- Ninguna.

## Impact

- `DroneAI.cs`: Modificación profunda de los estados de IA y captura física.
- `DroneNetworkSync.cs`: Cambio en la política de inicialización de componentes según el rol.
- Estabilidad de Red: Se espera una reducción drástica de "jitters" y discrepancias visuales del dron y el dinosaurio.
