FROM node:18-alpine

WORKDIR /app

COPY package*.json ./

RUN npm install --production

COPY backend/ ./backend/

# Exposem els ports dels microserveis (opcional però bona pràctica)
EXPOSE 3001 3002

# No definim CMD aquí per permetre que docker-compose ho gestioni
