class GameService {
    constructor(gameRepository) {
        this.gameRepository = gameRepository;
    }

    async createGame(host, teamAColor = 'red', teamBColor = 'blue', maxPlayers = 4) {
        const roomId = Math.random().toString(36).substring(2, 9).toUpperCase();
        
        const gameData = {
            roomId,
            host,
            teamAColor,
            teamBColor,
            maxPlayers,
            players: [{ username: host, team: 'A', isReady: false }],
            status: 'waiting'
        };

        return await this.gameRepository.create(gameData);
    }

    async listWaitingGames() {
        // Since we don't have a specific list method in repository yet, 
        // we might need to assume the repo can handle filtering or get all and filter here.
        // For Mongo, we should ideally have a find method.
        // I'll assume the repository has a generic find method or I will add it if it's missing.
        // Looking at GameRepositoryMongo, it doesn't have list.
        // I'll check GameRepositoryMongo.js again.
        return await this.gameRepository.findAllWaiting(); 
    }

    async joinGame(roomId, username, team) {
        const game = await this.gameRepository.findByRoomId(roomId);
        
        if (!game) {
            throw new Error('La partida no existeix');
        }

        if (game.status !== 'waiting') {
            throw new Error('La partida ja ha començat o ha finalitzat');
        }

        if (game.players.length >= game.maxPlayers) {
            throw new Error('La sala està plena');
        }

        if (game.players.some(p => p.username === username)) {
            throw new Error('El jugador ja és a la sala');
        }

        // Lògica d'assignació d'equips automàtica (Equilibri A/B)
        let assignedTeam = team;
        if (game.players.length === 1) {
            const hostTeam = game.players[0].team;
            assignedTeam = (hostTeam === 'A') ? 'B' : 'A';
        }

        const updatedPlayers = [...game.players, { username, team: assignedTeam, isReady: false }];
        
        return await this.gameRepository.update(roomId, { players: updatedPlayers });
    }

    async setReady(roomId, username) {
        const updatedGame = await this.gameRepository.updatePlayerReady(roomId, username, true);
        if (!updatedGame) throw new Error('La partida no existeix o el jugador no s\'ha trobat');

        console.log(`Document de la sala actualitzat (READY):`, JSON.stringify(updatedGame, null, 2));
        return updatedGame;
    }

    async checkGameStart(roomId, gameData = null) {
        const game = gameData || await this.gameRepository.findByRoomId(roomId);
        if (!game || game.status !== 'waiting') return null;

        const allReady = game.players.length === game.maxPlayers && game.players.every(p => p.isReady);

        if (allReady) {
            console.log(`Iniciant partida a la sala ${roomId}. Tots els jugadors llestos.`);
            return await this.gameRepository.update(roomId, { status: 'playing' });
        }

        return null;
    }

    async toggleReady(roomId, username) {
        const game = await this.gameRepository.findByRoomId(roomId);
        if (!game) throw new Error('La partida no existeix');

        const updatedPlayers = game.players.map(p => {
            if (p.username === username) {
                return { ...p, isReady: !p.isReady };
            }
            return p;
        });

        return await this.gameRepository.update(roomId, { players: updatedPlayers });
    }

    async leaveGame(roomId, username) {
        const game = await this.gameRepository.findByRoomId(roomId);
        if (!game) throw new Error('La partida no existeix');

        if (game.host === username) {
            console.log(`El host ${username} ha marxat de la sala ${roomId}. Eliminant sala.`);
            await this.deleteGame(roomId);
            return null; // Indica que la sala s'ha eliminat
        } else {
            console.log(`L'usuari ${username} ha marxat de la sala ${roomId}.`);
            const updatedGame = await this.gameRepository.pullPlayer(roomId, username);
            
            // Si la sala queda buida, l'eliminem
            if (updatedGame && updatedGame.players.length === 0) {
                console.log(`La sala ${roomId} ha quedat buida. Eliminant-la.`);
                await this.deleteGame(roomId);
                return null;
            }
            
            return updatedGame;
        }
    }

    async deleteGame(roomId) {
        // Assumeix que el repositori té un mètode delete o similar. 
        // Si no el té, l'haurem d'afegir.
        return await this.gameRepository.delete(roomId);
    }
}

module.exports = GameService;
