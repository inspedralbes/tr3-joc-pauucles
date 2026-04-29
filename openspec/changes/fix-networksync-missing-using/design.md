## Context

Durant l'última refactorització de `NetworkSync.cs`, es van introduir referències a `WebSocketState`, però es va ometre l'import del namespace `NativeWebSocket`.

## Goals / Non-Goals

**Goals:**
- Afegir `using NativeWebSocket;` a `NetworkSync.cs`.
- Eliminar l'error CS0103.

**Non-Goals:**
- Modificar la lògica de moviment.
- Canviar el sistema de comunicació.

## Decisions

### 1. Inclusió de la directiva using
S'afegirà a la part superior de `NetworkSync.cs` juntament amb els altres imports.
- **Racional:** És la solució estàndard per a errors de tipus no trobat (missing namespace).

## Risks / Trade-offs

- Cap risc identificat per a aquest canvi puntual.
