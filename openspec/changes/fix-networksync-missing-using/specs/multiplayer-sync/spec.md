## MODIFIED Requirements

### Requirement: Sincronització de moviment en temps real
El sistema SHALL permetre que un client enviï la seva posició i estat d'animació al servidor i que aquest els retransmeti als altres clients de la mateixa sala.

#### Scenario: Compilació de NetworkSync
- **WHEN** El compilador d'Unity processa `NetworkSync.cs`.
- **THEN** La directiva `using NativeWebSocket;` permet resoldre correctament els tipus relacionats amb l'estat del WebSocket (ex: `WebSocketState`).
