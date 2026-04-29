## Context

El mètode `AgafarBanderaAutomàticament` desactiva el collider de la bandera (`colB.enabled = false`) per evitar que aquesta col·lideixi amb el jugador mentre la porta. Tot i això, això provoca que el `Rigidbody2D` de la bandera no detecti el terra i caigui del mapa.

## Goals / Non-Goals

**Goals:**
- Mantenir el collider de la bandera actiu durant tot el joc.
- Evitar conflictes físics (empentes) entre el jugador i la seva pròpia bandera.

**Non-Goals:**
- No es modificarà la lògica de seguiment (`Bandera.cs`).
- No es canviarà el sistema de detecció de col·lisions amb altres objectes o enemics.

## Decisions

- **Ús de `Physics2D.IgnoreCollision`**: S'ha triat aquesta solució perquè permet ignorar col·lisions entre dos objectes específics de manera programàtica sense afectar la seva interacció amb la resta del món físic.
- **Mantenir `AgafarBandera`**: Es mantindrà la crida al mètode `AgafarBandera` per assegurar que la lògica de seguiment de la mascota s'inicia correctament.

## Risks / Trade-offs

- **[Risc] La bandera podria travessar el jugador** → **Mitigació**: Aquest és el comportament desitjat per evitar que el jugador "surti disparat" en tocar la seva pròpia bandera, però mantenint la capacitat de la bandera de recolzar-se al terra.
