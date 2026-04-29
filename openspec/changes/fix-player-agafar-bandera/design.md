## Context

El mètode `AgafarBandera` actual a `Player.cs` realitza operacions que poden entrar en conflicte amb el nou sistema de seguiment físic de la bandera (Dino), com el parentiu rígid i la desactivació parcial de la física.

## Goals / Non-Goals

**Goals:**
- Implementar la recollida de la bandera de manera que es mantingui com un objecte independent.
- Assegurar que el `Rigidbody2D` de la bandera estigui en mode `Dynamic` per permetre la detecció de col·lisions amb el terra.

**Non-Goals:**
- No es modificarà la lògica de moviment horitzontal del jugador.

## Decisions

- **Substitució exacta del mètode**: S'utilitzarà el codi proporcionat per l'usuari per substituir `AgafarBandera`. Aquest codi:
  1. Assigna la referència `banderaAgafada`.
  2. Elimina el parentiu (`SetParent(null)`).
  3. Estableix el `bodyType` a `Dynamic`.
  4. Inicia el seguiment mitjançant l'script `Bandera`.

## Risks / Trade-offs

- **[Risc] Conflictes de col·lisió** → **Mitigació**: Es pressuposa que el sistema de `IgnoreCollision` implementat anteriorment evitarà que la bandera empenyi al jugador.
