## Context

El sistema de combat a `MinijocUIManager.cs` necessita identificar quin dels dos jugadors és el que porta la bandera per assignar correctament els rols d'atacant i defensor. Aquesta informació resideix a la variable `banderaAgafada` de cada instància de `Player`.

## Goals / Non-Goals

**Goals:**
- Exposar la variable `banderaAgafada` perquè sigui accessible des d'altres classes.
- Resoldre l'error de compilació CS0122.

**Non-Goals:**
- Implementar un sistema de Getters/Setters complex (es prefereix accés directe per consistència amb altres variables del projecte).

## Decisions

- **Modificador Public**: Es canviarà el modificador de `private` a `public` directament. És la solució més ràpida i alineada amb l'estil actual del projecte on moltes variables d'estat són públiques per a la seva inspecció i manipulació des de gestors.

## Risks / Trade-offs

- **[Risc] Manipulació Externa No Desitjada** → Al ser pública, qualsevol script podria canviar el valor de `banderaAgafada`. *Mitigació*: Es mantindrà la disciplina de només llegir-la des del gestor, o escriure-la només quan sigui estrictament necessari (com ja es fa en el robatori).
