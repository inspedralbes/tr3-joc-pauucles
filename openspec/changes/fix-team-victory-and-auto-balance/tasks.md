## 1. GameManager Updates

- [x] 1.1 Add `EsDelMeuEquip(string username)` method to `GameManager.cs` to check player team affiliation.
- [x] 1.2 Update `FinalitzarPartida(bool victoria)` in `GameManager.cs` to ensure it correctly handles the boolean state.

## 2. MenuManager Updates

- [x] 2.1 Modify `AlRebreActualitzacioSales` in `MenuManager.cs` to use `GameManager.Instance.EsDelMeuEquip` when processing `GAME_OVER`.
- [x] 2.2 Update `UnirseAPartida(string roomId)` in `MenuManager.cs` to implement client-side team auto-balancing.
- [x] 2.3 Implement the player count logic for Team A and Team B in `UnirseAPartida`.

## 3. Verification

- [ ] 3.1 Verify team auto-balance correctly assigns Team A when it has fewer players.
- [ ] 3.2 Verify team auto-balance correctly assigns Team B when it has fewer players.
- [ ] 3.3 Verify victory screen correctly shows for both team members when a teammate wins.
