## Context

Actualment, quan s'utilitza `SetParent`, l'escala del fill (`Bandera`) és relativa a la del pare (`Player`). Això causa problemes si el jugador ha estat escalat a l'editor o per codi, ja que la bandera no manté la seva escala absoluta desitjada.

## Goals / Non-Goals

**Goals:**
- Fixar l'escala de la bandera a `(3, 3, 1)` immediatament després de fer el reparenting.
- Garantir que la bandera es visualitzi correctament tant en la recollida automàtica com en el robatori.

**Non-Goals:**
- Canviar l'escala del jugador.
- Modificar el sistema de moviment o combat.

## Decisions

- **Assignació manual de localScale**: S'ha triat `localScale = new Vector3(3f, 3f, 1f)` per sobre d'usar `lossyScale` o un `empty parent` neutre per simplicitat i control directe sobre l'asset visual de la bandera.
- **Ubicació del codi**: S'integrarà directament en les funcions que gestionen la vinculació de la bandera al jugador (`AgafarBanderaAutomàticament` i/o `AgafarBandera`).

## Risks / Trade-offs

- **[Risc] Escales diferents segons l'asset** → Si la bandera s'ha de canviar per un asset amb escala base diferent, caldrà actualitzar aquest codi. *Mitigació*: Es mantindrà el valor proposat per l'usuari (3f).
