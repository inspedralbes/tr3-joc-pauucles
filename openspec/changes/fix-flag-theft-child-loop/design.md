## Context

El sistema actual utilitza `GameObject.FindGameObjectWithTag("Bandera")` per identificar l'objecte que s'ha de robar un cop finalitzat el combat. Aquesta aproximació és arriscada en escenes amb múltiples instàncies de la bandera o quan el tag no està indexat de forma òptima. A més, no es garanteix que la bandera trobada sigui realment la que portava el perdedor.

## Goals / Non-Goals

**Goals:**
- Implementar una cerca de la bandera restringida a la jerarquia del jugador perdedor.
- Assegurar un traspàs net del `Transform` del perdedor al guanyador.
- Normalitzar la posició i escala local de la bandera un cop robada.

**Non-Goals:**
- Modificar com es recull la bandera del terra (fora de combat).
- Implementar lògica de xarxa o multijugador avançada en aquesta fase.

## Decisions

- **Cerca per Transform Children**: S'utilitzarà un bucle `foreach` sobre el `Transform` del jugador perdedor. Això garanteix que només estem robant l'objecte que el jugador realment porta com a fill.
- **Identificació per Tag**: Dins del bucle, s'utilitzarà `child.CompareTag("Bandera")` per identificar l'objecte correcte. És més eficient i segur que la cerca global.
- **Posicionament Fix (-0.8, 0, 0)**: Es manté el desplaçament lateral per assegurar que la bandera és visible al costat del jugador i no a sobre del seu centre exacte (evitant solapaments amb altres elements visuals).
- **Escala Unitària (1, 1, 1)**: Es força l'escala per evitar distorsions si el jugador guanyador té una escala diferent a la de la bandera original.

## Risks / Trade-offs

- **[Risk] Múltiples objectes "Bandera" en un jugador**: Si un jugador arribés a portar dos objectes amb el mateix tag, el codi s'aturaria en el primer trobat (`break`).
    - **Mitigation**: El disseny actual només permet portar una bandera a la vegada.
- **[Risk] Rendiment de la iteració**: Recórrer els fills d'un transform pot ser lent si n'hi ha centenars.
    - **Mitigation**: Els jugadors tenen pocs fills (sprite, collider, bandera, etc.), pel que l'impacte és nul.
