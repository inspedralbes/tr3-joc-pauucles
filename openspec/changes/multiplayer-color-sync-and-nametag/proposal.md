## Why

Per a una experiència de joc multijugador òptima, cal que els jugadors estiguin identificats visualment pels seus colors d'equip i els seus noms d'usuari. A més, la connexió ha de ser estable entre escenes i el moviment s'ha de reflectir correctament en tots els clients sense distorsions visuals en els Nametags.

## What Changes

- **Backend**: Broadcast global de missatges `PLAYER_MOVE` (roomId, username, x, y, flipX).
- **MenuManager (Unity)**: Implementació definitiva del Singleton persistent per garantir la connexió WebSocket al canviar d'escena i el processament centralitzat de missatges de xarxa.
- **GameManager (Unity)**: Sistema d'instanciació basat en colors d'equip. Es seleccionaran prefabs específics (Verd, Vermell, etc.) segons la configuració de la sala i l'equip del jugador.
- **Nametag i Moviment**: Ús de `flipX` per evitar l'efecte mirall en els noms d'usuari i integració amb `NetworkSync` per a la transmissió de posicions.

## Capabilities

### New Capabilities
- `color-based-spawn`: Capacitat d'instanciar diferents representacions visuals (prefabs) segons dades d'equip/color dinàmiques.
- `nametag-sync`: Sincronització de l'identificador textual (username) sobre cada avatar de jugador.

### Modified Capabilities
- `multiplayer-sync`: Es refina la transmissió per incloure el bit de gir (`flipX`).
- `centralized-websocket-management`: Es consolida l'estabilitat del Singleton persistent.

## Impact

- `GameManager.cs`: Nous camps per a prefabs de colors i lògica d'spawn actualitzada.
- `MenuManager.cs`: Consolidació com a gestor de xarxa persistent.
- `NetworkSync.cs`: Adaptació a la nova estructura de missatges.
- Prefabs de Jugador: Creació/Configuració de variants per color.
