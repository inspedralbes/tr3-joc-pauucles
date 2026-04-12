## ADDED Requirements

### Requirement: Declaració de la variable de contenidor Cable Pelat
El sistema HA DE declarar una variable privada per emmagatzemar la referència al contenidor visual del minijoc "Cable Pelat".

#### Scenario: Declaració amb èxit
- **WHEN** El codi es compila.
- **THEN** La variable `_contenidorCablePelat` està definida com a `VisualElement` a la classe `MinijocUIManager`.

### Requirement: Assignació de la referència del contenidor Cable Pelat
El sistema HA DE cercar l'element visual amb l'identificador `#ContenidorCablePelat` i assignar-lo a la variable corresponent.

#### Scenario: Assignació amb èxit
- **WHEN** Es crida al mètode `ShowUI`.
- **THEN** El sistema cerca `#ContenidorCablePelat` i n'emmagatzema la referència a `_contenidorCablePelat`.
