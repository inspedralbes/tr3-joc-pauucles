## Context

El component `UIDocument` de Unity UI Toolkit, quan es desactiva i es torna a activar, tendeix a recarregar l'asset UXML des de zero si no es gestiona amb cura. En el cas del `MinijocUIManager`, el mètode `HideUI()` està provocant aquesta recàrrega en desactivar el component o el GameObject, el que resulta en una pèrdua de l'estat visual configurat (com els contenidors amagats) i mostra tots els elements per defecte.

## Goals / Non-Goals

**Goals:**
- Mantenir el component `UIDocument` i el `GameObject` "PantallaCombats" sempre actius.
- Delegar tota la gestió de visibilitat al sistema d'estils (`display: None/Flex`).
- Evitar la recàrrega de l'asset UXML entre minijocs.

**Non-Goals:**
- Canviar el fitxer UXML.
- Modificar el sistema de selecció de minijocs (ruleta).

## Decisions

- **Persistència de l'Arrel**: Es mantindrà l'arrel de la UI activa per assegurar que les referències obtingudes a `Awake` o `ShowUI` segueixin sent vàlides i que el motor de UI no hagi de re-instanciar el DOM visual.
- **HideUI Minimalista**: El mètode `HideUI` es limitarà a cridar `AmagarTotsElsContenidors()`. Això és suficient per fer que la UI sigui "invisible" per a l'usuari sense desconnectar-la del sistema de Unity.
- **Accés Directe a l'Estil**: S'utilitzarà `element.style.display` per garantir que el motor de UI Toolkit aplica el canvi de visibilitat de forma immediata i eficient.

## Risks / Trade-offs

- **[Risk] UI Bloquejant Inputs**: Si el fons de la UI és transparent però intercepta clics, podria bloquejar el joc encara que sembli amagada. -> **[Mitigation]**: S'ha d'assegurar que el contenidor principal o el fons també s'amaguen amb `display: None` o que la propietat `pickingMode` està ben configurada. En aquest cas, `AmagarTotsElsContenidors` hauria d'incloure el fons si cal, o els contenidors han de cobrir tota la zona interactiva.
