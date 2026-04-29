## Context

Actualment, el client Unity utilitza `SocketIO` per comunicar-se amb el backend. Atès que el backend ha migrat a WebSockets purs (`ws`), el client Unity ha de fer el mateix per garantir la interoperabilitat. S'utilitzarà la llibreria `NativeWebSocket` per a Unity, ja que ofereix un bon suport tant per a l'Editor com per a WebGL.

## Goals / Non-Goals

**Goals:**
- Substituir la llibreria `SocketIO` per `NativeWebSocket`.
- Refactoritzar `MenuManager.cs` per gestionar la nova connexió WebSocket.
- Garantir que els missatges del WebSocket es processin al fil principal de Unity (`DispatchMessageQueue`).

**Non-Goals:**
- No es refactoritzarà la lògica de joc dins de Unity, només la capa de transport.
- No s'implementarà cap nova funcionalitat de joc en aquesta fase.

## Decisions

- **Llibreria `NativeWebSocket`**: S'ha triat aquesta llibreria perquè és lleugera, s'integra bé amb el gestor de paquets de Unity (UPM) i és altament compatible amb diferents plataformes de Unity.
- **Connexió Asíncrona**: Es modificarà el mètode `Start()` a `async void` per permetre l'ús de `await websocket.Connect()`, evitant bloquejos en l'arrencada de l'escena.
- **Gestió de la Cua de Missatges**: S'implementarà el mètode `Update()` per cridar a `websocket.DispatchMessageQueue()`, assegurant que els callbacks s'executin al fil principal de Unity.

## Risks / Trade-offs

- **[Risk] Canvi de format de missatges** → **Mitigation**: Caldrà assegurar-se que els missatges enviats i rebuts pel backend pur siguin compatibles amb el que el client espera rebre (JSON vs Binary). En aquesta fase inicial, s'enfoca en la connexió.
- **[Trade-off] Manca d'esdeveniments tipats** → **Mitigation**: `NativeWebSocket` treballa amb un flux d'esdeveniments més bàsic (`OnOpen`, `OnMessage`, etc.). Caldrà parsejar manualment els missatges si abans es feia mitjançant esdeveniments de SocketIO.

## Migration Plan

1. Modificar `Packages/manifest.json` per canviar les dependències.
2. Actualitzar els `using` i la definició de la variable de socket a `MenuManager.cs`.
3. Inicialitzar i connectar el WebSocket al `Start()`.
4. Afegir la crida a `DispatchMessageQueue()` al `Update()`.
