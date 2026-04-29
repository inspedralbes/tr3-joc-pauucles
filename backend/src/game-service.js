const express = require('express');
const http = require('http');
const WebSocket = require('ws');
const cors = require('cors');
const dotenv = require('dotenv');
const connectDB = require('./db');
const gameRoutes = require('./routes/gameRoutes');

dotenv.config();

const app = express();
const server = http.createServer(app);

// Conectar a la base de datos
connectDB();

const wss = new WebSocket.Server({ server });

app.use(cors());
app.use(express.json());

const { router: gameRouter, gameService, gameController } = gameRoutes(wss);
app.use('/api/games', gameRouter);

// Listener de conexió WebSocket (migrat de server.js)
wss.on("connection", (ws, req) => {
    const ip = req.socket.remoteAddress;
    console.log(`[WS GameService] Nou client connectat des de: ${ip}`);

    ws.on("message", async (data) => {
        try {
            const msg = JSON.parse(data);
            
            // Guardar roomId y username en el socket para filtrado eficiente
            if (msg.roomId) ws.roomId = msg.roomId;
            if (msg.username) ws.username = msg.username;

            if (msg.type === "READY") {
                console.log(`[WS] Jugador ${msg.username} preparat a la sala ${msg.roomId}`);
                const updatedGame = await gameService.setReady(msg.roomId, msg.username);
                if (updatedGame) {
                    await gameController.broadcastToRoom(updatedGame);
                    const startedGame = await gameService.checkGameStart(msg.roomId, updatedGame);
                    if (startedGame) {
                        await gameController.broadcastGameStart(startedGame);
                        await gameController.broadcastRoomUpdates();
                        console.log(`Partida iniciada oficialment a la sala: ${msg.roomId}`);
                    }
                }
            }

            if (msg.type === "leave_room") {
                const updatedGame = await gameService.leaveGame(msg.roomId, msg.username);
                await gameController.broadcastToRoom(updatedGame, msg.roomId);
                await gameController.broadcastRoomUpdates();
            }

            // Optimización: Solo enviar movimientos y eventos de juego a los miembros de la misma sala
            if (msg.type === "PLAYER_MOVE" || msg.type === "DRONE_MOVE" || msg.type === "GAME_OVER" ||
                msg.type === "MINIJOC_START" || msg.type === "MINIJOC_UPDATE" || msg.type === "MINIJOC_RESULT") {
                
                const message = JSON.stringify(msg);
                wss.clients.forEach((client) => {
                    // Filtrar: mismo roomId, no es el emisor, y conexión abierta
                    if (client !== ws && 
                        client.readyState === WebSocket.OPEN && 
                        client.roomId === msg.roomId) {
                        client.send(message);
                    }
                });
            }
        } catch (error) {
            console.error("Error processant missatge WebSocket:", error);
        }
    });

    ws.on("close", () => {
        console.log("Client desconnectat del WebSocket");
    });
});

const PORT = process.env.GAME_PORT || 3002;

server.listen(PORT, () => {
    console.log(`Game Service funcionant al port ${PORT}`);
});
