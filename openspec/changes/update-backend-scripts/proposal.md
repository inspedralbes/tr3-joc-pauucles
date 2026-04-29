## Why

The backend project needs standard execution and development scripts to streamline the workflow. Adding `start` and `dev` scripts ensures consistency in how the server is run across different environments.

## What Changes

- Modify `backend/package.json` to update the `scripts` section.
- Add `start` script: `"node src/server.js"`.
- Add `dev` script: `"nodemon src/server.js"`.
- Remove the default `test` script.

## Capabilities

### New Capabilities
- `backend-scripts`: Provides standardized scripts for starting the server in production and development modes.

### Modified Capabilities
- None.

## Impact

- **Affected Files**: `backend/package.json`.
- **Dependencies**: Suggests the use of `nodemon` for the development environment.
