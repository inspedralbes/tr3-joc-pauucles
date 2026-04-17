## ADDED Requirements

### Requirement: Filtratge de sales al lobby
El servidor SHALL enviar exclusivament les sales amb l'status `waiting` en les actualitzacions globals de la llista de sales per evitar que partides en curs siguin visibles per a nous jugadors.

#### Scenario: Actualització de sales actives
- **WHEN** un client demana la llista de sales o es produeix un broadcast de canvi.
- **THEN** el sistema recupera només les sales de MongoDB amb `status: "waiting"` i les envia per WebSocket.

### Requirement: Eliminació condicionada de sales
El sistema SHALL diferenciar entre el creador de la sala (`host`) i els jugadors convidats per determinar si la sala ha de ser eliminada de la base de dades en cas d'abandonament.

#### Scenario: El host abandona la sala
- **WHEN** el servidor detecta que el jugador que marxa és el `host` de la sala (via `LEAVE_ROOM` o desconnexió).
- **THEN** el sistema elimina el document de la sala de MongoDB completament.

#### Scenario: Un convidat abandona la sala
- **WHEN** un jugador que no és el `host` abandona la sala.
- **THEN** el sistema utilitza l'operador `$pull` per treure únicament aquest usuari de l'array `players` i manté la sala activa.
