const mongoose = require('mongoose');

const gameSchema = new mongoose.Schema({
    roomId: {
        type: String,
        unique: true,
        required: true
    },
    host: {
        type: String,
        required: true
    },
    teamAColor: {
        type: String,
        default: 'red'
    },
    teamBColor: {
        type: String,
        default: 'blue'
    },
    players: [{
        username: String,
        team: String,
        isReady: Boolean
    }],
    status: {
        type: String,
        enum: ['waiting', 'playing', 'finished'],
        default: 'waiting'
    },
    winner: {
        type: String,
        default: null
    },
    maxPlayers: {
        type: Number,
        default: 4
    }
}, { timestamps: true });

module.exports = mongoose.model('Game', gameSchema);
