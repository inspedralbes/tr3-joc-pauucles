## 1. Implementació al Servidor

- [x] 1.1 Modificar `backend/src/server.js` per afegir el listener `ws.on("message")`.
- [x] 1.2 Implementar el parseig JSON dels missatges entrants.
- [x] 1.3 Afegir la lògica per al tipus de missatge `leave_room`.
- [x] 1.4 Integrar les operacions de base de dades per actualitzar la llista de jugadors i esborrar sales buides.

## 2. Verificació

- [x] 2.1 Verificar que el servidor backend compila i arranca correctament.
- [x] 2.2 Comprovar la lògica de sortida de sala (p. ex. mitjançant un script de test que enviï el missatge JSON).
