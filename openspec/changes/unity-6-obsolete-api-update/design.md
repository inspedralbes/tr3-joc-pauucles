## Context

Unity ha introduït `FindFirstObjectByType<T>()` i `FindAnyObjectByType<T>()` com a substituts de `FindObjectOfType<T>()`. El primer és funcionalment equivalent a la cerca clàssica però amb un nom més explícit sobre quin objecte retorna si n'hi ha múltiples.

## Goals / Non-Goals

**Goals:**
- Substituir totes les crides de cerca d'objectes únics a `WebSocketClient.cs` i `MenuManager.cs`.
- Eliminar el warning CS0618.

**Non-Goals:**
- No es canviarà la lògica de negoci dels scripts, només l'API de cerca d'Unity.

## Decisions

- **Ús de `FindFirstObjectByType`**: S'ha triat aquesta versió en lloc de `FindAnyObjectByType` perquè és la que garanteix un comportament determinista (retorna el primer objecte trobat segons l'ordre de l'escena), mantenint la coherència amb el funcionament anterior de `FindObjectOfType`.

## Risks / Trade-offs

- **[Risc] Incompatibilitat amb versions molt antigues d'Unity** → **Mitigació**: Aquest projecte ja està orientat a versions recents que suporten aquesta API (2021.3.18+ / 2022.2+ / Unity 6).
