## Context

La mascota actualment depèn exclusivament de la física de terra per seguir al jugador. En nivells amb moltes plataformes o canvis bruscos d'altura, la mascota sovint queda enrere. La introducció d'un mode de levitació permetrà una navegació més "màgica" i funcional.

## Goals / Non-Goals

**Goals:**
- Implementar el canvi d'estat Caminar -> Levitació basat en altura (Y > 2f) o bloqueig per mur.
- Utilitzar `Vector2.MoveTowards` durant la levitació per a un moviment directe i previsible.
- Assegurar el retorn a la gravetat normal només quan estigui a prop del jugador i sobre terra.

**Non-Goals:**
- No s'afegiran noves animacions de vol (s'utilitzarà la de córrer o una existent si n'hi ha).
- No es modificarà el sistema d'atac o col·lisió de la mascota.

## Decisions

- **Control de Gravetat**: S'utilitzarà `rb.gravityScale = 0` per simular el vol, ja que és més senzill que aplicar forces constants cap amunt i evita conflictes amb altres velocitats.
- **Detecció de Bloqueig**: Es reutilitzarà el Raycast frontal existent. Si el Raycast detecta un obstacle I no podem saltar-lo (perquè és massa alt), s'activarà el mode levitació.
- **Moviment en Levitació**: Es farà un override parcial de la velocitat del Rigidbody o s'utilitzarà `transform.position` amb `MoveTowards` per garantir que el Dino ignori els esglaons intermedis mentre vola.

## Risks / Trade-offs

- **[Risc] El Dino es queda levitant permanentment si no troba terra ferm a prop del jugador** → **Mitigació**: El criteri de "prop del jugador" ha de ser prou ampli per assegurar la transició un cop arribi al seu destí.
- **[Risc] Passar a través de parets durant la levitació** → **Mitigació**: La levitació hauria de respectar els colliders si s'usa `MovePosition` o simplement acceptar que el Dino "vola" per sobre de tot per evitar bloquejos.
