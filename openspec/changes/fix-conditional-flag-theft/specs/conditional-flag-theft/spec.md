## ADDED Requirements

### Requirement: Flag Possession Check
The system SHALL verify that the losing player is the current owner of the flag before attempting any transfer.

#### Scenario: Loser carries flag
- **WHEN** a combat confrontation is resolved
- **AND** the flag's parent transform is equal to the loser's transform
- **THEN** the system SHALL proceed with the flag transfer to the winner

#### Scenario: Loser does not carry flag
- **WHEN** a combat confrontation is resolved
- **AND** the flag's parent transform is NOT the loser's transform
- **THEN** the system SHALL NOT modify the flag's position or parent
- **THEN** the system SHALL still apply the defeat penalty to the loser
