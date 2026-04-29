## 1. Connexió del Lobby (MenuManager)

- [x] 1.1 Cercar i vincular el botó `#btnConfirmarReady` a `MenuManager.cs`.
- [x] 1.2 Implementar l'enviament del missatge "READY" (format JSON) en fer clic al botó.

## 2. Gestió de l'Inici de Partida (WebSocketClient)

- [x] 2.1 Afegir variables estàtiques `Username`, `Team` i `ColorName` a `WebSocketClient.cs`.
- [x] 2.2 Assegurar la persistència del script amb `DontDestroyOnLoad` i gestionar la càrrega de l'escena "Bosque".
- [x] 2.3 Actualitzar `ProcessMessage` per processar el missatge "PARTIDA_INICIADA" i emmagatzemar les dades rebudes.
- [x] 2.4 Implementar la transició d'escena segura des del fil principal (`Update`).

## 3. Implementació del Nametag

- [x] 3.1 Crear el fitxer `Nametag.cs` a la carpeta de scripts.
- [x] 3.2 Implementar la lògica de traducció de colors (text a `Color`) i actualització del `TextMeshProUGUI`.
- [x] 3.3 Implementar `LateUpdate` per forçar la rotació a `Quaternion.identity`.

## 4. Integració al Jugador (Player)

- [x] 4.1 Afegir la referència a `Nametag` al script `Player.cs`.
- [x] 4.2 Vincular la configuració inicial del Nametag al mètode `Start` de `Player.cs` usant les dades estàtiques.

## 5. Verificació i Proves

- [ ] 5.1 Comprovar el flux complet: clic a LLEST -> recepció de PARTIDA_INICIADA -> canvi d'escena.
- [ ] 5.2 Verificar que el Nametag mostra el nom i color correctes a l'escena "Bosque".
- [ ] 5.3 Validar que el Nametag no rota amb el jugador.
