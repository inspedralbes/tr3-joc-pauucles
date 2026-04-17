## ADDED Requirements

### Requirement: Broadcast global de sales
El sistema SHALL enviar les actualitzacions de la llista de sales (`ACTUALITZAR_SALES`) a TOTS els clients connectats via WebSocket, sense cap tipus de filtre.

#### Scenario: Sincronització global del Lobby
- **WHEN** Es crea o s'elimina una sala.
- **THEN** El servidor itera per tots els clients a `wss.clients` i els envia el missatge `ACTUALITZAR_SALES` si el seu estat és `OPEN`.
