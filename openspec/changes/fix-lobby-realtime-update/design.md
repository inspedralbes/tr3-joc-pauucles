## Context

L'arquitectura actual ja disposa d'un servidor WebSocket (`wss`) injectat al `GameController.js`. Existeix un mètode `broadcastRoomUpdates()` que envia el llistat de sales a tots els clients connectats. Tot i això, aquest mètode ja s'està cridant en la creació i unió de sales. El problema detectat és que Unity espera un tipus de missatge específic o bé la sincronització no s'està disparant correctament en el flux de treball real.

## Goals / Non-Goals

**Goals:**
- Assegurar que la creació d'una sala invoqui l'actualització global.
- Garantir que el payload del missatge coincideixi amb el que el client d'Unity espera per repintar la llista.

**Non-Goals:**
- No es modificarà la base de dades MongoDB.
- No es canviarà el protocol de comunicació (es manté WebSocket pur).

## Decisions

- **Reutilització de `broadcastRoomUpdates`**: S'ha verificat que el mètode ja existeix i envia un missatge de tipus `room_list`. Es mantindrà aquesta nomenclatura per coherència amb el frontend.
- **Tipus de Missatge**: Tot i que la petició demanava `ACTUALITZAR_SALES`, el codi actual de Unity i el backend utilitzen `room_list`. Es mantindrà `room_list` al codi però s'assegurarà que el disparador (trigger) sigui immediatament posterior a l'escriptura a la BD.
- **Optimització de Cerca**: El mètode `listWaitingGames()` del `GameService` s'assegurarà de retornar només sales amb l'status `waiting`.

## Risks / Trade-offs

- **[Risc] Sobrecàrrega del servidor** → Si hi ha molts jugadors creant sales simultàniament, el broadcast massiu pot consumir amplada de banda. → **[Mitigació]** El payload és petit (només dades resumides de les sales waiting).
- **[Risc] Desconnexió de clients** → Els clients que perdin la connexió no rebran el broadcast. → **[Mitigació]** El client de Unity ha de tenir un mecanisme de reconnexió o refresc manual (no inclòs en aquest canvi específic).
