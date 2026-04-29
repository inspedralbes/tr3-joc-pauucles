## Why

Actualment, el joc presenta problemes de sincronització on els jugadors i drons poden no aparèixer per a nous clients que s'uneixen a la partida o quan hi ha pèrdua de paquets. A més, la IA del dron no detecta correctament qui porta el dinosaure, el que limita la seva eficàcia. Aquest canvi assegura una experiència multijugador robusta i una IA més intel·ligent.

## What Changes

- **Sincronització de Jugadors**: 
    - Implementació de throttling (0.1s) en `NetworkSync.cs` per a l'enviament de `PLAYER_MOVE`.
    - Lògica de "Forced Spawn" a `MenuManager.cs`: si es rep un moviment d'un jugador desconegut, s'instancia automàticament.
- **IA del Dron**:
    - Actualització de `CollectObservations` a `DroneAI.cs` per buscar activament el jugador que porta la bandera/dinosaure i passar la seva posició com a observació.
- **Sincronització de Drons**:
    - Implementació de "Forced Spawn" per a drons a `MenuManager.cs` quan es rep un `DRONE_MOVE` per a un dron no instanciat.

## Capabilities

### New Capabilities
- `forced-multiplayer-spawn`: Capacitat de gestionar la instanciació dinàmica d'entitats (jugadors i drons) basada en missatges de xarxa.
- `targeted-drone-observations`: Millora de les observacions de la IA per enfocar-se en l'objectiu que posseeix l'ítem clau.

### Modified Capabilities
- Ninguna.

## Impact

- `Assets/Scripts/NetworkSync.cs`: Throttling d'enviament.
- `Assets/Scripts/MenuManager.cs`: Lògica de spawn forçat.
- `Assets/Scripts/DroneAI.cs`: Millora en la recollida d'observacions.
- `Assets/Scripts/GameManager.cs`: Podria requerir mètodes d'instanciació accessibles per al spawn forçat.
