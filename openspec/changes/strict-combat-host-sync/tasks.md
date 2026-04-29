## 1. Player Script Refinement

- [x] 1.1 Remove the local `MinijocUIManager` discovery and initialization calls from the Host branch in `OnCollisionEnter2D`.
- [x] 1.2 Ensure the Host branch ONLY freezes players and sends the `MINIJOC_START` message.

## 2. Networking Handler Refactoring

- [x] 2.1 Update the `MINIJOC_START` handler in `MenuManager.cs` to perform robust UI discovery for BOTH participants.
- [x] 2.2 Use `Resources.FindObjectsOfTypeAll<MinijocUIManager>()[0]` to ensure the manager is found even if disabled.
- [x] 2.3 Implement the `gameObject.SetActive(true)` call and trigger `IniciarMinijoc` with the received index.

## 3. UI Manager Refactoring

- [ ] 3.1 Update `MinijocUIManager.IniciarMinijoc` to strictly manage container visibility.
- [ ] 3.2 Ensure `AmagarTotsElsMinijocs` is called at the very beginning of the initialization.
- [ ] 3.3 Update the `switch` statement to enable ONLY the container corresponding to the passed index.

## 4. Verification

- [ ] 4.1 Verify that the Host's UI does not open until the network round-trip is complete.
- [ ] 4.2 Verify that the Client's UI opens simultaneously with the Host.
- [ ] 4.3 Ensure no visual artifacts or overlapping containers occur during combat start.
