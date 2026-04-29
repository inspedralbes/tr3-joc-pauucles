## Why

El nou minijoc de pols de força necessita una interfície visual perquè els jugadors puguin veure el temps restant i el seu progrés (puntuació) durant el duel. Sense aquesta connexió, la mecànica és "cega" i l'usuari no rep feedback.

## What Changes

- **Integració de UI Toolkit a Pols de Força**: Modificació de `MinijocPolsimForcaLogic.cs` per gestionar elements visuals (`Label` per al temps i `VisualElement` per a la barra de progrés).
- **Mètode d'inicialització**: Creació de `InicialitzarUI(VisualElement root)` per fer el bind dels elements del document UXML.
- **Actualització visual en temps real**: Actualització del text del temporitzador i de l'amplada de la barra del Jugador 1 a l'`Update`.
- **Integració al Gestor de UI**: Actualització de `MinijocUIManager.cs` per incloure el contenidor del pols de força en la rotació de minijocs i activar la seva lògica.

## Capabilities

### New Capabilities
- `ui-integration-pols-forca`: Capacitat de vincular i actualitzar elements de l'UI Toolkit (temporitzador i barres de progrés) des de la lògica del minijoc de pols de força.

### Modified Capabilities
- Cap.

## Impact

- `MinijocPolsimForcaLogic.cs`: Nous camps privats i mètode d'inicialització.
- `MinijocUIManager.cs`: Lògica addicional per activar aquest minijoc específic.
