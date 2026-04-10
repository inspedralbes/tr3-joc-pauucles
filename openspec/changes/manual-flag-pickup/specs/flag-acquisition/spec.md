## MODIFIED Requirements

### Requirement: Flag Pickup Initiation
The system SHALL no longer automatically pick up the flag upon contact. Instead, contact only prepares the player for manual pickup.

#### Scenario: Contact with Flag
- **WHEN** a player makes contact with the flag
- **THEN** the system SHALL NOT automatically parent the flag to the player
- **AND** the system SHALL enable the manual pickup possibility
