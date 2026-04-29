## 1. Room Filtering Implementation

- [x] 1.1 Update `GameData` class in `MenuManager.cs` to include `public string createdAt;`.
- [x] 1.2 Implement filtering logic in `MenuManager.AlRebreActualitzacioSales` to ignore "waiting" rooms older than 10 minutes.
- [x] 1.3 Apply same filtering logic in `MenuManager.ObtenirPartides` (inside the successful response handling).

## 2. Player Lives HUD

- [x] 2.1 Update `Player.cs` to set `lives = 3` and initialize `maxLives = 3` (if applicable).
- [x] 2.2 Modify `Player.UpdateLivesUI()` to programmatically create/update an absolute-positioned container "HUD_Vides" (top: 20px, left: 20px, flexDirection: row).
- [x] 2.3 Implement logic in `UpdateLivesUI` to clear existing icons and draw hearts using the `iconaVida` sprite (size 40x40, margin 5).
- [x] 2.4 Ensure the heart HUD is only managed for the local player.

## 3. Minigame UI Styling

- [x] 3.1 Update `MinijocUIManager.cs` to apply `rgba(0,0,0,0.85)` background style to all minigame containers in `IniciarMinijoc`.
- [x] 3.2 Implement button styling logic to set black background, white text, and minimum dimensions (100x50) for all buttons within the active minigame.
- [x] 3.3 Verify that styling is applied every time a minigame starts to ensure consistency across different minigames.

## 4. Verification

- [x] 4.1 Verify that rooms older than 10 minutes (waiting state) no longer appear in the lobby.
- [x] 4.2 Confirm that the player starts with 3 lives and the heart HUD displays correctly in the top-left corner.
- [x] 4.3 Test minigame UI to ensure dark backgrounds and standardized buttons are applied.
