## Context

L'actual flux de `READY` utilitza un mètode genèric `update` que pot ser propici a condicions de carrera si no es gestiona amb cura. Es requereix que el canvi d'estat de preparació sigui persistent i que la validació d'inici de partida es faci sobre dades fresques de la base de dades per evitar inicis de partida erronis o duplicats.

## Goals / Non-Goals

**Goals:**
- Assegurar que cada actualització de `isReady` es desa correctament a MongoDB abans de notificar als clients.
- Centralitzar la lògica d'inici de partida al backend.
- Millorar la traçabilitat dels canvis d'estat de la sala al log del servidor.

**Non-Goals:**
- No es modificarà l'esquema de dades de `Game.js`.
- No es canviarà el protocol de comunicació existent.

## Decisions

- **Persistència Atòmica**: Tot i que ja s'utilitza `findOneAndUpdate`, s'assegurarà que el `GameService` i el `GameRepository` treballin amb la instància més actualitzada. S'ha decidit mantenir l'ús de `update` al repositori però garantir que el `save()` (o l'operació equivalent) es completi abans d'iniciar el broadcast.
- **Doble Validació**: Just després de guardar el `isReady: true`, el servidor tornarà a consultar la sala (o usarà el resultat del `findOneAndUpdate`) per verificar si `players.every(p => p.isReady)`. Això prevé problemes de desincronització entre memòria i disc.
- **Broadcast de Configuració**: El missatge `PARTIDA_INICIADA` s'enviarà a tots els clients, i aquests filtraran pel seu propi `username` per configurar-se localment (DontDestroyOnLoad).

## Risks / Trade-offs

- **[Risc] Sobrecàrrega de consultes a BD** → Cada `READY` implica un `update` i potencialment una validació extra. → **[Mitigació]** Donat el baix volum de jugadors per sala (2-4), MongoDB pot gestionar aquestes operacions sense cap impacte en el rendiment.
- **[Risc] Desconnexions durant el READY** → Si un jugador es posa READY i marxa just després. → **[Mitigació]** S'ha d'implementar (en futurs canvis) un handler de `close` que reseteji els estats o elimini el jugador de la sala.
