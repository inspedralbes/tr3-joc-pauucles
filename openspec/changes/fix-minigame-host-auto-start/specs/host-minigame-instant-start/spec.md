## ADDED Requirements

### Requirement: Inicio Local Instantáneo del Host
El sistema SHALL permitir que el jugador Host inicie la interfaz de minijuego inmediatamente tras procesar una colisión válida, sin depender de la recepción de mensajes de red externos.

#### Scenario: Host colisiona con un enemigo
- **WHEN** el jugador local es Host Y detecta una colisión válida con un enemigo
- **THEN** el sistema emite el mensaje de red `MINIJOC_START` Y activa inmediatamente la UI del minijuego localmente para los mismos participantes.

### Requirement: Protección de Redundancia de Apertura
El sistema SHALL ignorar peticiones de inicio de minijuego por red si ya existe un minijuego activo en el cliente local.

#### Scenario: Recepción de mensaje de inicio duplicado
- **WHEN** se recibe un mensaje `MINIJOC_START` por red Y la variable `minijocActiu` en `MinijocUIManager` es `true`
- **THEN** el sistema SHALL descartar el mensaje y NO intentar abrir una segunda instancia de la interfaz.
