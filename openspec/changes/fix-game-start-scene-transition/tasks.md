## 1. Backend (Notificació d'Inici)

- [x] 1.1 Implementar el mètode de broadcast `PARTIDA_INICIADA` al backend un cop l'estatus és `playing`.
- [x] 1.2 Assegurar que el JSON enviat a cada client conté `username`, `team` i `color` correctes.

## 2. Unity (Gestió del Canvi d'Escena)

- [x] 2.1 Verificar que `WebSocketClient.cs` processa correctament el missatge `PARTIDA_INICIADA`.
- [x] 2.2 Validar que les variables estàtiques de sessió es guarden abans d'activar `shouldStartGame`.
- [x] 2.3 Confirmar que l'Update realitza el `SceneManager.LoadScene("Bosque")` de forma fluida.

## 3. Verificació

- [ ] 3.1 Provar amb dos jugadors que el canvi d'escena ocorre simultàniament.
- [ ] 3.2 Verificar que en arribar a la nova escena, cada jugador té el color i nom configurat pel servidor.
