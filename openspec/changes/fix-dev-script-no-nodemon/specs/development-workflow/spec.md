## ADDED Requirements

### Requirement: Execució estable del backend
L'script de desenvolupament (`dev`) SHALL executar el servidor utilitzant `node` directament en lloc de `nodemon`.

#### Scenario: Inici del servidor en mode desenvolupament
- **WHEN** El desenvolupador executa `npm run dev`.
- **THEN** El sistema inicia `backend/src/server.js` utilitzant l'executable `node`.
- **THEN** El servidor NO es reiniciarà automàticament quan es detectin canvis en els fitxers.
