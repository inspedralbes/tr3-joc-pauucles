## 1. Project Setup

- [x] 1.1 Install backend dependencies: `express`, `mongoose`, `cors`, and `dotenv`.
- [x] 1.2 Create the `backend/src` directory structure.
- [x] 1.3 Ensure a `.env` file exists with `MONGO_URI` and `PORT` variables.

## 2. Core Implementation

- [x] 2.1 Create `backend/src/server.js` and import required modules.
- [x] 2.2 Initialize Express app and configure `dotenv.config()`.
- [x] 2.3 Apply `cors()` and `express.json()` middlewares.
- [x] 2.4 Implement MongoDB connection logic using `mongoose.connect()`.
- [x] 2.5 Add success and error handlers for the database connection.
- [x] 2.6 Configure the server listener on the specified port.

## 3. Verification

- [x] 3.1 Start the server and verify successful database connection log: "Base de dades connectada correctament".
- [x] 3.2 Verify successful server startup log: "Servidor funcionant al port 3000" (or specified port).
- [x] 3.3 Test a basic request (if any endpoint is added) or ensure no crash occurs on startup.
