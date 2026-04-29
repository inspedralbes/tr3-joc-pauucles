## Context

El sistema de recollida de bandera s'havia canviat recentment a un mode manual basat en tecles (`E` i `RightControl`). Per millorar la fluïdesa del joc, es vol revertir aquest canvi i tornar a un sistema automàtic per contacte.

## Goals / Non-Goals

**Goals:**
- Eliminar tota la lògica de proximitat i input manual relacionada amb la bandera.
- Implementar una recollida automàtica redundant (Trigger i Col·lisió).
- Assegurar que la bandera quedi desactivada físicament un cop recollida per evitar interaccions accidentals.

**Non-Goals:**
- No es canvia la lògica de combat (minijocs).
- No es modifica el comportament de la bandera fugitiva un cop està lliure.

## Decisions

- **Redundància de Detecció**: S'implementa tant en `OnTriggerEnter2D` com en `OnCollisionEnter2D`. Això assegura que, independentment de com estigui configurat el collider de la bandera (com a trigger o físic), la recollida sigui instantània.
- **Simplificació de Player.cs**: S'eliminen les variables `aPropDeBandera` i `banderaPropera`, ja que ja no cal mantenir l'estat de proximitat entre frames per esperar l'input.
- **Desactivació de Física Atòmica**: En el moment del `SetParent`, el collider s'ha de desactivar (`enabled = false`) en el mateix frame per evitar que es tornin a disparar esdeveniments de col·lisió.

## Risks / Trade-offs

- **[Risk] Conflictes amb altres triggers**: Altres objectes amb tags diferents podrien interferir si no es filtra correctament.
    - **Mitigation**: Ús estricte de `CompareTag("Bandera")` abans de realitzar cap acció.
