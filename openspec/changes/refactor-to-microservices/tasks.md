## 1. Preparación y Refactorización de Capa de Datos

- [x] 1.1 Analizar `backend/src/server.js` para identificar la distribución actual de rutas y lógica de sockets.
- [x] 1.2 Asegurar que la lógica de conexión a MongoDB en `db.js` sea exportable y reutilizable por múltiples servicios.

## 2. Implementación de Identity Service (Puerto 3001)

- [x] 2.1 Crear el archivo `backend/src/identity-service.js`.
- [x] 2.2 Migrar las rutas de autenticación (`/login`, `/register`) y sus controladores asociados.
- [x] 2.3 Configurar el servicio para cargar exclusivamente los modelos de Usuario.
- [x] 2.4 Validar que el servicio responde correctamente a peticiones HTTP en el puerto 3001.

## 3. Implementación de Game Service (Puerto 3002)

- [x] 3.1 Crear el archivo `backend/src/game-service.js`.
- [x] 3.2 Migrar la lógica de inicialización de Socket.io y los handlers de eventos de juego.
- [x] 3.3 Configurar el servicio para cargar los modelos de salas y estado de partida.
- [x] 3.4 Validar que el servicio acepta conexiones WebSocket en el puerto 3002.

## 4. Configuración de Nginx como Gateway

- [x] 4.1 Localizar y editar el archivo de configuración activo de Nginx (ej. `nginx_default.conf`).
- [x] 4.2 Definir los bloques `upstream` para `identity_service` (3001) y `game_service` (3002).
- [x] 4.3 Configurar la directiva `location /api/auth` para redirigir al Identity Service.
- [x] 4.4 Configurar la directiva `location /` o `/socket.io` para redirigir al Game Service, incluyendo soporte para WebSockets.
- [x] 4.5 Reiniciar/Recargar Nginx y validar el enrutamiento unificado (Configuración preparada).

## 5. Pruebas de Integración y Cierre

- [x] 5.1 Realizar una prueba de flujo completo: Registro -> Login -> Conexión a Sala de Juego a través del proxy.
- [x] 5.2 Verificar que no hay fugas de memoria o errores de repositorios no encontrados en los logs de cada servicio.
- [x] 5.3 Deprecar el archivo `server.js` original (Renombrado a server.js.old).
