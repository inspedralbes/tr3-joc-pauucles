## Context

L'actual implementació del lobby pateix d'inconsistències visuals. El backend no notifica correctament tots els canvis d'estat de les sales (com quan algú marxa), i el frontend acumula elements en lloc de refrescar-los. A més, el disseny visual utilitza una alineació asimètrica que no s'adapta bé a diferents resolucions de pantalla.

## Goals / Non-Goals

**Goals:**
- Implementar un sistema de refresc de llistes robust (neteja + repintat).
- Assegurar la sincronització total de l'estat de la sala al backend.
- Millorar l'estètica i alineació de la UI mitjançant Flexbox (UI Toolkit).

**Non-Goals:**
- No es canviarà la lògica de combat o el sistema d'autenticació.
- No es tracta de fer un redisseny total, sinó un "poliment" de l'existent.

## Decisions

- **Estratègia de Neteja**: S'utilitzarà `llistaPartides.itemsSource = null` i `llistaPartides.Rebuild()` (o mètodes equivalents segons la implementació de `ListView`) a `MenuManager.cs`. Per a contenidors de tipus `VisualElement` que s'omplen manualment, s'aplicarà `.Clear()`.
- **Broadcast Reactiu**: El mètode `leave_room` al backend es modificarà per cridar a `broadcastToRoom()` després de treure el jugador de la llista de MongoDB, si la sala encara té participants.
- **Centrat Flexbox**: S'utilitzaran les propietats `justify-content: center` i `align-items: center` als contenidors pare de les pantalles al fitxer `.uss`. Això aprofita la potència de Flexbox integrada a UI Toolkit.
- **Tipografia i Colors**: S'estandarditzaran els marges a valors de `10px` o `15px` i s'utilitzaran colors contrastats (fons foscos, textos clars) per millorar la llegibilitat.

## Risks / Trade-offs

- **[Risc] Rendiment de llistes grans** → Si es neteja i es torna a instanciar tot en llistes molt llargues, hi podria haver un petit "parpelleig". → **[Mitigació]** Donat que el nombre de jugadors i sales és petit (màxim 4-8), l'impacte serà inapreciable.
- **[Risc] Estils trencats** → Canviar l'alineació podria moure botons fora de lloc si tenen posicions absolutes. → **[Mitigació]** Es revisarà que tots els elements utilitzin posicionament relatiu.
