## Why

Un cop implementada la lògica de sortida de sales al backend, és necessari que el client Unity notifiqui activament al servidor quan un jugador decideix abandonar la sala d'espera. Això permet mantenir l'estat de les sales actualitzat i esborrar-les si es queden buides.

## What Changes

- Modificació de l'esdeveniment de clic de `btnTancarSalaEspera` a `MenuManager.cs`.
- Definició d'una estructura de dades (classe o objecte anònim) per al missatge `leave_room`.
- Enviament del missatge JSON a través de la connexió `NativeWebSocket` existent.

## Capabilities

### New Capabilities
- `unity-websocket-room-exit`: Notificació activa de sortida de sala al servidor mitjançant missatges WebSocket.

### Modified Capabilities
- Cap.

## Impact

- `DAMT3Atrapa la bandera/Assets/Scripts/MenuManager.cs`: S'actualitza el callback de tancament de sala per incloure la comunicació per xarxa.
