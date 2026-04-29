## Why

Cal afegir varietat als minijocs de combat per fer l'experiència de joc més dinàmica. El "Minijoc de Pols de Força" ofereix una mecànica ràpida basada en la velocitat de polsatge, ideal per resoldre enfrontaments directes entre jugadors.

## What Changes

- **Nou script de minijoc**: Creació de `MinijocPolsimForcaLogic.cs` per gestionar la lògica del pols de força.
- **Mecànica de polsatge**: Implementació de detecció d'entrada per a dos jugadors (J1: Espai/Click Esquerre, J2: Return/Click Dret).
- **Gestió de temps i puntuació**: Sistema de compte enrere de 10 segons i puntuació dinàmica que oscil·la entre 0 i 100.
- **Integració amb el sistema de combat**: Notificació del guanyador al gestor de combats en finalitzar el temps.

## Capabilities

### New Capabilities
- `minijoc-pols-forca`: Capacitat de gestionar un duel de pols de força basat en la velocitat de teclat o ratolí per a dos jugadors, amb límit de temps i determinació de guanyador.

### Modified Capabilities
- Cap.

## Impact

- `Assets/Scripts/MinijocPolsimForcaLogic.cs`: Nou fitxer de lògica.
- `MinijocUIManager.cs`: Caldrà integrar aquest nou minijoc per poder ser visualitzat i cridat durant els combats.
