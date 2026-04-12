## Context

The minigames were previously using partial or placeholder logic. A new UI structure was built in UI Builder, but the C# scripts need to be updated to link these new elements and handle the standard "revelation phase" that players expect after a minigame ends.

## Goals / Non-Goals

**Goals:**
- Implement the 3-second revelation phase in all minigame logic scripts.
- Correctly link all buttons and labels from the new UI structure using `VisualElement.Q`.
- Update input handling for all minigames (Space, Keys, Clicks).

**Non-Goals:**
- Redesigning the UXML or USS files.
- Adding complex animations during the revelation phase (simple label updates only).

## Decisions

- **State Pattern**: Each script will manage its own internal state (e.g., `_isRevealing`) to handle the transition from gameplay to results.
- **Unified Timer**: All scripts will use `Time.deltaTime` to manage both the gameplay timer (where applicable) and the revelation timer (exactly 3s).
- **UI Binding**: All bindings will happen in `InicialitzarUI(VisualElement root)`. We will use the exact names from the UXML (e.g., "BtnPedra", "TextTempsPPTLLS").
- **Physical Feedback in Draw**: For `AcaparamentMirades`, the draw condition will trigger the same physical separation logic implemented previously in `MinijocUIManager`.

## Risks / Trade-offs

- **Risk**: Missing a UI element name in the `Q<T>` query will cause a null reference.
  - **Mitigation**: Add null checks for all queried elements and log warnings if they are missing.
- **Risk**: Hardcoding 3s in multiple scripts might make it harder to change later.
  - **Mitigation**: Use a local variable or constant `const float TEMPS_REVELACIO = 3f;` in each script.
