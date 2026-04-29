## Context

S'ha detectat un error de compilació CS0103 ("The name '_contenidorCablePelat' does not exist in the current context") en el fitxer `MinijocUIManager.cs` després de la implementació de la lògica del nou minijoc.

## Goals / Non-Goals

**Goals:**
- Declarar la variable `_contenidorCablePelat` per permetre la compilació.
- Obtenir correctament la referència de l'element visual del UI Toolkit.

**Non-Goals:**
- Canviar la lògica del minijoc "Cable Pelat".
- Afegir nous mètodes al gestor de la IU.

## Decisions

- **Declaració a nivell de classe**: La variable es declara com a `private VisualElement` per ser coherent amb la resta de contenidors (`_contenidorPPTLLS`, `_contenidorParellsSenars`, etc.).
- **Inicialització a ShowUI**: L'assignació de la referència es realitza en el mètode `ShowUI` on es busquen la resta d'elements visuals mitjançant el mètode `Q`.

## Risks / Trade-offs

- **[Risc] NullReferenceException**: Si l'element "ContenidorCablePelat" no existeix al fitxer UXML, la variable serà null.
  - **[Mitigació]**: S'ha de verificar la seva existència abans d'usar-la en el mètode d'inicialització.
