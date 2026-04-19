## Why

El sistema de joc necessita una lògica d'inicialització completa per a la partida. Actualment, no s'instancien les banderes basades en el color d'equip ni es gestiona la instanciació dinàmica dels personatges segons la skin seleccionada. Aquest canvi permetrà que la partida s'iniciï amb tots els elements visuals correctes tant per al jugador local com per als remots.

## What Changes

- **Instanciació de Banderes**: Implementació del mètode `InstanciarBanderes()` que consulta els colors d'equip de la sala actual i instancia els prefabs corresponents en els punts de spawn d'equip.
- **Lògica de Jugadors Dinàmica**: Implementació del mètode `InstanciarJugador(string skinName, Transform spawnPoint)` per permetre el spawn de personatges amb skins específiques (Biker, Cyborg, Woodcutter, etc.).
- **Inicialització del Start**: Integració d'aquestes crides en el mètode `Start()` del `GameManager` per garantir que la partida s'inicialitzi correctament en carregar l'escena.

## Capabilities

### New Capabilities
- `final-game-setup`: Gestió completa de la instanciació d'elements de joc (jugadors i banderes) basat en l'estat de la sala.

### Modified Capabilities
<!-- Cap -->

## Impact

- `GameManager.cs`: Canvi en el flux d'inicialització i addició de mètodes d'instanciació.
- Flux de joc: Garantia de sincronització visual inicial entre tots els clients.
