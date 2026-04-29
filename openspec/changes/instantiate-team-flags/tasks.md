## 1. Actualització del MenuManager (Unity)

- [x] 1.1 Afegir `public GameData currentRoomData;` a la classe `MenuManager`.
- [x] 1.2 Actualitzar `EnviarPeticioJoin` per guardar el resultat a `currentRoomData`.
- [x] 1.3 Actualitzar `EnviarPeticio` (en el cas de `/games/create`) per guardar el resultat a `currentRoomData`.

## 2. Configuració de Banderes al GameManager (Unity)

- [x] 2.1 Afegir variables públiques de tipus `GameObject`: `banderaBlava`, `banderaVermella`, `banderaGroga`, `banderaVerda`.
- [x] 2.2 Implementar el mètode `GetFlagPrefab(string color)` per retornar el prefab correcte.
- [x] 2.3 Implementar el mètode `InstanciarBanderes()`:
    - [x] 2.3.1 Cercar els objectes `PuntSpawn_Equip1` i `PuntSpawn_Equip2` a l'escena.
    - [x] 2.3.2 Instanciar la bandera de l'equip A al punt 1 amb offset X=+2.
    - [x] 2.3.3 Instanciar la bandera de l'equip B al punt 2 amb offset X=+2.
- [x] 2.4 Cridar `InstanciarBanderes()` dins del mètode `Start()` del `GameManager`.

## 3. Verificació

- [x] 3.1 Verificar que les banderes apareixen amb el color correcte segons la sala.
- [x] 3.2 Verificar que el posicionament és correcte respecte als spawns.
