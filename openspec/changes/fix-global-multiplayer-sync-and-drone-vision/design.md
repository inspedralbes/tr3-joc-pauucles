## Context

El sistema actual de xarxa confia en què tots els clients reben el missatge d'unió (`JOIN`) per instanciar els jugadors. Tanmateix, si un client s'uneix tard o hi ha pèrdua de paquets, les entitats (jugadors i drons) no s'instancien localment, tot i rebre missatges de moviment. Això provoca que les entitats siguin "invisibles". Pel que fa al dron, les seves observacions actualment són estàtiques, el que impedeix que la IA reaccioni al jugador que porta l'objectiu clau.

## Goals / Non-Goals

**Goals:**
- Implementar throttling d'enviament a 10Hz per a la posició del jugador.
- Garantir que qualsevol missatge de moviment (`PLAYER_MOVE`, `DRONE_MOVE`) provoqui la instanciació de l'entitat si aquesta no existeix.
- Dinamitzar les observacions del dron per detectar l'objectiu.

**Non-Goals:**
- Refactoritzar completament el sistema de xarxa.
- Implementar interpolació avançada d'estat (es manté el Lerp bàsic).

## Decisions

### 1. Throttling a NetworkSync.cs
S'afegirà un temporitzador (`lastSendTime`) i un interval (`sendInterval = 0.1f`) al mètode `Update` per limitar les crides a `SendPosition` quan s'actua com a Host/LocalPlayer.
Rationale: 10 enviaments per segon és l'estàndard per a jocs d'acció per mantenir el trànsit de xarxa baix sense sacrificar massa la fluïdesa.

### 2. Spawn Forçat a MenuManager.cs
En el mètode `AlRebreActualitzacioSales`, es modificarà el processament de `PLAYER_MOVE` i `DRONE_MOVE`.
- Per a `PLAYER_MOVE`: Si `GameManager.Instance.remotePlayers` no conté el `username`, es cridarà a `GameManager.Instance.AddRemotePlayer(moveMsg.username)`.
- Per a `DRONE_MOVE`: Si no es troba el dron pel `teamId`, s'instanciarà el prefab de dron corresponent.

### 3. Observacions Dinàmiques a DroneAI.cs
En `CollectObservations`, s'iterarà sobre els jugadors a l'escena (o s'utilitzarà una referència des de `GameManager`) per comprovar qui porta la bandera.
- Si s'utilitza la propietat `isCarryingDino` de `Player.cs`, el dron passarà aquesta posició al sensor.

## Risks / Trade-offs

- **[Risc] Instanciació múltiple**: Si no es controla bé el moment del spawn, es podrien crear duplicats. -> **Mitigació**: Comprovar sempre l'existència al diccionari/llista de `GameManager` abans d'instanciar.
- **[Risc] Rendiment**: Iterar sobre jugadors en cada frame d'observació. -> **Mitigació**: ML-Agents crida a `CollectObservations` segons el `Decision Period` (sol ser > 1 frame), i el nombre de jugadors és baix (màxim 4-8).
