## ADDED Requirements

### Requirement: Actualització atòmica de l'estat READY
El sistema SHALL realitzar actualitzacions atòmiques dels camps interns dels jugadors per garantir que els canvis de preparació es reflecteixin correctament a la base de dades.

#### Scenario: Guardat forçat amb findOneAndUpdate
- **WHEN** el servidor processa un missatge de tipus `READY` per a un usuari i sala concrets.
- **THEN** el sistema invoca `findOneAndUpdate` utilitzant l'operador posicional `$` per posar `isReady: true` i retorna el document actualitzat.

### Requirement: Verificació d'estat fresc post-actualització
El sistema SHALL utilitzar les dades retornades immediatament per la base de dades després de l'actualització per decidir si la partida ha de començar.

#### Scenario: Inici de partida amb dades consistents
- **WHEN** s'ha rebut el document fresc de la sala després d'un `READY`.
- **THEN** el sistema verifica si `players.length === maxPlayers` i si TOTS els participants estan a `isReady: true` abans de canviar l'estat a `playing`.
