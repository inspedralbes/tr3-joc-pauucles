## Context

El component `MenuManager` gestiona la comunicació amb el backend per a la creació de partides. Actualment, falta la transició d'estat a la UI quan una partida es crea amb èxit.

## Goals / Non-Goals

**Goals:**
- Tancar el diàleg de creació de sala automàticament en rebre confirmació del servidor.
- Garantir que la llista de sales mostri la sala acabada de crear (o l'estat actual del servidor).
- Assegurar que `ObtenirPartides` és robust i neteja correctament la UI.

**Non-Goals:**
- Implementar redirecció automàtica a la partida (només feedback al lobby).
- Canviar el format de dades enviat al servidor.

## Decisions

- **Control de Flux a `EnviarPeticio`**: S'afegirà una condició específica per a l'endpoint `/games/create` dins del bloc d'èxit de la petició.
  - S'utilitzarà `popUpCrearSala.style.display = DisplayStyle.None;`.
  - Es cridarà `StartCoroutine(ObtenirPartides());`.
- **Neteja del ListView**: El component `ListView` d'Unity UI Toolkit gestiona la seva llista d'ítems mitjançant `itemsSource`. Simplement reassignant un nou array o llista, la UI es refresca. Cal assegurar que el wrapper JSON (`GameListWrapper`) s'inicialitza correctament encara que la llista vingui buida.

## Risks / Trade-offs

- **[Risc] Petició pendent**: Si `ObtenirPartides` triga massa, l'usuari podria pensar que no ha passat res.
  - **Mitigació**: El tancament del pop-up és immediat en rebre l'èxit, donant feedback instantani de que l'acció s'ha completat.
