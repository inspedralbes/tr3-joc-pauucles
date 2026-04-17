## Why

The current `MenuManager.cs` script needs to be refactored to use Unity's UI Toolkit instead of TextMeshPro. This alignment ensures consistency with the modern UI system used in the project, facilitating better UI management and integration with existing authentication logic.

## What Changes

- **UI Toolkit Migration**: Replace `TMPro` references with `UnityEngine.UIElements`.
- **Initialization Refactor**: Implement `OnEnable` to retrieve the `rootVisualElement` from the `UIDocument`.
- **Element Querying**: Update logic to find UI elements (`inputNomJugador`, `inputPassword`, `btnRegistre`, `btnLogin`) using `root.Q<T>`.
- **Event Binding**: Connect button `clicked` events to `RegistrarUsuari` and `FerLogin` using lambda expressions.
- **Logic Retention**: Ensure the underlying authentication methods (`RegistrarUsuari`, `FerLogin`, and the `EnviarPeticio` coroutine) remain unchanged.

## Capabilities

### New Capabilities
- `unity-ui-toolkit-auth-integration`: Direct integration between UI Toolkit components and the authentication service.

### Modified Capabilities
- None.

## Impact

- `DAMT3Atrapa la bandera/Assets/Scripts/MenuManager.cs`: Primary file for the refactor.
- **Unity Project**: Requires a `UIDocument` component on the same GameObject as `MenuManager`.
