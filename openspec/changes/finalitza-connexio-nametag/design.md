## Context

Actualment el projecte disposa de comunicació bàsica via WebSocket, però el flux de lobby a partida no està tancat. Es requereix que el jugador pugui indicar que està preparat i que el sistema el transicioni a l'escena de joc mantenint la seva identitat visual.

## Goals / Non-Goals

**Goals:**
- Vincular el botó `#btnConfirmarReady` per enviar "READY".
- Emmagatzemar dades d'usuari (`username`, `team`, `color`) de forma persistent entre escenes.
- Automatitzar el canvi d'escena a "Bosque" en rebre "PARTIDA_INICIADA".
- Implementar un sistema de Nametag visualment estable per al jugador.

**Non-Goals:**
- No es pretén unificar les llibreries de WebSocket actualment (es mantindrà l'ús de `NativeWebSocket` a `MenuManager` i `System.Net.WebSockets` a `WebSocketClient` segons el codi existent).
- No es tracta de la lògica de joc multijugador avançada, només la configuració inicial del jugador propi.

## Decisions

- **Persistència de dades**: S'utilitzaran camps estàtics a `WebSocketClient.cs` (`public static string Username`, etc.) per emmagatzemar la informació del jugador rebuda del servidor. Això facilita l'accés des de qualsevol script (com `Player.cs`) sense dependre de la jerarquia d'escena.
- **Transició d'escena**: `WebSocketClient` gestionarà la càrrega de l'escena "Bosque" mitjançant `SceneManager.LoadScene`. Atès que la recepció del WebSocket pot ocórrer en un fil secundari, s'utilitzarà un flag i es processarà al `Update` (fil principal).
- **Nametag Script**: Es crearà un script dedicat `Nametag.cs` acoblat a un Canvas de món (`World Space`) per al jugador.
- **Estabilitat del Nametag**: S'aplicarà `Quaternion.identity` al `LateUpdate` per evitar que el nom s'inclini quan el personatge es mou o fa salts.
- **Traducció de Colors**: El script `Nametag` contindrà una funció per mapejar cadenes (ex: "Verd") a constants `Color` de Unity (ex: `Color.green`).

## Risks / Trade-offs

- **[Risc] Sincronització de fils**: Els callbacks de WebSocket poden no estar al fil principal de Unity. -> **[Mitigació]** Ús de flags i `Update` per a accions de Unity (càrrega d'escena).
- **[Risc] Persistència del WebSocket**: Si `WebSocketClient` no és persistent, la connexió es tancarà en canviar d'escena. -> **[Mitigació]** S'afegirà `DontDestroyOnLoad`.
- **[Trade-off] Variables estàtiques**: Simplifiquen l'accés però poden ser menys escalables que un `ScriptableObject` o un Singleton formal. Donada la simplicitat requerida, es mantenen estàtiques.
