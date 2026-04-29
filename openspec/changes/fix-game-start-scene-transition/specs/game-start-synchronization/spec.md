## ADDED Requirements

### Requirement: Notificació personalitzada d'inici de partida
El servidor SHALL enviar un missatge de tipus `PARTIDA_INICIADA` a cada client de la sala quan es compleixin les condicions d'inici (tots llestos i sala plena).

#### Scenario: Enviament de dades d'identitat
- **WHEN** l'status de la sala canvia a `playing`.
- **THEN** el servidor envia a cada client un JSON amb els camps `username`, `team` i `color` (assignat segons l'equip A/B i els colors de la sala).

### Requirement: Transició d'escena automatitzada a Unity
El client d'Unity SHALL processar el missatge d'inici de partida i carregar l'escena de joc de forma segura.

#### Scenario: Càrrega d'escena 'Bosque'
- **WHEN** el script `WebSocketClient` rep el missatge `PARTIDA_INICIADA`.
- **THEN** el sistema guarda les dades del jugador en variables estàtiques, posa el flag `shouldStartGame` a true i l'Update executa `SceneManager.LoadScene("Bosque")`.
