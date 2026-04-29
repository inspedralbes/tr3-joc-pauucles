## Context

L'script `Player.cs` gestiona el moviment, el salt i l'escalada del personatge, però no comunica aquests estats al component `Animator` de Unity. Això fa que el personatge es desplaci de forma estàtica sense animacions que acompanyin el moviment.

## Goals / Non-Goals

**Goals:**
- Integrar l'Animator en el flux de control del `Player.cs`.
- Mantenir el rendiment actual (actualitzacions d'Animator són lleugeres).
- Assegurar que el codi sigui robust davant la falta del component Animator.

**Non-Goals:**
- Crear les animacions o el Animator Controller (es dóna per fet que ja existeixen o es crearan a Unity).
- Refactoritzar el sistema de moviment actual.

## Decisions

- **Inicialització**: S'utilitzarà `GetComponent<Animator>()` en el `Start()` per obtenir la referència. Això és estàndard en Unity per a components interns.
- **Actualització a Update()**: S'ha triat `Update()` per a l'actualització de paràmetres visuals (animacions) ja que coincideix amb la freqüència de renderitzat i és on es recull l'input i s'actualitza la lògica visual.
- **Comprovació de nul·litat**: S'inclourà un check `if (anim != null)` abans de cada crida per evitar errors si el component no està present en el GameObject.

## Risks / Trade-offs

- **[Risk]** Si els noms dels paràmetres a Unity no coincideixen amb el codi (`yVelocity`, `isRunning`, `isGrounded`), les animacions no funcionaran. → **Mitigation**: Documentar clarament els requeriments de l'Animator Controller.
- **[Trade-off]** Actualitzar l'Animator a cada frame té un cost mínim de CPU, però és necessari per a una resposta visual immediata.
