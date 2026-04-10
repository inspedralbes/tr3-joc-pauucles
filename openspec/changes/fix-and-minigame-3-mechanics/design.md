## Context

S'ha detectat un error de compilació a `MinijocUIManager.cs` degut a una mala construcció d'un string interpolat. Paral·lelament, es vol evolucionar el minijoc AturaBarra d'un sistema de puntuació abstracte a un sistema de precisió visual basat en una zona objectiu que apareix aleatòriament a cada enfrontament.

## Goals / Non-Goals

**Goals:**
- Arreclar l'error de sintaxi CS8076/CS1002.
- Implementar la càrrega i posicionament aleatori de `ZonaObjectiu`.
- Implementar la lògica de detecció de col·lisió visual entre `Fletxa` i `ZonaObjectiu`.
- Integrar la resolució amb el sistema de feedback de 2.5 segons.

**Non-Goals:**
- Implementar dificultats variables (més velocitat o zones més petites) en aquest canvi.
- Canviar l'estètica dels elements de la UI.

## Decisions

- **Correcció de l'String Interpolat**: S'assegurarà que les expressions dins de `{}` estiguin ben tancades i que el punt i coma final estigui fora de les cometes si és part de la sentència.
- **Càlcul de Rang de la Zona**: En lloc de puntuacions, es farà un check de `fletxaPos >= zonaLeft && fletxaPos <= (zonaLeft + zonaWidth)`. Això és molt més intuïtiu visualment per al jugador.
- **Amplada de la Zona**: S'utilitzarà el valor de `resolvedStyle.width` si és possible, o un valor per defecte constant si l'UI encara no s'ha renderitzat (encara que en el `ShowUI` ja hauria d'estar disponible).
- **Consistència en la Resolució**: Es mantindrà l'ús de la corrutina `MostrarResultatIEsperar` per garantir que el jugador veu el missatge de "DINS" o "FORA" abans que la UI desaparegui.

## Risks / Trade-offs

- **[Risk] Zona fora de límits**: Si es posa el left a 400 i la zona fa 100, podria sobresortir. -> **[Mitigation]**: El rang de random s'ha calculat (10-400) assumint una amplada total de la barra de ~500px i una zona de ~50-80px.
- **[Risk] Queries fallides**: Si `ZonaObjectiu` no està al fitxer UXML. -> **[Mitigation]**: S'afegirà un null-check i un log d'error clar.
