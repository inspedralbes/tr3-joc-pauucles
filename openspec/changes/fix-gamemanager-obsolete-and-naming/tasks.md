## 1. Refactorització del GameManager

- [x] 1.1 Modificar `AssignarSpawn` per actualitzar el patró de noms a `PuntSpawn_Equip1` i `PuntSpawn_Equip2`.
- [x] 1.2 Substituir `Object.FindObjectsOfType<Transform>()` per `UnityEngine.Object.FindObjectsByType<Transform>(UnityEngine.FindObjectsSortMode.None)`.
- [x] 1.3 Canviar la comparació de noms de `Contains` a igualtat exacta (`==`).

## 2. Verificació i Neteja

- [x] 2.1 Comprovar que el warning CS0618 ha desaparegut de la consola de Unity.
- [x] 2.2 Validar que la cerca de punts de spawn retorna resultats correctes si els objectes de l'escena estan ben anomenats.
