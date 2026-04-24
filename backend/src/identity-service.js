const express = require('express');
const cors = require('cors');
const dotenv = require('dotenv');
const connectDB = require('./db');
const userRoutes = require('./routes/userRoutes');

dotenv.config();

const app = express();

// Connect to Database
connectDB();

app.use(cors());
app.use(express.json());

// Routes
app.use('/api/users', userRoutes);

const PORT = process.env.IDENTITY_PORT || 3001;

app.listen(PORT, () => {
    console.log(`Identity Service funcionant al port ${PORT}`);
});
