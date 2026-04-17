## 1. Verificació de la Lògica de Creació

- [ ] 1.1 Validar que `GameController.js` crida correctament a `broadcastRoomUpdates()` en finalitzar el mètode `create`.
- [ ] 1.2 Validar que el `GameService.js` retorna la llista de sales filtrada per `waiting` a la petició de llistat global.

## 2. Reforç de Broadcasts

- [ ] 2.1 Assegurar-se que el tipus de missatge enviat és `room_list` (per mantenir compatibilitat amb Unity).
- [ ] 2.2 Verificar que el broadcast s'emet a tots els clients actius en el servidor WebSocket (`wss.clients`).

## 3. Proves d'Integració

- [ ] 3.1 Provar la creació d'una sala des d'un client i verificar la recepció automàtica en un segon client.
- [ ] 3.2 Confirmar que no hi ha retards significatius en l'actualització visual del lobby a Unity.
