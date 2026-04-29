## ADDED Requirements

### Requirement: Database Cleanup
L'script de seed SHALL netejar completament les col·leccions d'usuaris, sales (games) i resultats abans d'inserir les dades noves per evitar duplicats o estats inconsistents.

#### Scenario: Successful Cleanup
- **WHEN** s'executa l'script `seed.js`
- **THEN** les col·leccions especificades queden buides abans de la inserció de dades de prova

### Requirement: Structured Data Ingestion
L'script de seed SHALL inserir almenys 3 usuaris de prova, 2 sales de joc configurades i un conjunt de resultats ficticis per a cada usuari.

#### Scenario: Verify Data Presence
- **WHEN** finalitza l'execució de `seed.js`
- **THEN** la base de dades conté exactament els registres definits en l'script de seeding

### Requirement: Self-closing Connection
L'script de seed SHALL tancar la connexió amb MongoDB un cop hagi finalitzat totes les operacions d'inserció o en cas d'error crític.

#### Scenario: Clean Exit
- **WHEN** les dades s'han inserit correctament
- **THEN** el procés de Node.js finalitza de forma neta i tanca el socket de la base de dades
