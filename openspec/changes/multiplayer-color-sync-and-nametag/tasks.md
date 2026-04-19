## 1. Actualització del Backend

- [x] 1.1 Revisar `backend/src/server.js` per assegurar el broadcast de `PLAYER_MOVE` amb els camps `roomId`, `username`, `x`, `y`, `flipX` i animacions.

## 2. Consolidació del MenuManager (Unity)

- [x] 2.1 Implementar el patró Singleton amb `DontDestroyOnLoad`.
- [x] 2.2 Configurar la recepció de `PLAYER_MOVE` i la redirecció al `GameManager`.

## 3. Sistema de Colors al GameManager (Unity)

- [x] 3.1 Afegir referències a prefabs de colors: `prefabRojo`, `prefabVerde`, `prefabAzul`, `prefabAmarillo` i un `prefabDefecto`.
- [x] 3.2 Implementar la funció `GetPrefabPerColor(string color)` per mapejar noms de color a prefabs.
- [x] 3.3 Actualitzar la lògica d'instanciació per seleccionar el prefab basant-se en el color de l'equip del jugador.

## 4. Nametags i Sincronització (Unity)

- [x] 4.1 Modificar `Player.cs` (local) per usar `flipX` i assignar el `username` al seu Nametag.
- [x] 4.2 Actualitzar `NetworkSync.cs` per enviar el camp `flipX`.
- [x] 4.3 Actualitzar `RemotePlayer.cs` per aplicar `flipX` i mostrar el `username`.

## 5. Verificació

- [x] 5.1 Verificar que cada equip apareix amb el color triat a la sala.
- [x] 5.2 Comprovar que el nom d'usuari es llegeix correctament mentre el jugador gira.
