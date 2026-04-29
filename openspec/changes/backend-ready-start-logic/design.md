## Context

El projecte requereix una transició fluida entre el lobby i la partida. Actualment, el servidor rep el missatge de "READY" però no actualitza l'estat global de la sala per disparar l'inici del joc. A més, l'escena 'Bosque' d'Unity espera dades de sessió (equip i color) que el servidor encara no envia de forma explícita al missatge d'inici.

## Goals / Non-Goals

**Goals:**
- Implementar la lògica completa de `isReady` al backend.
- Centralitzar la decisió d'inici de partida al servidor.
- Automatitzar l'assignació d'equips A/B en la petició `/join`.

**Non-Goals:**
- No es modificarà la interfície de Unity en aquest canvi.
- No es tractarà la lògica de combat (només l'inici).

## Decisions

- **Actualització de READY**: Es realitzarà directament al listener de WebSocket a `server.js` o delegant al `GameService`. S'ha decidit usar el `GameService` per mantenir la lògica de negoci fora del fitxer d'entrada del servidor.
- **Estat 'playing'**: Un cop s'identifica que `players.length === maxPlayers` i tots tenen `isReady === true`, l'estat de la sala canviarà a `playing` per evitar que nous jugadors intentin unir-se a una partida en curs.
- **Missatge PARTIDA_INICIADA**: Aquest missatge es farà per broadcast a tots els clients connectats a la sala. Inclourà les dades individuals perquè cada client pugui fer el `DontDestroyOnLoad` i la càrrega d'escena amb la informació correcta.
- **Lògica d'equips al Join**: Si `players.length === 1`, el sistema comprovarà l'equip del `players[0]`. Si és 'A', assignarà 'B' al nou jugador; si és 'B', assignarà 'A'.

## Risks / Trade-offs

- **[Risc] Sincronització de broadcasts** → El broadcast `PARTIDA_INICIADA` ha de ser l'últim missatge que rebin els jugadors al lobby. → **[Mitigació]** S'assegurarà que el canvi d'estat a la BD sigui previ a l'enviament del missatge per evitar inconsistències si algun client consulta la llista de sales al mateix microsegon.
- **[Risc] Inconsistència de noms d'equips** → Els clients d'Unity poden esperar "Rojo/Azul" i el servidor pot estar usant "A/B". → **[Mitigació]** S'utilitzaran els strings literals que ja s'han definit a les constants de `MenuManager.cs`.
