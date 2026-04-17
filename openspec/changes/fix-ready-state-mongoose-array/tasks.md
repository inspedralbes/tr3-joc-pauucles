## 1. Backend (Actualització Atòmica)

- [x] 1.1 Modificar el mètode `setReady` a `GameService.js` (o allà on es gestioni el missatge WebSocket `READY`) per utilitzar `findOneAndUpdate` amb l'operador posicional `$`.
- [x] 1.2 Afegir un `console.log` per mostrar el document de la sala retornat i validar que `isReady` és `true`.
- [x] 1.3 Assegurar que el mètode retorna el document actualitzat per ser usat en les següents fases.

## 2. Lògica d'Inici de Partida

- [x] 2.1 Actualitzar el mètode `checkGameStart` per utilitzar el document fresc retornat de la base de dades.
- [x] 2.2 Implementar la validació `every(p => p.isReady)` sobre la llista de jugadors actualitzada.
- [x] 2.3 Realitzar el canvi d'status a `playing` mitjançant un nou guardat si es compleixen les condicions.

## 3. Verificació i Proves

- [ ] 3.1 Provar el flux amb dos usuaris i confirmar que la sala passa a estat `playing` automàticament.
- [ ] 3.2 Verificar al log del servidor que el `isReady` apareix correctament persistit.
