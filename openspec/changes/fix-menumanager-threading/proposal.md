## Why

Els callbacks de la llibreria `NativeWebSocket` en Unity s'executen en un fil en segon pla (background thread). Atès que la majoria de les APIs de Unity (com `Debug.Log`, UI Toolkit, etc.) només es poden cridar des del fil principal (main thread), el codi actual causa `UnityException`. Aquest canvi implementa un mecanisme de sincronització per executar accions des del fil principal.

## What Changes

- Implementació d'una cua d'execució asíncrona (`_executionQueue`) a `MenuManager.cs`.
- Creació del mètode `EnqueueMainThread` per afegir accions a la cua de forma segura entre fils.
- Modificació del mètode `Update` per buidar i executar la cua en cada frame.
- Refactorització dels listeners de `NativeWebSocket` per utilitzar `EnqueueMainThread` quan es cridin APIs de Unity.

## Capabilities

### New Capabilities
- `unity-main-thread-dispatcher`: Mecanisme per delegar l'execució de codi des de fils secundaris al fil principal de Unity de forma segura.

### Modified Capabilities
- Cap (és una millora d'implementació interna).

## Impact

- `DAMT3Atrapa la bandera/Assets/Scripts/MenuManager.cs`: S'afegeix la lògica de threading i es modifiquen els callbacks del WebSocket.
