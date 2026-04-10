## Why

The current UI system in `Player.cs` uses the legacy `UnityEngine.UI`. Migrating to `UI Toolkit` (`UnityEngine.UIElements`) allows for a more modern, efficient, and flexible UI management within Unity. This change also increases the player's life count to 5 for better gameplay balance.

## What Changes

- **BREAKING**: Removed `UnityEngine.UI` and `Text` references in `Player.cs`.
- Added `UnityEngine.UIElements` and `UIDocument` support.
- Increased player lives from 3 to 5.
- Implemented visual life tracking using `VisualElement`s (Vida1 through Vida5).
- Replaced text-based life display with style-based visibility (`display = DisplayStyle.None`) for the life indicators.
- Ensured all existing coroutines and collision logic remain functional.

## Capabilities

### New Capabilities
- `player-ui-toolkit`: Modern UI integration for player status using Unity UI Toolkit.

### Modified Capabilities
- `player-consequences`: Updating the life management logic to handle 5 lives and UI Toolkit integration.

## Impact

- **Player.cs**: Code refactoring to swap UI systems and adjust life count.
- **Unity Scene**: Requires a `UIDocument` in the scene with 5 `VisualElement`s named 'Vida1' to 'Vida5'.
- **UI Architecture**: Shift from legacy UI Text to UI Toolkit `VisualElement`s.
