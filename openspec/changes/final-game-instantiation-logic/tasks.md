## 1. Modificacions al GameManager (Unity)

- [x] 1.1 Implementar el mètode `InstanciarBanderes()`:
    - [x] 1.1.1 Llegir `teamAColor` i `teamBColor` de `MenuManager.Instance.currentRoomData`.
    - [x] 1.1.2 Afegir lògica de `switch/if` per mapejar colors a prefabs de banderes.
    - [x] 1.1.3 Instanciar la bandera A a `PuntSpawn_Equip1` (+2 offset X) i la B a `PuntSpawn_Equip2` (+2 offset X).
- [x] 1.2 Implementar el mètode `InstanciarJugador(string skinName, Transform spawnPoint)`:
    - [x] 1.2.1 Afegir `switch` per seleccionar el prefab segons la skin.
    - [x] 1.2.2 Assignar `prefabWoodcutter` com a opció per defecte.
- [x] 1.3 Actualitzar el mètode `Start()`:
    - [x] 1.3.1 Cridar `InstanciarBanderes()`.
    - [x] 1.3.2 Cridar `InstanciarJugador()` per al jugador local utilitzant la skin de `MenuManager.Instance.currentSkin`.

## 2. Verificació i Proves

- [x] 2.1 Verificar que les banderes apareixen en els colors triats a la sala.
- [x] 2.2 Verificar que el jugador local apareix amb la skin seleccionada a l'inventari.
