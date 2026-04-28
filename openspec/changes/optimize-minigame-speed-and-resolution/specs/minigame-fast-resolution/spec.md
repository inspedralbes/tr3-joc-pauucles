## ADDED Requirements

### Requirement: Timer de Sesión Única
El sistema SHALL iniciar el temporizador del minijuego una sola vez al comienzo de la actividad.

#### Scenario: Timer sin reinicios
- **WHEN** el minijuego comienza
- **THEN** el sistema inicia el temporizador y prohíbe cualquier reinicio del mismo hasta la resolución final.

### Requirement: Resolución Basada en Eventos Inmediatos
El sistema SHALL finalizar el minijuego e informar del resultado en cuanto se cumpla una condición de victoria o derrota.

#### Scenario: Error del jugador
- **WHEN** un jugador comete un error (ej. falla el timing)
- **THEN** el sistema envía inmediatamente el mensaje de resultado y cierra la interfaz del minijuego.

#### Scenario: Objetivo completado
- **WHEN** un jugador alcanza el objetivo (ej. límite de pulsaciones)
- **THEN** el sistema envía inmediatamente el mensaje de resultado (Victoria) y cierra la interfaz.

### Requirement: Autoridad de Resolución por Velocidad
El sistema SHALL otorgar la victoria al jugador cuyo mensaje de éxito sea recibido primero por el servidor en caso de empate técnico.

#### Scenario: Doble acierto
- **WHEN** ambos jugadores completan el objetivo casi simultáneamente
- **THEN** el servidor declara ganador al primer mensaje procesado.

### Requirement: Castigo Segmentado
El sistema SHALL incluir el identificador del jugador perdedor en el mensaje de penalización para asegurar que solo este reciba el stun.

#### Scenario: Aplicación de Stun
- **WHEN** se resuelve un perdedor
- **THEN** el sistema emite un mensaje de castigo que contiene el ID del perdedor, y solo el cliente con ese ID aplica el efecto de stun.

### Requirement: Limpieza Post-Resolución
El sistema SHALL ocultar todos los elementos de la interfaz del minijuego inmediatamente tras la decisión del ganador.

#### Scenario: Retorno al gameplay
- **WHEN** el Host decide el ganador
- **THEN** ambos clientes ocultan la UI del minijuego de forma síncrona.
