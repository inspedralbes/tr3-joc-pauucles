## ADDED Requirements

### Requirement: Minigame UI Visibility
The minigame UI root MUST be explicitly set to visible before any minigame-specific logic starts.

#### Scenario: Starting a minigame
- **WHEN** `IniciarMinijoc` (formerly `ShowUI`) is called
- **THEN** the `UIDocument` root element's display style is set to `Flex` and the GameObject is set to active

## RENAMED Requirements

### Requirement: Rename ShowUI to IniciarMinijoc
**FROM**: `ShowUI(Player p1, Player p2)`
**TO**: `IniciarMinijoc(Player p1, Player p2)`
