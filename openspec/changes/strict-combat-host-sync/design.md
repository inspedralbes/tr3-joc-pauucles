## Context

To achieve perfect synchronization in minigame startup, we are moving to a pure "Network Event" model. In this model, even the player who triggers the combat (the Host) does not open the UI immediately. Instead, they broadcast their selection and wait for the reflected message from the server, ensuring that both participants enter the combat state at the exact same moment.

## Goals / Non-Goals

**Goals:**
- Eliminate local race conditions in UI activation.
- Centralize combat startup in the network message handler.
- Ensure strict container visibility management in `MinijocUIManager`.

**Non-Goals:**
- Modifying individual minigame internal logic (only the container activation is changed).
- Changing the Host election criteria (Lexicographical name comparison remains).

## Decisions

### 1. Passive Host Initiation
- **Decision**: Remove all UI-related calls from `Player.OnCollisionEnter2D`.
- **Rationale**: By removing local side effects, we ensure that the Host and Client follow an identical code path for UI activation (via the network handler).

### 2. Network-Only Entry Point
- **Decision**: The `MINIJOC_START` handler in `MenuManager.cs` becomes the sole entry point for `MinijocUIManager.IniciarMinijoc`.
- **Implementation**: 
    - Search for UI manager using `Resources.FindObjectsOfTypeAll`.
    - Activate the discovered GameObject.
    - Pass the `gameIndex` from the JSON message.

### 3. Strict Container Activation in `MinijocUIManager`
- **Decision**: Update `IniciarMinijoc(int index)` to strictly call `AmagarTotsElsMinijocs` before enabling the target container.
- **Rationale**: This prevents any visual artifacts from previous sessions or manual edits in the UXML.

## Risks / Trade-offs

- **[Risk] Reflection Delay** → The Host might experience a tiny delay (ping) between collision and UI appearance.
    - *Mitigation*: This is standard for online multiplayer and is preferable to desynchronized game starts.
- **[Risk] UI Object discovery** → `Resources.FindObjectsOfTypeAll` can be slow or find unexpected objects.
    - *Mitigation*: We will use the first valid scene instance found.
