const express = require('express');
const mongoose = require('mongoose');
const cors = require('cors');
const dotenv = require('dotenv');
const userRoutes = require('./routes/userRoutes');

dotenv.config();

const app = express();

app.use(cors());
app.use(express.json());

app.use('/api/users', userRoutes);

mongoose.connect(process.env.MONGO_URI)
    .then(() => {
        console.log('Base de dades connectada correctament');
    })
    .catch((err) => {
        console.error('Error connectant a la base de dades:', err);
    });

const PORT = process.env.PORT || 3000;

app.listen(PORT, () => {
    console.log(`Servidor funcionant al port ${PORT}`);
});
