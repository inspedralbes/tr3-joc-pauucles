## Why

El minijoc de "Parells o Senars" actualment no té la lògica de joc implementada ni la interfície d'usuari funcional. Aquesta millora permetrà que el minijoc sigui jugable, amb un repte matemàtic aleatori, un límit de temps i conseqüències per a la victòria o derrota del jugador local.

## What Changes

- **Restauració de la UI**: Es configurarà el `UIDocument` per interactuar amb els elements visuals (etiquetes i botons).
- **Lògica de Càlcul Aleatori**: El joc generarà una suma de dos números aleatoris i determinarà si el resultat és parell o senar.
- **Temporitzador**: S'afegirà un compte enrere de 5 segons que actualitzarà la interfície en temps real.
- **Gestió d'Events de Botons**: Els botons "Parell" i "Senar" comprovaran la resposta de l'usuari.
- **Càstig/Recompensa**: Es cridaran els mètodes `GuanyarMinijoc()` o `PerdreMinijoc()` del jugador local segons el resultat, tancant la interfície del minijoc.

## Capabilities

### New Capabilities
- `minijoc-parells-senars-logic`: Lògica central del minijoc que gestiona el cicle de vida d'una partida ràpida de parells o senars.

### Modified Capabilities
- Cap (no hi ha specs prèvies detallades per aquest minijoc).

## Impact

- `MinijocParellsSenarsLogic.cs`: Serà el fitxer principalment afectat on es realitzarà tota la implementació.
- `PlayerLocal.cs` (o similar): S'utilitzarà per notificar el resultat del minijoc.
- Interfície d'usuari (UI Toolkit): S'interactuarà amb les labels de temps, operació i els botons de resposta.
