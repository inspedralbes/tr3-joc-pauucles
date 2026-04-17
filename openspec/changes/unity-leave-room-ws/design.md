## Context

El `MenuManager.cs` ja disposa d'un mecanisme per tancar la Sala d'Espera i tornar al Lobby. No obstant això, aquesta acció és purament visual en el client. El servidor necessita rebre una notificació per actualitzar l'estat de la sala i dels jugadors.

## Goals / Non-Goals

**Goals:**
- Enviar un missatge WebSocket amb el tipus `leave_room` quan s'abandona la sala.
- Incloure el `roomId` i el `username` del jugador en el missatge.
- Verificar que la connexió WebSocket estigui oberta abans d'intentar enviar dades.

**Non-Goals:**
- No s'implementarà cap lògica de reconnexió automàtica en aquesta fase.
- No es modificarà la interfície d'usuari (UI).

## Decisions

- **Uso de `JsonUtility`**: S'utilitzarà `JsonUtility.ToJson` per serialitzar el missatge. Atès que `JsonUtility` no suporta objectes anònims, es crearà una classe senzilla `[Serializable]` per representar el missatge de sortida.
- **Verificació d'Estat (`WebSocketState.Open`)**: S'afegirà una comprovació de seguretat per evitar errors si s'intenta enviar un missatge amb el socket tancat.

## Risks / Trade-offs

- **[Risk] Error de serialització** → **Mitigation**: Es definirà una classe `LeaveRoomMessage` amb els atributs exactes que el servidor espera rebre.
- **[Trade-off] Dependència de l'ID de sala** → **Mitigation**: L'enviament només es realitzarà si `currentRoomId` no és nul.

## Migration Plan

1. Definir la classe `LeaveRoomMessage` a `MenuManager.cs`.
2. Localitzar el callback `btnTancarSalaEspera.clicked` a `OnEnable`.
3. Inserir la lògica d'enviament del WebSocket abans de resetear les variables d'estat.
