## 1. Gestió de Dependències Unity

- [x] 1.1 Editar `DAMT3Atrapa la bandera/Packages/manifest.json`.
- [x] 1.2 Eliminar la dependència de SocketIO si existeix.
- [x] 1.3 Afegir la dependència de `NativeWebSocket`: `"com.endel.nativewebsocket": "https://github.com/endel/NativeWebSocket.git#upm"`.

## 2. Refactorització de MenuManager.cs

- [x] 2.1 Actualitzar els `using`: eliminar `SocketIO` i afegir `using NativeWebSocket;`.
- [x] 2.2 Canviar el mètode `Start()` a `async void Start()`.
- [x] 2.3 Inicialitzar la variable `websocket = new WebSocket("ws://localhost:3000");`.
- [x] 2.4 Configurar els listeners `OnOpen` i `OnClose` amb missatges de log.
- [x] 2.5 Afegir `await websocket.Connect();` al final del `Start()`.
- [x] 2.6 Implementar `void Update()` per cridar a `websocket.DispatchMessageQueue()`.

## 3. Verificació i Neteja

- [x] 3.1 Verificar que el projecte Unity compila sense errors.
- [x] 3.2 Comprovar que el client es connecta correctament al servidor WebSocket backend quan s'executa el projecte.
