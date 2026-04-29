class UserRepositoryInMemory {
    constructor() {
        this.users = [];
    }

    async create(userData) {
        const newUser = {
            ...userData,
            coins: userData.coins ?? 0,
            skins: userData.skins ?? ['base'],
            gamesPlayed: userData.gamesPlayed ?? 0,
            wins: userData.wins ?? 0,
            losses: userData.losses ?? 0
        };
        this.users.push(newUser);
        return newUser;
    }

    async findByUsername(username) {
        return this.users.find(user => user.username === username) || null;
    }
}

module.exports = UserRepositoryInMemory;
