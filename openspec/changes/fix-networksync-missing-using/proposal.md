## Why

L'script `NetworkSync.cs` presenta un error de compilació CS0103 ("The name 'WebSocketState' does not exist in the current context") perquè li falta la directiva `using` de la llibreria de WebSockets.

## What Changes

- S'afegeix `using NativeWebSocket;` a la part superior de `NetworkSync.cs`.
- Es restaura la capacitat de l'script per comprovar l'estat de la connexió abans d'enviar dades.

## Capabilities

### New Capabilities
<!-- Cap -->

### Modified Capabilities
- `multiplayer-sync`: Es corregeix un error tècnic que n'impedeix el funcionament.

## Impact

- `NetworkSync.cs`: Canvi menor per incloure el namespace necessari.
- Compilació: Es resol l'error CS0103 i el projecte torna a compilar correctament a Unity.
