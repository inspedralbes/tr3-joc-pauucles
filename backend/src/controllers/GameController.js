const WebSocket = require('ws');

class GameController {
    constructor(gameService, wss) {
        this.gameService = gameService;
        this.wss = wss;
        console.log('GameController inicialitzat. Estat wss:', !!this.wss);
    }

    async create(req, res) {
        const { host, teamAColor, teamBColor, maxPlayers } = req.body;
        
        if (!host) {
            return res.status(400).json({ error: 'Falta el camp host' });
        }

        try {
            const game = await this.gameService.createGame(host, teamAColor, teamBColor, maxPlayers);
            
            // Broadcast updates after successful creation
            await this.broadcastRoomUpdates();
            console.log("Broadcast CREAR_SALA enviat");
            
            res.status(201).json(game);
        } catch (error) {
            res.status(400).json({ error: error.message });
        }
    }

    async broadcastRoomUpdates() {
        try {
            console.log('Iniciant broadcastRoomUpdates. Estat wss:', !!this.wss);
            const games = await this.gameService.listWaitingGames();
            const message = JSON.stringify({
                type: "ACTUALITZAR_SALES",
                sales: games
            });

            if (this.wss && this.wss.clients) {
                console.log('Enviant broadcast a ' + this.wss.clients.size + ' clients');
                this.wss.clients.forEach((client) => {
                    if (client.readyState === WebSocket.OPEN) {
                        client.send(message);
                    }
                });
                console.log("Broadcast ACTUALITZAR_SALES enviat a tots els clients.");
            } else {
                console.log('No s\'ha pogut fer el broadcast: wss o wss.clients no estan disponibles');
            }
        } catch (error) {
            console.error("Error en el broadcast de sales:", error);
        }
    }

    async broadcastToRoom(gameData, roomIdFallback = null) {
        try {
            console.log('Iniciant broadcastToRoom. Estat wss:', !!this.wss);
            const roomId = gameData ? gameData.roomId : roomIdFallback;
            const message = JSON.stringify({
                type: "ROOM_UPDATED",
                room: gameData // Serà null si la sala s'ha eliminat
            });

            if (this.wss && this.wss.clients) {
                console.log('Enviant broadcast a ' + this.wss.clients.size + ' clients');
                this.wss.clients.forEach((client) => {
                    if (client.readyState === WebSocket.OPEN) {
                        client.send(message);
                    }
                });
                console.log(`Broadcast ROOM_UPDATED enviat per a la sala ${roomId}`);
            } else {
                console.log('No s\'ha pogut fer el broadcast: wss o wss.clients no estan disponibles');
            }
        } catch (error) {
            console.error("Error en el broadcast de sala:", error);
        }
    }

    async broadcastGameStart(gameData) {
        try {
            if (this.wss && this.wss.clients) {
                // Per a cada jugador a la sala, enviem el seu missatge d'inici personalitzat
                // Atès que no tenim mapeig de sockets, fem broadcast de tots els inicis
                // El client filtrarà pel seu username.
                gameData.players.forEach(player => {
                    const playerColor = (player.team === 'A') ? gameData.teamAColor : gameData.teamBColor;
                    
                    const message = JSON.stringify({
                        type: "PARTIDA_INICIADA",
                        username: player.username,
                        team: player.team,
                        color: playerColor
                    });

                    this.wss.clients.forEach((client) => {
                        if (client.readyState === WebSocket.OPEN) {
                            client.send(message);
                        }
                    });
                });
                console.log(`Broadcast PARTIDA_INICIADA enviat per a la sala ${gameData.roomId}`);
            }
        } catch (error) {
            console.error("Error en el broadcast d'inici de partida:", error);
        }
    }

    async list(req, res) {
        try {
            const games = await this.gameService.listWaitingGames();
            res.status(200).json(games);
        } catch (error) {
            res.status(500).json({ error: error.message });
        }
    }

    async join(req, res) {
        const { roomId, username, team } = req.body;

        if (!roomId || !username || !team) {
            return res.status(400).json({ error: 'Falten camps obligatoris (roomId, username, team)' });
        }

        try {
            const updatedGame = await this.gameService.joinGame(roomId, username, team);
            
            // Broadcast updates after successful join
            await this.broadcastToRoom(updatedGame);
            await this.broadcastRoomUpdates();
            console.log("Broadcast JOIN_ROOM enviat");
            
            res.status(200).json(updatedGame);
        } catch (error) {
            res.status(400).json({ error: error.message });
        }
    }
}

module.exports = GameController;
