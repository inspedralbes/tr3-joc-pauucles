## Context

L'arquitectura actual de minijocs a "Atrapa la bandera" utilitza un `MinijocUIManager` que activa i desactiva contenidors de UI Toolkit basats en una selecció aleatòria (ruleta). El nou minijoc "Cable Pelat" requereix una interacció basada en la posició del punter (ratolí/tíctil) respecte a elements visuals específics.

## Goals / Non-Goals

**Goals:**
- Crear una lògica de minijoc desacoblada que gestioni l'estat d'inici, perill i meta.
- Implementar la detecció de "col·lisió" mitjançant els esdeveniments de punter de UI Toolkit.
- Integrar el minijoc en el flux de combat existent a `MinijocUIManager`.

**Non-Goals:**
- Modificar el sistema de xarxa o el servidor.
- Implementar animacions complexes en aquesta fase.

## Decisions

- **Detecció per Esdeveniments**: S'utilitzaran `PointerEnterEvent` en lloc d'un bucle `Update` per minimitzar el cost computacional i aprofitar les capacitats natives de UI Toolkit.
- **Estat de Control (`enCurs`)**: S'implementa una variable de control per evitar que el jugador guanyi o perdi per accident sense haver iniciat el recorregut oficialment a la `#ZonaInici`.
- **Integració al Switch**: S'assigna el `case 6` al `MinijocUIManager` seguint l'ordre d'altres minijocs ja implementats.

## Risks / Trade-offs

- **[Risc] Velocitat del punter**: Si el jugador mou el ratolí molt ràpidament, podria "saltar-se" la detecció d'una zona petita. 
  - **[Mitigació]**: Es recomana que el disseny UXML de `#FonsPerill` sigui prou gran i que les zones de control tinguin dimensions generoses.
- **[Trade-off] Multi-plataforma**: `PointerEnterEvent` és compatible tant amb ratolí com amb pantalles tàctils, cosa que facilita la portabilitat.
