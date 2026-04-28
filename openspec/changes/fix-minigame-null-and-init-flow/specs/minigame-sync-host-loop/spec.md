## ADDED Requirements

### Requirement: Procesamiento de Inicio en Host
El sistema SHALL asegurar que el Host procese el mensaje `MINIJOC_START` recibido por red para activar su propia interfaz de minijuego.

#### Scenario: Host recibe señal de inicio
- **WHEN** el Host recibe el mensaje `MINIJOC_START` con su ID de usuario como uno de los participantes
- **THEN** el sistema SHALL activar la UI de minijuego y congelar el movimiento local, sincronizándose temporalmente con el cliente remoto.

### Requirement: Sincronización de Identificadores de Juego
El sistema SHALL utilizar el `minijuegoID` proporcionado por el mensaje de red para abrir la instancia de minijuego correcta en todas las máquinas.

#### Scenario: Apertura de UI síncrona
- **WHEN** un cliente (incluido el Host) recibe el mensaje de inicio
- **THEN** el sistema SHALL llamar a `MinijocUIManager.IniciarMinijoc` utilizando exactamente el ID del juego contenido en el mensaje.
