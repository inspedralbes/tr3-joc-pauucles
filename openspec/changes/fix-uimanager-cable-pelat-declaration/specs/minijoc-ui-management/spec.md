## ADDED Requirements

### Requirement: Declaració de la variable per al contenidor Cable Pelat
El sistema HA DE declarar una variable privada per emmagatzemar la referència al contenidor visual del minijoc "Cable Pelat".

#### Scenario: Declaració amb èxit
- **WHEN** El codi es compila.
- **THEN** La variable `_contenidorCablePelat` està definida a la classe `MinijocUIManager`.

### Requirement: Inicialització de la referència del contenidor Cable Pelat
El sistema HA D'assignar la referència de l'element visual `#ContenidorCablePelat` a la variable corresponent.

#### Scenario: Assignació amb èxit
- **WHEN** Es crida al mètode `ShowUI`.
- **THEN** El sistema cerca l'element visual mitjançant `root.Q` i assigna el resultat a `_contenidorCablePelat`.
