## Context

Actualment el projecte es divideix en un client Unity WebGL i un backend de microserveis Node.js (`identity-service.js` i `game-service.js`). El desplegament s'ha de centralitzar utilitzant Docker per simplificar la gestió d'infraestructura i assegurar que Nginx serveix tant el client com l'API.

## Goals / Non-Goals

**Goals:**
- Conteniritzar els serveis de backend en una única imatge versàtil.
- Orquestrar el backend i el proxy invers (Nginx) amb Docker Compose.
- Configurar Nginx per servir el joc WebGL i enrutar l'API.
- Utilitzar una xarxa interna de Docker per a la comunicació entre contenidors.

**Non-Goals:**
- Conteniritzar la base de dades MongoDB (s'assumeix que és externa o s'executa fora d'aquesta pila específica per ara, tot i que Compose ho podria suportar).
- Configurar SSL/TLS en aquest disseny inicial.

## Decisions

### 1. Dockerfile versàtil per al Backend
- **Decisió**: Crear un Dockerfile a `backend/Dockerfile` basat en `node:18-alpine`.
- **Racional**: alpine redueix la mida de la imatge. No definirem un `CMD` fix, deixant que el `docker-compose.yml` especifiqui quin servei arrenca cada contenidor.

### 2. Docker Compose com a Orquestrador
- **Decisió**: Definir serveis `identity`, `game` i `nginx` al fitxer d'arrel.
- **Racional**: Permet gestionar dependències (ex: el proxy depèn que els serveis estiguin up) i centralitzar els logs.

### 3. Nginx com a Gateway i Host Estàtic
- **Decisió**: Muntar la build de Unity WebGL en un volum dins del contenidor Nginx a `/usr/share/nginx/html`.
- **Racional**: Nginx és extremadament eficient servint fitxers estàtics i gestionant el proxy pass per a peticions REST i WebSockets.

### 4. Comunicació interna per DNS de Docker
- **Decisió**: Redirigir el trànsit d'Nginx a `http://identity:3001` i `http://game:3002`.
- **Racional**: Evita dependre d'IPs fixes i aprofita la resolució de noms nativa de Docker.

## Risks / Trade-offs

- **[Risc] Mida de la Build de Unity** → **Mitigació**: S'ha d'assegurar que la build de WebGL està correctament copiada o muntada com a volum per evitar imatges Nginx massa pesades si s'inclouen en la build.
- **[Risc] Persistència de Logs** → **Mitigació**: Es recomana utilitzar volums per als logs de Nginx i dels serveis Node si es requereix anàlisi posterior.
- **[Risc] Connexió a DB** → **Mitigació**: S'ha de configurar correctament la URI de MongoDB al fitxer `.env` (ex: `mongodb://host.docker.internal:27017` si la DB està a la màquina host).
