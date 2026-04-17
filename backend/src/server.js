const express = require('express');
const http = require('http');
const WebSocket = require('ws');
const mongoose = require('mongoose');
const cors = require('cors');
const dotenv = require('dotenv');
const userRoutes = require('./routes/userRoutes');
const gameRoutes = require('./routes/gameRoutes');
const Game = require('./models/Game');

dotenv.config();

const app = express();
const server = http.createServer(app);

// Inicialització del servidor WebSocket compartint el servidor HTTP
const wss = new WebSocket.Server({ server });

app.use(cors());
app.use(express.json());

app.use('/api/users', userRoutes);
const { router: gameRouter, gameService, gameController } = gameRoutes(wss);
app.use('/api/games', gameRouter);

// Listener de connexió WebSocket
wss.on("connection", (ws) => {
    console.log("Client connectat via WebSocket pur");

    ws.on("message", async (data) => {
        try {
            const msg = JSON.parse(data);
            console.log("Missatge rebut:", msg);

            if (msg.type === "READY") {
                const updatedGame = await gameService.setReady(msg.roomId, msg.username);
                if (updatedGame) {
                    // 4) Un cop guardat, fer el broadcast de 'ROOM_UPDATED'
                    await gameController.broadcastToRoom(updatedGame);
                    
                    // 5) Just després, comprovar si tots estan llestos usant les dades fresques
                    const startedGame = await gameService.checkGameStart(msg.roomId, updatedGame);
                    if (startedGame) {
                        // 6) Enviar broadcast PARTIDA_INICIADA
                        await gameController.broadcastGameStart(startedGame);
                        await gameController.broadcastRoomUpdates();
                        console.log(`Partida iniciada oficialment a la sala: ${msg.roomId}`);
                    }
                }
            }

            if (msg.type === "leave_room") {
                const updatedGame = await gameService.leaveGame(msg.roomId, msg.username);
                // Avisem a la sala (si és null, el controlador notificarà l'eliminació)
                await gameController.broadcastToRoom(updatedGame, msg.roomId);
                // Avisem al lobby sempre (per actualitzar comptador de jugadors o eliminar sala)
                await gameController.broadcastRoomUpdates();
            }
        } catch (error) {
            console.error("Error processant missatge WebSocket:", error);
        }
    });

    ws.on("close", () => {
        console.log("Client desconnectat del WebSocket");
    });

    ws.on("error", (error) => {
        console.error("Error al WebSocket:", error);
    });
});

mongoose.connect(process.env.MONGO_URI)
    .then(() => {
        console.log('Base de dades connectada correctament');
    })
    .catch((err) => {
        console.error('Error connectant a la base de dades:', err);
    });

const PORT = process.env.PORT || 3000;

server.listen(PORT, () => {
    console.log(`Servidor funcionant al port ${PORT}`);
});
