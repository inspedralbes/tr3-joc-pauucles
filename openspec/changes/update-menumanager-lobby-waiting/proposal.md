## Why

Actualment el `MenuManager.cs` no gestiona la transició a una sala d'espera després de crear una partida. Aquesta funcionalitat és essencial per permetre als jugadors esperar a altres usuaris abans de començar el joc i per visualitzar l'estat actual de la sala.

## What Changes

- Addició de referències a la UI de la sala d'espera (`pantallaSalaEspera`, `btnTancarSalaEspera`).
- Implementació de la transició visual del Lobby a la Sala d'Espera en crear una sala amb èxit.
- Gestió de l'ID de la sala actual (`currentRoomId`).
- Funcionalitat per abandonar la sala d'espera i tornar al Lobby.

## Capabilities

### New Capabilities
- `unity-waiting-room-management`: Gestió de l'estat visual i la navegació de la sala d'espera al client Unity.

### Modified Capabilities
- Cap (és una millora de la interfície de l'usuari i el flux de navegació).

## Impact

- `DAMT3Atrapa la bandera/Assets/Scripts/MenuManager.cs`: S'afegeixen variables i lògica de navegació.
- UI Toolkit: Es depèn de l'existència dels elements `pantallaSalaEspera` i `btnTancarSalaEspera` al fitxer UXML vinculat.
