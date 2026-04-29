## Why

Actualment, la sincronització en temps real de la interfície d'usuari (UI) del Lobby a Unity és deficient. Els canvis en l'estat de les sales (com ara la creació de noves sales, l'entrada o sortida de jugadors) no es reflecteixen de forma immediata per a tots els usuaris connectats. A més, existeix el risc que les actualitzacions visualitzades fallin silenciosament si s'intenten executar fora del fil principal (Main Thread) d'Unity.

## What Changes

- **Subscripció a esdeveniments de sala**: S'assegurarà que el client Unity processi correctament els missatges `ACTUALITZAR_SALES` i `ROOM_UPDATED` enviats pel backend.
- **Actualització visual immediata**: Es refactoritzaran les funcions de repintat de la UI (`ConfigurarLlistaPartides` i `OmplirLlistaJugadors`) per forçar un refresc visual (Rebuild/Refresh) després de cada actualització de dades.
- **Garantia de Main Thread**: Es validarà que totes les crides a la API de `UnityEngine.UIElements` derivades de missatges de xarxa estiguin encapsulades en el mètode `EnqueueMainThread`.
- **Neteja de redundància**: Es consolidarà la lògica de recepció de missatges per evitar que múltiples components processin el mateix esdeveniment de forma desarticulada.

## Capabilities

### New Capabilities
- `realtime-lobby-sync`: Sincronització reactiva de la llista de sales i la informació dels jugadors a la sala d'espera.

### Modified Capabilities
- Cap.

## Impact

- `MenuManager.cs`: Canvis en el processament de missatges i gestió de la UI.
- `WebSocketClient.cs`: Revisió per evitar col·lisions de processament.
- Experiència de l'usuari: Millora dràstica en la percepció de fluïdesa i consistència en el Lobby.
