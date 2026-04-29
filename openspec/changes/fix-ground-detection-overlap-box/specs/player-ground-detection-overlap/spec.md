## ADDED Requirements

### Requirement: Concentrated OverlapBox Ground Detection
The system SHALL determine the grounding state by projecting a small overlap box at the base center of the player's collider.

#### Scenario: Standing on a surface
- **WHEN** an overlap box (width: 80% of player width, height: 0.1) is checked at the bottom edge of the player's bounds
- **THEN** it MUST return true if any non-trigger collider other than the player's own collider is detected

### Requirement: Horizontal Inset for Wall Avoidance
The grounding overlap box MUST be narrower than the player's collider (80% of width) to prevent accidental grounding against vertical walls.

#### Scenario: Sliding against a wall
- **WHEN** the player is flush against a vertical wall but not on the ground
- **THEN** the overlap box MUST NOT detect the wall as ground due to the 80% width constraint

### Requirement: Trigger Filtering in Overlap
The ground detection results SHALL be filtered to ignore all trigger colliders.

#### Scenario: Overlapping a trigger zone
- **WHEN** the overlap box detects a collider marked as `isTrigger`
- **THEN** it MUST ignore that hit and continue checking others or return false
