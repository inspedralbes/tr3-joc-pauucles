const express = require('express');
const router = express.Router();
const GameRepositoryMongo = require('../repositories/mongo/GameRepositoryMongo');
const GameService = require('../services/GameService');
const GameController = require('../controllers/GameController');

module.exports = (wss) => {
    const gameRepository = new GameRepositoryMongo();
    const gameService = new GameService(gameRepository);
    const gameController = new GameController(gameService, wss);

    router.post('/create', (req, res) => gameController.create(req, res));
    router.get('/list', (req, res) => gameController.list(req, res));
    router.post('/join', (req, res) => gameController.join(req, res));

    return { router, gameService, gameController };
};
