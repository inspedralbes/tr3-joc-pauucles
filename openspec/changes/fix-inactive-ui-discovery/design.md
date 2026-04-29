## Context

The minigame initiation logic currently relies on `FindObjectOfType`, which fails to locate the `MinijocUIManager` if its GameObject is inactive. This is a common issue in standalone builds where UI elements might be disabled by default. Additionally, the UI container management needs to be more robust to handle multiple minigames within the same `UIDocument`.

## Goals / Non-Goals

**Goals:**
- Ensure `MinijocUIManager` is found regardless of its active state using `Resources.FindObjectsOfTypeAll`.
- Force the UI manager's GameObject to active upon discovery.
- Surgical movement locking of only the two players involved in combat.
- Reliable "Hide All, Show Active" pattern for minigame UI containers.

**Non-Goals:**
- Redesigning the minigame mechanics themselves.
- Changing the networking layer (which uses `NetworkSync`).

## Decisions

### 1. Robust Manager Discovery in `Player.cs`
- **Decision**: Use `Resources.FindObjectsOfTypeAll<MinijocUIManager>()` instead of singleton or standard Find methods.
- **Rationale**: This method can find assets and inactive objects in the scene, which is necessary if the UI root is disabled.
- **Implementation**:
    ```csharp
    var managers = Resources.FindObjectsOfTypeAll<MinijocUIManager>();
    if (managers.Length > 0) {
        var ui = managers[0];
        ui.gameObject.SetActive(true);
        ui.IniciarMinijoc(this.gameObject, collision.gameObject);
    }
    ```

### 2. Surgical Movement Locking in `MinijocUIManager`
- **Decision**: Delegate the responsibility of freezing participants to the `MinijocUIManager`.
- **Rationale**: Centralizing the "Combat State" management in the UI manager ensures that participants are frozen exactly when the UI appears.
- **Implementation**: `IniciarMinijoc(GameObject g1, GameObject g2)` will get the `Player` components and set `potMoure = false`.

### 3. Container Visibility Management
- **Decision**: Use `DisplayStyle.None` for all containers and `DisplayStyle.Flex` for the active one.
- **Rationale**: Ensures no visual overlap if multiple containers are accidentally enabled in the UXML.
- **Implementation**: Update `AmagarTotsElsMinijocs` and the `switch` statement in `IniciarMinijoc`.

## Risks / Trade-offs

- **[Risk] Resources.FindObjectsOfTypeAll Performance** → This method is slower than `FindObjectOfType`.
    - *Mitigation*: It is only called once when combat starts (infrequent event), and it ensures build stability.
- **[Risk] Magic Strings in UXML** → Relying on container IDs like "ContenidorPPTLLS".
    - *Mitigation*: These are documented and part of the core UI design.
