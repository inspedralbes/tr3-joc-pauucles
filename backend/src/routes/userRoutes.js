const express = require('express');
const router = express.Router();
const UserRepositoryMongo = require('../repositories/mongo/UserRepositoryMongo');
const UserService = require('../services/UserService');
const UserController = require('../controllers/UserController');

const userRepository = new UserRepositoryMongo();
const userService = new UserService(userRepository);
const userController = new UserController(userService);

router.post('/register', (req, res) => userController.register(req, res));

module.exports = router;
