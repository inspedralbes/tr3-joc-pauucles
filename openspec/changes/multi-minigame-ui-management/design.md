## Context

The current `MinijocUIManager.cs` manages multiple minigames by caching their containers in private variables. However, to ensure maximum reliability and clean transitions—especially when adding new minigames or during rapid initialization—a more robust method for resetting the UI state is needed. The proposed change introduces a systematic way to hide all potential minigame containers using the `rootVisualElement` before activating the specific one needed.

## Goals / Non-Goals

**Goals:**
- Implement a robust `AmagarTotsElsMinijocs(VisualElement root)` helper method.
- Ensure all minigame containers are hidden before any specific minigame starts.
- Clean up the `IniciarMinijoc` flow to properly handle root element acquisition and UI activation.

**Non-Goals:**
- Redesigning the individual minigame logic scripts.
- Changing the networking or combat trigger logic outside of the UI management.

## Decisions

### 1. Robust UI Hiding Helper
- **Decision**: Create `AmagarTotsElsMinijocs(VisualElement root)` as a standalone helper that queries the root element for specific IDs.
- **Rationale**: Relying on cached references is efficient, but re-querying or ensuring the root-level display states are reset provides a safety net against accidental overlaps.
- **Implementation**: The method will query for `#ContenidorPPTLLS`, `#ContenidorPolsForca`, `#ContenidorDuelMirades`, `#ContenidorAturaBarra`, and `#ContenidorParellsSenars`.

### 2. Streamlined Initialization Flow
- **Decision**: Sequence the UI activation in `IniciarMinijoc` to obtain the root element first, then call the hiding helper, and finally enable the chosen container.
- **Rationale**: This guarantees a "blank slate" before the random minigame selection takes over the screen.

## Risks / Trade-offs

- **[Risk] Performance Overhead** → Re-querying VisualElements with `Q<VisualElement>` every time a minigame starts is slightly slower than using cached references.
    - *Mitigation*: Given that minigames start infrequently (once per combat), the overhead is negligible compared to the benefit of UI consistency.
- **[Risk] Naming Mismatches** → If the UXML IDs do not match the strings in the code, the hiding logic will fail.
    - *Mitigation*: The design explicitly lists the expected IDs, which must be verified against the project's UXML assets.
