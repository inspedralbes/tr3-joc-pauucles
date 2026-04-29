## 1. Correcció de Queries i Referències

- [ ] 1.1 Revisar i corregir les queries `.Q<VisualElement>("ContenidorPPTLLS")` i `.Q<VisualElement>("ContenidorParellsSenars")` a `MinijocUIManager.cs`.
- [ ] 1.2 Assegurar que les referències es guarden correctament i no es perden entre crides.

## 2. Implementació de la Gestió de Visibilitat

- [ ] 2.1 Crear el mètode privat `AmagarTotsElsContenidors()` que posi `DisplayStyle.None` a totes les referències de contenidors no nules.
- [ ] 2.2 Cridar a `AmagarTotsElsContenidors()` al principi de `ShowUI()`.
- [ ] 2.3 Cridar a `AmagarTotsElsContenidors()` a dins de `HideUI()`.

## 3. Reassignació d'IDs i Lògica de Ruleta

- [ ] 3.1 Actualitzar l'array `_nomsMinijocs` per moure "ParellsSenars" a la posició 2 (ID 2).
- [ ] 3.2 Modificar el `switch` a `ShowUI()` per gestionar el `case 2` iniciant el minijoc de Parells o Senars.
- [ ] 3.3 Eliminar el comportament de "fallback tie" per a l'ID 2.
- [ ] 3.4 Dins de cada cas del switch, activar només el contenidor corresponent posant `DisplayStyle.Flex`.

## 4. Validació

- [ ] 4.1 Provar la ruleta i verificar que mai es veuen dos menús alhora.
- [ ] 4.2 Confirmar que no surten errors de "contenidor no trobat" a la consola si l'objecte està actiu.
- [ ] 4.3 Validar que el joc Parells o Senars s'inicia correctament quan surt l'ID 2.
