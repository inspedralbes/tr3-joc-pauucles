## Context

Following the universal networking synchronization update, certain minigame logic scripts are missing implementation details required by the `MinijocUIManager` bridge. Specifically, `MinijocPPTLLSLogic` has a variable naming mismatch, and `MinijocParellsSenarsLogic` and `MinijocAcaparamentMiradesLogic` are missing the `RebreResultatXarxa` method. These omissions result in compilation errors CS0103 and CS1061.

## Goals / Non-Goals

**Goals:**
- Eliminate compilation errors CS0103 and CS1061.
- Ensure all minigame logics implement the networking bridge method `RebreResultatXarxa`.
- Harmonize variable naming in `MinijocPPTLLSLogic`.

**Non-Goals:**
- Adding new features or minigame modes.
- Changing the networking protocol itself.

## Decisions

### 1. Variable Synchronization in `MinijocPPTLLSLogic`
- **Decision**: Declare `jocActiu` as a private member variable and use it consistently.
- **Rationale**: Currently, there's a mix between `jocActiu` and `_jocActiu`, leading to "variable does not exist" errors in certain methods. Standardizing on `jocActiu` (or ensured consistent prefixing) solves this.

### 2. Method Stubbing for Network Results
- **Decision**: Add `public void RebreResultatXarxa(string winner)` to all missing logic scripts.
- **Rationale**: `MinijocUIManager` expects this method to exist on all potential active logic components.
- **Implementation**: The method will check if the winner is "RIVAL_WIN" and, if so, trigger a local loss/game-over state and close the UI.

## Risks / Trade-offs

- **[Risk] Redundant logic** → Duplicating the method in multiple files.
    - *Mitigation*: This is necessary to satisfy the `GetComponent<T>()` pattern used in the manager without a formal interface (which would require a larger refactor).
