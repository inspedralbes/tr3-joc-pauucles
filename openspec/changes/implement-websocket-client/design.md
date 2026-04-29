## Context

L'aplicació TR3 utilitza un flux on el jugador primer s'uneix a una sala d'espera en una interfície web/backend. Quan la partida comença, Unity ha de saber qui és el jugador actual per configurar el seu Nametag i equip. Els WebSockets són el canal idoni per a aquesta notificació en temps real.

## Goals / Non-Goals

**Goals:**
- Crear una classe `WebSocketClient` que gestioni la connexió de baix nivell amb `System.Net.WebSockets.ClientWebSocket`.
- Implementar la lògica de "Parsing" del missatge JSON de sessió.
- Actualitzar `Player.cs` per acceptar configuracions externes asíncronament.

**Non-Goals:**
- No s'implementarà sincronització de posicions (Networking de moviment) en aquest script.
- No es gestionarà la reconnexió automàtica complexa per ara (només connexió inicial).

## Decisions

- **Llibreria**: S'utilitzarà `System.Net.WebSockets` en lloc de llibreries de tercers o `UnityWebRequest` perquè Unity 2021+ té suport natiu estable i és més eficient per a connexions persistents.
- **Detecció de Jugador**: El Woodcutter és el prefab principal del jugador local. S'utilitzarà `GameObject.FindObjectOfType<Player>()` (o una cerca pel nom del prefab) per localitzar-lo un cop rebudes les dades.
- **Fil d'execució**: Atès que `ClientWebSocket` és asíncron, caldrà assegurar-se que les crides a mètodes d'Unity (com canviar text d'UI o tags) es facin al fil principal (Main Thread) mitjançant una cua de tasques o comprovacions al `Update`.

## Risks / Trade-offs

- **[Risc] Bloqueig del Main Thread** → **Mitigació**: L'ús de `await` i `Task` assegura que la recepció de paquets no bloquegi els frames del joc.
- **[Risc] El jugador encara no existeix a l'escena un cop rebut el missatge** → **Mitigació**: S'afegirà una comprovació de nul·litat i, si cal, una espera petita abans d'intentar la inicialització.
