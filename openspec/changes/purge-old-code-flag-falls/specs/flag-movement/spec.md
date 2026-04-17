## MODIFIED Requirements

### Requirement: Purga i estandardització de la recollida
El sistema HA DE purgar qualsevol lògica de recollida antiga i substituir-la per un mètode robust que asseguri la independència física de la bandera i l'activació del seu estat dinàmic.

#### Scenario: Recollida purgada i segura
- **WHEN** Un jugador recull la bandera.
- **THEN** El sistema HA DE:
  1. Assignar la referència.
  2. Treure el parentiu.
  3. Ignorar col·lisions recursivament amb tots els fills.
  4. Configurar el `bodyType` a `Dynamic`.
  5. Habilitar el collider.
  6. Iniciar el seguiment.
