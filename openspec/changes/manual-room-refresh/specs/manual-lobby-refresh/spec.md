## ADDED Requirements

### Requirement: Botó d'actualització manual
El sistema SHALL mostrar un botó al lobby que permeti a l'usuari forçar el refresc de la llista de sales disponibles.

#### Scenario: Clic al botó de refresc
- **WHEN** l'usuari clica el botó `#btnActualitzarSales`.
- **THEN** el sistema inicia una petició HTTP GET al servidor per obtenir la llista actualitzada de sales actives.

### Requirement: Comunicació amb el backend
El sistema SHALL realitzar una petició de xarxa asíncrona per obtenir les dades del servidor.

#### Scenario: Petició exitosa de llista de sales
- **WHEN** la petició HTTP GET a `/api/games/list` finalitza amb èxit.
- **THEN** el sistema processa el JSON rebut i prepara l'actualització de la interfície.

### Requirement: Neteja del contenidor de la llista
El sistema SHALL buidar completament el contenidor visual de la llista de sales abans d'afegir els nous elements rebuts per evitar la duplicitat de dades.

#### Scenario: Neteja abans de repintar
- **WHEN** les noves dades de sales estan llestes per ser mostrades.
- **THEN** el sistema crida al mètode `.Clear()` (o equivalent segons el tipus de col·lecció) del contenidor de la llista visual ABANS d'instanciar o afegir nous ítems.
