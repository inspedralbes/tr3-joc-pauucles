## Context

En la versió actual de `MinijocUIManager.cs`, el mètode `ShowUI` inicialitza les referències als contenidors visuals (`_contenidorPPTLLS` i `_contenidorParellsSenars`) utilitzant `_uiDocument.rootVisualElement.Q<VisualElement>("...")`. S'ha reportat una `ArgumentNullException` quan s'intenta fer aquesta consulta, indicant que `rootVisualElement` o un element intermig és nul.

## Goals / Non-Goals

**Goals:**
- Implementar comprovacions de nul·litat robustes abans de cada consulta UQuery.
- Assegurar que la lògica d'activació de minijocs no depengui d'elements de UI no trobats.
- Millorar el diagnòstic d'errors de UI mitjançant `Debug.LogError`.

**Non-Goals:**
- Redissenyar el fitxer UXML o l'estructura de la interfície.
- Modificar la lògica de resolució dels minijocs.

## Decisions

- **Null-Check de `rootVisualElement`**: Abans de qualsevol consulta `.Q()`, es comprovarà si `rootVisualElement` és nul. Si ho és, s'avortarà el mètode `ShowUI` per evitar el crash.
- **Validació de Contenidors**: Les referències als contenidors es validaran després de la cerca. Si no es troben, es loguejarà un error descriptiu i el minijoc es cancel·larà mitjançant `HideUI()` o una sortida controlada.
- **Accés Segur a `style.display`**: Només s'accedirà a la propietat de visibilitat si el contenidor corresponent ha estat trobat amb èxit.

## Risks / Trade-offs

- **[Risk] UI Invisible**: Si el logueig d'errors falla o és ignorat, el jugador podria quedar-se immòbil (`potMoure = false`) sense veure cap interfície. -> **[Mitigation]**: S'ha d'assegurar que si la UI no es pot mostrar, es cridi immediatament a `HideUI()` per restaurar la mobilitat del jugador.
