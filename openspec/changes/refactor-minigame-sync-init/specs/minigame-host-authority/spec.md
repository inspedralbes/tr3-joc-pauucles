## ADDED Requirements

### Requirement: Autoridad de Detección del Host
El sistema DEBE permitir que solo el Host (creador de la sala) gestione la lógica de colisión para el inicio de minijuegos.

#### Scenario: Colisión detectada por el Host
- **WHEN** un jugador detecta una colisión en la máquina del Host.
- **THEN** el sistema DEBE seleccionar aleatoriamente un minijuego y emitir el mensaje `START_MINIGAME` por red.

#### Scenario: Colisión detectada por un Cliente
- **WHEN** un jugador detecta una colisión en una máquina que no es el Host.
- **THEN** el sistema DEBE ignorar el procesamiento local de la colisión y no abrir ninguna interfaz.

### Requirement: Recepción Obligatoria de Inicio
El sistema DEBE iniciar el minijuego en todos los clientes involucrados únicamente tras recibir la señal del servidor.

#### Scenario: Recepción de START_MINIGAME
- **WHEN** un cliente recibe el mensaje `START_MINIGAME` con su ID de usuario como atacante o defensor.
- **THEN** el sistema DEBE congelar el movimiento del jugador, mostrar la UI del minijuego especificado y establecer el estado de combate.

### Requirement: Sincronización de Participantes
El mensaje de inicio DEBE contener la información necesaria para identificar inequívocamente a los combatientes.

#### Scenario: Identificación de combatientes
- **WHEN** se emite el mensaje `START_MINIGAME`.
- **THEN** el sistema DEBE incluir `idAtacante`, `idDefensor` y `minijuegoID` en el payload del mensaje.
