## Context

L'ús d'eines de reinici automàtic com `nodemon` és útil per a la velocitat de desenvolupament, però en sistemes basats en estat (com els jocs amb WebSockets), els reinicis inesperats invaliden les sessions dels clients connectats (Unity).

## Goals / Non-Goals

**Goals:**
- Eliminar `nodemon` de l'script `dev`.
- Assegurar que el servidor es manté viu durant les proves integrades amb Unity.

**Non-Goals:**
- Eliminar la dependència `nodemon` del `package.json` (pot ser útil per a altres tasques).
- Configurar un sistema de *hot-reloading* més complex.

## Decisions

### 1. Substitució de nodemon per node
Es modificarà directament la cadena de text de l'script `dev`.
- **Racional:** És la forma més directa i senzilla de complir amb el requeriment sense afegir dependències noves.

## Risks / Trade-offs

- **[Trade-off]** Menys agilitat al backend: S'ha de reiniciar manualment per cada canvi de codi al servidor. -> **Mitigation:** El benefici en l'estabilitat de la connexió amb Unity compensa aquest inconvenient durant la fase final d'integració.
