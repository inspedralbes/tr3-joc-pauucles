## MODIFIED Requirements

### Requirement: Nametag Rendering Consistency
The system SHALL ensure the Nametag is always visible above the player with the correct sorting order and depth offset.

#### Scenario: Nametag initialization
- **WHEN** the Nametag is initialized (Start)
- **THEN** its `Canvas` component MUST have `sortingOrder` set to 10
- **AND** its `localPosition` MUST be set to `(0, 1.2f, -0.1f)` to ensure it renders in front of the player's sprite
