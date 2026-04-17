## 1. Actualització de Player.cs

- [x] 1.1 Afegir el mètode `InicialitzarJugador(string username, string team)` a `Player.cs`.
- [x] 1.2 Implementar la lògica dins d'aquest mètode per actualitzar el Nametag (si el prefab té una referència d'UI) i assignar el `idJugador` o equip segons correspongui.

## 2. Creació de WebSocketClient.cs

- [x] 2.1 Crear l'script `WebSocketClient.cs` a la carpeta `Scripts`.
- [x] 2.2 Implementar la connexió a `ws://localhost:3000` usant `ClientWebSocket`.
- [x] 2.3 Implementar la recepció de missatges en un bucle asíncron.
- [x] 2.4 Implementar el "Parsing" del JSON per extreure `username` i `team` quan el tipus de missatge sigui l'inici de partida.
- [x] 2.5 Afegir la cerca del personatge `Player` i la crida a `InicialitzarJugador`.

## 3. Integració i Verificació

- [x] 3.1 Afegir el component `WebSocketClient` a un GameObject persistent a la primera escena o a l'escena de joc.
- [x] 3.2 Verificar que la connexió s'estableix correctament (logs a la consola).
- [x] 3.3 Verificar que el nom del personatge Woodcutter canvia al nom de la sessió un cop rebut el missatge de "Game Start".
