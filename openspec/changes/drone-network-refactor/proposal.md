## Why

El sistema de sincronización del dron actual presenta conflictos de autoridad entre el Host y los Clientes, lo que genera movimientos erráticos y falta de precisión en los estados de IA. Es necesario establecer una separación estricta de responsabilidades: el Host calcula la IA y la física, mientras que los Clientes se limitan a replicar visualmente la posición recibida, eliminando cualquier lógica local que interfiera.

## What Changes

- **Depuración de Clientes (DroneNetworkSync.cs)**: Los clientes no-Host destruirán sus componentes de IA (`DroneAI`, `DecisionRequester`) y pasarán su física a modo Kinematic.
- **Sincronización Unidireccional**: Solo el Host enviará datos de movimiento; los Clientes solo interpolarán (Lerp) hacia los datos recibidos.
- **Estados Rígidos de IA (DroneAI.cs)**:
    - **REPOSO**: El dron se ancla físicamente a la base y apaga el razonamiento de ML-Agents.
    - **CAZA**: Se activa el razonamiento y se utiliza una velocidad de caza aumentada para perseguir objetivos.
    - **RETORNO**: Se apaga el razonamiento y se utiliza movimiento determinista (MoveTowards) para volver a la base ignorando colisiones.

## Capabilities

### New Capabilities
- `drone-state-authority`: Implementación de una máquina de estados rígida con autoridad absoluta del Host y replicación visual pura en Clientes.

### Modified Capabilities
- Ninguna.

## Impact

- `DroneAI.cs`: Refactorización completa de la lógica de movimiento y estados.
- `DroneNetworkSync.cs`: Cambio en la gestión de componentes durante la inicialización.
- Rendimiento de Red: Reducción de conflictos de físicas y mejora en la suavidad visual para los Clientes.
