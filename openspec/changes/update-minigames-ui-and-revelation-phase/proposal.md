## Why

The current minigame implementations are not properly linked to the new UI Builder elements, and they lack a consistent revelation phase. This change ensures all minigames use the correct UI references and provide a 3-second feedback window (revelation phase) before concluding, improving player experience and visual clarity.

## What Changes

- **PPTLLS**: Link buttons (Pedra, Paper, Tisora, Llangardaix, Spock), time and result labels. Add 3s revelation phase.
- **Parells o Senars**: Link operation and result labels, and choice buttons. Implement sum-based logic with immediate feedback and 3s revelation phase.
- **AturaBarra**: Link result label. Add 3s revelation phase after stopping the arrow.
- **PolsimForca**: Link time and result labels. Support multiple input methods (Space, Return, Click). Add 3s revelation phase.
- **AcaparamentMirades**: Link time and result labels, and direction buttons. Add 3s revelation phase and ensure draw force is applied.
- **BREAKING**: All minigames now require a 3-second delay (revelation phase) before calling `FinalitzarCombat`.

## Capabilities

### New Capabilities
- `minigame-revelation-phase`: Implements a standardized 3-second delay after game resolution to show results before closing the UI.

### Modified Capabilities
- `acaparament-mirades-logic`: Updated to include UI button linking and the revelation phase.

## Impact

- `MinijocPPTLLS.cs`, `MinijocParellsSenarsLogic.cs`, `MinijocAturaBarraLogic.cs`, `MinijocPolsimForcaLogic.cs`, `MinijocAcaparamentMiradesLogic.cs`: Logic updates.
- `MinijocUIManager.cs`: Indirect impact as it receives the final call after the revelation phase.
- UI Toolkit (UXML/USS): Depends on existing elements being present.
