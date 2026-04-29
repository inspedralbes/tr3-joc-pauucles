## Context

The "Polsim de Força" minigame needs to apply physical and state consequences to players when it concludes. Currently, it only notifies the UI manager but does not trigger the `WinCombat()` and `LoseCombat()` methods on the involved players.

## Goals / Non-Goals

**Goals:**
- Add `Player` references to `MinijocPolsimForcaLogic`.
- Pass these references from `MinijocUIManager` during initialization.
- Call `WinCombat()` and `LoseCombat()` on the appropriate players in `FinalitzarMinijoc()`.

**Non-Goals:**
- Change the core scoring or timing logic of the minigame.
- Modify the `MinijocUIManager.FinalitzarCombat` method itself (except for its call).

## Decisions

- **Initialization Update**: Modify `MinijocPolsimForcaLogic.InicialitzarUI` (or add a new method) to accept `Player p1` and `Player p2`.
- **Result Logic**:
  - If "Jugador 1" wins: `p1.WinCombat()`, `p2.LoseCombat()`.
  - If "Jugador 2" wins: `p2.WinCombat()`, `p1.LoseCombat()`.
  - On tie: No combat consequences (standard behavior).

## Risks / Trade-offs

- **Risk**: Null references if players are not passed correctly.
- **Mitigation**: Add null checks before calling methods on `p1` and `p2`.
