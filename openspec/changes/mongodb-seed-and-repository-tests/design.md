## Context

El projecte backend utilitza Node.js, Express i MongoDB (via Mongoose). Actualment existeixen repositoris per a usuaris, jocs i resultats, però no hi ha una eina per inicialitzar la base de dades amb dades consistents de prova. Els tests unitaris existents són limitats i es troben principalment en arxius de script individuals (`testRegistration.js`, `testRepositories.js`).

## Goals / Non-Goals

**Goals:**
- Proporcionar un mecanisme d'inicialització de dades (`seed.js`) que pugui ser executat manualment.
- Estendre la suite de tests per cobrir els repositoris de jocs i resultats.
- Assegurar que els tests siguin independents i netegin el seu propi estat.

**Non-Goals:**
- Implementar un framework de testing complet com Jest o Mocha (es mantindran els scripts de test senzills existents per coherència, o s'ampliaran seguint el seu patró).
- Crear un sistema de seeding complex amb fitxers externs (JSON/YAML); les dades estaran hardcoded en l'script per simplicitat inicial.

## Decisions

### 1. Script de Seeding (`seed.js`)
- **Decisió**: Crear un script autònom que utilitzi els models existents de Mongoose per inserir dades.
- **Racional**: Reutilitza la lògica de negoci i les validacions de esquema ja definides.
- **Alternativa**: Insercions directes via driver de MongoDB o `mongoimport`. Es descarta per mantenir la coherència amb els models.

### 2. Ampliació de Tests Unitaris
- **Decisió**: Crear `testGameRepository.js` i `testResultRepository.js` seguint el patró de `testRepositories.js`.
- **Racional**: Mantenir la simplicitat del projecte actual sense introduir noves dependències de testing si no és estrictament necessari. Els scripts utilitzaran `console.assert` o verificacions manuals.

### 3. Neteja de col·leccions
- **Decisió**: L'script de seed utilitzarà `deleteMany({})` en cada col·lecció abans de la inserció.
- **Racional**: És la forma més ràpida i segura de garantir un estat "net" per a les proves.

## Risks / Trade-offs

- **[Risc] Execució accidental en producció** → **Mitigació**: L'script de seed ha de comprovar una variable d'entorn o demanar confirmació si `process.env.NODE_ENV === 'production'`.
- **[Risc] Inconsistència de dades (IDs)** → **Mitigació**: Es definiran IDs fixes (ObjectIDs vàlids) per als usuaris de prova en el seed per permetre que altres scripts (com els de jocs) puguin fer-hi referència de forma predictible.
