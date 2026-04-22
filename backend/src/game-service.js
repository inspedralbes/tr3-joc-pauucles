const express = require('express');
const http = require('http');
const WebSocket = require('ws');
const cors = require('cors');
const connectDB = require('./db');
const gameRoutes = require('./routes/gameRoutes');

const app = express();
const server = http.createServer(app);

// Inicialització del servidor WebSocket compartint el servidor HTTP
const wss = new WebSocket.Server({ server });

app.use(cors());
app.use(express.json());

const { router: gameRouter, gameService, gameController } = gameRoutes(wss);
app.use('/api/games', gameRouter);

// Listener de connexió WebSocket (Lògica extreta de server.js)
wss.on("connection", (ws) => {
    console.log("Client connectat via WebSocket al Game Service");

    ws.on("message", async (data) => {
        try {
            const msg = JSON.parse(data);

            if (msg.type === "READY") {
                const updatedGame = await gameService.setReady(msg.roomId, msg.username);
                if (updatedGame) {
                    await gameController.broadcastToRoom(updatedGame);
                    const startedGame = await gameService.checkGameStart(msg.roomId, updatedGame);
                    if (startedGame) {
                        await gameController.broadcastGameStart(startedGame);
                        await gameController.broadcastRoomUpdates();
                    }
                }
            }

            if (msg.type === "leave_room") {
                const updatedGame = await gameService.leaveGame(msg.roomId, msg.username);
                await gameController.broadcastToRoom(updatedGame, msg.roomId);
                await gameController.broadcastRoomUpdates();
            }

            if (msg.type === "PLAYER_MOVE" || msg.type === "GAME_OVER" ||
                msg.type === "MINIJOC_START" || msg.type === "MINIJOC_UPDATE" || msg.type === "MINIJOC_RESULT") {
                const message = JSON.stringify(msg);
                wss.clients.forEach((client) => {
                    if (client !== ws && client.readyState === WebSocket.OPEN) {
                        client.send(message);
                    }
                });
            }
        } catch (error) {
            console.error("Error processant missatge WebSocket:", error);
        }
    });

    ws.on("close", () => console.log("Client desconnectat"));
});

// Connect to DB and Start Server
connectDB().then(() => {
    const PORT = process.env.GAME_PORT || 3002;
    server.listen(PORT, () => {
        console.log(`Game Service (WebSockets) funcionant al port ${PORT}`);
    });
});
