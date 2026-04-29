## ADDED Requirements

### Requirement: Sincronització de nom d'usuari
Tots els prefabs de jugador (locals i remots) SHALL mostrar el seu `username` a l'element de text del seu Nametag.

#### Scenario: Configuració del Nametag en spawn
- **WHEN** Un jugador és instanciat.
- **THEN** El sistema busca el component `TextMeshPro` o similar dins de la jerarquia del prefab i hi assigna el valor del camp `username`.
