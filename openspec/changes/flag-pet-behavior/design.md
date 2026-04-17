## Context

Actualment la bandera s'acobla al jugador mitjançant `transform.SetParent`, el que hereta totes les transformacions del jugador de manera rígida. Volem passar a un sistema de seguiment desacoblat on la bandera tingui la seva pròpia lògica de moviment i animació.

## Goals / Non-Goals

**Goals:**
- Desacoblar la bandera del transform del jugador.
- Implementar un seguiment fluid basat en física (`Rigidbody2D`).
- Automatitzar les animacions de la mascota basant-se en el seu estat de moviment.
- Implementar el gir visual (Flip) automàtic.

**Non-Goals:**
- No es canviarà el sistema de detecció de col·lisions per agafar la bandera.
- No s'afegiran noves habilitats de combat a la mascota en aquest canvi.

## Decisions

- **Ús de `Vector2.SmoothDamp`**: S'ha triat per sobre de `Vector2.MoveTowards` o `Lerp` perquè proporciona una acceleració i desacceleració natural, ideal per a un comportament de seguiment de mascota.
- **Mantenir `Rigidbody2D` en mode `Dynamic` o `Kinematic`?**: Es mantindrà segons la configuració actual però s'assegurarà que pugui moure's lliurement (sense ser fill del jugador). Si estava en `Static` per ser agafada, ara ha de ser capaç de moure's.
- **Lògica de plor (`isSad`)**: Es basarà en si l'objectiu (`targetSeguiment`) és nul o si el propi Dino porta un temps sense moure's significativament malgrat tenir un target.

## Risks / Trade-offs

- **[Risc] La bandera pot quedar-se atrapada darrere d'obstacles** → **Mitigació**: El seguiment es farà cap a una posició relativa al jugador. Si la bandera té col·lisions, podria bloquejar-se; caldrà verificar si el Prefab té `Collider2D` i si aquest hauria de ser `Trigger` durant el seguiment.
- **[Risc] Moviment espasmòdic si el SmoothDamp no està ben configurat** → **Mitigació**: Ajustar el `smoothTime` (velocitat de seguiment) per trobar l'equilibri entre resposta ràpida i fluïdesa.
