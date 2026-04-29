## MODIFIED Requirements

### Requirement: Flag Transfer on Combat Victory
The system SHALL allow a winning player to take the flag from a losing player if the latter was carrying it, ensuring correct visual attachment.

#### Scenario: Winner steals flag
- **WHEN** a combat confrontation is resolved
- **AND** the loser was carrying the flag
- **THEN** the flag SHALL be detached from the loser
- **THEN** the flag SHALL be attached to the winner (parent)
- **THEN** the flag's `localPosition` SHALL be set to `Vector3.zero`
- **THEN** the loser's flag reference SHALL be cleared
