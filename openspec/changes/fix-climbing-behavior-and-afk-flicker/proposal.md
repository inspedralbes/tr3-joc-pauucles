## Why

The current player implementation has two issues that affect gameplay feel and visual polish:
1. The AFK "flicker" effect incorrectly triggers while the player is climbing if they are not providing horizontal input, which is distracting and illogical.
2. Climbing movement using the "Jump" button (Space) requires repeated presses instead of supporting continuous movement when held, making the climbing experience clunky.

## What Changes

- **AFK Logic Update**: Modified the condition for triggering the AFK flicker to ensure it only activates when the player is both stationary AND not climbing.
- **Climbing Movement Improvement**: Enhanced the climbing logic to support continuous upward movement when the "Jump" button is held down, aligning it with standard platformer expectations.

## Capabilities

### New Capabilities
- `player-movement-refinement`: Defines the refined behaviors for player states, specifically focusing on the interaction between climbing and secondary systems like AFK detection and input handling.

### Modified Capabilities
<!-- No existing behavioral specs for player movement were found in openspec/specs/. -->

## Impact

- `Player.cs`: The core player controller script will be modified.
- User Experience: Improved responsiveness during climbing and fixed visual glitches during vertical navigation.
