const mongoose = require('mongoose');
const dotenv = require('dotenv');

dotenv.config();

const connectDB = async () => {
    try {
        await mongoose.connect(process.env.MONGO_URI);
        console.log('Base de dades connectada correctament');
    } catch (err) {
        console.error('Error connectant a la base de dades:', err);
        process.exit(1);
    }
};

module.exports = connectDB;
