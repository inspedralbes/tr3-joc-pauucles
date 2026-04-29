## Why

The Unity `MenuManager.cs` script needs to be updated to support TextMeshPro input fields for user credentials. This allows for a more flexible UI integration where input fields can be assigned directly in the Unity Inspector and public methods can be linked to UI buttons.

## What Changes

- **TextMeshPro Integration**: Add `using TMPro;` to support `TMP_InputField`.
- **UI References**: Add public `TMP_InputField` variables for `campUsuari` and `campPassword`.
- **Button Handlers**: Add public `BotoRegistrarClicat` and `BotoLoginClicat` methods to be called from the Unity UI system.
- **Backend Linkage**: Ensure these new methods correctly call the existing `RegistrarUsuari` and `FerLogin` logic.

## Capabilities

### New Capabilities
- `unity-ui-fields-integration`: Enables direct interaction between Unity UI TextMeshPro components and the authentication logic.

### Modified Capabilities
- None.

## Impact

- `DAMT3Atrapa la bandera/Assets/Scripts/MenuManager.cs`: Primary location for script modifications.
- **Unity Editor**: Requires manual assignment of input fields in the `MenuManager` component.
