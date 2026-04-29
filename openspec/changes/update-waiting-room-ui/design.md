## Context

The `MenuManager.cs` script manages room transitions and data binding. The `#pantallaSalaEspera` element in `MenuUI.uxml` is the main container for the waiting room. We need to ensure it is centered and that its child elements (labels and buttons) are consistently positioned.

## Goals / Non-Goals

**Goals:**
- Dynamically display the room ID in the waiting room.
- Center the waiting room UI container.
- Stabilize the position of the action buttons.

**Non-Goals:**
- Adding new functional features to the waiting room.
- Changing the background artwork.

## Decisions

### 1. Script-based Room Code Update
We will modify the `OnEnable` or equivalent transition method in `MenuManager.cs` to find the `codeLabel` and set its text.
- **Rationale**: The room ID is only known at runtime after a successful join/create operation.

### 2. USS-based Centering
We will add or update the CSS for `#pantallaSalaEspera` in `MenuStyles.uss`.
- **Properties**: `flex-direction: column`, `align-items: center`, `justify-content: center`.
- **Rationale**: Standardizes the layout across all resolutions.

### 3. UI Restructuring for Buttons
In `MenuUI.uxml`, we will wrap the "INVENTARI" and "LLEST" buttons in a `VisualElement` with `flex-grow: 0`.
- **Rationale**: Prevents these buttons from expanding or shifting based on the content of the player list or room code labels.

## Risks / Trade-offs

- **[Risk]** → Centering might overlap elements if the screen height is too small.
- **[Mitigation]** → Use `min-height` or scroll views if content grows too large (though unlikely for this screen).
- **[Risk]** → `codeLabel` might not be found if the name is typoed in the script.
- **[Mitigation]** → Add null checks before setting the text.
