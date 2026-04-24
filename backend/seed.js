const mongoose = require('mongoose');
const dotenv = require('dotenv');
const User = require('./src/models/User');
const Game = require('./src/models/Game');
const Result = require('./src/models/Result');

dotenv.config();

const MONGO_URI = process.env.MONGO_URI || 'mongodb://localhost:27017/atrapa_bandera';

const seedData = async () => {
    try {
        console.log('--- Iniciant Seeding de la Base de Dades ---');
        
        // 1.1 & 1.5: Connexió a MongoDB
        await mongoose.connect(MONGO_URI);
        console.log('Connexió a MongoDB establerta.');

        // 1.2: Neteja de col·leccions
        console.log('Netejant col·leccions existents...');
        await User.deleteMany({});
        await Game.deleteMany({});
        await Result.deleteMany({});
        console.log('Col·leccions netejades.');

        // 1.3 & 1.4: Definició i Inserció de dades de prova
        console.log('Inserint usuaris de prova...');
        const users = [
            { username: 'user1', password: 'password123', coins: 100, wins: 5 },
            { username: 'user2', password: 'password123', coins: 50, wins: 2 },
            { username: 'user3', password: 'password123', coins: 0, wins: 0 }
        ];
        const insertedUsers = await User.insertMany(users);
        console.log(`${insertedUsers.length} usuaris inserits.`);

        console.log('Inserint sales (games) de prova...');
        const games = [
            {
                roomId: 'ROOM_001',
                host: 'user1',
                status: 'waiting',
                players: [
                    { username: 'user1', team: 'red', isReady: true },
                    { username: 'user2', team: 'blue', isReady: false }
                ]
            },
            {
                roomId: 'ROOM_002',
                host: 'user3',
                status: 'playing',
                players: [
                    { username: 'user3', team: 'red', isReady: true }
                ]
            }
        ];
        const insertedGames = await Game.insertMany(games);
        console.log(`${insertedGames.length} sales inserides.`);

        console.log('Inserint resultats de prova...');
        const results = [
            {
                gameId: 'OLD_GAME_ID_1',
                duration: 300,
                winningTeam: 'red',
                finalScores: { red: 3, blue: 1 }
            },
            {
                gameId: 'OLD_GAME_ID_2',
                duration: 450,
                winningTeam: 'blue',
                finalScores: { red: 0, blue: 3 }
            }
        ];
        const insertedResults = await Result.insertMany(results);
        console.log(`${insertedResults.length} resultats inserits.`);

        console.log('--- Seeding completat amb èxit ---');
    } catch (error) {
        console.error('Error durant el seeding:', error);
    } finally {
        // 1.5: Tancament net de la connexió
        await mongoose.connection.close();
        console.log('Connexió a MongoDB tancada.');
        process.exit(0);
    }
};

seedData();
