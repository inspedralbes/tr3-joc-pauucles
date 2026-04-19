const bcrypt = require('bcrypt');

class UserService {
    constructor(userRepository) {
        this.userRepository = userRepository;
        this.saltRounds = 10;
    }

    async register(username, password) {
        const existingUser = await this.userRepository.findByUsername(username);
        if (existingUser) {
            throw new Error('El nom d\'usuari ja existeix');
        }

        const hashedPassword = await bcrypt.hash(password, this.saltRounds);
        const newUser = await this.userRepository.create({
            username,
            password: hashedPassword
        });

        return {
            id: newUser._id,
            username: newUser.username
        };
    }

    async login(username, password) {
        const user = await this.userRepository.findByUsername(username);
        if (!user) {
            throw new Error('Usuari o contrasenya incorrectes');
        }

        const isMatch = await bcrypt.compare(password, user.password);
        if (!isMatch) {
            throw new Error('Usuari o contrasenya incorrectes');
        }

        return {
            id: user._id,
            username: user.username,
            skinEquipada: user.skinEquipada
        };
    }

    async updateSkin(username, skinName) {
        const user = await this.userRepository.updateSkin(username, skinName);
        if (!user) {
            throw new Error('Usuari no trobat');
        }
        return {
            id: user._id,
            username: user.username,
            skinEquipada: user.skinEquipada
        };
    }
}

module.exports = UserService;
