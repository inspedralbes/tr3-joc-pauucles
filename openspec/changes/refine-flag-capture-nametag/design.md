## Context

The project uses a team-based "Capture the Flag" mechanic. Currently, there are inconsistencies in how teams are identified between the player and the flags, leading to capture failures. Furthermore, the local player's nametag discovery is fragile, often failing if the component type doesn't match the expected `TextMeshPro` type or if the hierarchy is different.

## Goals / Non-Goals

**Goals:**
- Implement a robust nametag discovery system for the local player.
- Ensure flag capture logic is verifiable through diagnostic logging.
- Synchronize team identification strings between `GameManager` and `Bandera`.

**Non-Goals:**
- Refactoring the entire networking system.
- Modifying remote player nametag logic (focus is on local visuals).

## Decisions

### 1. Robust Nametag Discovery
In `GameManager.ConfigurarLocalPlayerVisuals()`, we will use a multi-step discovery process for the text component:
- **Step A**: Try `GetComponentInChildren<TMPro.TextMeshPro>()`.
- **Step B**: Try `GetComponentInChildren<UnityEngine.UI.Text>()`.
- **Step C**: If both fail, find a child named "Nametag" and search there.
- **Rationale**: This covers different prefab versions (TMP vs Legacy UI) and nested hierarchies.

### 2. Diagnostic Logging in Bandera
We will add a log at the entry of `Bandera.OnTriggerEnter2D`:
- **Log**: `[Bandera] Col·lisió! Jugador equip: {jugadorEquip}, Bandera equip: {equipPropietari}`.
- **Rationale**: This allows immediate identification of team mismatches in the console without needing a debugger attached.

### 3. Team Variable Renaming
Renaming `elMeuEquip` to `jugadorEquip` in `Bandera.cs`.
- **Rationale**: Aligns with the domain language of the requested fix and improves readability regarding whose team is being evaluated.

## Risks / Trade-offs

- **[Risk]** Component discovery is performance-heavy if called frequently.
- **[Mitigation]** This is only called once during `ConfigurarLocalPlayerVisuals()` (local player initialization).

- **[Risk]** Hardcoded "Nametag" name fallback.
- **[Mitigation]** Standardizing the prefab hierarchy to include this object if standard component discovery fails.
