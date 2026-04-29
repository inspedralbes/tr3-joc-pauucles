## Context

La mecànica de la bandera fugitiva afegeix una capa de joc emergent en alliberar la bandera quan el portador perd un combat. Actualment, el robatori és directe i instantani. El nou disseny requereix un script dedicat a l'objecte bandera per gestionar el seu propi estat i moviment independent dels jugadors.

## Goals / Non-Goals

**Goals:**
- Implementar un comportament de retorn automàtic de la bandera a la seva base.
- Sincronitzar la desactivació del collider amb la possessió per evitar robatoris "fregant".
- Canviar el flux de `ProcessarResultatCombat` per alliberar la bandera en lloc de transferir-la.

**Non-Goals:**
- No es tracta de fer una IA complexa per a la bandera; és un moviment lineal simple cap a un punt fix.
- No es canvia la posició inicial de la bandera a l'escena.

## Decisions

- **Script `Bandera.cs`**: Es crea per centralitzar la lògica de retorn i estat. S'usa `Vector3.MoveTowards` per a un moviment controlat i previsible.
- **`SetParent(null)` en Combat**: En lloc de `SetParent(guanyador)`, s'allibera la bandera per forçar els jugadors a haver de perseguir-la o esperar que torni a la base.
- **Desactivació de Collider**: Es desactiva el collider quan el jugador la porta per evitar que altres jugadors la "robín" per col·lisió simple (només minijoc o quan està lliure).
- **Activació de Collider al Destí**: Només quan la bandera deixa d'estar en estat "fugint" es torna a activar la seva interactivitat física.

## Risks / Trade-offs

- **[Risk] La bandera es queda bloquejada**: Si el camí de retorn està obstruït.
    - **Mitigation**: El moviment és `transform.position` directe (sense física/obstacles complexos) per garantir que arribi al destí.
- **[Risk] Jugador no pot agafar la bandera mentre fuig**: 
    - **Mitigation**: El collider es desactiva quan el jugador la porta, però s'ha d'assegurar que estigui actiu mentre fuig perquè algú pugui interceptar-la. Segons el requeriment, el collider s'activa en arribar al destí, però el disseny permet interceptar-la si s'actualitza la lògica a `Player.cs`.
