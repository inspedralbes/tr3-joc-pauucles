## ADDED Requirements

### Requirement: Minigame UI Background Overlay
The system SHALL apply a semi-transparent black background (rgba(0,0,0,0.85)) to all minigame UI containers.

#### Scenario: Minigame container background check
- **WHEN** a minigame is active
- **THEN** its UI container has a dark semi-transparent overlay

### Requirement: Standardized Button Styles
The system SHALL style all minigame buttons with a black background, white text, and a minimum size of 100x50 pixels to prevent overlapping.

#### Scenario: Button style verification
- **WHEN** a minigame button is rendered
- **THEN** it displays white text on a black background with at least 100px width and 50px height
