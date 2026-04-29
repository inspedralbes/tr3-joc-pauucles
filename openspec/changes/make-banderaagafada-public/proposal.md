## Why

This change is needed to allow other scripts or systems to access and monitor the `banderaAgafada` variable in the `Player` script. Making it public facilitates easier debugging and coordination between game elements, such as UI managers or game logic that needs to know if a player is holding the flag.

## What Changes

- **Modified**: Change `private Transform banderaAgafada;` to `public Transform banderaAgafada;` in `Player.cs`.

## Capabilities

### New Capabilities
- None

### Modified Capabilities
- None

## Impact

- **Affected Code**: `DAMT3Atrapa la bandera/Assets/Scripts/Player.cs`
- **APIs/Systems**: Any system interacting with the `Player` component will now be able to see and modify the `banderaAgafada` transform.
