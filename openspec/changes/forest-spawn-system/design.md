## Context

A l'escena 'Bosque', els personatges es carreguen a la seva posició de prefab per defecte. Això trenca la immersió i l'estratègia de joc per equips. S'ha de garantir que cada equip tingui una zona de sortida diferenciada.

## Goals / Non-Goals

**Goals:**
- Crear un `GameManager` que s'encarregui de la configuració inicial de l'escena.
- Moure el jugador al spawn corresponent immediatament al carregar l'escena.
- Suportar múltiples punts de spawn per equip per evitar apilaments.

**Non-Goals:**
- No es tracta d'un sistema de spawn en temps real (respawn post-mort), només d'inici de partida.
- No es modificarà la interfície d'usuari HUD en aquest canvi.

## Decisions

- **Identificació de punts**: S'utilitzarà `GameObject.FindObjectsOfType<Transform>()` i es filtrarà pel nom de l'objecte pare o contenidor (ex: buscar fills d'un objecte anomenat "Spawns_Equip1"). Alternativament, es poden buscar objectes individuals que comencin per "SpawnEquipX". S'ha decidit buscar per nom de GameObject per evitar dependències de Tags que poden no estar configurats.
- **Accés a dades**: S'accedirà a `WebSocketClient.Team` que és una variable estàtica ja existent que guarda la informació rebuda del servidor durant la fase de lobby.
- **Posicionament**: El moviment es farà mitjançant `transform.position`. Si el jugador té un `Rigidbody2D`, s'ha de considerar fer el canvi al `Start` abans de les simulacions físiques pesades per evitar conflictes de col·lisions immediates.

## Risks / Trade-offs

- **[Risc] No es troben punts de spawn** → **[Mitigació]** El `GameManager` mostrarà un Error al log i deixarà el jugador a la posició per defecte (fallback).
- **[Risc] L'escena es carrega abans que les dades de WebSocket estiguin llestes** → **[Mitigació]** Donat que el canvi d'escena el dispara el propi `WebSocketClient` un cop rep la confirmació, les dades haurien de ser-hi. S'afegirà una validació de nul·litat.
- **[Trade-off] Cerca per nom** → És més lent que les referències directes a l'inspector, però permet que els dissenyadors de nivells afegeixin o treguin punts sense haver d'actualitzar el script `GameManager`.
