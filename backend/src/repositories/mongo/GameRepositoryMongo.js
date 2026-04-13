const Game = require('../../models/Game');

class GameRepositoryMongo {
    async create(gameData) {
        const game = new Game(gameData);
        return await game.save();
    }

    async findByRoomId(roomId) {
        return await Game.findOne({ roomId });
    }

    async update(roomId, data) {
        return await Game.findOneAndUpdate(
            { roomId },
            { $set: data },
            { new: true }
        );
    }
}

module.exports = GameRepositoryMongo;
