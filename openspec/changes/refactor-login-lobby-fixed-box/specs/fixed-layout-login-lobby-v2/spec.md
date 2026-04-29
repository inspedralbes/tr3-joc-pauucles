## ADDED Requirements

### Requirement: Full-screen Centered Containers
Els contenidors `#pantallaLogin` i `#pantallaLobby` SHALL actuar com a wrappers a pantalla completa, sense fons, i centrant els seus fills.

#### Scenario: Verify main container styles
- **WHEN** el panell de la UI es carrega
- **THEN** `#pantallaLogin` i `#pantallaLobby` tenen `width: 100%`, `height: 100%`, `justify-content: center` i `align-items: center`

### Requirement: Login Drawing Box
La pantalla de login SHALL contenir un element `#CapsaDibuixLogin` amb mides fixes per al posicionament dels elements de registre i entrada.

#### Scenario: Fixed login box properties
- **WHEN** s'inspecciona `#CapsaDibuixLogin`
- **THEN** té `width: 500px`, `height: 700px`, `position: relative` i `-unity-background-scale-mode: scale-to-fit`

### Requirement: Lobby Drawing Box
La pantalla del lobby SHALL contenir un element `#CapsaDibuixLobby` amb mides fixes optimitzades per a la llista de partides.

#### Scenario: Fixed lobby box properties
- **WHEN** s'inspecciona `#CapsaDibuixLobby`
- **THEN** té `width: 900px`, `height: 500px`, `position: relative` i `-unity-background-scale-mode: scale-to-fit`

### Requirement: Absolute Positioning of UI Elements
Tots els botons, camps de text (`TextField`) i llistes (`ListView`) dins de les capses de dibuix SHALL estar posicionats de forma absoluta.

#### Scenario: Verify element positioning
- **WHEN** es comproven els elements interactius dins de `#CapsaDibuixLogin` o `#CapsaDibuixLobby`
- **THEN** tenen `position: absolute` i `margin: 0`

### Requirement: Minimalist Button Style
Els botons de les pantalles refactoritzades SHALL ser transparents per defecte, mostrant només el seu contingut de text o fons personalitzat del contenidor pare.

#### Scenario: Verify button aesthetics
- **WHEN** s'examinen els botons dins del login o lobby
- **THEN** tenen `background-color: transparent` i `border-width: 0px`
