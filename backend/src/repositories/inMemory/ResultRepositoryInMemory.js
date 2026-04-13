class ResultRepositoryInMemory {
    constructor() {
        this.results = [];
    }

    async create(resultData) {
        const newResult = {
            ...resultData,
            createdAt: new Date(),
            updatedAt: new Date()
        };
        this.results.push(newResult);
        return newResult;
    }

    async findByGameId(gameId) {
        return this.results.find(result => result.gameId === gameId) || null;
    }
}

module.exports = ResultRepositoryInMemory;
