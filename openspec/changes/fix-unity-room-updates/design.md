## Context

El backend de Node.js utilitza `ACTUALITZAR_SALES` i `ROOM_UPDATED` com a tipus de missatges per a les actualitzacions en temps real. El client Unity té estructures de dades que no coincideixen amb el JSON del backend (usa `games` en lloc de `sales`, i `game` en lloc de `room`). A més, el client no està filtrant correctament els missatges de tipus `ACTUALITZAR_SALES`.

## Goals / Non-Goals

**Goals:**
- Sincronitzar les estructures de dades de C# amb el JSON del backend.
- Corregir la lògica de processament de missatges a `MenuManager.cs`.
- Assegurar que les actualitzacions de la UI es fan al fil principal.

**Non-Goals:**
- Canviar el protocol de comunicació (seguir amb WebSockets purs).
- Modificar el backend.
- Refer el sistema d'UI Toolkit.

## Decisions

### 1. Renombrar camps a RoomListMessage i RoomUpdateMessage
Es canviaran els noms dels camps a les classes serialitzables de C# per coincidir exactament amb les claus JSON del backend.
- `RoomListMessage.games` -> `RoomListMessage.sales`
- `RoomUpdateMessage.game` -> `RoomUpdateMessage.room`
- **Racional:** `JsonUtility` d'Unity és molt estricte amb els noms dels camps. Si no coincideixen exactament, el resultat serà `null` o buit.

### 2. Actualització del mètode AlRebreActualitzacioSales
Es modificarà el bloc `if` que comprova el tipus de missatge.
- Canviar `"room_list"` per `"ACTUALITZAR_SALES"`.
- Mantenir `"ROOM_UPDATED"`.
- **Racional:** El backend ja està enviant `"ACTUALITZAR_SALES"`, així que el client s'ha d'adaptar.

### 3. Ús de EnqueueMainThread per a tota la lògica de UI
Tota la lògica que modifiqui VisualElements s'ha d'encapsular en `EnqueueMainThread` per evitar errors de fil (thread-safety) en Unity.

## Risks / Trade-offs

- **[Risk]** Si el backend canvia el format de `GameData`, el client tornarà a fallar. -> **Mitigation:** El client registra errors de parseig a la consola per facilitar el depurat.
- **[Risk]** Alta freqüència d'actualitzacions del lobby podria causar parpelleig. -> **Mitigation:** `ConfigurarLlistaPartides` ja neteja la llista, però s'hauria de vigilar si la llista creix molt.
