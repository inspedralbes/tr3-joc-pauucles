## 1. Network Protocol Update

- [ ] 1.1 Add `public float z;` to the `PlayerMoveMessage` class in `NetworkSync.cs`.
- [ ] 1.2 Update `SendPosition` in `NetworkSync.cs` to include `transform.position.z` in the JSON payload.
- [ ] 1.3 Update `RebrePosicio` in `NetworkSync.cs` to accept the `z` coordinate and apply it to `posicioObjectiu`.

## 2. Player Logic Enhancement

- [ ] 2.1 Implement the `RutinaStun` coroutine in `Player.cs`.
- [ ] 2.2 Implement `GuanyarMinijoc()` in `Player.cs` to restore mobility and send the Z=999 signal.
- [ ] 2.3 Implement `PerdreMinijoc()` in `Player.cs` to trigger the stun routine.
- [ ] 2.4 Implement `EnviarSenyalZ(float zValue)` in `Player.cs` to update the actual position.

## 3. Z-Hack Receiver Implementation

- [ ] 3.1 Update `AlRebreActualitzacioSales` in `MenuManager.cs` to detect `moveMsg.z == 999f`.
- [ ] 3.2 Implement the remote defeat trigger: close UI and call `localPlayer.PerdreMinijoc()`.
- [ ] 3.3 Ensure the received Z is forced back to 0.0 after processing to avoid rendering artifacts.

## 4. Verification

- [ ] 4.1 Verify that winning a minigame triggers a 3s stun on the opponent's screen.
- [ ] 4.2 Verify that the Z Hack correctly closes the UI for the losing participant.
- [ ] 4.3 Confirm that characters do not remain at Z=999 after the signaling is complete.
