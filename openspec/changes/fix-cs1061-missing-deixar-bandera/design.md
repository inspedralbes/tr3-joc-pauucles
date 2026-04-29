## Context

L'error CS1061 indica que s'estan intentant cridar mètodes que no existeixen en les classes `Player` i `Bandera`. Això és un efecte secundari d'una purga de codi anterior que va ser massa agressiva o incompleta.

## Goals / Non-Goals

**Goals:**
- Implementar els mètodes `DeixarBandera` i `DeixarDeSeguir`.
- Restaurar la funcionalitat de desvinculació de la bandera.
- Corregir els errors de compilació.

**Non-Goals:**
- No es modificarà la lògica de recollida (`AgafarBandera`).

## Decisions

- **Implementació de `DeixarDeSeguir` a `Bandera.cs`**:
  - Nul·lifica `targetSeguiment`.
  - Atura el moviment horitzontal establint `linearVelocity.x` a 0.
- **Implementació de `DeixarBandera` a `Player.cs`**:
  - Comprova si hi ha una bandera agafada.
  - Obté el component `Bandera` i crida a `DeixarDeSeguir`.
  - Nul·lifica la referència `banderaAgafada`.

## Risks / Trade-offs

- **[Risc] Referències nul·les** → **Mitigació**: S'inclouen comprovacions de nul·litat tant per a la referència de la bandera com per al seu component abans de cridar mètodes.
