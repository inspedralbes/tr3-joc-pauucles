## MODIFIED Requirements

### Requirement: Sincronització del Nametag Local
El sistema SHALL mostrar el nom d'usuari correcte sobre el cap del jugador local.

#### Scenario: Configuració del Nametag en spawn
- **WHEN** El jugador local és configurat o instanciat pel `GameManager`.
- **THEN** Es busca el component `TextMeshPro` (o `TextMeshProUGUI`) dins de la jerarquia de fills de l'objecte.
- **THEN** S'hi assigna el valor del camp `username` o `userId` obtingut de la sessió.
- **THEN** Si no es troba el component, s'emet un avís al log.
