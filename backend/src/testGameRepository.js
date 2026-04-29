const GameRepositoryMongo = require('./repositories/mongo/GameRepositoryMongo');
const mongoose = require('mongoose');
const dotenv = require('dotenv');
const Game = require('./models/Game');

dotenv.config();

const MONGO_URI = process.env.MONGO_URI || 'mongodb://localhost:27017/atrapa_bandera';

async function testGameMongo() {
    console.log('--- Testing Game Mongo Repository ---');
    try {
        await mongoose.connect(MONGO_URI);
        const repo = new GameRepositoryMongo();
        
        const testRoomId = 'TEST_ROOM_999';

        // Cleanup
        await Game.deleteOne({ roomId: testRoomId });

        // 2.2: Test Create
        console.log('Testing create...');
        await repo.create({
            roomId: testRoomId,
            host: 'test_host',
            players: [{ username: 'test_host', team: 'red', isReady: true }]
        });

        // 2.2: Test Find
        console.log('Testing findByRoomId...');
        const game = await repo.findByRoomId(testRoomId);

        if (game && game.roomId === testRoomId) {
            console.log('✓ Game create and find successful');
        } else {
            throw new Error('✗ Game find failed');
        }

        // 2.2: Test Delete
        console.log('Testing delete...');
        await repo.delete(testRoomId);
        const deletedGame = await repo.findByRoomId(testRoomId);

        if (!deletedGame) {
            console.log('✓ Game delete successful');
        } else {
            throw new Error('✗ Game delete failed');
        }

        console.log('--- Game Repository Tests Passed ---');
    } catch (err) {
        console.error('! Game test error:', err.message);
        process.exit(1);
    } finally {
        await mongoose.disconnect();
    }
}

testGameMongo();
