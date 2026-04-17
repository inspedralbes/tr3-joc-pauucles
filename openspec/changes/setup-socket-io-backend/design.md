## Context

El backend actual utiliza Express para manejar peticiones HTTP y operaciones CRUD básicas. Para soportar el juego "Atrapa la bandera" en tiempo real, necesitamos una capa de WebSockets. Socket.io es la elección estándar debido a su robustez y facilidad de uso.

## Goals / Non-Goals

**Goals:**
- Instalar e integrar `socket.io` en el servidor backend.
- Modificar el arranque de Express para utilizar un servidor HTTP nativo (`http.createServer`).
- Configurar CORS para permitir conexiones WebSocket desde cualquier origen.
- Implementar un listener base para confirmar la conectividad de los clientes.

**Non-Goals:**
- Implementar la lógica del juego (movimiento, combate, etc.) en este paso.
- Cambiar la estructura de las rutas de la API existentes.
- Modificar la base de datos o el modelo de datos.

## Decisions

- **Envolver Express con `http.createServer(app)`**: Socket.io necesita una instancia de servidor HTTP para engancharse. Aunque `app.listen` crea una internamente, crearla explícitamente es una práctica recomendada que nos permite pasar la instancia directamente a `new Server(server)`.
- **CORS dinámico (`origin: "*"`)**: Para desarrollo y para coincidir con la flexibilidad actual de la API, permitiremos todas las conexiones. Esto se configurará directamente en las opciones de inicialización de Socket.io.
- **Middleware para inyectar `io` en las peticiones (Opcional pero recomendado)**: Consideramos inyectar la instancia de `io` en el objeto `req` de Express si necesitáramos emitir eventos desde los controladores en el futuro, pero por ahora nos limitaremos a la inicialización base solicitada.

## Risks / Trade-offs

- **[Riesgo] Interrupción de rutas API**: Al cambiar `app.listen` por `server.listen`, existe el riesgo de que la aplicación no arranque si hay errores en el servidor HTTP.
  - **Mitigación**: Usar el mismo puerto (`PORT`) definido en el entorno y verificar el arranque exitoso antes de dar la tarea por finalizada.
- **[Riesgo] Bloqueo de CORS por WebSockets**: Las reglas de CORS de Socket.io son independientes de las de Express.
  - **Mitigación**: Configurar explícitamente el objeto `cors` en el constructor de `Server`.
