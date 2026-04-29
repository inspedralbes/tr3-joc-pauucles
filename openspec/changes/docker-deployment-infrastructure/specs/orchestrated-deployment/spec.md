## ADDED Requirements

### Requirement: Service Orchestration with Docker Compose
El sistema SHALL utilitzar Docker Compose per aixecar simultàniament els serveis d'identitat, joc i el proxy invers.

#### Scenario: Stack Initialization
- **WHEN** s'executa `docker-compose up`
- **THEN** els contenidors `identity`, `game` i `nginx` han d'arrencar correctament en la mateixa xarxa interna

### Requirement: Internal Network Resolution
Els contenidors SHALL poder-se comunicar entre ells utilitzant els noms de servei definits al compose.

#### Scenario: Proxy to Game Service
- **WHEN** Nginx intenta redirigir trànsit a `http://game:3002`
- **THEN** la petició ha d'arribar al contenidor del servei de joc amb èxit
