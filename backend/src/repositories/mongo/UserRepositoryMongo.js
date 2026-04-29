const User = require('../../models/User');

class UserRepositoryMongo {
    async create(userData) {
        const user = new User(userData);
        return await user.save();
    }

    async findByUsername(username) {
        return await User.findOne({ username });
    }

    async updateSkin(username, skinName) {
        return await User.findOneAndUpdate(
            { username },
            { skinEquipada: skinName },
            { new: true }
        );
    }
}

module.exports = UserRepositoryMongo;
