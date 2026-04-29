## Why

The current minigame system lacks consistent UI visibility control. Users are experiencing issues where the minigame interface does not appear when a challenge starts or remains visible after it ends. Implementing explicit state-driven visibility using UI Toolkit's `DisplayStyle` will ensure a reliable user experience and provide debugging clarity through console logs.

## What Changes

- **Component Integration**: Ensure the minigame UI manager has a valid reference to the `UIDocument` component.
- **Visibility Lifecycle**: Implement explicit logic to show the UI root at the start of a minigame and hide it upon completion.
- **Debug Feedback**: Add logging to track visibility transitions in the Unity console.

## Capabilities

### New Capabilities
- `minigame-ui-lifecycle`: Manages the explicit visibility state (Flex/None) of the minigame UI Toolkit root.

### Modified Capabilities
- `foundations`: Update foundation for UI interaction and state feedback.

## Impact

- `MinijocUIManager.cs`: Updated with `UIDocument` handling and visibility logic.
- UI Toolkit Root: Now explicitly controlled via `DisplayStyle`.
