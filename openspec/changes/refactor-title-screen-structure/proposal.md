## Why

L'estructura actual de la pantalla de títol a `MenuUI.uxml` és poc flexible i utilitza mètodes de posicionament que dificulten el disseny precís d'interfícies fixes (com una màquina arcade). Refactoritzant a un contenidor de mida fixa amb posicionament absolut per als elements interns, tindrem un control total sobre la disposició visual, independentment de com s'ajusti el contenidor pare.

## What Changes

- **Refactorització de `#PantallaTitol`**: Es netejarà d'imatges de fons i es configurarà com un contenidor flexible a pantalla completa per centrar el contingut.
- **Nova estructura per a `#CapsaMaquina`**: Es transformarà en un contenidor de mida fixa (800x600px) amb posicionament relatiu per actuar com a marc de referència.
- **Posicionament Absolut**: El títol (`Label`) i els botons (`#btnStartGame`, `#btnExitGame`) es mouran directament dins de `#CapsaMaquina` i utilitzaran posicionament absolut.
- **Estilització de Botons**: S'eliminaran els fons i les vores dels botons de la pantalla de títol per permetre que el disseny de fons de la màquina (si n'hi ha un de global o posterior) defineixi la seva aparença.

## Capabilities

### New Capabilities
- `fixed-layout-title-screen`: Implementació d'una estructura de UI basada en un contenidor de mida fixa amb elements interns posicionats de forma absoluta per a la pantalla de títol.

### Modified Capabilities
- `ui-foundations`: Actualització de les convencions de disseny per a pantalles de menú principals.

## Impact

- **Fitxers afectats**: `DAMT3Atrapa la bandera/Assets/UI/MenuUI.uxml`.
- **Sistemes**: Interfície d'usuari (UI Toolkit).
- **Dependències**: No hi ha canvis en les dependències externes, només en l'estructura interna del fitxer UXML.
