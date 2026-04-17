## Context

El lobby del joc necessita una forma robusta de refrescar la llista de sales disponibles. Tot i que existeix una actualització reactiva per WebSocket, el refresc manual via HTTP serveix com a mecanisme de recuperació (fallback) i assegura que l'usuari vegi l'estat real del servidor sota demanda.

## Goals / Non-Goals

**Goals:**
- Vincular un botó de refresc manual a la UI del lobby.
- Implementar la petició HTTP GET per obtenir les sales.
- Garantir que no hi hagi elements duplicats a la llista visual en refrescar.

**Non-Goals:**
- No es modificarà la lògica del servidor de backend.
- No es tractarà la lògica de creació de sales (només llistat).

## Decisions

- **Mecanisme de Refresc**: S'utilitzarà `UnityWebRequest.Get` per fer la petició a `/api/games/list`. Aquesta és una ruta estàndard de l'API de backend que retorna l'array de sales en estat 'waiting'.
- **Gestió de la UI**: Atès que s'utilitza `ListView` d'UI Toolkit a `MenuManager.cs`, el mètode `.Clear()` es referirà a la neteja de la font de dades o del contenidor abans d'assignar la nova llista. Es farà un èmfasi especial en buidar qualsevol referència prèvia abans de repintar per complir amb el requeriment d'evitar duplicats.
- **Async/Await vs Coroutines**: Es mantindrà el patró existent a `MenuManager.cs` (Coroutines) per a la consistència del codi.

## Risks / Trade-offs

- **[Risc] Duplicitat visual** → Si el `ListView` no es refresca correctament, podrien aparèixer sales velles. → **[Mitigació]** Ús del mètode `Rebuild()` i assegurar que la llista d'origen estigui neta abans de l'assignació.
