## Context

El proyecto de Unity requiere un cliente de Socket.io compatible con .NET/Unity para comunicarse con el servidor Node.js. `SocketIOUnity` es un wrapper robusto del cliente oficial de Socket.io para C#.

## Goals / Non-Goals

**Goals:**
- Integrar la librería `SocketIOUnity` en el proyecto de Unity mediante el sistema de gestión de paquetes (UPM).
- Asegurar que la librería sea descargable directamente desde GitHub para facilitar el control de versiones.

**Non-Goals:**
- Implementar la lógica de envío de mensajes en este paso.
- Configurar servidores WebSocket adicionales.

## Decisions

- **Uso de Git URL en `manifest.json`**: Unity permite añadir paquetes externos proporcionando la URL del repositorio Git. Esta opción es más limpia que descargar el `.unitypackage` manualmente, ya que permite actualizar y gestionar la dependencia de forma centralizada.
- **Librería `SocketIOUnity` (itisnajim)**: Se elige esta versión por su buena integración con el sistema de eventos de Unity y su compatibilidad con las versiones recientes de Socket.io en el servidor.

## Risks / Trade-offs

- **[Riesgo] Problemas de red al descargar de GitHub** → **Mitigación**: Verificar que el entorno de desarrollo tenga acceso a GitHub y que la URL sea correcta.
- **[Riesgo] Incompatibilidad de versiones de NewtonSoft.Json** → **Mitigación**: Unity suele incluir `com.unity.nuget.newtonsoft-json`. Si hay conflictos, se resolverán ajustando las dependencias en el Package Manager.
