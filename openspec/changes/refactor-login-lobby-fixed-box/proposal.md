## Why

L'objectiu és unificar el mètode de layout de totes les pantalles del menú principal (`#pantallaLogin` i `#pantallaLobby`) utilitzant una estructura de "capsa fixa" (Fixed Box). Això permet un control absolut sobre la posició dels elements visuals, facilitant la seva integració amb el disseny de fons de tipus arcade o màquina virtual, i assegurant que els botons i camps es mantinguin en coordenades precises independentment del contingut.

## What Changes

- **Refactorització de Contenidors Pare**: `#pantallaLogin` i `#pantallaLobby` passaran a ser contenidors centrats (Flexbox) a pantalla completa i sense fons.
- **Noves Capses de Disseny**:
  - `#CapsaDibuixLogin` (500x700px) per a la pantalla de login.
  - `#CapsaDibuixLobby` (900x500px) per a la pantalla del lobby.
- **Posicionament Absolut**: Tots els elements interactius (camps de text, botons, llistes) passaran a tenir `position: absolute` i marges a 0 per permetre el posicionament via coordenades (top/left).
- **Estilització de Botons**: Els botons d'aquestes pantalles seran transparents i sense vores per destacar només el text (o el disseny que hi hagi a sota).

## Capabilities

### New Capabilities
- `fixed-layout-login-lobby-v2`: Implementació refinada del sistema de capsa fixa per a les pantalles de login (500x700) i lobby (900x500).

### Modified Capabilities
- `ui-foundations`: Actualització de les mides estàndard per a les capses de dibuix de la interfície.

## Impact

- **Fitxers afectats**: `DAMT3Atrapa la bandera/Assets/UI/MenuUI.uxml`.
- **Sistemes**: Interfície d'usuari (UI Toolkit).
- **Dependències**: Cap canvi en dependències de codi, només canvis d'estructura UXML.
