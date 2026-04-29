## Context

Actualment, el mètode `Update` de `Player.cs` realitza un `return` d'hora si `!potMoure`. La lògica de gestió AFK es troba després d'aquest retorn, el que significa que si un jugador entra en combat o mor mentre està en estat AFK, el temps i l'alpha no es resetegen, provocant un parpelleig persistent.

## Goals / Non-Goals

**Goals:**
- Aturar el parpelleig AFK immediatament quan el jugador entra en un estat on no es pot moure (`!potMoure`).
- Garantir que el sprite tingui sempre alpha `1f` durant els combats i estats especials.

**Non-Goals:**
- Canviar el llindar de temps (3s) per activar l'estat AFK.
- Modificar el sistema de parpelleig en si mateix.

## Decisions

- **Reseteig Proactiu**: S'afegirà una comprovació al principi de l'Update per netejar `tempsInactiu` i l'alpha del `SpriteRenderer` si `potMoure` és `false`.
- **Simplificació de la Lògica**: En lloc de moure tota la gestió AFK, es prefereix resetar-la quan es detecta el bloqueig de moviment per assegurar que el retorn d'hora no deixi estats inconsistents.

## Risks / Trade-offs

- **[Risc] Rendiment**: Afegir més operacions al `Update`.
  - **[Mitigació]**: L'operació de reseteig només es farà quan `potMoure` sigui fals, que és un estat temporal, i l'assignació de color es pot optimitzar per només fer-se si el temps era superior a zero.
