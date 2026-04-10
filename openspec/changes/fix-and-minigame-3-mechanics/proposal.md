## Why

Es requereix una correcció urgent d'un error de sintaxi a `MinijocUIManager.cs` que impedeix la compilació del projecte. A més, es vol millorar la jugabilitat del tercer minijoc (AturaBarra) introduint una "Zona Objectiu" aleatòria, fent que l'enfrontament sigui més dinàmic i depengui de la precisió del jugador.

## What Changes

- **Correcció de Sintaxi**: Arreclar l'error de string interpolat (CS8076, CS1002) a `MinijocUIManager.cs`.
- **Nova Mecànica AturaBarra**:
    - Introducció de l'element `ZonaObjectiu` a la UI.
    - Posicionament aleatori de la `ZonaObjectiu` en iniciar el minijoc.
    - Lògica de col·lisió entre la `Fletxa` i la `ZonaObjectiu` per determinar el guanyador.
    - Feedback visual i resolució del combat amb retard de 2.5 segons.

## Capabilities

### New Capabilities
- `minijoc-atura-barra-mechanics`: Mecànica de precisió amb zona objectiu aleatòria per al minijoc 3.

### Modified Capabilities
- `minijoc-atura-barra-logic`: Actualització de la lògica placeholder a una mecànica interactiva real.

## Impact

- **MinijocUIManager.cs**: Correccions de sintaxi i actualització profunda de la lògica d'AturaBarra.
- **UI Toolkit**: Cal assegurar que l'element `ZonaObjectiu` existeix al fitxer UXML.
- **Estabilitat**: El codi tornarà a compilar correctament.
