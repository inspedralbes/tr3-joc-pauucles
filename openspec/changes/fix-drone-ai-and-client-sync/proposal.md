## Why

Actualment, l'IA del dron experimenta crashejos silenciosos o es queda en estat IDLE a causa de referències nul·les en la recollida d'observacions (quan l'objectiu desapareix o no s'ha instanciat). A més, hi ha una ruptura en la sincronització visual, ja que els missatges de xarxa per als drons no es processen correctament al client o són bloquejats per l'absència del dron a la llista local de l'escena.

## What Changes

- **Blindatge de l'IA (DroneAI.cs)**:
    - Implementació de controls de nul·litat estrictes a `CollectObservations`.
    - Lògica de cerca activa: si la bandera a terra és nul·la, el dron buscarà quin jugador la té i n'observarà la posició.
    - Fallback a `Vector3.zero` per evitar errors `NullReferenceException`.
- **Correcció de Recepció al Client (MenuManager.cs)**:
    - Addició de logs de depuració per confirmar la recepció de `DRONE_MOVE`.
    - Garantia que el missatge es transmet al component `DroneNetworkSync` del dron corresponent.
- **Sincronització Visual (DroneNetworkSync.cs)**:
    - Assegurar que `ReceiveUpdate` emmagatzema correctament la posició de destinació.
    - Verificació que el `Lerp` visual es realitza sense interferències d'altres lògiques de moviment.

## Capabilities

### New Capabilities
- `drone-ai-robustness`: Capacitat d'autocorreció de la IA davant la pèrdua d'objectius físics a l'escena.
- `client-drone-sync-diagnostics`: Sistema de logs i verificació de flux per a la sincronització de drons en clients remots.

### Modified Capabilities
- Ninguna.

## Impact

- `Assets/Scripts/DroneAI.cs`: Canvi en la lògica de sensors.
- `Assets/Scripts/MenuManager.cs`: Canvi en el processament de paquets JSON.
- `Assets/Scripts/DroneNetworkSync.cs`: Canvi en la interpolació visual.
- `Assets/Scripts/GameManager.cs`: Verificació de la llista de drons actius.
