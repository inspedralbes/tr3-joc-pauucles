## 1. Persistència de Skin al Login

- [x] 1.1 Modificar `FerLogin` o la gestió de la resposta a `MenuManager.cs` per extreure `skinEquipada`.
- [x] 1.2 Implementar `PlayerPrefs.SetString("skinEquipada", ...)` amb el valor obtingut.

## 2. Refactorització del GameManager

- [x] 2.1 Definir el `struct SkinMapping` a `GameManager.cs`.
- [x] 2.2 Afegir la llista `public List<SkinMapping> skinsDisponibles` al `GameManager`.
- [x] 2.3 Modificar `InstanciarLocalPlayer` per llegir la skin desada amb `PlayerPrefs.GetString`.

## 3. Lògica d'Instanciació i Càmera

- [x] 3.1 Implementar la cerca del prefab correcte dins de `skinsDisponibles`.
- [x] 3.2 Actualitzar el seguiment de la càmera (Cinemachine o MainCamera) per apuntar al nou objecte del jugador.
- [x] 3.3 Verificar que el `NetworkSync` i el `Nametag` es configuren correctament en el nou objecte.

## 4. Configuració a l'Editor

- [ ] 4.1 Assignar els prefabs de les skins a la llista `skinsDisponibles` des de l'Inspector d'Unity.
- [ ] 4.2 Provar el flux complet: Login -> Càrrega d'escena -> Validació visual de la skin.
