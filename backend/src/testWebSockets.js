const WebSocket = require('ws');
const axios = require('axios');

const API_URL = 'http://localhost:3000/api';
const WS_URL = 'ws://localhost:3000';

async function testWebSocketSync() {
    console.log('--- Iniciant test de WebSockets ---');
    
    const ws = new WebSocket(WS_URL);
    
    ws.on('open', () => {
        console.log('Connectat al servidor WebSocket');
    });

    ws.on('message', (data) => {
        const msg = JSON.parse(data);
        console.log('Missatge rebut via WS:', msg.type);
        if (msg.type === 'ACTUALITZAR_SALES') {
            console.log('OK: Rebut ACTUALITZAR_SALES');
        }
        if (msg.type === 'ROOM_UPDATED') {
            console.log('OK: Rebut ROOM_UPDATED');
        }
    });

    // Esperar a que connecti
    await new Promise(resolve => setTimeout(resolve, 1000));

    try {
        console.log('Provant CREACIÓ de sala...');
        const createRes = await axios.post(`${API_URL}/games/create`, {
            host: 'testUser',
            teamAColor: '#FF0000',
            teamBColor: '#0000FF',
            maxPlayers: 4
        });
        const roomId = createRes.data.roomId;
        console.log('Sala creada:', roomId);

        await new Promise(resolve => setTimeout(resolve, 1000));

        console.log('Provant JOIN de sala...');
        await axios.post(`${API_URL}/games/join`, {
            roomId: roomId,
            username: 'player2',
            team: 'B'
        });

        await new Promise(resolve => setTimeout(resolve, 1000));

        console.log('Provant READY...');
        ws.send(JSON.stringify({
            type: 'READY',
            roomId: roomId,
            username: 'testUser'
        }));

        await new Promise(resolve => setTimeout(resolve, 2000));

    } catch (error) {
        console.error('Error durant el test:', error.response ? error.response.data : error.message);
    } finally {
        ws.close();
        console.log('Test finalitzat');
    }
}

testWebSocketSync();
