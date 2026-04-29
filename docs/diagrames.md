# Diagrames del Projecte TR3

## Diagrama de Casos d'Ús
```mermaid
useCaseDiagram
    actor Jugador
    
    Jugador -- (Identificació/Login)
    Jugador -- (Gestionar Inventari/Skins)
    Jugador -- (Crear Partida)
    Jugador -- (Unir-se a Partida existent)
    Jugador -- (Jugar Partida Multijugador)
    Jugador -- (Veure Resultats Finals)
```

## Diagrama de Seqüència (Sincronització de Partida)
```mermaid
sequenceDiagram
    participant Unity as Client Unity
    participant Nginx as Proxy Nginx (Port 80)
    participant GameJS as Game Service (Port 3002)
    participant MongoDB as DB (Atlas)

    Unity->>Nginx: WebSocket Connection Request
    Nginx->>GameJS: Forward WS Connection
    GameJS-->>Unity: Connection Established

    Note over Unity, GameJS: Durant la Partida

    Unity->>GameJS: JSON: { type: "PLAYER_MOVE", ... }
    GameJS->>GameJS: Relay logic (Broadcast to others)
    GameJS-->>Unity: Broadcast state updates

    Unity->>GameJS: JSON: { type: "GAME_OVER", ... }
    GameJS->>MongoDB: Save results
    GameJS-->>Unity: Send final results
```

## Diagrama Entitat-Relació (Base de Dades)
```mermaid
erDiagram
    USER ||--o{ GAME : plays
    USER {
        string _id
        string username
        string password
        string skinEquipada
    }
    GAME {
        string _id
        string roomId
        string host
        string status
        int maxPlayers
    }
    RESULT {
        string _id
        string roomId
        string winner
        int duration
        date createdAt
    }
    GAME ||--o{ RESULT : generates
```

## Diagrama de Microserveis / Arquitectura
```mermaid
graph TD
    subgraph Client
        Unity[Client Unity]
    end

    subgraph "Servidor Ubuntu (204.168.215.211)"
        Nginx[Nginx Reverse Proxy]
        Identity[Identity Service :3001]
        Game[Game Service :3002]
        Fail2ban[Fail2ban Security]
    end

    subgraph Cloud
        MongoAtlas[MongoDB Atlas Cluster]
    end

    Unity -- HTTP /api/users --> Nginx
    Unity -- HTTP /api/games --> Nginx
    Unity -- WebSockets --> Nginx

    Nginx -- Proxy --> Identity
    Nginx -- Proxy --> Game

    Identity -- Mongoose --> MongoAtlas
    Game -- Mongoose --> MongoAtlas
```
