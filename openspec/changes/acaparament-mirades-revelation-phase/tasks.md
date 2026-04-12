## 1. MinijocAcaparamentMiradesLogic Implementation

- [x] 1.1 Add state variables: `tempsRestant`, `tempsRevelacio`, `faseRevelacio`, labels `_textTemps` and `_textResultat`, and choice strings `eleccioJ1` and `eleccioJ2`.
- [x] 1.2 Implement `InicialitzarUI`: query "TextTempsMirades" and "TextResultatMirades" and clear the result text.
- [x] 1.3 Implement `IniciarMinijoc`: reset timers to 5s/3s, `faseRevelacio` to false, and choices to "Cap".
- [x] 1.4 Implement Choice Phase in `Update`: handle W/A/S/D (J1) and Arrow keys (J2) to record "Amunt", "Avall", "Esquerra", "Dreta".
- [x] 1.5 Transition to Revelation: when time is up or both chose, set `faseRevelacio = true` and display choices.
- [x] 1.6 Implement Revelation Phase in `Update`: count down 3s and then evaluate the winner (J2 wins if opposite).
- [x] 1.7 Call `MinijocUIManager.Instance.FinalitzarCombat` with the result ("Jugador 2" or "Empat").

## 2. MinijocUIManager Physical Feedback

- [x] 2.1 Update `FinalitzarCombat` in `MinijocUIManager.cs` to check for "Empat".
- [x] 2.2 Implement physical separation: apply `AddForce(Impulse, 10f)` to `_atacant` and `_defensor` in opposite directions when a draw occurs.
