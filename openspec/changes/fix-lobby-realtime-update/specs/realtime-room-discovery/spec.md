## ADDED Requirements

### Requirement: Notificació immediata de creació de sala
El servidor SHALL realitzar un broadcast per WebSocket a tots els clients connectats quan es creï una nova sala de joc amb èxit.

#### Scenario: Broadcast en crear sala
- **WHEN** un usuari envia una petició per crear una sala i el servidor la guarda correctament a MongoDB.
- **THEN** el servidor emet un missatge de tipus `ACTUALITZAR_SALES` que inclou el llistat actualitzat de sales actives.

### Requirement: Consistència de la llista de sales
El broadcast d'actualització SHALL contenir exclusivament les sales que es troben en estat d'espera (`waiting`).

#### Scenario: Filtratge de sales enviades
- **WHEN** el servidor prepara el missatge `ACTUALITZAR_SALES`.
- **THEN** el sistema recupera de MongoDB només aquelles sales que encara no han començat la partida (estat `waiting`).
