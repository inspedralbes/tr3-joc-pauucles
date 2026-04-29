const UserRepositoryInMemory = require('./repositories/inMemory/UserRepositoryInMemory');
const UserRepositoryMongo = require('./repositories/mongo/UserRepositoryMongo');
const mongoose = require('mongoose');
const dotenv = require('dotenv');

dotenv.config();

async function testInMemory() {
    console.log('--- Testing In-Memory Repository ---');
    const repo = new UserRepositoryInMemory();
    
    await repo.create({ username: 'testuser', password: 'password123' });
    const user = await repo.findByUsername('testuser');
    
    if (user && user.username === 'testuser') {
        console.log('✓ In-memory create and find successful');
        console.log('User data:', user);
    } else {
        console.error('✗ In-memory test failed');
    }
}

async function testMongo() {
    console.log('\n--- Testing Mongo Repository ---');
    if (!process.env.MONGO_URI) {
        console.log('! Skipping Mongo test: MONGO_URI not found in .env');
        return;
    }

    try {
        await mongoose.connect(process.env.MONGO_URI);
        const repo = new UserRepositoryMongo();
        
        // Cleanup previous tests if any
        const User = require('./models/User');
        await User.deleteOne({ username: 'mongouser' });

        await repo.create({ username: 'mongouser', password: 'password123' });
        const user = await repo.findByUsername('mongouser');

        if (user && user.username === 'mongouser') {
            console.log('✓ Mongo create and find successful');
        } else {
            console.error('✗ Mongo test failed');
        }
    } catch (err) {
        console.error('! Mongo test error (likely no DB running):', err.message);
    } finally {
        await mongoose.disconnect();
    }
}

async function runTests() {
    await testInMemory();
    await testMongo();
}

runTests();
