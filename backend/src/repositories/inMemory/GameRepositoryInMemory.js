class GameRepositoryInMemory {
    constructor() {
        this.games = [];
    }

    async create(gameData) {
        const newGame = {
            roomId: gameData.roomId,
            host: gameData.host,
            teamAColor: gameData.teamAColor || 'red',
            teamBColor: gameData.teamBColor || 'blue',
            players: gameData.players || [],
            status: gameData.status || 'waiting',
            winner: gameData.winner || null,
            createdAt: new Date(),
            updatedAt: new Date()
        };
        this.games.push(newGame);
        return newGame;
    }

    async findByRoomId(roomId) {
        return this.games.find(game => game.roomId === roomId) || null;
    }

    async update(roomId, data) {
        const index = this.games.findIndex(game => game.roomId === roomId);
        if (index === -1) return null;

        this.games[index] = {
            ...this.games[index],
            ...data,
            updatedAt: new Date()
        };
        return this.games[index];
    }

    async findAllWaiting() {
        return this.games.filter(game => game.status === 'waiting');
    }
}

module.exports = GameRepositoryInMemory;
