## Context

The current `MenuManager.cs` script uses `VisualElement` and `TextField` from the UI Toolkit, but the user wants to integrate standard TextMeshPro (TMP) input fields from the GameObject-based UI system. This requires adding the TMPro namespace and exposing public variables and methods for Editor-based assignment.

## Goals / Non-Goals

**Goals:**
- Extend `MenuManager.cs` to support `TMP_InputField`.
- Provide public entry points for button clicks that utilize the TMP field values.

**Non-Goals:**
- Complete migration from UI Toolkit to GameObject UI (this change only adds support for TMP fields).
- Validation logic for input lengths or characters (assumed to be handled elsewhere or out of scope).

## Decisions

- **Namespace addition**: Add `using TMPro;` at the top of the file to access the TextMeshPro API.
- **Field exposure**: Declare `campUsuari` and `campPassword` as public fields. This is chosen over serialized private fields for direct Inspector accessibility as requested.
- **Public Wrapper Methods**: Implement `BotoRegistrarClicat` and `BotoLoginClicat` as public methods. These will act as the bridge between the Unity Event system (Buttons) and the internal logic, passing the `.text` property of the TMP fields.

## Risks / Trade-offs

- **Redundancy**: There might be overlapping functionality if both UI Toolkit fields and TMP fields are present. **Mitigation**: The design assumes the user is transitioning towards or specifically requiring TMP fields for certain interactions.
- **Null Reference Risk**: If fields are not assigned in the Inspector, the public methods will fail. **Mitigation**: Standard Unity workflow requires manual assignment; developers should ensure fields are linked.
