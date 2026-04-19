## ADDED Requirements

### Requirement: Session-Driven UI Consistency
The game foundation MUST ensure that UI visibility consistently reflects the current session state (authenticated vs. unauthenticated).

#### Scenario: Session state change
- **WHEN** a player's authentication state changes (e.g., successful login)
- **THEN** the core UI managers MUST synchronize the visible panels to match the new state.
