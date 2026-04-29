## Context

El fitxer `MinijocParellsSenarsLogic.cs` conté actualment una lògica de minijoc que inclou una "fase de revelació" de 3 segons. El requeriment de l'usuari demana una simplificació i restauració de la UI que elimini aquesta complexitat addicional, fent que el minijoc sigui més directe i immediat.

## Goals / Non-Goals

**Goals:**
- Implementar una generació d'operacions matemàtiques aleatòries (1-50).
- Assegurar que el temporitzador de 5 segons funciona correctament i actualitza la UI.
- Implementar la detecció de victòria/derrota immediata en prémer els botons o esgotar el temps.
- Integrar la comunicació amb el component `Player` local.

**Non-Goals:**
- Mantenir la fase de revelació de 3 segons (es descartarà per seguir les instruccions de l'usuari).
- Implementar sincronització de xarxa avançada (es prioritzarà la lògica local demanada).

## Decisions

- **Gestió de la UI**: S'utilitzarà `root.Q<Button>` i `root.Q<Label>` dins de `InicialitzarUI` (o similar) per obtenir les referències als elements de UI Toolkit.
- **Estat del Joc**: S'utilitzarà la variable `jocActiu` per controlar si l' `Update` ha de processar el temporitzador.
- **Tancament del Minijoc**: S'utilitzarà `gameObject.SetActive(false)` per tancar el minijoc immediatament després d'una acció final, d'acord amb les instruccions.
- **Referència al Jugador**: Es buscarà el component `Player` local per cridar els mètodes de resultat.

## Risks / Trade-offs

- **[Risc]**: Perdre la retroalimentació visual de per què s'ha perdut/guanyat en tancar la UI immediatament. → **[Mitigació]**: Seguir estrictament la petició de l'usuari ja que és un requeriment directe d'implementació.
- **[Risc]**: Conflictes amb referències de UI si el fitxer `.uxml` ha canviat. → **[Mitigació]**: Utilitzar noms de selectors estàndard (`BtnParells`, `BtnSenars`, `TextOperacio`, `TextTempsMates`).
