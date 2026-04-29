## Context

El sistema actual pateix d'inconsistències en la gestió del cicle de vida de les sales. Les partides que ja han començat segueixen apareixent al lobby, i no hi ha una distinció clara entre qui té el control de la sala (host). A més, la transició a l'escena de joc no és prou robusta per garantir que tots els clients estiguin sincronitzats amb la seva identitat correcta.

## Goals / Non-Goals

**Goals:**
- Netejar el lobby de sales en joc.
- Protegir l'existència de la sala si el host no ha marxat.
- Automatitzar la càrrega de l'escena 'Bosque' per a tots els participants llestos.

**Non-Goals:**
- No es modificarà el sistema d'autenticació.
- No es tractarà la lògica de joc post-càrrega (moviment, punts, etc.) en aquest disseny.

## Decisions

- **Filtratge en la Font**: El mètode `listWaitingGames()` al `GameService.js` (o directament la consulta a MongoDB al repositori) s'actualitzarà per afegir la condició `{ status: "waiting" }`. Això és més eficient que filtrar en el controlador o al frontend.
- **Lògica de Sortida Atòmica**: Al handler de `LEAVE_ROOM` i al tancament del socket, es farà una consulta per obtenir la sala. Es compararà el `username` que marxa amb el camp `host` del document. S'utilitzarà `deleteOne` per al host o `$pull` per als convidats per evitar carregues innecessàries de documents grans a memòria.
- **Broadcast de PARTIDA_INICIADA**: S'optarà per un enviament individualitzat dins del bucle de jugadors de la sala al backend. Això permet que cada client rebi un objecte JSON net amb els seus propis paràmetres, simplificant el processament a `WebSocketClient.cs`.
- **Accés al root de la UI**: `MenuManager.cs` tindrà una referència al `VisualElement` arrel de la seva `UIDocument` per poder fer l'ocultació global immediata (`display = DisplayStyle.None`).

## Risks / Trade-offs

- **[Risc] Sales Buides** → Si un convidat marxa i la sala es queda buida però el host no hi és (per error previ). → **[Mitigació]** El servidor pot implementar una tasca de neteja periòdica (cron) per a sales sense activitat, però de moment confiem en la lògica de host/convidat.
- **[Risc] Sincronització de Càrrega** → Un client triga més a carregar l'escena que un altre. → **[Mitigació]** Donat que el sistema és un prototip, es confia en el fet que el canvi d'escena és la primera acció i les sincronitzacions de posició (GameManager) compensaran els desfasaments inicials.
