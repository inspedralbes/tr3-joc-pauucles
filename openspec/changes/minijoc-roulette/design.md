## Context

El sistema de combat actual és molt limitat ja que només ofereix un minijoc. Es vol expandir la varietat del joc implementant una "ruleta" que seleccioni un minijoc entre 6 possibles opcions quan dos jugadors col·lideixen.

## Goals / Non-Goals

**Goals:**
- Implementar una selecció aleatòria d'un sencer (1-6) en el moment de la col·lisió.
- Estructurar el codi de `MinijocUIManager.cs` per gestionar diferents minijocs.
- Mantenir la funcionalitat completa del minijoc PPTLLS (ID 1).
- Proporcionar un mecanisme temporal (fallback) per als minijocs encara no implementats (IDs 2-6) que eviti bloquejos.

**Non-Goals:**
- Implementar la UI o la lògica específica dels minijocs 2-6 en aquest canvi.
- Modificar el sistema de col·lisions base.

## Decisions

- **Estructura Switch**: S'utilitzarà una estructura `switch` en `MinijocUIManager.cs` per delegar la inicialització i gestió a cada minijoc específic segons el seu ID. Aquesta estructura és fàcil d'expandir a mesura que s'afegeixin nous minijocs.
- **Resolució Forçada per Empat**: Per als minijocs no implementats, s'ha decidit resoldre el combat com un empat. Això permet que els jugadors continuïn la partida sense quedar bloquejats (ja que se'ls torna a posar `potMoure = true`).
- **Noms dels Minijocs**: Es definirà un array o diccionari amb els noms dels minijocs per als logs de depuració.

## Risks / Trade-offs

- **[Risk] Confusió del jugador**: El jugador pot quedar confós si de sobte se li tanca la UI sense jugar. → **[Mitigation]**: El `Debug.Log` ajudarà als desenvolupadors a veure què està passant, i s'assumeix que aquest és un estat temporal de desenvolupament. En el futur, cada cas del switch tindrà la seva pròpia UI.
