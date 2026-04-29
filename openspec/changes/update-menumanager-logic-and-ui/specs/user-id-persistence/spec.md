## ADDED Requirements

### Requirement: Emmagatzematge del User ID
El sistema HA D'emmagatzemar el camp `id` de la resposta JSON de login per identificar l'usuari durant la sessió.

#### Scenario: Login exitós guarda ID
- **WHEN** un usuari fa login correctament
- **THEN** el sistema guarda el valor del camp `id` del JSON de resposta a una variable privada `userId`.

### Requirement: Host en creació de sala
El sistema HA D'enviar el `userId` com a camp `host` en la petició de creació de sala.

#### Scenario: Creació de sala inclou host
- **WHEN** l'usuari confirma la creació d'una nova sala
- **THEN** el JSON enviat a `/games/create` inclou el camp `host` amb el `userId` emmagatzemat.
