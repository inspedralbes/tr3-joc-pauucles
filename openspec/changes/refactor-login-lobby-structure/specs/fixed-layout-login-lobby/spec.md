## ADDED Requirements

### Requirement: Full-screen Centered Wrappers
Els contenidors `#pantallaLogin` i `#pantallaLobby` SHALL ocupar tot l'espai del panell i centrar el seu contingut.

#### Scenario: Verification of screen wrappers
- **WHEN** la UI es renderitza
- **THEN** `#pantallaLogin` i `#pantallaLobby` tenen `width: 100%`, `height: 100%`, `justify-content: center` i `align-items: center`

### Requirement: Fixed Size Login Canvas
La pantalla de login SHALL tenir un contenidor de referència `#CapsaDibuixLogin` amb una mida fixa de 500x700px.

#### Scenario: Login canvas properties
- **WHEN** s'inspecciona `#CapsaDibuixLogin`
- **THEN** té `width: 500px`, `height: 700px` i `position: relative`

### Requirement: Fixed Size Lobby Canvas
La pantalla de lobby SHALL tenir un contenidor de referència `#CapsaDibuixLobby` amb una mida fixa de 800x600px.

#### Scenario: Lobby canvas properties
- **WHEN** s'inspecciona `#CapsaDibuixLobby`
- **THEN** té `width: 800px`, `height: 600px` i `position: relative`

### Requirement: Standardized Absolute Positioning
Tots els elements interactius (botons, inputs, llistes) dins de les capses de dibuix SHALL usar posicionament absolut.

#### Scenario: Check absolute positioning
- **WHEN** es comproven els elements fills de les capses de dibuix
- **THEN** tenen l'atribut `position: absolute`

### Requirement: Transparent Interactive Elements
Els botons de les pantalles de login i lobby SHALL ser transparents i sense vores per defecte.

#### Scenario: Button style verification
- **WHEN** es visualitzen els botons de login o lobby
- **THEN** tenen `background-color: transparent` i `border-width: 0px`
