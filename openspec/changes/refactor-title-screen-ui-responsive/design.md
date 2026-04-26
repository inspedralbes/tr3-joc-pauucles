## Context

The current `MenuUI.uxml` file uses absolute coordinates for the title screen elements. This results in poor scaling on different screen resolutions. The project uses Unity UI Toolkit (UXML/USS).

## Goals / Non-Goals

**Goals:**
- Convert `#PantallaTitol` to a responsive Flexbox container.
- Centralize content within a 800x600 container (`#CapsaMaquina`).
- Group buttons logically within `#GrupBotons`.
- Eliminate absolute positioning and manual coordinate-based offsets.
- Maintain visual consistency by using transparent buttons that rely on text and background images.

**Non-Goals:**
- Redesigning the entire UI system or other screens (Login, Lobby, etc.).
- Changing the existing assets or fonts.

## Decisions

- **Flexbox Centering**: `#PantallaTitol` will use `justify-content: center` and `align-items: center` to ensure the content stays at the heart of the screen regardless of resolution.
- **Fixed-Aspect Container**: `#CapsaMaquina` is set to 800x600px with `-unity-background-scale-mode: scale-to-fit`. This allows the "machine" frame to scale proportionally within the main screen.
- **Element Reordering**: The Title Label and Buttons will be moved inside `#CapsaMaquina` to benefit from the container's relative positioning.
- **Style Overrides**: Style attributes previously defining absolute positions (`top`, `left`, `bottom`, `position: absolute`) will be purged.
- **Button Grouping**: A new `#GrupBotons` VisualElement will be added to wrap `btnStartGame` and `btnExitGame`, using `align-items: center` and `margin-top: 25%` for vertical separation from the title.

## Risks / Trade-offs

- **Risk**: Fixed size of `#CapsaMaquina` (800x600) might be too large for very small screens.
    - **Mitigation**: The `scale-to-fit` and flex-based centering will ensure it shrinks as needed without breaking the layout.
- **Risk**: Transparent buttons might be hard to see if the background image changes significantly.
    - **Mitigation**: Ensure text color contrast remains high (currently using red for title and pixel fonts).
