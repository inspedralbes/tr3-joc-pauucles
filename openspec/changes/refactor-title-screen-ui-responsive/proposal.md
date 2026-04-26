## Why

The current title screen (`#PantallaTitol`) in `MenuUI.uxml` relies on absolute positioning for its elements (Title Label, Start and Exit buttons). This approach makes the UI fragile and non-responsive across different screen resolutions and aspect ratios. Refactoring the structure to use Flexbox will ensure a consistent and centered layout on all devices.

## What Changes

- **Structural Refactor**: Introduce a centered container hierarchy using Flexbox instead of absolute coordinates.
- **New Container (`#CapsaMaquina`)**: A fixed-size (800x600px) responsive container that acts as the main frame for the title screen content.
- **Responsive Alignment**: Configure `#PantallaTitol` as a full-screen Flexbox container to center its children.
- **Button Grouping**: Create a `#GrupBotons` container to manage the layout of action buttons.
- **Style Cleanup**: Remove `position: absolute` and manual margins from title elements and buttons.
- **Visual Updates**: Set buttons to have transparent backgrounds and no borders to rely on their text/images, and adjust title label alignment.

## Capabilities

### New Capabilities
- `responsive-title-screen`: Implementation of a Flexbox-based layout for the game's entry point to support multiple resolutions.

### Modified Capabilities
- None

## Impact

- **UI/UX**: Improved visual consistency across different screen sizes.
- **Files**: 
    - `DAMT3Atrapa la bandera/Assets/UI/MenuUI.uxml`: Major structure and style attribute changes.
    - `DAMT3Atrapa la bandera/Assets/UI/MenuStyles.uss`: Potential additions for the new containers.
