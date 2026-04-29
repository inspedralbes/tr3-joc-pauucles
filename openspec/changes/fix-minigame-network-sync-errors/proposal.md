## Why

The recent universal network synchronization refactor introduced several compilation errors (CS0103 and CS1061) due to missing variables and unimplemented interface methods in various minigame logic scripts. Fixing these is critical to restore the project's buildability and ensure that network events are correctly handled across all minigames.

## What Changes

- **PPTLLS Variable Fix**: Declare the missing `jocActiu` variable in `MinijocPPTLLSLogic.cs` and ensure its state is correctly managed during initialization and completion.
- **ParellsSenars Interface Implementation**: Add the missing `RebreResultatXarxa` method to `MinijocParellsSenarsLogic.cs` to handle rival victory events.
- **AcaparamentMirades Interface Implementation**: Add the missing `RebreResultatXarxa` method to `MinijocAcaparamentMiradesLogic.cs` to handle rival victory events.
- **Network Resolution Consistency**: Ensure that all minigames react to rival "win" messages by immediately stopping local execution and closing the UI.

## Capabilities

### New Capabilities
- `minigame-network-fault-tolerance`: Ensuring all minigame logics properly implement the required networking bridge methods.

### Modified Capabilities
- `minigame-network-sync`: Refining the synchronization protocol requirements to include mandatory result handling.

## Impact

- `MinijocPPTLLSLogic.cs`: Fixes CS0103 (missing variable).
- `MinijocParellsSenarsLogic.cs`: Fixes CS1061 (missing method called by UIManager).
- `MinijocAcaparamentMiradesLogic.cs`: Fixes CS1061 (missing method called by UIManager).
- `MinijocUIManager.cs`: Reliability of the network bridge improves as all targets now implement the required methods.
