## Why

L'estructura actual de les pantalles de Login i Lobby a `MenuUI.uxml` és inconsistent i dificulta el disseny d'interfícies amb elements posicionats de forma precisa sobre fons predefinits. Refactoritzant aquestes pantalles a un model de "capsa fixa" (Fixed Box) amb posicionament absolut, obtindrem un control total sobre la disposició dels elements, facilitant la seva integració visual en el futur.

## What Changes

- **Refactorització de `#pantallaLogin` i `#pantallaLobby`**: Es configuraran com a contenidors flexibles a pantalla completa, centrats i sense fons propis.
- **Noves Capses de Dibuix**:
  - `#CapsaDibuixLogin`: Contenidor de 500x700px per a la interfície de login.
  - `#CapsaDibuixLobby`: Contenidor de 800x600px per a la interfície del lobby.
- **Reubicació d'Elements**: Els camps de text, llistes i botons es mouran dins de les seves respectives capses de dibuix.
- **Posicionament Absolut i Estilització**: Tots els botons d'aquestes pantalles passaran a usar posicionament absolut, amb fons transparents i sense vores.

## Capabilities

### New Capabilities
- `fixed-layout-login-lobby`: Implementació d'una estructura de UI basada en capses de mida fixa i posicionament absolut per a les pantalles de login i lobby.

### Modified Capabilities
- `ui-foundations`: Extensió de les convencions de disseny fixes a la resta de pantalles del menú principal.

## Impact

- **Fitxers afectats**: `DAMT3Atrapa la bandera/Assets/UI/MenuUI.uxml`.
- **Sistemes**: Interfície d'usuari (UI Toolkit).
- **Dependències**: No hi ha canvis en les dependències externes.
