## Context

L'error CS0104 ocorre perquè tant el namespace `System` (que conté `Object`) com el namespace `UnityEngine` (que també conté `Object`) estan sent utilitzats alhora. El compilador no sap a quina classe `Object` ens referim quan fem `Object.FindFirstObjectByType`.

## Goals / Non-Goals

**Goals:**
- Qualificar explícitament les crides d'API d'Unity.
- Resoldre l'error d'ambigüitat en el fitxer `WebSocketClient.cs`.

**Non-Goals:**
- No es canviarà la lògica de seguiment o connexió.

## Decisions

- **Namespace explícit**: S'utilitzarà `UnityEngine.Object.FindFirstObjectByType` per sobre de l'eliminació del `using System;` per mantenir la compatibilitat amb mètodes del sistema com `Exception` o `Task`.

## Risks / Trade-offs

- **[Risc] Oblidar altres instàncies** → **Mitigació**: Es farà una cerca global d'instàncies de `Object.` que no estiguin precedides per `UnityEngine.`.
