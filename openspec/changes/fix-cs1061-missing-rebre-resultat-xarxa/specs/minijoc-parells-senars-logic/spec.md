## ADDED Requirements

### Requirement: Processament de resultats externs (Xarxa)
El sistema ha de ser capaç de rebre un senyal extern que indiqui el guanyador del minijoc i actuar en conseqüència si el jugador local ha perdut.

#### Scenario: Victòria del rival per xarxa
- **WHEN** es rep una crida a `RebreResultatXarxa` amb un guanyador que no és el local (ex: "RIVAL_WIN")
- **THEN** el joc s'atura immediatament (`jocActiu = false`), es tanca la interfície i es crida `playerLocal.PerdreMinijoc()`.
