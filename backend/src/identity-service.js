const express = require('express');
const cors = require('cors');
const connectDB = require('./db');
const userRoutes = require('./routes/userRoutes');

const app = express();

// Middleware
app.use(cors());
app.use(express.json());

// Routes
app.use('/api/users', userRoutes);

// Connect to DB and Start Server
connectDB().then(() => {
    const PORT = process.env.IDENTITY_PORT || 3001;
    app.listen(PORT, () => {
        console.log(`Identity Service funcionant al port ${PORT}`);
    });
});
