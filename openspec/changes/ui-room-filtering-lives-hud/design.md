## Context

The project requires aesthetic and functional improvements to the UI without affecting core gameplay mechanics (combat, movement). The main areas are room management in the lobby, player health visualization during gameplay, and consistent styling for minijocs.

## Goals / Non-Goals

**Goals:**
- Filter out stale "waiting" rooms (older than 10 mins).
- Standardize player lives to 3 and implement a heart-based HUD.
- Apply consistent dark styling to minigame containers and buttons.

**Non-Goals:**
- Do NOT modify `GuanyarMinijoc`, `PerdreMinijoc`, `RebreDerrotaXarxa`.
- Do NOT change physics or movement variables (`potMoure`, etc.).
- Do NOT change the backend (beyond using existing `createdAt` field).

## Decisions

### 1. Room Filtering (MenuManager.cs)
- **Decision**: Update `GameData` class to include `createdAt` (string).
- **Implementation**: In `AlRebreActualitzacioSales` and `ObtenirPartides`, filter the `sales` array.
- **Rationale**: The backend already provides `createdAt` via Mongoose timestamps.
- **Logic**: `DateTime.TryParse(game.createdAt, out DateTime createdTime)` and compare with `DateTime.UtcNow.AddMinutes(-10)`.

### 2. Lives HUD (Player.cs)
- **Decision**: Programmatically create a `VisualElement` container for hearts.
- **Implementation**:
  - Set `lives = 3` and `maxLives = 3` (if applicable).
  - In `UpdateLivesUI`, check for a container named "HUD_Vides". If missing, create it as a child of `rootVisualElement`.
  - Style: `position: Absolute`, `top: 20px`, `left: 20px`, `flexDirection: row`.
  - Content: Clear children and add N images using the `iconaVida` Sprite.
- **Rationale**: Using UI Toolkit allows for flexible, procedural layout without relying on pre-existing UXML elements that might be missing or broken.

### 3. Minigame Styling (MinijocUIManager.cs)
- **Decision**: Apply styles in `IniciarMinijoc`.
- **Containers**: Apply `backgroundColor = new Color(0, 0, 0, 0.85f)` to `ContenidorPPTLLS`, `ContenidorParellsSenars`, etc.
- **Buttons**: Use `root.Query<Button>().ForEach(...)` to apply standard styles:
  - `backgroundColor = Color.black`
  - `color = Color.white`
  - `minWidth = 100`, `minHeight = 50`.

## Risks / Trade-offs

- [Risk] → `createdAt` format from backend might differ from `DateTime.TryParse` expectations. [Mitigation] → Use robust parsing or check exact JSON format first.
- [Risk] → `iconaVida` sprite might not be loaded in `Resources`. [Mitigation] → Ensure it's in a Resources folder or find it in the scene.
