## 1. Millora de la Subscripció de Missatges (Unity)

- [x] 1.1 Revisar el mètode `AlRebreActualitzacioSales` a `MenuManager.cs` per assegurar que processa correctament tant la llista global com les dades de sala específica.
- [x] 1.2 Garantir que tots els blocs de processament de dades estiguin protegits amb `try-catch` per evitar que un error de parseig talli el thread.

## 2. Refactorització del Fil Principal (Unity)

- [x] 2.1 Moure les crides a `ConfigurarLlistaPartides` i `OmplirLlistaJugadors` estrictament dins de blocs `EnqueueMainThread`.
- [x] 2.2 Verificar que el mètode `Update` de `MenuManager` processa la cua `_executionQueue` en cada frame.

## 3. Consolidació de la UI Reactiva (Unity)

- [x] 3.1 Actualitzar `ConfigurarLlistaPartides` per cridar a `llistaPartides.Rebuild()` immediatament després d'assignar la font de dades.
- [x] 3.2 Actualitzar `OmplirLlistaJugadors` per cridar a `llistaJugadorsSala.Rebuild()` immediatament després d'assignar la font de dades.
- [x] 3.3 Assegurar que si el missatge `ROOM_UPDATED` indica que la sala ja no existeix (room null), el jugador és redirigit visualment al Lobby.

## 4. Neteja de Redundància

- [x] 4.1 Desactivar o redirigir el processament de missatges de Lobby a `WebSocketClient.cs` cap a `MenuManager.cs` per evitar inconsistències d'estat.
