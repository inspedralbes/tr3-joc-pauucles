## Context

L'arquitectura actual utilitza `NativeWebSocket` per a la comunicació asíncrona. Tot i que `MenuManager.cs` disposa d'un mètode `EnqueueMainThread`, algunes actualitzacions visualitzades podrien estar fallant perquè el mètode `Rebuild()` de les `ListView` no s'està cridant en el moment adequat o perquè les referències de la UI es tornen obsoletes després d'una desconnexió parcial. També s'ha detectat redundància entre `MenuManager` i `WebSocketClient`.

## Goals / Non-Goals

**Goals:**
- Garantir que el Lobby és 100% reactiu a esdeveniments externs.
- Eliminar bloquejos visuals causats per l'accés a la UI des de fils secundaris.
- Refrescar tant la llista global de partides com la llista interna de jugadors de la sala d'espera.

**Non-Goals:**
- Implementar un sistema complet de reconnexió (es farà en un futur canvi).
- Refer el disseny UXML de les llistes.

## Decisions

### 1. Ús sistemàtic del Dispatcher (EnqueueMainThread)
Tota la lògica continguda a `AlRebreActualitzacioSales` (a `MenuManager.cs`) s'ha de revisar per assegurar que qualsevol accés a VisualElements (labels, llistes, botons) estigui dins de `EnqueueMainThread(() => { ... })`.
- **Racional**: Unity UI Toolkit no és thread-safe. Un intent d'accés des del fil del WebSocket provoca fallades silencioses.

### 2. Refresc forçat de ListView
A les funcions `ConfigurarLlistaPartides` i `OmplirLlistaJugadors`, s'ha d'assignar la nova `itemsSource` i cridar immediatament a `Rebuild()` dins del fil principal.
- **Racional**: Assignar la font de dades no sempre activa el repintat automàtic si la referència de l'array no ha canviat prou per als observadors d'Unity.

### 3. Gestió de missatges JSON
Es millorarà el parseig de JSON per gestionar els tipus `ACTUALITZAR_SALES` i `ROOM_UPDATED` de forma robusta, assegurant que els IDs de sala coincideixin abans d'actualitzar la sala d'espera.

## Risks / Trade-offs

- **[Risk]** Alta freqüència de missatges podria saturar la cua del fil principal. -> **Mitigation**: Els missatges de lobby són poc freqüents (unions/sortides/creacions); el risc és baix.
- **[Trade-off]** Consolidar la lògica pot requerir canvis en `WebSocketClient.cs`, el que podria afectar temporalment la lògica de moviment si no es fa amb cura.
