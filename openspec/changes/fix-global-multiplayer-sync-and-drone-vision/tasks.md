## 1. Throttling de Xarxa de Jugadors

- [x] 1.1 Modificar `NetworkSync.cs` per afegir les variables `sendInterval = 0.1f` i `lastSendTime`.
- [x] 1.2 Actualitzar el mètode `Update` a `NetworkSync.cs` per aplicar el throttling en l'enviament de la posició.

## 2. Spawn Forçat d'Entitats

- [x] 2.1 Modificar el processament de `PLAYER_MOVE` a `MenuManager.cs` per instanciar el jugador si no existeix al diccionari de `remotePlayers`.
- [x] 2.2 Modificar el processament de `DRONE_MOVE` a `MenuManager.cs` per instanciar el dron si no es troba a l'escena.
- [x] 2.3 Verificar que el `GameManager.cs` té els mètodes necessaris per instanciar jugadors i drons sota demanda.

## 3. IA del Dron i Observacions

- [x] 3.1 Modificar `CollectObservations` a `DroneAI.cs` per trobar el jugador que té l'objectiu clau.
- [x] 3.2 Implementar la lògica de detecció d'ítem clau (si un jugador té `isCarryingDino` o similar).
- [x] 3.3 Passar la posició de l'objectiu (jugador amb ítem o ítem sol) al sensor d'observacions.
