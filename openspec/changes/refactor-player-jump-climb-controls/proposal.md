## Why

The current player controls for jumping and climbing are somewhat overlapping, which can lead to unresponsive or unintuitive behavior (e.g., unintended climbing or jumping). Separating these controls clearly will improve the game feel and provide more precise movement, especially when interacting with ladders.

## What Changes

- **Strict Jump Control**: Modify jumping logic to trigger exclusively with the Space key and only when the player is grounded and not currently climbing.
- **Explicit Climbing Activation**: Climbing will now only start when the player is near a ladder and provides vertical input (W/S or Arrow keys).
- **Jump from Ladder**: Implement the ability to jump while climbing, which will cancel the climbing state and apply a jump force.
- **Refined Climbing Physics**: Ensure gravity is disabled and vertical velocity is directly controlled by input while climbing, reverting to default gravity otherwise.
- **Input Standardization**: Replace generic `Input.GetButton` calls with specific `KeyCode.Space` and `Input.GetAxisRaw("Vertical")` for these actions as requested.

## Capabilities

### New Capabilities
- `player-movement-refinement`: Improved separation and responsiveness of jump and climb mechanics in the Player controller.

### Modified Capabilities
<!-- No existing capabilities whose requirements are changing were found in openspec/specs/ -->

## Impact

- **Player.cs**: Major updates to `Update` and `FixedUpdate` methods regarding movement logic.
- **Input System**: Transition from Input Manager buttons to specific KeyCodes for jump/climb interaction.
- **Game Feel**: Significant improvement in platforming and ladder traversal.
