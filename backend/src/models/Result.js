const mongoose = require('mongoose');

const resultSchema = new mongoose.Schema({
    gameId: {
        type: String,
        required: true
    },
    duration: {
        type: Number,
        required: true
    },
    winningTeam: {
        type: String,
        required: true
    },
    finalScores: {
        type: mongoose.Schema.Types.Mixed,
        required: true
    }
}, { timestamps: true });

module.exports = mongoose.model('Result', resultSchema);
