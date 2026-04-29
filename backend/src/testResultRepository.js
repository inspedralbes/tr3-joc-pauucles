const ResultRepositoryMongo = require('./repositories/mongo/ResultRepositoryMongo');
const mongoose = require('mongoose');
const dotenv = require('dotenv');
const Result = require('./models/Result');

dotenv.config();

const MONGO_URI = process.env.MONGO_URI || 'mongodb://localhost:27017/atrapa_bandera';

async function testResultMongo() {
    console.log('--- Testing Result Mongo Repository ---');
    try {
        await mongoose.connect(MONGO_URI);
        const repo = new ResultRepositoryMongo();
        
        const testGameId = 'TEST_GAME_RESULT_123';

        // Cleanup
        await Result.deleteOne({ gameId: testGameId });

        // 2.4: Test Save Result (create)
        console.log('Testing create (saveResult)...');
        await repo.create({
            gameId: testGameId,
            duration: 120,
            winningTeam: 'blue',
            finalScores: { red: 1, blue: 5 }
        });

        // 2.4: Test findByGameId
        console.log('Testing findByGameId...');
        const result = await repo.findByGameId(testGameId);

        if (result && result.gameId === testGameId) {
            console.log('✓ Result save and find successful');
        } else {
            throw new Error('✗ Result find failed');
        }

        console.log('--- Result Repository Tests Passed ---');
    } catch (err) {
        console.error('! Result test error:', err.message);
        process.exit(1);
    } finally {
        await mongoose.disconnect();
    }
}

testResultMongo();
