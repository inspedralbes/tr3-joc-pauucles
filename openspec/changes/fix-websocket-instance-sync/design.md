## Context

S'ha detectat una fragmentació en la gestió de WebSockets. `MenuManager` obre la connexió per al Lobby, però `NetworkSync` busca `WebSocketClient`, el qual té una instància buida o desconnectada en el flux real de joc.

## Goals / Non-Goals

**Goals:**
- Centralitzar la connexió a `MenuManager`.
- Garantir que el WebSocket no es tanca en carregar el nivell de joc.
- Establir un patró de disseny Singleton robust.

**Non-Goals:**
- Canviar la llibreria de WebSockets (`NativeWebSocket`).
- Implementar un sistema de reconnexió complex (per ara es busca estabilitat).

## Decisions

### 1. Singleton MenuManager amb DontDestroyOnLoad
Es modificarà `Awake` per assegurar que només existeixi una instància i que aquesta sobrevisqui al canvi d'escena.
- **Racional:** Evita la reinicialització del WebSocket i manté l'estat del socket actiu durant tota la sessió.

### 2. Accés públic al WebSocket
La variable `websocket` passarà de privada a pública.
- **Racional:** Permet una comunicació "fire and forget" des de qualsevol punt del codi (com el loop de moviment).

### 3. Centralització del Processament de Missatges
Tota la lògica de recepció (incloent `PARTIDA_INICIADA` i `PLAYER_MOVE`) es gestionarà a `MenuManager.AlRebreActualitzacioSales` (o un mètode equivalent reanomenat).

## Risks / Trade-offs

- **[Risk]** Si `MenuManager` depèn de referències d'UI que ja no existeixen a l'escena "Bosque", el codi podria fallar. -> **Mitigation:** S'afegiran comprovacions de nul·litat (`null-checks`) abans d'accedir a qualsevol VisualElement.
- **[Trade-off]** `MenuManager` ara té més responsabilitats de les que el seu nom indica. -> **Mitigation:** En un futur es podria reanomenar a `NetworkManager`, però per ara mantenim el nom per minimitzar canvis disruptius.
