# Documentació del Patró Repository

## Separació de Responsabilitats
Aquest projecte implementa el patró **Repository** per garantir una separació clara entre la persistència de dades i la lògica de negoci. L'estructura seguida és:

1.  **Repository (Dades)**: L'única part del codi que sap *on* i *com* es guarden les dades (MongoDB o In-Memory). Implementa operacions CRUD bàsiques.
2.  **Service (Lògica)**: Conté les regles de negoci (ex: validar si una sala és plena, assignar equips). Crida al Repository per obtenir o guardar dades.
3.  **Controller (HTTP/WS)**: Gestiona la comunicació externa. Rep les peticions, crida als serveis i torna la resposta al client.

## Implementacions de Repositoris
S'han creat dues implementacions per a cada entitat principal (Users, Games, Results):

-   **Implementació Mongo**: Utilitza `Mongoose` per persistir dades en una base de dades MongoDB Atlas. Ideal per a producció.
-   **Implementació In-Memory**: Guarda les dades en objectes JavaScript (`Map` o `Array`) en memòria. Això permet executar tests unitaris ràpids sense necessitat d'una base de dades activa.

## Justificació
Aquesta arquitectura permet:
- **Testibilitat**: Podem provar tota la lògica de joc usant el repositori en memòria.
- **Flexibilitat**: Si en el futur volem canviar MongoDB per SQL, només haurem de crear una nova implementació del repositori sense tocar la lògica de negoci.
- **Desacoblament**: Els serveis no saben res de la implementació de la base de dades.
