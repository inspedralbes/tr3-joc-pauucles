const bcrypt = require('bcrypt');

class UserService {
    constructor(userRepository) {
        this.userRepository = userRepository;
    }

    async register(username, password) {
        const existingUser = await this.userRepository.findByUsername(username);
        if (existingUser) {
            throw new Error('User already exists');
        }

        const hashedPassword = await bcrypt.hash(password, 10);
        return await this.userRepository.create({
            username,
            password: hashedPassword
        });
    }
}

module.exports = UserService;
