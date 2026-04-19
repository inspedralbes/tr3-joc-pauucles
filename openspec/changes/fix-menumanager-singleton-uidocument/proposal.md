## Why

The `MenuManager` class suffers from a `MissingReferenceException` when returning to the menu scene from the game. This occurs because the singleton instance persists via `DontDestroyOnLoad`, but its internal reference to the `UIDocument` component becomes null/obsolete as the previous scene's UI is destroyed. Additionally, a stricter singleton implementation is needed to prevent multiple instances from existing and causing logical conflicts.

## What Changes

- **Strict Singleton Implementation**: Update `Awake()` in `MenuManager.cs` to ensure only one instance exists by destroying duplicates immediately.
- **Dynamic UI Reference Refresh**: In the `OnSceneLoaded` method, explicitly re-fetch the `UIDocument` reference before performing any UI operations.
- **Initialization Sequence Fix**: Ensure UI visibility logic (`ActualitzarVisibilitatSegonsSessio`) is called only after the UI reference has been refreshed.

## Capabilities

### New Capabilities
- `strict-singleton-lifecycle`: Guarantees a single persistent instance of the MenuManager.
- `dynamic-ui-reference-refresh`: Ensures UI references are updated across scene transitions to prevent stale component errors.

### Modified Capabilities
- `foundations`: Update global manager lifecycle foundations.

## Impact

- `MenuManager.cs`: Core logic for singleton and UI reference management.
- `UIDocument`: Reference handling across scene loads.
