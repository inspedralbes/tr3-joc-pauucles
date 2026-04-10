## MODIFIED Requirements

### Requirement: Classe Principal
- **ADDED**: Extend the architecture to include separate logic classes for all 6 minigames.
- **ADDED**: Ensure all scripts are placed in `Assets/Scripts/` and do not inherit from `MonoBehaviour`.

#### Scenario: Unified interface
- **WHEN** any minigame logic is requested
- **THEN** it can be accessed via static methods or independent class instances without needing a GameObject
