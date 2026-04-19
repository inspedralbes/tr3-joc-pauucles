# Pla d'Implementació: Sincronització de Minijocs

## fase 1: Backend
1. **Modificar `server.js`**:
   - Afegir gestió de missatges tipus `MINIJOC_START`, `MINIJOC_UPDATE` i `MINIJOC_RESULT` per a que es facin broadcast a tots els clients.

## fase 2: Client Unity (Base)
1. **Modificar `Player.cs`**:
   - En `OnCollisionEnter2D`, si és el jugador local qui col·lisiona:
     - Generar `gameIndex` (evitant el 4).
     - Enviar missatge `MINIJOC_START` via WebSocket.
2. **Modificar `MenuManager.cs`**:
   - Afegir mètodes de suport per enviar `MINIJOC_START`.
   - Assegurar que el handler `AlRebreActualitzacioSales` processi correctament els nous tipus de missatges.
3. **Modificar `MinijocUIManager.cs`**:
   - Eliminar ID 4 de la llista de noms.
   - Corregir `FinalitzarCombat` per determinar el guanyador localment de forma correcta (basat en el rol d'atacant/defensor).

## fase 3: Client Unity (Lògica de Minijocs)
1. **Parells i Senars**:
   - Modificar per enviar els números si som el "Host" (qui ha iniciat el xoc).
   - Rebre i assignar els números si som el rival.
2. **Atura la Barra**:
   - Modificar per enviar la posició de la zona objectiu si som el "Host".
   - Rebre i assignar la zona si som el rival.
3. **Acaparament de Mirades**:
   - Implementar enviament de `CHOICE:` quan es tria una direcció.
   - Sincronitzar la fi del joc quan ambdues eleccions estiguin disponibles.

## fase 4: Verificació
1. Proves manuals amb dos clients connectats.
2. Verificació que cap minijoc es queda penjat per pèrdua de paquets (implementar timeouts si cal).
