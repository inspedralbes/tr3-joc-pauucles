## ADDED Requirements

### Requirement: Refresc Estabilitzat del Lobby
El sistema SHALL esperar un temps prudencial abans de refrescar la llista de partides quan el jugador torna al Lobby.

#### Scenario: Retorn al Lobby amb Retard
- **WHEN** el jugador prem el botó `btnTancarSalaEspera`.
- **THEN** el sistema ha d'esperar 0.5 segons abans d'executar la corrutina `ObtenirPartides` per assegurar que el servidor ha actualitzat correctament l'estat.
