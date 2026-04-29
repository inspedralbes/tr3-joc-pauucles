## 1. Modificacions al GameManager (Unity)

- [x] 1.1 Crear el mètode `private IEnumerator EsperarDadesISpawn()`.
- [x] 1.2 Implementar la condició d'espera: `yield return new WaitUntil(() => WebSocketClient.Instance.IsConnected() && MenuManager.Instance.currentRoomData != null);`.
- [x] 1.3 Modificar el mètode `Start()` per iniciar la corrutina en lloc de cridar directament a `InstanciarBanderes()`.
- [x] 1.4 Actualitzar `InstanciarBanderes()` per aplicar una escala de `new Vector3(3f, 3f, 1f)` (o 4f segons convingui) a les banderes instanciades.
- [x] 1.5 Actualitzar `ConfigurarLocalPlayerVisuals()`: cercar el component `TextMeshPro` als fills de `localPlayer` i assignar-li `MenuManager.Instance.userId` (o `username`).

## 2. Verificació

- [x] 2.1 Verificar que les banderes s'instancien correctament quan un jugador s'uneix a una sala ja creada.
- [x] 2.2 Comprovar que el nom d'usuari local apareix sobre el personatge en iniciar l'escena de combat.
