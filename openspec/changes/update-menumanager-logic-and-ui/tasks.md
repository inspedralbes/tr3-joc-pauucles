## 1. UI Updates (UXML)

- [x] 1.1 Renombrar `#btnConfirmarSala` (text "Cancelar") a `#btnCancelarSala` a `MenuUI.uxml`.
- [x] 1.2 Renombrar `#btnTancarPopUp` (text "Crear") a `#btnConfirmarSala` a `MenuUI.uxml`.

## 2. Data Structures & Variables (C#)

- [x] 2.1 Afegir variable privada `string userId;` a la classe `MenuManager`.
- [x] 2.2 Crear la classe `LoginResponse` amb el camp `id`.
- [x] 2.3 Actualitzar la classe `CreateGameData` per incloure el camp `host`.

## 3. Implementation Logic (C#)

- [x] 3.1 Actualitzar `EnviarPeticio` per parsejar la resposta del login i guardar el `id` a `userId`.
- [x] 3.2 Actualitzar `CrearNovaSala` per assignar `host = userId` a l'objecte JSON.
- [x] 3.3 Vincular `btnTancar.clicked` al `OnEnable` per amagar pantalles de joc.
- [x] 3.4 Vincular `btnTancarLobby.clicked` al `OnEnable` per amagar el lobby i tornar al login.
- [x] 3.5 Vincular `btnCancelarSala.clicked` al `OnEnable` per amagar el pop-up de creació de sala.
- [x] 3.6 Actualitzar les referències de botons al mètode `OnEnable` amb els nous IDs del punt 1.
