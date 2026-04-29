## Why

Actualment, el procés de desenvolupament i proves es veu dificultat per la manca d'un estat inicial de la base de dades consistent i automatitzat. A més, la cobertura de tests unitaris per a la capa de dades (repositoris) és incompleta, cosa que augmenta el risc de regressions en modificar la lògica d'accés a dades de jocs i resultats.

## What Changes

- **Nou script de seed**: Creació de `backend/seed.js` per carregar dades de prova inicials (usuaris, sales i resultats) a MongoDB de forma determinista.
- **Ampliació de tests unitaris**: Creació de nous arxius de test per a `GameRepositoryMongo` i `ResultRepositoryMongo` per assegurar el correcte funcionament de les operacions CRUD bàsiques.
- **Millora del workflow de desenvolupament**: Inclusió d'una eina per netejar i repoblar la base de dades ràpidament.

## Capabilities

### New Capabilities
- `data-seeding`: Capacitat per inicialitzar la base de dades amb dades de prova estructurades.
- `repository-testing-suite`: Suite de tests unitaris per validar la integritat de la capa de persistència de jocs i resultats.

### Modified Capabilities
- `foundations`: S'inclouen requeriments sobre la consistència de dades i mètodes de verificació automàtica.

## Impact

- `backend/seed.js`: Nou arxiu a l'arrel del backend.
- `backend/src/testRepositories.js`: Serà ampliat o complementat amb nous arxius de test.
- `backend/src/repositories/mongo/`: Es validaran els repositoris existents.
- Base de dades MongoDB: Es veurà afectada per les operacions de neteja i inserció de l'script de seed.
