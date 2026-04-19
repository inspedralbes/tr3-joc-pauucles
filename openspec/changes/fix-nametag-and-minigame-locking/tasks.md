## 1. Nametag Visual Fixes

- [x] 1.1 Add `Start()` method to `Nametag.cs`.
- [x] 1.2 Implement `GetComponent<Canvas>().sortingOrder = 10;` in `Nametag.Start()`.
- [x] 1.3 Update `transform.localPosition = new Vector3(0, 1.2f, -0.1f);` in `Nametag.Start()`.

## 2. Robust Minigame Discovery

- [x] 2.1 Update `OnCollisionEnter2D` in `Player.cs` to store `MinijocUIManager.Instance` in a local variable.
- [x] 2.2 Add fallback logic in `Player.cs` to use `GameObject.Find("PantallaCombats")` if the instance is null.
- [x] 2.3 Implement the `[SISTEMA]` Debug.Log when the manager is successfully found.
- [x] 2.4 Ensure `potMoure = false` is applied to `this` and `opponent` only if the manager is found.

## 3. Verification

- [ ] 3.1 Verify Nametag is visible in front of the player in a standalone build.
- [ ] 3.2 Verify combat correctly freezes both players even when the singleton instance is initially null.
