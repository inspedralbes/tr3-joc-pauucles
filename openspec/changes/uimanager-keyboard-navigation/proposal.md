## Why

Actualment, els menús dels minijocs només es poden navegar amb el ratolí, cosa que dificulta l'accessibilitat i la velocitat de resposta durant els combats ràpids. És necessari implementar un sistema de navegació per teclat (WASD/Fletxes) que permeti als jugadors seleccionar i confirmar la seva jugada de forma més eficient.

## What Changes

- **Navegació per Teclat**: Implementació de la lògica per moure's entre botons usant W/S i les tecles de fletxa (Amunt/Avall).
- **Feedback Visual de Selecció**: Canvi dinàmic del color de fons del botó seleccionat per indicar el focus de l'usuari.
- **Confirmació per Teclat**: Suport per a les tecles Espai i Enter per activar el botó seleccionat.
- **Gestió d'Índexs**: Reinici automàtic de l'índex de selecció en obrir un nou minijoc per assegurar una experiència consistent.
- **Suport per a múltiples contenidors**: Aplicació de la navegació tant a `ContenidorPPTLLS` com a `ContenidorParellsSenars`.

## Capabilities

### New Capabilities
- `uimanager-ui-navigation`: Sistema de navegació i interacció amb elements de UI mitjançant el teclat.

### Modified Capabilities
- `uimanager-keyboard-input`: Expansió del suport de teclat per incloure navegació i confirmació global.

## Impact

- **MinijocUIManager.cs**: Actualització de l' `Update` per gestionar els inputs de navegació i implementació de mètodes per actualitzar el focus visual.
- **Experiència d'usuari**: Millora significativa en l'accessibilitat i el control dels minijocs.
