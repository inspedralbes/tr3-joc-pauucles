## 1. Robustesa de l'IA (DroneAI.cs)

- [x] 1.1 Modificar `CollectObservations` per afegir Null-Checks als objectes bandera i dinosaure.
- [x] 1.2 Implementar cerca activa de jugadors amb la bandera si l'objecte de terra és nul.
- [x] 1.3 Assegurar un fallback de posició (ex: `Vector3.zero`) per evitar el crasheig del sensor.

## 2. Diagnòstic de Xarxa (MenuManager.cs)

- [x] 2.1 Afegir `Debug.Log` detallat al processament del missatge `DRONE_MOVE` per confirmar recepció.
- [x] 2.2 Afegir `Debug.LogError` si es rep un moviment per a un dron que no es troba a la llista `dronsEscena`.

## 3. Sincronització Visual (DroneNetworkSync.cs)

- [x] 3.1 Revisar que `ReceiveUpdate` emmagatzemi correctament la `targetPosition` en el client remot.
- [x] 3.2 Verificar que el mètode `Update` realitzi el `Lerp` visual quan `isRemote` és cert.
- [x] 3.3 Assegurar que no hi hagi lògiques de moviment local que trepitgin el moviment sincronitzat de xarxa en el client.
