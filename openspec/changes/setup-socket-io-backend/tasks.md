## 1. Configuración de Dependencias

- [x] 1.1 Instalar `socket.io` en el directorio `backend` usando `npm install socket.io`.

## 2. Integración de Socket.io en server.js

- [x] 2.1 Importar el módulo `http` nativo de Node.js en `backend/src/server.js`.
- [x] 2.2 Importar la clase `Server` del paquete `socket.io`.
- [x] 2.3 Crear una instancia del servidor HTTP envolviendo la aplicación `app` de Express.
- [x] 2.4 Inicializar `io` utilizando la instancia del servidor HTTP y configurando CORS para permitir todos los orígenes (`origin: "*"`).
- [x] 2.5 Implementar el listener base `io.on("connection", ...)` para registrar la conexión de nuevos clientes en la consola.
- [x] 2.6 Modificar el arranque de la aplicación para que utilice `server.listen` en lugar de `app.listen`, asegurando que el puerto y el callback se mantengan igual.

## 3. Verificación y Pruebas

- [x] 3.1 Arrancar el servidor y verificar que no hay errores de sintaxis o de inicialización en la consola.
- [x] 3.2 Probar una de las rutas de la API existentes (por ejemplo, `/ping` o `/api/users`) para asegurar que el servidor HTTP sigue manejando correctamente el tráfico de Express.
- [x] 3.3 Verificar que el mensaje "Client connectat via Socket" aparezca cuando se intente conectar un cliente de prueba (o mediante herramientas como Postman/Insomnia).
