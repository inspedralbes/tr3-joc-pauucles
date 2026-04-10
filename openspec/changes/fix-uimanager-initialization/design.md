## Context

S'ha identificat que el `MinijocUIManager` falla en accedir al `rootVisualElement` perquè la referència al `UIDocument` no es recupera correctament del GameObject "PantallaCombats". A més, la lògica de Singleton podria estar creant instàncies paral·leles que no tenen el component `UIDocument`.

## Goals / Non-Goals

**Goals:**
- Assegurar que `_uiDocument` s'assigna correctament usant `GetComponent<UIDocument>()`.
- Corregir el patró Singleton perquè utilitzi la instància existent a l'escena.
- Evitar l'accés a elements de la UI Toolkit si el component o l'objecte estan desactivats.

**Non-Goals:**
- Moure l'script a un altre GameObject.
- Canviar la jerarquia del fitxer UXML.

## Decisions

- **Inicialització en Awake**: S'eliminarà qualsevol assignació externa o creació dinàmica de `UIDocument`. El script buscarà el component en el mateix objecte on resideix.
- **Singleton Estricte**: El Singleton només s'assignarà si l'objecte té el component `UIDocument`. Si ja existeix una instància, la nova es destruirà immediatament per evitar conflictes.
- **Verificació d'Actiu**: Abans de mostrar la UI, es comprovarà `_uiDocument.isActiveAndEnabled` i `_uiDocument.rootVisualElement != null`.

## Risks / Trade-offs

- **[Risk] Awake order**: Si un altre script intenta accedir al Singleton abans que el seu `Awake` s'hagi executat, podria rebre null. -> **[Mitigation]**: S'ha d'assegurar que el `MinijocUIManager` estigui ben posicionat en l'ordre d'execució de Unity o utilitzar una inicialització lazy si cal, encara que el requeriment de l'usuari demana `Awake`.
