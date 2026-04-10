## Context

El `MinijocUIManager` ja disposa d'un sistema de selecció aleatòria de minijocs (ruleta). Fins ara, només el minijoc PPTLLS tenia una interfície visual activa. Aquest disseny descriu com integrar la interfície per al minijoc de Parells o Senars, gestionant múltiples contenidors dins del mateix `UIDocument`.

## Goals / Non-Goals

**Goals:**
- Gestionar la visibilitat de contenidors visuals (`display: None/Flex`) segons el minijoc triat.
- Vincular els botons `BtnParells` i `BtnSenars` a la lògica corresponent.
- Implementar la resolució del combat per al minijoc ID 4.

**Non-Goals:**
- Implementar la interfície per als minijocs 2, 3, 5 o 6 en aquest canvi.
- Modificar el fitxer UXML (se suposa que els elements ja hi són o s'afegiran manualment).

## Decisions

- **Estructura de Contenidors**: S'utilitzaran dos `VisualElement` principals com a contenidors: `ContenidorPPTLLS` i `ContenidorParellsSenars`. Això permet aïllar les interfícies de cada minijoc dins del mateix fitxer UXML.
- **Mètode d'Assignació Automàtica**: Per simplificar les proves locals, quan un jugador tria una opció, s'assigna l'opció restant a l'oponent automàticament abans de cridar a la lògica de resolució.
- **Ús de `display`**: S'utilitzarà la propietat `style.display` de UI Toolkit per mostrar/amagar els contenidors, ja que és més eficient que activar/desactivar GameObjects.

## Risks / Trade-offs

- **[Risk] Referències nul·les**: Si el fitxer UXML no conté els noms exactes dels contenidors o botons, el script fallarà. -> **[Mitigation]**: S'afegiran comprovacions de nul·litat (`if (element != null)`) abans d'accedir a les propietats o esdeveniments dels elements de la UI.
