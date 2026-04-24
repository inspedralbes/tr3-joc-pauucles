## ADDED Requirements

### Requirement: Test-Driven Repository Integrity
Tota nova implementació en la capa de persistència SHALL anar acompanyada d'un test unitari que validi el seu contracte de servei.

#### Scenario: Verify new repository method
- **WHEN** s'afegeix un mètode a un repositori
- **THEN** s'ha de poder executar un test que confirmi la seva correctesa funcional

### Requirement: Deterministic Environment Initialization
L'entorn de desenvolupament SHALL poder-se restablir a un estat conegut mitjançant una única comanda de inicialització de dades.

#### Scenario: Reset Environment
- **WHEN** el desenvolupador executa l'script de seeding
- **THEN** la base de dades es troba en un estat vàlid per a proves manuals o automàtiques
