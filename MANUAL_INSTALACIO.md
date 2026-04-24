# Manual d'Instal·lació - Atrapa el Dinosaure

Aquesta guia explica com configurar i posar en marxa l'entorn de desenvolupament per al backend del projecte.

## Requisits Previs
* **Node.js** (v18 o superior)
* **MongoDB** (Local o instància a Atlas)
* **Nginx** (Opcional per a desenvolupament, obligatori per a arquitectura de microserveis completa)

## 1. Instal·lació de Dependències
Des de l'arrel del projecte, executa:
```bash
npm install
```

## 2. Configuració de la Base de Dades
Assegura't que el teu servei de MongoDB està actiu. Pots configurar la URI de connexió al fitxer `.env` (si no existeix, crea'l basant-te en els valors per defecte dels serveis).

### Inicialització de Dades (Seeding)
Per carregar els usuaris, sales i resultats de prova:
```bash
npm run seed
```

## 3. Execució dels Microserveis
El backend està separat en dos serveis independents. Has d'obrir dues terminals o executar-los en segon pla:

### Identity Service (Autenticació i Usuaris)
Escoltarà al port **3001**.
```bash
node backend/src/identity-service.js
```

### Game Service (Lògica de Joc i WebSockets)
Escoltarà al port **3002**.
```bash
node backend/src/game-service.js
```

## 4. Configuració d'Nginx (Proxy Invers)
Perquè el client (Unity) pugui comunicar-se amb ambdós serveis a través d'un únic punt d'entrada, s'ha de configurar Nginx.

Exemple de configuració (`nginx_default.conf`):
```nginx
server {
    listen 80;

    location /api/users/ {
        proxy_pass http://localhost:3001;
    }

    location /api/games/ {
        proxy_pass http://localhost:3002;
    }

    location /socket.io/ {
        proxy_pass http://localhost:3002;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection "upgrade";
    }
}
```

## 5. Tests
Pots verificar que els repositoris funcionen correctament amb:
```bash
npm run test:repos
```
