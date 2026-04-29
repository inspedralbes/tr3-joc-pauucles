## Context

S'ha detectat un error de compilació CS0103 ("The name '_contenidorCablePelat' does not exist in the current context") en el fitxer `MinijocUIManager.cs`. Aquest error bloqueja la compilació del projecte des de la introducció de la lògica del minijoc "Cable Pelat".

## Goals / Non-Goals

**Goals:**
- Declarar la variable `_contenidorCablePelat` per permetre la compilació.
- Obtenir correctament la referència de l'element visual del UI Toolkit.

**Non-Goals:**
- Modificar la lògica d'altres minijocs.
- Redissenyar l'estructura del gestor de la IU.

## Decisions

- **Declaració a nivell de classe**: Es declara com a `private VisualElement _contenidorCablePelat;` juntament amb els altres contenidors visuals (`_contenidorPPTLLS`, `_contenidorParellsSenars`, etc.) per mantenir la consistència del codi.
- **Assignació a ShowUI**: S'utilitza el mètode `root.Q<VisualElement>("ContenidorCablePelat")` dins del mètode `ShowUI` (on s'assignen la resta d'elements visuals) per obtenir la referència en temps d'execució.

## Risks / Trade-offs

- **[Risc] NullReferenceException**: Si l'identificador "ContenidorCablePelat" no coincideix amb el definit al fitxer UXML, la variable serà nul·la.
  - **[Mitigació]**: Assegurar-se que l'identificador al fitxer UXML és correcte i afegir una comprovació de nul·litat opcional abans de l'ús.
