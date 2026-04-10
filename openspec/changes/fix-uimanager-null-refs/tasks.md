## 1. Implementació de Seguretat Null a MinijocUIManager

- [x] 1.1 Modificar `ShowUI` a `MinijocUIManager.cs` per comprovar si `_uiDocument.rootVisualElement` és nul.
- [x] 1.2 Afegir comprovacions de nul·litat a les referències `_contenidorPPTLLS` i `_contenidorParellsSenars` abans d'usar-les.
- [x] 1.3 Assegurar que si no es troba algun element crític, es cridi a `HideUI()` per alliberar els jugadors.
- [x] 1.4 Incloure missatges descriptius amb `Debug.LogError` per facilitar la depuració en cas de falla.

## 2. Verificació

- [x] 2.1 Compilar el projecte a Unity.
- [x] 2.2 Provar que el joc no llança excepcions `ArgumentNullException` quan es col·lideix entre jugadors.
- [x] 2.3 Simular la falta de contenidors al fitxer UXML i verificar que es logueja un error sense tancar el joc.
