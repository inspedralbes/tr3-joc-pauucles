## Why

The current jumping system feels rigid and unforgiving, often failing to register jumps if the player is slightly off the edge or if they press the jump button slightly before hitting the ground. Improving "Game Feel" through Coyote Time and Jump Buffering will make the movement feel more fluid, responsive, and professional.

## What Changes

- **Coyote Time**: Added a grace period that allows players to jump for a short time after leaving a platform without actually jumping.
- **Jump Buffering**: Added a small window where jump inputs are "remembered" and executed as soon as the player touches the ground.
- **Variable Jump Height**: (Optional/Improved) Added the ability to control jump height by releasing the jump button early.
- **Instant Velocity Reset**: The jump now directly sets the vertical velocity for more consistent behavior.

## Capabilities

### New Capabilities
- `player-jump-refinement`: Defines the advanced mechanics for player jumping, including grace periods and input buffering to improve responsiveness.

### Modified Capabilities
<!-- No existing behavioral specs for player jumping were found in openspec/specs/. -->

## Impact

- `Player.cs`: The core player controller script will be modified to include new variables and logic in `Update`.
- Gameplay: Movement will feel more responsive and forgiving, reducing frustration during platforming.
