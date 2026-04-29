const mongoose = require('mongoose');

const userSchema = new mongoose.Schema({
    username: {
        type: String,
        unique: true,
        required: true
    },
    password: {
        type: String,
        required: true
    },
    coins: {
        type: Number,
        default: 0
    },
    skins: {
        type: [String],
        default: ['base']
    },
    skinEquipada: {
        type: String,
        default: 'Woodcutter'
    },
    gamesPlayed: {
        type: Number,
        default: 0
    },
    wins: {
        type: Number,
        default: 0
    },
    losses: {
        type: Number,
        default: 0
    }
});

module.exports = mongoose.model('User', userSchema);
