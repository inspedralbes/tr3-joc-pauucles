## Context

The current flag capture implementation in `Bandera.cs` manually calculates distances and moves towards a target in `Update`. This is redundant because Unity's transform hierarchy is designed to handle this exact scenario: one object moving with another.

## Goals / Non-Goals

**Goals:**
- Transition flag carrying to a hierarchical model (`SetParent`).
- Simplify `Bandera.cs` by removing manual tracking variables and code.
- Ensure visual consistency with a fixed offset.

**Non-Goals:**
- Implementing flag physics while carried (it will be kinematic/parented).
- Modifying the networking protocol (we rely on the existing sync).

## Decisions

### 1. Transform Parenting
We will use `transform.SetParent(collision.transform)` inside `OnTriggerEnter2D`.
- **Rationale**: This is the most idiomatic way in Unity to make an object follow another perfectly. It removes the need for `Update` logic and variables like `targetSeguiment`.

### 2. Local Offset
Immediately after parenting, we will set `transform.localPosition = new Vector3(-0.5f, 0.5f, 0f)`.
- **Rationale**: Provides a consistent visual position (behind and slightly above the player) regardless of where the collision happened.

### 3. Logic Cleanup
Variables `esCapturada`, `targetSeguiment`, and their associated logic in `Update` and `OnTriggerEnter2D` will be removed.
- **Rationale**: These are no longer needed with parenting.

## Risks / Trade-offs

- **[Risk]** Scaling issues: If the player has a non-uniform scale, the flag will inherit it.
- **[Mitigation]** We assume player scale is (1,1,1) or handled uniformly.
- **[Risk]** Network Sync: Remote players might not see the flag parented if they don't trigger the collision locally.
- **[Mitigation]** We will ensure `NetworkSync` is active, but if the capture state is not broadcast, remotes might need a separate mechanism. However, following the user's specific directive to use hierarchy and no extra code, we proceed with parenting.
