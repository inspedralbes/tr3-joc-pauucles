## 1. Implementació de l'Script de Seeding

- [x] 1.1 Crear `backend/seed.js` amb la configuració de connexió a MongoDB.
- [x] 1.2 Implementar la lògica de neteja de les col·leccions `users`, `games` i `results`.
- [x] 1.3 Definir dades de prova (3 usuaris, 2 sales, resultats d'exemple).
- [x] 1.4 Implementar la inserció seqüencial de dades assegurant la integritat referencial (IDs d'usuaris en sales/resultats).
- [x] 1.5 Afegir tancament net de la connexió i logs informatius.

## 2. Ampliació de la Suite de Tests Unitaris

- [x] 2.1 Crear `backend/src/testGameRepository.js` basat en el patró de `testRepositories.js`.
- [x] 2.2 Implementar tests per a `createGame`, `findGameById` i `deleteGame`.
- [x] 2.3 Crear `backend/src/testResultRepository.js`.
- [x] 2.4 Implementar tests per a `saveResult` i `getResultsByUserId`.
- [x] 2.5 Validar que tots els tests passen correctament amb una base de dades neta (pot usar-se el seed).

## 3. Integració i Documentació

- [x] 3.1 Afegir un script al `package.json` del backend per executar el seed (ex: `"seed": "node seed.js"`).
- [x] 3.2 Verificar que el seed i els tests funcionen en l'entorn local.
- [x] 3.3 Actualitzar el README.md si cal amb instruccions sobre com inicialitzar dades per a desenvolupament.
