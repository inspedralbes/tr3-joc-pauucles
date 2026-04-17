## Context

El sistema actual de seguiment de la bandera té problemes de fluïdesa i no permet que la mascota interactuï correctament amb l'entorn (salts). A més, hi ha codi de gestió AFK a `Player.cs` que interfereix amb l'estètica visual del personatge.

## Goals / Non-Goals

**Goals:**
- Substituir `SmoothDamp` (posició) per moviment basat en velocitat (`Rigidbody2D.linearVelocity`).
- Implementar un sistema de detecció d'obstacles mitjançant Raycasts.
- Netejar el codi de `Player.cs` de funcionalitats AFK i escalat forçat.

**Non-Goals:**
- No es modificarà el sistema de combat.
- No s'afegiran estats complexos d'IA (patrulla, etc.).

## Decisions

- **Moviment Horitzontal**: En lloc de suavitzar la posició, s'assignarà directament la velocitat X al `Rigidbody2D` si es supera la distància mínima. Això permet que la gravetat d'Unity gestioni les caigudes de manera natural.
- **Detecció de Terra**: S'utilitzarà un `OverlapBox` o `Raycast` a `Bandera.cs` per comprovar si el Dino està a terra abans de permetre un salt.
- **Detecció d'Obstacles**: S'utilitzarà `Physics2D.Raycast` en la direcció del moviment horitzontal. El raig serà curt (aprox. 0.5f - 1f) per detectar parets o el següent esgraó d'una escala.
- **Eliminació d'AFK**: Es suprimirà la variable `tempsInactiu` i el bloc de parpelleig per mantenir el color del Sprite consistent.

## Risks / Trade-offs

- **[Risc] El Dino pot saltar constantment davant d'una paret alta** → **Mitigació**: El Raycast ha de ser precís i només saltar si es mou cap a l'obstacle.
- **[Risc] Inestabilitat en les velocitats si es barregen forces i assignacions directes** → **Mitigació**: S'assignarà la velocitat directament: `rb.linearVelocity = new Vector2(targetXVel, rb.linearVelocity.y)`.
