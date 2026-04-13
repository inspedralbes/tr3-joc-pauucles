class UserController {
    constructor(userService) {
        this.userService = userService;
    }

    async register(req, res) {
        try {
            const { username, password } = req.body;
            if (!username || !password) {
                return res.status(400).json({ error: 'Username and password are required' });
            }

            const user = await this.userService.register(username, password);
            
            // Convert to object and remove password
            const userResponse = user.toObject ? user.toObject() : { ...user };
            delete userResponse.password;

            res.status(201).json(userResponse);
        } catch (error) {
            res.status(400).json({ error: error.message });
        }
    }
}

module.exports = UserController;
