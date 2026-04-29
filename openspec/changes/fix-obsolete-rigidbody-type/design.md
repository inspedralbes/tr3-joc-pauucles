## Context

Unity ha evolucionat la seva API de físiques per a 2D, movent el control del tipus de cos de `Rigidbody2D` des d'un simple booleà `isKinematic` a un sistema d'enumeració més complet anomenat `bodyType`. L'ús continuat de `isKinematic` genera advertències CS0618 que s'han de resoldre per complir amb els estàndards de qualitat del projecte.

## Goals / Non-Goals

**Goals:**
- Eliminar tots els avisos CS0618 relacionats amb `Rigidbody2D.isKinematic`.
- Migrar a l'API `bodyType` a tots els scripts del projecte.

**Non-Goals:**
- Canviar el comportament físic del joc (la migració ha de ser transparent a nivell de gameplay).

## Decisions

- **Ús de bodyType**: Es realitzarà una substitució directa de `isKinematic = true` per `bodyType = RigidbodyType2D.Kinematic` i `isKinematic = false` per `bodyType = RigidbodyType2D.Dynamic`. Aquesta és la forma oficial recomanada per la documentació de Unity per resoldre l'obsolescència.
- **Enumeració RigidbodyType2D**: S'assegurarà que el namespace `UnityEngine` està present per accedir a l'enumeració correctament.

## Risks / Trade-offs

- **[Risk] Canvis en el comportament de col·lisió**: Tot i que oficialment són equivalents, el pas de Kinematic a Dynamic pot tenir lleugeres diferències en la integració de forces si no es gestiona bé el moment del canvi. -> **[Mitigation]**: S'ha de garantir que la velocitat es reseteja correctament en els punts crítics (com s'ha fet en canvis anteriors).
