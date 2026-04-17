## MODIFIED Requirements

### Requirement: Consolidació de la recollida de la bandera
El sistema HA DE centralitzar tota la lògica de recollida en un únic mètode Trigger, assegurant la compatibilitat amb l'estructura de fills de la mascota i eliminant qualsevol referència a variables o mètodes obsolets.

#### Scenario: Recollida consolidada en OnTriggerEnter2D
- **WHEN** El jugador entra en contacte amb un Trigger amb el tag "Bandera".
- **THEN** El sistema HA DE:
  1. Identificar el component `Bandera` en el pare de l'objecte de col·lisió.
  2. Ignorar col·lisions recursivament amb tots els colliders de la mascota.
  3. Iniciar el seguiment dinàmic.
  4. NO HA DE fer ús de la variable `banderaPortant`.
  5. NO HA DE realitzar comprovacions de tag "Bandera" en col·lisions físiques (OnCollisionEnter2D).
