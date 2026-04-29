## 1. Player Collision Rewrite

- [x] 1.1 Update `OnCollisionEnter2D` in `Player.cs` to retrieve local and rival usernames.
- [x] 1.2 Implement the lexicographical comparison: `string.Compare(nomLocal, nomRival) < 0`.
- [x] 1.3 Implement the **Host branch**: Generate `gameIndex`, activate `MinijocUIManager`, start game, and send `MINIJOC_START`.
- [x] 1.4 Implement the **Client branch**: Stop movement, log "Sóc client, espero la xarxa", and FES UN `return;` immediat.

## 2. Network Reception Refactor

- [x] 2.1 Update `AlRebreActualitzacioSales` in `MenuManager.cs` (or equivalent) to process `MINIJOC_START`.
- [x] 2.2 Inside the handler, implement robust UI discovery using `Resources.FindObjectsOfTypeAll<MinijocUIManager>()[0]`.
- [x] 2.3 Ensure the discovered UI is set to active and initialized with the exact `gameIndex` received.

## 3. Verification

- [ ] 3.1 Verify that only the lexicographical leader (Host) initiates the UI locally.
- [ ] 3.2 Verify that the Follower (Client) freezes movement but remains idle until the network message arrives.
- [ ] 3.3 Verify that both players end up in the exact same minigame simultaneously.
