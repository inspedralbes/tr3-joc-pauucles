## 1. Contenirització del Backend

- [x] 1.1 Crear `backend/Dockerfile` basat en imatge Node.js alpine, copiant tot el contingut del backend i instal·lant dependències.
- [x] 1.2 Assegurar que el Dockerfile no té un CMD per defecte o que permet l'arrencada selectiva.
- [x] 1.3 Crear un fitxer `.dockerignore` a la carpeta `backend` per evitar incloure `node_modules`.

## 2. Orquestració amb Docker Compose

- [x] 2.1 Renombrar el `docker-compose.yml` actual a `docker-compose.ml-agents.yml` (opcional) o actualitzar-lo.
- [x] 2.2 Crear/Actualitzar `docker-compose.yml` a l'arrel definint el servei `identity` (mapejat al port 3001 intern).
- [x] 2.3 Definir el servei `game` al compose (mapejat al port 3002 intern).
- [x] 2.4 Definir el servei `nginx` al compose basat en la imatge `nginx:latest`.

## 3. Configuració de Nginx per a Docker

- [x] 3.1 Crear `nginx_docker.conf` (o actualitzar l'existent) amb la lògica de proxy invers a `http://identity:3001` i `http://game:3002`.
- [x] 3.2 Configurar el bloc `location /` per servir els arxius de `/usr/share/nginx/html`.
- [x] 3.3 Assegurar el suport de WebSockets (headers Upgrade i Connection) per al servei `game`.

## 4. Muntatge i Verificació

- [x] 4.1 Configurar volums al `docker-compose.yml` per muntar la build de Unity WebGL a la ruta corresponent de Nginx.
- [ ] 4.2 Executar `docker-compose build` i `docker-compose up` per validar l'arrencada de tot l'stack. (Pendent d'arrencada de Docker)
- [ ] 4.3 Verificar que el client WebGL carrega i es pot comunicar amb el backend a través del proxy.
