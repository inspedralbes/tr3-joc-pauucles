## Context

The Nametag and Minigame locking mechanisms work correctly in the Unity Editor but show fragility in the standalone executable build. Rendering layers for the Nametag's Canvas are not consistently prioritized, and singleton discovery via `FindObjectOfType` sometimes fails or returns null during rapid scene transitions or specific build optimizations.

## Goals / Non-Goals

**Goals:**
- Guarantee Nametag visibility by forcing Canvas sorting order and adjusting depth.
- Implement a fallback mechanism for discovering the `MinijocUIManager`.
- Ensure surgical locking of movement only for the current fighters.
- Provide clear console diagnostics for system-level actions.

**Non-Goals:**
- Redesigning the Nametag UI or Minigame UI.
- Changing the core combat logic.

## Decisions

### 1. Forced Nametag Rendering Priority
- **Decision**: Programmatically set the `sortingOrder` of the Nametag's `Canvas` and adjust its local offset.
- **Rationale**: Manual Inspector settings can sometimes be overridden or behave differently in builds. Forcing it via code ensures consistency.
- **Implementation**: In `Start()`, set `Canvas.sortingOrder = 10` and `transform.localPosition = new Vector3(0, 1.2f, -0.1f)`.

### 2. Aggressive Manager Discovery in `Player.cs`
- **Decision**: Enhance `OnCollisionEnter2D` to find `MinijocUIManager` by name if the static instance is unavailable.
- **Rationale**: In some builds, static instances might not be fully initialized or found by type during the exact frame of collision. Finding by path/name "PantallaCombats" provides a reliable fallback.
- **Implementation**:
  ```csharp
  MinijocUIManager manager = MinijocUIManager.Instance;
  if (manager == null) {
      GameObject go = GameObject.Find("PantallaCombats");
      if (go != null) manager = go.GetComponent<MinijocUIManager>();
  }
  ```

### 3. Surgical Fighter Locking
- **Decision**: Apply `potMoure = false` explicitly to `this` and `opponent` ONLY after successful manager discovery.
- **Rationale**: Prevents accidental player freezing if the manager is truly missing.
- **Implementation**: Only lock movement inside the successful manager check block and add the `[SISTEMA]` log.

## Risks / Trade-offs

- **[Risk] Magic Strings** → Using `GameObject.Find("PantallaCombats")` introduces a hard dependency on the object name in the hierarchy.
    - *Mitigation*: This object is part of the core HUD/UI prefab and is unlikely to be renamed. It serves as a necessary safety net for build stability.
