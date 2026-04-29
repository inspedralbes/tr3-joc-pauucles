## 1. Bandera.cs Refactor

- [x] 1.1 Remove `esCapturada`, `targetSeguiment`, and manual `Update` follow logic from `Bandera.cs`.
- [x] 1.2 Implement hierarchical parenting using `transform.SetParent` in `OnTriggerEnter2D`.
- [x] 1.3 Set `transform.localPosition` to `new Vector3(-0.5f, 0.5f, 0f)` after parenting.

## 2. NetworkSync & Logic Verification

- [x] 2.1 Check `NetworkSync.cs` to ensure local player coordinate transmission remains uninterrupted.
- [x] 2.2 Verify that team identification logic in `OnTriggerEnter2D` correctly uses `equipPropietari`.

## 3. Verification

- [x] 3.1 Verify flag correctly attaches to the enemy player upon collision.
- [x] 3.2 Verify the flag moves perfectly with the player without jitter.
