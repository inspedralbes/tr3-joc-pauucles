## ADDED Requirements

### Requirement: Step-by-Step Installation Guide
El fitxer `MANUAL_INSTALACIO.md` SHALL descriure seqüencialment els passos per instal·lar les dependències del projecte i configurar l'entorn de base de dades.

#### Scenario: Successful Dependency Installation
- **WHEN** un desenvolupador segueix el manual
- **THEN** ha de poder executar `npm install` i tenir tots els paquets necessaris

### Requirement: Database Initialization Instructions
El manual SHALL incloure les comandes per arrencar MongoDB i executar l'script `seed.js` per carregar dades de prova.

#### Scenario: Verify Seeding Process
- **WHEN** s'executa la comanda de seeding descrita
- **THEN** la base de dades s'ha de poblar amb l'estat inicial esperat

### Requirement: Service Execution Guide
El manual SHALL explicar com aixecar els serveis d'identitat i de joc de forma independent.

#### Scenario: Running Microservices
- **WHEN** es segueixen les instruccions d'arrencada
- **THEN** els serveis han d'estar escoltant en els ports 3001 i 3002 respectivament
