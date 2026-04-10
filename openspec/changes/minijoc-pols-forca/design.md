## Context

Els minijocs actuals del projecte resolen combats mitjançant diferents mecàniques (Llangardaix-Spock, etc.). Aquest nou minijoc és una prova de força de "tapping" on la puntuació d'un jugador puja a costa de l'altre, simulant una estirada de corda o un pols.

## Goals / Non-Goals

**Goals:**
- Crear un script autònom `MinijocPolsimForcaLogic.cs`.
- Implementar la lògica de polsatge simultani per a dos jugadors.
- Gestionar el final de partida per temps i declarar un guanyador.

**Non-Goals:**
- Implementar la interfície gràfica (UXML/USS) en aquest pas (només la lògica de backend del minijoc).
- Modificar el comportament físic del món de joc.

## Decisions

- **Control d'Input Dual**: S'utilitzaran `KeyCode.Space` i `KeyCode.Return` per a entrada de teclat, i els clics de ratolí (0 i 1) per a entrada tàctil/ratolí, permetent flexibilitat en el control.
- **Diferencial de Puntuació**: Cada pulsació suma +2 a la puntuació pròpia i resta -2 a l'oponent. Això fa que el minijoc sigui una lluita de "suma zero" centrada en el valor de 50.
- **Clampeig de Valors**: S'utilitzarà `Mathf.Clamp(valor, 0, 100)` per evitar valors negatius o excessius en les puntuacions.
- **Notificació al Gestor**: Es dependrà d'una instància de `MinijocUIManager` o un callback similar per passar el guanyador quan el temporitzador arribi a zero.

## Risks / Trade-offs

- **[Risc] Velocitat de Polsatge** → Si un jugador és extremadament ràpid, podria arribar a 100/0 molt abans que s'acabi el temps. *Mitigació*: El joc continua fins que s'acaba el temps per donar lloc a remuntades.
- **[Trade-off] Entrada Compartida** → L'ús de clics de ratolí pot ser confús si el ratolí s'utilitza per a altres coses. *Mitigació*: El combat bloqueja el moviment general, així que el ratolí queda lliure per al minijoc.
