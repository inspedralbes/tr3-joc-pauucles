## ADDED Requirements

### Requirement: Sincronització del Nametag amb Unity UI Text
El sistema SHALL actualitzar el component de text del jugador local amb el seu nom d'usuari real.

#### Scenario: Configuració de nom en el Nametag
- **WHEN** El `GameManager` configura els visuals del jugador local.
- **THEN** Es busca el component `UnityEngine.UI.Text` dins dels objectes fills del jugador.
- **THEN** S'assigna el valor de `MenuManager.Instance.username` al camp `text` del component trobat.
- **THEN** Si el component no es troba, s'emet un avís de depuració (Warning).
