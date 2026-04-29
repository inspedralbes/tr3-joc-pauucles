## 1. Implementació del Thread Dispatcher

- [x] 1.1 Crear la variable `private readonly System.Collections.Generic.Queue<System.Action> _executionQueue = new System.Collections.Generic.Queue<System.Action>();` a `MenuManager.cs`.
- [x] 1.2 Implementar el mètode `public void EnqueueMainThread(System.Action action)` amb `lock`.

## 2. Consum de la Cua

- [x] 2.1 Actualitzar el mètode `Update` per buidar i executar `_executionQueue` utilitzant `lock`.

## 3. Refactorització de Listeners de WebSocket

- [x] 3.1 Modificar `websocket.OnOpen` per utilitzar `EnqueueMainThread`.
- [x] 3.2 Modificar `websocket.OnClose` per utilitzar `EnqueueMainThread`.
- [x] 3.3 Modificar `websocket.OnError` per utilitzar `EnqueueMainThread`.
- [x] 3.4 Modificar `websocket.OnMessage` per utilitzar `EnqueueMainThread`.

## 4. Verificació

- [x] 4.1 Comprovar que el projecte compila sense errors de sintaxi.
- [x] 4.2 Verificar que els logs de connexió apareixen a la consola de Unity sense llançar `UnityException`.
