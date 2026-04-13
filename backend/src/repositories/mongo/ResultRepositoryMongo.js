const Result = require('../../models/Result');

class ResultRepositoryMongo {
    async create(resultData) {
        const result = new Result(resultData);
        return await result.save();
    }

    async findByGameId(gameId) {
        return await Result.findOne({ gameId });
    }
}

module.exports = ResultRepositoryMongo;
