## 1. Player Script Preparation

- [x] 1.1 Declare `private static float ultimXoc = 0f;` in `Player.cs`.
- [x] 1.2 Declare `private static int comptadorCombats = 0;` in `Player.cs`.

## 2. Deterministic Collision Logic

- [x] 2.1 Implement the cooldown firewall in `OnCollisionEnter2D`: `if (Time.time - ultimXoc < 3f) return;`.
- [x] 2.2 Update `ultimXoc` and increment `comptadorCombats`.
- [x] 2.3 Retrieve `localName` and `nomRival` (using `RemotePlayer` for the rival).
- [x] 2.4 Generate the deterministic shared key: `clau = (local < rival) ? local + rival : rival + local`.
- [x] 2.5 Calculate `gameIndex` using `Mathf.Abs((clau + comptadorCombats).GetHashCode()) % 5`.

## 3. Immediate UI Activation

- [x] 3.1 Freeze local and opponent movement.
- [x] 3.2 Open UI immediately using `Resources.FindObjectsOfTypeAll<MinijocUIManager>()[0]`.
- [x] 3.3 Ensure NO network messages are sent for the initiation trigger.

## 4. Verification

- [ ] 4.1 Verify that both players enter the exact same minigame simultaneously without any network delay.
- [ ] 4.2 Verify that rapid collisions do not trigger multiple minigames or desync the counter.
