## Context

El sistema actual utilitza un patró de "carregar -> modificar a memòria -> guardar" (`find` -> `players.isReady = true` -> `save`). Mongoose té dificultats per detectar canvis profunds en arrays d'objectes si no s'utilitzen mètodes explícits com `markModified` o mètodes atòmics de MongoDB. Això ha provocat que el camp `isReady` no es persisteixi correctament, bloquejant l'inici de les partides.

## Goals / Non-Goals

**Goals:**
- Implementar l'actualització atòmica de l'estat `isReady`.
- Garantir que el broadcast de `ROOM_UPDATED` contingui dades persistides.
- Assegurar que la validació d'inici de partida ocorre sobre dades consistents.

**Non-Goals:**
- No es modificarà la interfície de Unity en aquest canvi.
- No es canviaran les llibreries del projecte.

## Decisions

- **Operador Posicional `$`**: S'utilitzarà `findOneAndUpdate` amb el filtre `{ roomId, "players.username": username }` i l'update `{ $set: { "players.$.isReady": true } }`. Aquesta és la forma més eficient i segura d'actualitzar un element específic d'un array en MongoDB sense carregar tot el document a memòria.
- **Opció `{ new: true }`**: Imprescindible per rebre el document després de l'aplicació del canvi, permetent fer el broadcast immediatament sense fer una segona consulta a la base de dades.
- **Validació de log**: S'afegirà un `console.log` del document retornat per confirmar visualment al log del servidor que el canvi s'ha aplicat abans d'emetre els missatges de WebSocket.

## Risks / Trade-offs

- **[Risc] Concurrència** → Dos jugadors es posen READY gairebé alhora. → **[Mitigació]** `findOneAndUpdate` és una operació atòmica a nivell de document en MongoDB, el que elimina problemes de concurrència en l'escriptura.
