## ADDED Requirements

### Requirement: Independent Identity Service
El sistema SHALL tener un servicio de identidad independiente ejecutándose en el puerto 3001. Este servicio debe manejar exclusivamente las rutas de `/login`, `/register` y gestión de perfiles de usuario.

#### Scenario: Successful Identity Service Startup
- **WHEN** el servicio de identidad se inicia
- **THEN** debe escuchar en el puerto 3001 y conectarse solo a los repositorios de usuarios

### Requirement: Independent Game Service
El sistema SHALL tener un servicio de juego independiente ejecutándose en el puerto 3002. Este servicio debe manejar exclusivamente la lógica de WebSockets, gestión de salas y estado de la partida.

#### Scenario: Successful Game Service Startup
- **WHEN** el servicio de juego se inicia
- **THEN** debe escuchar en el puerto 3002 y conectarse a los repositorios de juego y salas

### Requirement: Isolated Repository Instantiation
Cada microservicio SHALL instanciar solo los repositorios de MongoDB que requiere para sus operaciones, evitando cargar modelos innecesarios.

#### Scenario: Selective loading in Identity Service
- **WHEN** el Identity Service arranca
- **THEN** el registro de logs debe mostrar que solo se cargó el repositorio de usuarios y no los de juego
