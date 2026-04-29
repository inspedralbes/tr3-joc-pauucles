## Context

S'ha identificat un error de lògica en el sistema de combat on la bandera es transfereix al guanyador encara que el perdedor no la portés. Això causa teletransports inconsistents de la bandera per l'escena. Es vol corregir aquest comportament afegint una comprovació de possessió real abans del traspàs.

## Goals / Non-Goals

**Goals:**
- Validar la possessió de la bandera pel perdedor abans de moure-la.
- Assegurar que la bandera roman en la seva posició original si el combat no n'implica el seu traspàs.
- Mantenir l'aplicació del càstig de derrota independentment de la possessió de la bandera.

**Non-Goals:**
- Canviar les coordenades de posicionament de la bandera.
- Modificar el sistema de detecció de col·lisions.

## Decisions

- **Comprovació de Parentiu**: S'utilitzarà `bandera.transform.parent == jugadorPerdedor.transform` com a criteri de veritat per determinar si el perdedor realment portava la bandera. Aquesta és la forma més fiable ja que el sistema de robatori actual utilitza `SetParent`.
- **Refactorització de ProcessarResultatCombat**: Es modificarà aquest mètode al `MinijocUIManager` per incloure el condicional de robatori abans de cridar als mètodes de `Player`.

## Risks / Trade-offs

- **[Risk] Referències nul·les**: Si l'objecte bandera no es troba a l'escena en el moment de la comprovació. -> **[Mitigation]**: S'afegiran null-checks tant per a l'objecte bandera com per als jugadors implicats.
- **[Risk] Banderes deslligades**: Si la bandera està a terra (sense pare), la condició serà falsa, el que és correcte (no es pot robar a algú que no la té).
