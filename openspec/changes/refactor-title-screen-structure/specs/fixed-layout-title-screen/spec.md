## ADDED Requirements

### Requirement: Centered Main Container
El contenidor `#PantallaTitol` SHALL ocupar tot l'espai disponible i centrar el seu contingut tant horitzontal com verticalment.

#### Scenario: Centering verification
- **WHEN** el panell de la UI es renderitza
- **THEN** el contenidor `#PantallaTitol` té `width: 100%`, `height: 100%`, `justify-content: center` i `align-items: center`

### Requirement: Fixed Size Machine Box
El contenidor `#CapsaMaquina` SHALL tenir una mida fixa de 800x600 píxels i servir com a context de posicionament per als seus elements fills.

#### Scenario: Fixed box properties
- **WHEN** s'inspecciona `#CapsaMaquina`
- **THEN** té `width: 800px`, `height: 600px` i `position: relative`

### Requirement: Absolute Positioning of Elements
El títol (`Label`) i els botons de joc (`#btnStartGame`, `#btnExitGame`) SHALL estar posicionats de forma absoluta dins de `#CapsaMaquina`.

#### Scenario: Absolute elements check
- **WHEN** es comprova el posicionament dels elements fills de `#CapsaMaquina`
- **THEN** el Label i els botons tenen `position: absolute` i tots els seus marges a 0

### Requirement: Transparent Buttons
Els botons de la pantalla de títol SHALL tenir un fons transparent i no mostrar vores.

#### Scenario: Button visual style
- **WHEN** es visualitzen els botons `#btnStartGame` i `#btnExitGame`
- **THEN** tenen `background-color: transparent` i `border-width: 0`
