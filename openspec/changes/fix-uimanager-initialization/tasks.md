## 1. Refactorització de la Inicialització

- [x] 1.1 Actualitzar el mètode `Awake` per assignar `_uiDocument = GetComponent<UIDocument>()`.
- [x] 1.2 Corregir la lògica de Singleton a `Awake` per assegurar que s'usa la instància de l'escena.
- [x] 1.3 Afegir un `Debug.LogError` si `_uiDocument` no es troba en el mateix GameObject.

## 2. Millora del mètode ShowUI

- [x] 2.1 Afegir una comprovació de nul·litat per a `_uiDocument` i `_uiDocument.rootVisualElement` al principi de `ShowUI`.
- [x] 2.2 Comprovar que el component `_uiDocument` estigui actiu (`isActiveAndEnabled`) abans d'accedir al root.
- [x] 2.3 Refactoritzar la lògica de cerca de contenidors per ser més robusta davant de components desactivats.

## 3. Validació

- [x] 3.1 Verificar que el Singleton s'assigna correctament al GameObject "PantallaCombats".
- [x] 3.2 Confirmar que no es llancen excepcions `ArgumentNullException` quan s'inicia un combat.
- [x] 3.3 Comprovar que si el GameObject es desactiva manualment, el log d'error és descriptiu i no hi ha crash.
