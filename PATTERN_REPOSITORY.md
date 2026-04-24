# Patró Repository - Atrapa el Dinosaure

El projecte utilitza el **Patró Repository** per gestionar la capa de persistència. Aquest patró actua com una capa d'abstracció entre la lògica de negoci (serveis) i el mecanisme d'emmagatzematge de dades (MongoDB o Memòria).

## Conceptes Clau
* **Desacoblament**: Els serveis no saben si les dades estan en una base de dades real o en un array en memòria.
* **Testabilitat**: Podem utilitzar repositoris "In-Memory" per a tests unitaris ràpids sense dependre d'una base de dades externa.
* **Flexibilitat**: Canviar de MongoDB a una altra base de dades (com PostgreSQL) només requeriria crear una nova implementació del repositori sense tocar la lògica de negoci.

## Implementacions de l'Interfície

### 1. Versió en Memòria (`UserRepositoryInMemory.js`)
Ideal per a proves o entorns on no es requereix persistència permanent.

```javascript
class UserRepositoryInMemory {
    constructor() {
        this.users = [];
    }

    async create(userData) {
        const newUser = { ...userData };
        this.users.push(newUser);
        return newUser;
    }

    async findByUsername(username) {
        return this.users.find(u => u.username === username) || null;
    }
}
```

### 2. Versió en MongoDB (`UserRepositoryMongo.js`)
Utilitzada en producció i desenvolupament real, utilitzant **Mongoose**.

```javascript
const User = require('../../models/User');

class UserRepositoryMongo {
    async create(userData) {
        const user = new User(userData);
        return await user.save();
    }

    async findByUsername(username) {
        return await User.findOne({ username });
    }
}
```

## Com afegir un nou Repositori
Si necessites crear un repositori per a una nova entitat (ex: `SkinRepository`):

1. **Defineix el Model**: Crea el esquema de Mongoose a `backend/src/models/`.
2. **Crea la Interfície/Classe Base**: Tot i que en JavaScript no hi ha interfícies estrictes, crea la classe a `backend/src/repositories/mongo/` seguint el mateix nom de mètodes.
3. **Injecta el Repositori**: Al teu servei o ruta, instancia el repositori que vulguis utilitzar:
   ```javascript
   const repo = new SkinRepositoryMongo();
   const service = new SkinService(repo);
   ```

Aquesta estructura ens permet escalar el sistema de dades sense afectar el comportament del joc.
