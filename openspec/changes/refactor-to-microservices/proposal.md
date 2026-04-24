## Why

La arquitectura monolítica actual en `server.js` dificulta la escalabilidad y el mantenimiento independiente de las funcionalidades de autenticación y juego. Esta transición a microservicios permitirá un escalado diferenciado, despliegues más seguros y una mejor organización del código, asegurando que el sistema sea más robusto y fácil de extender en el futuro.

## What Changes

- **BREAKING**: El servidor monolítico centralizado se descompone en servicios independientes. Las comunicaciones que antes eran internas ahora podrían requerir saltos de red controlados por Nginx.
- **División de Servicios**: Creación de `identity-service.js` (Puerto 3001) para autenticación y `game-service.js` (Puerto 3002) para WebSockets y lógica de juego.
- **Configuración de Nginx**: Actualización de la configuración para actuar como Proxy Inverso, enrutando `/api/auth` al servicio de identidad y las conexiones de socket/juego al servicio de juego.
- **Optimización de Capa de Datos**: Refactorización para que cada microservicio instancie únicamente los repositorios de MongoDB necesarios para su dominio.

## Capabilities

### New Capabilities
- `microservices-infrastructure`: Definición y configuración de los nuevos servicios independientes y su ciclo de vida.
- `service-discovery-proxy`: Implementación de la capa de enrutamiento mediante Nginx para unificar el acceso a los microservicios.

### Modified Capabilities
- `foundations`: Actualización de la arquitectura base del sistema para soportar el modelo distribuido.

## Impact

- `backend/src/server.js`: Será descompuesto en los nuevos servicios.
- `nginx_default.conf` (o archivos de configuración equivalentes): Requerirá nuevas reglas de proxy pass.
- `backend/src/repositories/` y `backend/src/models/`: Se modificará cómo se instancian y cargan en los servicios.
- Scripts de despliegue/Dockerfile: Ajustes para soportar múltiples puntos de entrada.
