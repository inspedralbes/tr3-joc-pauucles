## ADDED Requirements

### Requirement: Integració de NativeWebSocket
El client Unity SHALL utilitzar la llibreria `NativeWebSocket` per a totes les comunicacions en temps real mitjançant el protocol WebSocket pur.

#### Scenario: Connexió del Client Unity
- **WHEN** s'arrenca l'escena on està el `MenuManager`
- **THEN** el client ha d'intentar establir una connexió WebSocket al servidor configurat (`ws://localhost:3000`).

### Requirement: Gestió del Fil Principal
El client SHALL assegurar-se que els callbacks d'esdeveniments del WebSocket s'executin al fil principal de Unity.

#### Scenario: Processament de Missatges
- **WHEN** el client rep un missatge del servidor WebSocket
- **THEN** el client ha de cridar a `DispatchMessageQueue()` al mètode `Update()` per processar els missatges a la cua d'esdeveniments.

### Requirement: Feedback de Connexió
El client SHALL proporcionar feedback visual (mitjançant logs de consola en aquesta fase) sobre l'estat de la connexió.

#### Scenario: Connexió Establerta
- **WHEN** la connexió WebSocket s'estableix correctament
- **THEN** s'ha de mostrar un log a la consola de Unity: "Connexió WebSocket pura establerta!".

#### Scenario: Connexió Tancada
- **WHEN** la connexió WebSocket es tanca o falla
- **THEN** s'ha de mostrar un log a la consola de Unity: "WebSocket desconnectat".
