## Context

El proyecto utiliza actualmente un backend monolítico en `backend/src/server.js` que gestiona tanto la API REST (autenticación) como las conexiones de tiempo real (Socket.io). Esta arquitectura presenta cuellos de botella y mezcla responsabilidades de dominio (Identidad vs. Juego). Contamos con Nginx en el repositorio, lo que facilita la transición a una arquitectura de microservicios mediante un proxy inverso.

## Goals / Non-Goals

**Goals:**
- Desacoplar la lógica de autenticación de la lógica de tiempo real del juego.
- Implementar un sistema de enrutamiento transparente para el cliente vía Nginx.
- Reducir la huella de memoria de cada servicio cargando solo los modelos de base de datos necesarios.
- Mantener la compatibilidad con el frontend existente sin cambios significativos en el cliente.

**Non-Goals:**
- Migrar a una arquitectura de contenedores más compleja (K8s) en este paso.
- Implementar comunicación inter-servicio (IPC) compleja; por ahora se busca aislamiento.
- Refactorizar la lógica interna de los controladores, solo su distribución.

## Decisions

### 1. Nginx como Gateway / Proxy Inverso
- **Decisión**: Utilizar Nginx para centralizar todas las peticiones entrantes.
- **Racional**: Permite que el cliente (Unity/Web) siga apuntando a un único punto de entrada, simplificando la gestión de CORS y evitando exponer múltiples puertos al exterior.
- **Alternativas**: Usar un API Gateway en Node.js (como Express-Gateway), pero Nginx es más eficiente para el manejo de conexiones WebSocket y ya está presente en el entorno.

### 2. Estructura de "Monorepo" para Servicios
- **Decisión**: Mantener los servicios dentro de `backend/src/` compartiendo las carpetas `models`, `repositories` y `services`.
- **Racional**: Facilita la implementación inmediata sin necesidad de gestionar múltiples repositorios o paquetes npm externos para el código compartido de base de datos. Cada servicio importará solo lo que necesite.

### 3. Separación de Puertos Internos
- **Decisión**: Identity Service en 3001, Game Service en 3002.
- **Racional**: Convención estándar para evitar colisiones y facilitar la configuración del upstream en Nginx.

## Risks / Trade-offs

- **[Riesgo] Configuración de WebSockets en Nginx** → **Mitigación**: Asegurar que las directivas `proxy_set_header Upgrade $http_upgrade` y `Connection "upgrade"` estén correctamente configuradas para evitar desconexiones.
- **[Riesgo] Duplicación de lógica de conexión a DB** → **Mitigación**: Centralizar la lógica de conexión en `db.js` y que cada servicio la invoque al arrancar.
- **[Riesgo] Latencia adicional por el Proxy** → **Mitigación**: Nginx tiene una latencia despreciable en comparación con la lógica de red de los servicios Node.js.
