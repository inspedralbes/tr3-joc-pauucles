## Why

The current implementation of `MinijocUIManager.cs` lacks a robust way to manage multiple minigame containers within a single `UIDocument`. This change introduces a selective visibility system to ensure only the relevant minigame UI is displayed, preventing overlaps and ensuring a clean transition between different minigames.

## What Changes

- **Centralized UI Hiding**: Implementation of an auxiliary method `AmagarTotsElsMinijocs` to hide all minigame containers at the start of any minigame session.
- **Selective UI Activation**: Logic to specifically enable the container of the chosen minigame (PPTLLS, PolsForca, DuelMirades, AturaBarra, ParellsSenars) during initialization.
- **Improved Root Element Access**: Optimized access to the `rootVisualElement` of the `UIDocument` during the minigame startup phase.

## Capabilities

### New Capabilities
- `multi-minigame-ui-logic`: Management of display states for multiple minigame containers within the same UI context.

### Modified Capabilities
- `foundations`: Adjust basic UI management rules to support selective container visibility.

## Impact

- `MinijocUIManager.cs`: Core logic for minigame startup and UI management.
- `UIDocument` Assets: Relevant VisualElements must match the naming convention used in the code (ex: `#ContenidorPPTLLS`).
