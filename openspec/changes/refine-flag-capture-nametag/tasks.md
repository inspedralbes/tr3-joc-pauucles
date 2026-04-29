## 1. Local Player Visuals Refinement

- [x] 1.1 Update `GameManager.ConfigurarLocalPlayerVisuals()` to use exhaustive text component search.
- [x] 1.2 Implement fallback logic for "Nametag" GameObject discovery in `ConfigurarLocalPlayerVisuals()`.
- [x] 1.3 Verify `MenuManager.Instance.userId` is correctly assigned to the discovered component.

## 2. Flag Capture Logic & Debugging

- [x] 2.1 Update `Bandera.OnTriggerEnter2D()` to include diagnostic logging for team collisions.
- [x] 2.2 Rename `elMeuEquip` to `jugadorEquip` in `Bandera.cs` for clarity.
- [x] 2.3 Ensure capture logic (following) is only triggered when `jugadorEquip != equipPropietari`.
- [x] 2.4 Verify `InstanciarBanderes()` in `GameManager.cs` uses consistent team IDs ("A", "B").

## 3. Verification

- [x] 3.1 Verify nametag display for the local player in-game.
- [x] 3.2 Verify console output correctly reports team identities during flag collisions.
- [x] 3.3 Verify successful flag capture when colliding with an enemy flag.
