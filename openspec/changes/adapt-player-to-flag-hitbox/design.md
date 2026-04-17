## Context

L'usuari ha introduït una "Hitbox" a la bandera, que és un objecte fill amb un collider Trigger i el tag "Bandera". Això trenca la detecció actual a `Player.cs` que assumia que el collider estava al mateix objecte que el component `Bandera`. A més, cal ignorar les col·lisions amb tots els colliders de la bandera (el principal i el de la hitbox) per evitar empentes físiques no desitjades.

## Goals / Non-Goals

**Goals:**
- Adaptar `OnTriggerEnter2D` per detectar correctament el component `Bandera` des d'un fill.
- Ignorar col·lisions de manera exhaustiva en tots els fills del Dino.
- Mantenir el Dino com un objecte `Dynamic` i sense parentiu.

**Non-Goals:**
- No es modificarà la lògica interna de l'script `Bandera.cs`.

## Decisions

- **Ús de `GetComponentInParent<Bandera>()`**: Permet trobar el component de control encara que el Trigger sigui un fill.
- **Bucle `GetComponentsInChildren<Collider2D>()`**: Assegura que tant el collider físic com el de detecció siguin ignorats pel jugador, evitant conflictes de física.
- **Manteniment del mode `Dynamic`**: Essencial per a la detecció de terra implementada anteriorment.

## Risks / Trade-offs

- **[Risc] Ignorar col·lisions massa àmpliament** → **Mitigació**: Només s'aplica IgnoreCollision entre el jugador actual i la bandera recollida, el que és el comportament esperat.
