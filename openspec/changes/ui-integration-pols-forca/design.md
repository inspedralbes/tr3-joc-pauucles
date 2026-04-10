## Context

Actualment tenim la lògica del minijoc de pols de força en un script separat, però encara no està connectada visualment amb el document UXML que gestiona la interfície d'usuari (`PantallaMinijoc.uxml`). Cal fer que la lògica actualitzi els elements visuals durant el joc.

## Goals / Non-Goals

**Goals:**
- Vincular els elements visuals `TextTempsPols` i `BarraJ1Pols` a la lògica.
- Actualitzar el text del temps amb format d'un decimal ("F1").
- Actualitzar l'amplada de la barra del Jugador 1 basant-se en el percentatge de la seva puntuació.
- Integrar la crida des de `MinijocUIManager.cs` per activar el minijoc correctament.

**Non-Goals:**
- Crear nous fitxers UXML o USS (s'utilitzen els IDs existents).
- Canviar la mecànica interna de puntuació.

## Decisions

- **Injecció d'UI via Mètode**: S'ha triat passar el `VisualElement` arrel (`root`) al mètode `InicialitzarUI` per mantenir l'script modular i fàcil de cridar des d'un gestor central.
- **Consultes per ID**: S'utilitzarà `root.Q<T>(id)` per localitzar els elements visuals dinàmicament en el moment de la inicialització.
- **Actualització en Update**: Es realitzarà l'actualització de l'UI a l'`Update` només quan `jocActiu` sigui cert, assegurant un feedback fluid de 60 FPS o més.
- **Gestió de la Ruleta**: A `MinijocUIManager`, s'afegirà un cas especial per activar el contenidor del pols de força, amagant la resta per evitar solapaments visuals.

## Risks / Trade-offs

- **[Risc] IDs de UI Inexistents** → Si els IDs `TextTempsPols` o `BarraJ1Pols` no existeixen al UXML, el joc podria fallar. *Mitigació*: S'afegiran comprovacions de nul·litat (`if (textTemps != null)`) abans d'accedir a les propietats.
- **[Trade-off] Dependència de MinijocUIManager** → El minijoc depèn que un tercer el "desperti" i li passi l'UI. *Mitigació*: Aquesta és l'arquitectura triada per al projecte per centralitzar la gestió de pantalles.
