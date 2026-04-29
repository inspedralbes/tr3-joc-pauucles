## Context

Fins ara, el combat es resolia sense tenir en compte qui portava la bandera o qui iniciava el combat per aplicar penalitzacions o robatoris. Cal centralitzar aquesta lògica a `MinijocUIManager` per facilitar la integració amb futurs sistemes (com la IA).

## Goals / Non-Goals

**Goals:**
- Identificar clarament l'atacant i el defensor al començar un combat.
- Implementar un mètode de finalització que apliqui lògica de joc (pèrdua de bandera).
- Netejar la UI al acabar.

**Non-Goals:**
- Implementar la IA del Guàrdia en aquest pas (només preparar l'espai).
- Canviar els minijocs existents.

## Decisions

- **Variables de Jugador Privades**: S'utilitzaran camps privats `atacant` i `defensor` per mantenir l'estat del combat actiu.
- **Identificació de Rols**: En aquesta fase, s'assumirà que `p1` és l'atacant i `p2` el defensor, o es determinarà per qui porta la bandera.
- **Desvinculació de Bandera**: S'utilitzarà `SetParent(null)` sobre el Transform de la bandera per alliberar-la al món quan el defensor perdi. S'ha de garantir que la referència interna del jugador també es netegi.

## Risks / Trade-offs

- **[Risc] Referències Nul·les** → Si un jugador mor o es destrueix durant el minijoc, les referències d'atacant/defensor podrien causar errors. *Mitigació*: S'afegiran comprovacions de nul·litat abans d'operar.
- **[Trade-off] String per al Guanyador** → S'utilitza un string per identificar el guanyador ("Jugador 1", "Jugador 2") per simplicitat amb el feedback de consola existent, tot i que un Enum seria més robust.
