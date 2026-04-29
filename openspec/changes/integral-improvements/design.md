## Context

El projecte necessita una millora en la claredat dels resultats dels combats i en la fluïdesa del moviment post-combat. S'ha identificat que el tancament immediat de la UI confon als jugadors, i que els obstacles físics (jugadors derrotats) dificulten el progrés del guanyador. A més, el minijoc AturaBarra requereix una implementació interactiva que superi el placeholder de puntuacions aleatòries pur.

## Goals / Non-Goals

**Goals:**
- Implementar efectes visuals i físics per millorar el flux de joc (Fantasma i Imant).
- Proporcionar feedback textual clar sobre els resultats del combat.
- Afegir una pausa deliberada abans de tancar la UI per claredat.
- Implementar la interactivitat del minijoc AturaBarra usant Ping-Pong i proximitat al centre.

**Non-Goals:**
- Implementar animacions complexes de personatges o UI.
- Modificar el sistema de xarxa o de puntuació global de la partida.

## Decisions

- **Estat de Trigger per al Perdedor**: S'ha triat canviar `isTrigger` a true perquè permet que altres jugadors travessin el personatge sense desactivar completament les col·lisions (permetent encara altres interaccions si calgués).
- **Magnetització Instantània**: Posar `localPosition = Vector3.zero` assegura que la bandera estigui perfectament centrada en el nou propietari, evitant offsets estranys que podrien ocórrer si la col·lisió va ser lateral.
- **Retard en la Resolució**: S'utilitzarà una corrutina centralitzada a `MinijocUIManager` per gestionar el flux: Mostrar Resultat -> Esperar -> HideUI -> Aplicar Premis. Això assegura que el jugador local sempre sàpiga què ha passat.
- **Mathf.PingPong per a AturaBarra**: Aquesta funció de Unity és ideal per moure un valor entre dos límits de forma cíclica, simplificant el codi de moviment de la fletxa en l'Update.
- **Càlcul de Puntuació**: Es basarà en `Mathf.Abs(fletxaPos - 250)`, on un valor menor implica una puntuació major.

## Risks / Trade-offs

- **[Risk] UI Bloquejada**: Si la corrutina de retard falla o es cancel·la malament, la UI podria quedar-se oberta bloquejant el joc. -> **[Mitigation]**: S'assegurarà que el mètode `HideUI` sigui robust i que la corrutina estigui ben gestionada pel cicle de vida del GameObject.
- **[Risk] Travessar el terra**: En posar el collider com a trigger, el jugador podria caure pel terra. -> **[Mitigation]**: S'ha de verificar si el jugador té un Rigidbody cinemàtic o si la gravetat s'ha de desactivar temporalment mentre és fantasma. Com que `isFrozen` ja atura el moviment, el risc és menor si el personatge no té gravetat activa en aquell moment.
