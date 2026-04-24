## ADDED Requirements

### Requirement: Node.js Backend Containerization
El sistema SHALL permetre la creació d'una imatge Docker per als microserveis del backend basats en Node.js.

#### Scenario: Successful Docker Build
- **WHEN** s'executa `docker build -t backend-image ./backend`
- **THEN** s'ha de generar una imatge funcional que contingui totes les dependències i el codi del backend

### Requirement: Multi-service Entry Point support
La imatge Docker SHALL ser capaç d'arrencar diferents serveis (identity o game) depenent de la comanda d'execució.

#### Scenario: Running Identity Service
- **WHEN** s'executa el contenidor amb `node src/identity-service.js`
- **THEN** el servei ha de ser accessible internament al port 3001
