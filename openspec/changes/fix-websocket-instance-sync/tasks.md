## 1. Refactorització del MenuManager (Unity)

- [x] 1.1 Implementar el patró Singleton a `MenuManager.cs` (`public static MenuManager Instance`).
- [x] 1.2 Afegir `DontDestroyOnLoad(gameObject)` a `Awake`.
- [x] 1.3 Fer pública la variable `websocket` (`public WebSocket websocket`).
- [x] 1.4 Protegir els accessos a la UI ( VisualElements ) amb `if != null` per evitar errors en canviar d'escena.

## 2. Actualització del Flux de Missatges (Unity)

- [x] 2.1 Modificar el mètode de recepció a `MenuManager.cs` per processar missatges `PLAYER_MOVE`.
- [x] 2.2 Redirigir les dades de moviment rebuts al `GameManager.Instance.UpdateRemotePlayer()`.

## 3. Correcció del NetworkSync (Unity)

- [x] 3.1 Actualitzar `NetworkSync.cs` per utilitzar `MenuManager.Instance.websocket.SendText()` en lloc de cridar a `WebSocketClient`.
- [x] 3.2 Eliminar referències obsoletes a `WebSocketClient` dins del loop de moviment.

## 4. Verificació

- [x] 4.1 Comprovar que la connexió es manté activa en entrar al "Bosque".
- [x] 4.2 Verificar que els jugadors remots es mouen en temps real.
