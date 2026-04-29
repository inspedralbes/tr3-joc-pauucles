## Context

Es vol millorar el gameplay multijugador evitant que els jugadors derrotats bloquegin físicament els guanyadors (especialment quan aquests han de continuar la partida ràpidament). També cal assegurar que la bandera robada s'ajusti visualment al cos del guanyador i començar a preparar la interfície per a un nou minijoc d'habilitat.

## Goals / Non-Goals

**Goals:**
- Implementar un estat de "fantasma" (trigger) per als perdedors immobilitzats.
- Assegurar l'ajust visual de la bandera robada (`localPosition = Vector3.zero`).
- Implementar la infraestructura bàsica per al minijoc 3 (AturaBarra).

**Non-Goals:**
- Implementar la lògica de moviment de la barra en el minijoc 3 (només placeholder).
- Canviar el sistema de puntuació global.

## Decisions

- **Uso de isTrigger**: Per a l'efecte fantasma, s'utilitzarà la propietat `isTrigger` del `Collider2D` del jugador. Aquesta és la forma més directa a Unity per permetre el pas a través d'un objecte sense desactivar el seu script de col·lisió (necessari per detectar quan acaba el cooldown).
- **Magnetització de la Bandera**: En lloc de només canviar el parell, es forçarà la posició local a zero per evitar que la bandera quedi "flotant" lluny del jugador guanyador si la col·lisió va ocórrer a certa distància.
- **Estructura de Contenidors Expandible**: El `MinijocUIManager` seguirà el patró de contenidors actual, afegint `ContenidorAturaBarra` a la llista de neteja global.

## Risks / Trade-offs

- **[Risk] Jugador travessant el terra**: Si el collider del jugador és l'únic que evita que caigui pel terra i es posa en `isTrigger`, el jugador perdedor podria caure al buit. -> **[Mitigation]**: S'ha de verificar si el jugador té un collider separat per als peus o si la gravetat s'ha de desactivar temporalment juntament amb l'estat de trigger. Com que `isFrozen` ja atura el moviment, es revisarà si cal congelar el Rigidbody en Y.
