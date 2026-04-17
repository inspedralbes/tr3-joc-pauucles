## ADDED Requirements

### Requirement: Sincronització de Fils en Unity
El sistema SHALL permetre que qualsevol acció generada des d'un fil secundari sigui delegada al fil principal de Unity de forma segura per a la seva execució.

#### Scenario: Delegació Correcta al Fil Principal
- **WHEN** el backend rep una acció des d'un fil secundari (com un callback de WebSocket)
- **THEN** aquesta acció ha de ser emmagatzemada en una cua sincronitzada i executada posteriorment en el mètode `Update` de Unity.

### Requirement: Integració amb NativeWebSocket
Tots els esdeveniments de `NativeWebSocket` que cridin a APIs de Unity (Debug, UI, etc.) MUST utilitzar el mecanisme de sincronització.

#### Scenario: Callback de Connexió Segura
- **WHEN** s'invoca el callback `OnOpen` de `NativeWebSocket`
- **THEN** el log de consola s'ha d'executar a través del mecanisme de sincronització per evitar `UnityException`.
