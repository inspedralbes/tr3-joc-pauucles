## Context

The backend is already initialized with an entry point at `src/server.js`. To facilitate the development and execution of the server, the `package.json` file needs to be updated with appropriate scripts.

## Goals / Non-Goals

**Goals:**
- Provide a standard command to start the server in production (`npm start`).
- Provide a command for development with automatic reloads using `nodemon` (`npm run dev`).
- Clean up the default script section.

**Non-Goals:**
- Implementing actual tests.
- Adding complex deployment scripts.

## Decisions

- **Development Tool**: Recommend **nodemon** for the `dev` script. Nodemon is the industry standard for development in Node.js, providing automatic reloads on file changes.
- **Production Execution**: Use **node** directly for the `start` script to ensure minimal overhead and compatibility with production environments.
- **Test Removal**: Remove the default `test` script because no testing framework is currently configured, avoiding misleading "no test specified" errors.

## Risks / Trade-offs

- [Risk] Running `npm run dev` will fail if `nodemon` is not installed. → **Mitigation**: Ensure `nodemon` is added as a development dependency or instructed to be installed.
