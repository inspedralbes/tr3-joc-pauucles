## Why

The `banderaAgafada` variable in `Player.cs` is currently private, which prevents other classes like `MinijocUIManager` from accessing it. This causes a CS0122 protection level error and prevents the UI from correctly identifying the player who is currently defending the flag during combat.

## What Changes

- Change the visibility of `banderaAgafada` from `private` to `public` in the `Player` class.
- The new declaration will be: `public Transform banderaAgafada;`.

## Capabilities

### New Capabilities
- `player-flag-visibility`: Allow external systems to query if a player is carrying the flag.

### Modified Capabilities
- None

## Impact

- **Affected Code**: `Player.cs` (declaration change).
- **Systems**: Combat UI logic in `MinijocUIManager` which depends on identifying the flag carrier.
