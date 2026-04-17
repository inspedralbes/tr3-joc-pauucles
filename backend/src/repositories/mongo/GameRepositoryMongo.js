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

    async updatePlayerReady(roomId, username, isReady) {
        return await Game.findOneAndUpdate(
            { roomId, "players.username": username },
            { $set: { "players.$.isReady": isReady } },
            { new: true }
        );
    }

    async pullPlayer(roomId, username) {
        return await Game.findOneAndUpdate(
            { roomId },
            { $pull: { players: { username: username } } },
            { new: true }
        );
    }

    async findAllWaiting() {
        return await Game.find({ status: 'waiting' });
    }

    async delete(roomId) {
        return await Game.deleteOne({ roomId });
    }
}

module.exports = GameRepositoryMongo;
