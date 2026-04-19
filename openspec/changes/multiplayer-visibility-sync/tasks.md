## 1. Correcció Visual (Unity)

- [x] 1.1 Localitzar l'script de moviment (ex: `PlayerController.cs` o similar).
- [x] 1.2 Substituir la lògica de gir: canviar les assignacions a `transform.localScale` per `spriteRenderer.flipX = (direccio < 0)`.

## 2. Implementació al Backend

- [x] 2.1 Modificar `backend/src/server.js`:
    - [x] 2.1.1 Afegir handler per al missatge `PLAYER_MOVE`.
    - [x] 2.1.2 Implementar el broadcast del missatge rebut a tots els clients connectats.

## 3. Sincronització de Moviment (Unity)

- [x] 3.1 Crear l'script `NetworkSync.cs`:
    - [x] 3.1.1 Implementar l'enviament periòdic (10Hz) de posició, `flipX` i animació actual al servidor.
- [x] 3.2 Actualitzar el sistema de recepció de missatges (ex: `WebSocketClient.cs` o `GameManager.cs`) per processar `PLAYER_MOVE`.

## 4. Gestió de Jugadors Remots (Unity)

- [x] 4.1 Crear el prefab `JugadorRemot`.
- [x] 4.2 Crear l'script `RemotePlayer.cs` per aplicar les dades de xarxa a l'objecte remot (posició, flipX, animator).
- [x] 4.3 Implementar a `GameManager` (o similar) la lògica d'instanciació de jugadors remots en rebre l'inici de la partida o en unir-se nous jugadors.

## 5. Verificació

- [x] 5.1 Verificar que el Nametag no gira amb el personatge.
- [x] 5.2 Verificar que el moviment del jugador A es reflecteix a la pantalla del jugador B.
