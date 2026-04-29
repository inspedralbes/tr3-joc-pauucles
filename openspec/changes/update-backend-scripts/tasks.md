## 1. Setup

- [x] 1.1 Install `nodemon` as a development dependency: `npm install --save-dev nodemon` in the `backend` directory.

## 2. Update package.json Scripts

- [x] 2.1 Open `backend/package.json`.
- [x] 2.2 Add `"start": "node src/server.js"` to the `scripts` section.
- [x] 2.3 Add `"dev": "nodemon src/server.js"` to the `scripts` section.
- [x] 2.4 Remove the existing `test` script from the `scripts` section.

## 3. Verification

- [x] 3.1 Verify that the `scripts` section only contains the `start` and `dev` scripts.
- [x] 3.2 Test the start script by running `npm start` in the `backend` directory.
- [x] 3.3 Test the development script by running `npm run dev` in the `backend` directory (optional if nodemon is installed).
