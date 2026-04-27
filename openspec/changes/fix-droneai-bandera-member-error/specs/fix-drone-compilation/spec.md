## ADDED Requirements

### Requirement: Referencia Correcta a Bandera
El `DroneAI` DEBE utilizar el miembro `equipPropietari` de la clase `Bandera` para realizar comparaciones de equipo.

#### Scenario: Búsqueda de Bandera del Equipo
- **WHEN** El dron ejecuta `BuscarDinosaurioEquipo()`.
- **THEN** El sistema DEBE comparar `b.equipPropietari` con `this.teamId`.
