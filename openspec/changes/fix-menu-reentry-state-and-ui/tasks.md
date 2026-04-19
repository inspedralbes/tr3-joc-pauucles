## 1. MenuManager Refactoring

- [x] 1.1 In `MenuManager.cs`, implement `public void NetejarEstatTornada()` that nullifies `currentRoomData` and empties `currentRoomId`.
- [x] 1.2 Refactor the existing UI initialization code into a new method `private void VincularEsdevenimentsUI()`.
- [x] 1.3 Ensure `VincularEsdevenimentsUI` uses `-=` before `+=` for event handlers to prevent duplication.
- [x] 1.4 Register a callback for `SceneManager.sceneLoaded` in `Awake()` or `Start()` that calls `VincularEsdevenimentsUI()` and `ActualitzarVisibilitatSegonsSessio()` when entering "MenuPrincipal".

## 2. GameManager Integration

- [x] 2.1 Update `GameManager.cs`, specifically the `TornarAlMenu` method.
- [x] 2.2 Call `MenuManager.Instance.NetejarEstatTornada()` before the scene load call.

## 3. Verification

- [x] 3.1 Verify that after winning/losing and clicking "Tornar", the lobby appears and allows creating a new room.
- [x] 3.2 Verify that no duplicate button click logs appear in the console.
- [x] 3.3 Verify that the room list is refreshed automatically upon reentry.
