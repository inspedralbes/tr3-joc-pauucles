## Context

El sistema actual de drons pateix de dos problemes crítics:
1. **Crash de l'IA**: El mètode `CollectObservations` a `DroneAI.cs` assumeix que els objectius físics (prefabs de banderes o dinosaures) sempre estan presents a l'escena. Quan un jugador agafa un d'aquests objectius, l'objecte original pot ser desactivat o destruït, provocant un error de referència nul·la que atura l'execució de l'agent.
2. **Fallada de Sincronització**: Els clients remots sovint no veuen el moviment dels drons perquè el flux de dades des del `MenuManager.cs` fins al `DroneNetworkSync.cs` es perd o no s'informa de la seva recepció, dificultant la depuració.

## Goals / Non-Goals

**Goals:**
- Implementar una recollida d'observacions "a prova de fallades" a `DroneAI.cs`.
- Millorar la visibilitat de la recepció de paquets de drones al client.
- Assegurar la interpolació de moviment visual en drons remots.

**Non-Goals:**
- Refactoritzar el sistema de ML-Agents.
- Canviar la lògica de joc de les banderes.

## Decisions

### 1. Observacions Dinàmiques (DroneAI.cs)
**Decisió**: Si la referència a la bandera a terra és `null`, s'iterarà sobre els jugadors actius per trobar qui té la propietat `banderaAgafada` o similar.
**Raonament**: Això garanteix que l'IA sempre tingui una coordenada de destinació vàlida (la posició del jugador que té l'objectiu) o un fallback segur, evitant el crasheig del procés de ML-Agents.

### 2. Flux de Xarxa Diagnòstic (MenuManager.cs)
**Decisió**: Afegir un log explícit `[CLIENT-DRONE-RECV]` en rebre `DRONE_MOVE`.
**Raonament**: Permet confirmar si el problema és de xarxa (el missatge no arriba) o d'aplicació (el missatge arriba però no s'aplica al dron).

### 3. Interpolació de Moviment (DroneNetworkSync.cs)
**Decisió**: Garantir que el mètode `Update` executi `Vector3.Lerp(transform.position, targetPosition, interpolationSpeed * Time.deltaTime)` quan `isRemote` és cert.
**Raonament**: Assegura que el client vegi un moviment fluid cap a l'última posició coneguda, eliminant els salts o el bloqueig del moviment visual.

## Risks / Trade-offs

- **[Risc] Sobrecàrrega de logs** → **Mitigació**: Els logs de xarxa de drones s'activaran cada 300 frames o només en canvis significatius per no saturar la consola de Unity.
- **[Risc] Rendiment de cerca activa** → **Mitigació**: La cerca de jugadors amb la bandera es realitzarà només si la referència directa a l'objecte falla.
