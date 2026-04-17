## 1. Actualització d'Estructures de Dades (C#)

- [x] 1.1 Modificar `RoomListMessage` a `MenuManager.cs`: canviar el camp `games` per `sales`.
- [x] 1.2 Modificar `RoomUpdateMessage` a `MenuManager.cs`: canviar el camp `game` per `room`.

## 2. Refactorització del Processament de Missatges (C#)

- [x] 2.1 Actualitzar el mètode `AlRebreActualitzacioSales` a `MenuManager.cs`:
    - [x] 2.1.1 Canviar la condició `listMsg.type == "room_list"` per `listMsg.type == "ACTUALITZAR_SALES"`.
    - [x] 2.1.2 Corregir l'ús de `listMsg.sales` (abans `games`).
    - [x] 2.1.3 Corregir l'ús de `updateMsg.room` (abans `game`) al bloc de `ROOM_UPDATED`.
- [x] 2.2 Assegurar que totes les crides a `ConfigurarLlistaPartides` i `OmplirLlistaJugadors` es fan dins de `EnqueueMainThread`.

## 3. Verificació (Opcional si es pot provar localment)

- [x] 3.1 Provar la connexió i comprovar que el Lobby s'actualitza automàticament en crear o tancar sales al backend.
- [x] 3.2 Provar que la llista de jugadors d'una sala es refresca quan un nou jugador s'uneix o canvia l'estat de `READY`.
