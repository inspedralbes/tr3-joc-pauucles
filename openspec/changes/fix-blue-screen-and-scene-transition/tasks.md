## 1. Preparation

- [x] 1.1 Add `using UnityEngine.SceneManagement;` to `MenuManager.cs`.

## 2. Data Structure

- [x] 2.1 Define the `PartidaIniciadaMsg` serializable class inside `MenuManager.cs`.

## 3. Core Implementation

- [x] 3.1 Refactor `PARTIDA_INICIADA` handler to parse the full JSON message.
- [x] 3.2 Persist `username`, `team`, and `color` to `WebSocketClient` static fields.
- [x] 3.3 Trigger `SceneManager.LoadScene("Bosque")` in the main thread after UI adjustment.

## 4. Verification

- [x] 4.1 Verify immediate scene transition after match start.
- [x] 4.2 Verify player data (Team, Color) is correctly loaded in the "Bosque" scene.
