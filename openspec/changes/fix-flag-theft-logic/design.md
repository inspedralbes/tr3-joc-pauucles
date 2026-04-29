## Context

El sistema de combat actual permet que un guanyador prengui la bandera del perdedor. No obstant això, la implementació és fràgil perquè depèn de referències locals que poden no estar actualitzades o que es veuen afectades pel motor de física de Unity, causant que la bandera "surti volant" o quedi mal posicionada.

## Goals / Non-Goals

**Goals:**
- Implementar una cerca global de la bandera per assegurar que sempre es troba l'objecte.
- Forçar el posicionament visual a sobre del cap del jugador guanyador.
- Anul·lar qualsevol influència de la física (gravetat o velocitat) mentre la bandera és transportada.

**Non-Goals:**
- Implementar animacions de robatori.
- Canviar el sistema de col·lisions de la bandera.

## Decisions

- **GameObject.FindGameObjectWithTag("Bandera")**: S'ha decidit utilitzar aquesta cerca en lloc de confiar en que el `perdedor.banderaAgafada` no sigui nul. Això fa que el robatori sigui molt més robust, especialment si hi ha algun desajust de xarxa o de referències entre scripts en el futur.
- **isKinematic = true**: En assignar la bandera a un jugador, es desactivarà el seu caràcter dinàmic. Això evita que el `Rigidbody2D` intenti corregir la posició segons la gravetat, permetent que el `transform.localPosition` s'apliqui estrictament sense "jittering".
- **Offset (0, 0.8f, 0)**: Aquest valor s'ha triat per assegurar que la bandera és visible per sobre de l'sprite del jugador sense tapar-lo ni quedar massa lluny.

## Risks / Trade-offs

- **[Risk] Rendiment de Find**: `GameObject.Find` és una operació costosa. -> **[Mitigation]**: Com que només es crida una vegada en acabar el minijoc (quan el jugador guanya), el seu impacte és insignificant comparat amb el guany en robustesa.
- **[Risk] Múltiples Banderes**: Si hi ha més d'una bandera amb el mateix tag. -> **[Mitigation]**: El disseny actual del joc assumeix una única bandera ("Atrapa la bandera").
