## Context

El problema d'accidentalitat en el robatori de la bandera prové del fet que l'objecte "Bandera" manté la seva capacitat de col·lisionar fins i tot quan ja és filla d'un jugador. Això fa que altres jugadors puguin disparar esdeveniments de col·lisió amb la bandera simplement passant a prop del portador actual.

## Goals / Non-Goals

**Goals:**
- Desactivar la interacció física de la bandera mentre està sent portada.
- Garantir que la bandera només es pugui obtenir mitjançant col·lisió quan està al terra.
- Assegurar que la bandera només es pugui obtenir mitjançant la lògica de combat (Minijoc) quan ja té propietari.

**Non-Goals:**
- Modificar el sistema de moviment dels jugadors.
- Canviar els visuals de la bandera.

## Decisions

- **Modificació a Player.cs**: S'inserirà la lògica de desactivació del collider directament dins del mètode que gestiona la col·lisió/trigger amb la bandera.
- **GetComponent<Collider2D>().enabled = false**: S'ha triat desactivar el component sencer per assegurar que cap tipus de col·lisió (trigger o normal) es produeixi mentre el jugador la porta.
- **Re-activació a DeixarBandera()**: Per mantenir la funcionalitat si la bandera es torna a deixar al terra, s'ha d'assegurar que el collider es torni a activar.

## Risks / Trade-offs

- **[Risk] La bandera es perd si el collider no es reactiva**: Si un jugador deixa la bandera i el collider es queda en `false`, cap altre jugador podrà tornar-la a agafar.
    - **Mitigation**: Assegurar que `DeixarBandera()` a `Player.cs` posi `enabled = true`.
