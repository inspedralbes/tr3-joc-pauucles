## ADDED Requirements

### Requirement: Deterministic Container Deployment
El projecte SHALL garantir que qualsevol canvi en el codi pot ser desplegat de forma determinista mitjançant la reconstrucció d'imatges de contenidor.

#### Scenario: Code Update
- **WHEN** es modifica el codi i s'executa `docker-compose build`
- **THEN** els contenidors han de reflectir la nova versió del codi sense errors d'entorn
