## Why

Habilitar la comunicación por WebSockets en el cliente de Unity para interactuar con el backend en tiempo real. Esta integración es fundamental para sincronizar eventos del juego de baja latencia entre los jugadores.

## What Changes

- **Dependencia de Unity**: Se añade `com.itisnajim.socketiounity` al `manifest.json` del proyecto Unity.
- **Origen de la Librería**: Se utiliza el repositorio oficial de GitHub de `SocketIOUnity` para descargar la dependencia mediante el Package Manager de Unity.

## Capabilities

### New Capabilities
- `unity-real-time-client`: Proporciona la infraestructura necesaria en Unity para conectarse y comunicarse con un servidor Socket.io.

### Modified Capabilities
- Ninguna.

## Impact

- **`DAMT3Atrapa la bandera/Packages/manifest.json`**: Se añade la nueva dependencia.
- **Unity Editor**: El Package Manager descargará automáticamente el paquete tras guardar el archivo.
