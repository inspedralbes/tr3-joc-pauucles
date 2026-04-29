## Context

Actualment, `MenuManager.cs` utilitza `NativeWebSocket` per a la comunicació en temps real. Els callbacks d'aquesta llibreria s'invoquen des d'un fil secundari per evitar bloquejar el fil de renderitzat de Unity. Això però causa problemes en intentar utilitzar funcions de Unity que no són "thread-safe".

## Goals / Non-Goals

**Goals:**
- Implementar un patró de disseny "Thread Dispatcher" dins de `MenuManager.cs`.
- Assegurar que qualsevol acció que interactuï amb Unity des d'un callback de WebSocket s'executi en el fil principal.

**Non-Goals:**
- No es pretén crear un gestor de fils global per a tot el projecte, només solucionar el problema immediat a `MenuManager.cs`.

## Decisions

- **Cua d'Accions amb Bloqueig (`Queue<Action>` + `lock`)**: S'utilitza una cua estàndard de C# i l'operació `lock` per garantir que l'accés a la cua des de diferents fils no causi corrupció de dades. És una solució senzilla i efectiva per a aquest cas d'ús.
- **Bucle d'Execució a `Update`**: El mètode `Update` de Unity s'executa sempre al fil principal. Procesar la cua en aquest mètode garanteix que les accions s'executin correctament.

## Risks / Trade-offs

- **[Risk] Latència en l'execució d'accions** → **Mitigation**: Com que el `Update` s'executa aproximadament 60 vegades per segon, la latència afegida serà de mil·lisegons, imperceptible per a l'usuari.
- **[Trade-off] Bloqueig de la cua** → **Mitigation**: El temps de bloqueig amb `lock` per a les operacions d'encuar i desencuar és extremadament curt. No hi haurà impacte significatiu en el rendiment.

## Migration Plan

1. Definir la cua `_executionQueue` i el mètode `EnqueueMainThread`.
2. Actualitzar `Update` per consumir la cua després de cridar a `websocket.DispatchMessageQueue()`.
3. Revisar i actualitzar tots els esdeveniments de `websocket` (`OnOpen`, `OnClose`, `OnError`, `OnMessage`).
