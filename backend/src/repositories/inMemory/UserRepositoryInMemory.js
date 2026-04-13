class UserRepositoryInMemory {
    constructor() {
        this.users = [];
    }

    async create(userData) {
        const newUser = {
            ...userData,
            coins: userData.coins ?? 0,
            skins: userData.skins ?? ['base']
        };
        this.users.push(newUser);
        return newUser;
    }

    async findByUsername(username) {
        return this.users.find(user => user.username === username) || null;
    }
}

module.exports = UserRepositoryInMemory;
