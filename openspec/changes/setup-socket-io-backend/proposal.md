## Why

Habilitar la comunicación bidireccional y en tiempo real entre el servidor y los clientes del juego "Atrapa la bandera". Esto es esencial para sincronizar eventos inmediatos como la captura de banderas, actualizaciones de posición y el estado del combate sin depender de peticiones HTTP tradicionales.

## What Changes

- **Dependencia de Socket.io**: Se añadirá `socket.io` al proyecto del backend mediante `npm install`.
- **Integración con Express**: El servidor Express existente en `backend/src/server.js` se vinculará a un servidor HTTP nativo para soportar WebSockets.
- **Configuración de CORS**: Se configurará `socket.io` para permitir conexiones desde cualquier origen (`origin: "*"`), manteniendo la paridad con la configuración actual de la API.
- **Listener de Conexión Base**: Se implementará un listener inicial para el evento `connection` que registre las conexiones entrantes de los clientes.
- **Continuidad de Servicio**: Se garantiza que las rutas de la API existentes sigan funcionando y que el servidor mantenga el mismo puerto de escucha.

## Capabilities

### New Capabilities
- `real-time-communication`: Proporciona una infraestructura base para mensajería en tiempo real utilizando WebSockets a través de Socket.io.

### Modified Capabilities
- Ninguna. No se modifican los requisitos de las capacidades existentes.

## Impact

- **`backend/package.json`**: Se añade `socket.io` como dependencia.
- **`backend/src/server.js`**: Cambios estructurales para envolver la aplicación Express con un servidor HTTP y arrancar Socket.io.
- **Infraestructura**: Nuevo endpoint de WebSocket disponible en la misma dirección y puerto que la API.
