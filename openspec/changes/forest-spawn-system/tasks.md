## 1. Creació del GameManager

- [x] 1.1 Crear el fitxer `GameManager.cs` a `Assets/Scripts/`.
- [x] 1.2 Implementar la referència al jugador local ( Woodcutter ).
- [x] 1.3 Implementar la lògica de cerca de punts de spawn al mètode `Start`.

## 2. Lògica de Selecció i Posicionament

- [x] 2.1 Afegir validació per a `WebSocketClient.Team` per determinar l'equip del jugador.
- [x] 2.2 Implementar filtre d'objectes per nom ( `SpawnEquip1` / `SpawnEquip2` ).
- [x] 2.3 Implementar la tria aleatòria d'un punt de la llista d'objectes vàlids.
- [x] 2.4 Aplicar la posició del punt seleccionat al transform del jugador.

## 3. Integració i Verificació

- [ ] 3.1 Assignar el script `GameManager` a un objecte buit a l'escena 'Bosque'.
- [ ] 3.2 Crear objectes de prova (Spawns) a l'escena amb els noms correctes.
- [ ] 3.3 Validar que el jugador apareix en una posició diferent segons l'equip assignat al lobby.
