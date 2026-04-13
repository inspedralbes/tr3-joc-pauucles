const User = require('../../models/User');

class UserRepositoryMongo {
    async create(userData) {
        const user = new User(userData);
        return await user.save();
    }

    async findByUsername(username) {
        return await User.findOne({ username });
    }
}

module.exports = UserRepositoryMongo;
