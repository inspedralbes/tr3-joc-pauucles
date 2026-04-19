class UserController {
    constructor(userService) {
        this.userService = userService;
    }

    async register(req, res) {
        const { username, password } = req.body;
        if (!username || !password) {
            return res.status(400).json({ error: 'Falten camps obligatoris' });
        }

        try {
            const user = await this.userService.register(username, password);
            res.status(201).json(user);
        } catch (error) {
            res.status(400).json({ error: error.message });
        }
    }

    async login(req, res) {
        const { username, password } = req.body;
        if (!username || !password) {
            return res.status(400).json({ error: 'Falten camps obligatoris' });
        }

        try {
            const user = await this.userService.login(username, password);
            res.status(200).json(user);
        } catch (error) {
            res.status(401).json({ error: error.message });
        }
    }

    async updateSkin(req, res) {
        const { username, skinName } = req.body;
        if (!username || !skinName) {
            return res.status(400).json({ error: 'Falten camps obligatoris' });
        }

        try {
            const user = await this.userService.updateSkin(username, skinName);
            res.status(200).json(user);
        } catch (error) {
            res.status(400).json({ error: error.message });
        }
    }
}

module.exports = UserController;
