const http = require('http');

const userData = JSON.stringify({
    username: 'newuser_' + Date.now(),
    password: 'securepassword123'
});

const options = {
    hostname: 'localhost',
    port: 3000,
    path: '/api/users/register',
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
        'Content-Length': userData.length
    }
};

function makeRequest(data) {
    return new Promise((resolve, reject) => {
        const req = http.request(options, (res) => {
            let body = '';
            res.on('data', (chunk) => body += chunk);
            res.on('end', () => {
                resolve({
                    status: res.statusCode,
                    body: JSON.parse(body)
                });
            });
        });

        req.on('error', (e) => reject(e));
        req.write(data);
        req.end();
    });
}

async function runTests() {
    console.log('--- Testing User Registration Endpoint ---');
    try {
        // Test 1: Successful Registration
        console.log('Scenario: Successful registration...');
        const res1 = await makeRequest(userData);
        console.log('Status:', res1.status);
        console.log('Body:', res1.body);
        
        if (res1.status === 201 && !res1.body.password && res1.body.username) {
            console.log('✓ Registration successful');
        } else {
            console.error('✗ Registration failed');
        }

        // Test 2: Duplicate Registration
        console.log('\nScenario: Duplicate registration...');
        const res2 = await makeRequest(userData);
        console.log('Status:', res2.status);
        console.log('Body:', res2.body);

        if (res2.status === 400 && res2.body.error === 'User already exists') {
            console.log('✓ Duplicate detection successful');
        } else {
            console.error('✗ Duplicate detection failed');
        }

    } catch (err) {
        console.error('! Test error (ensure server is running):', err.message);
    }
}

runTests();
