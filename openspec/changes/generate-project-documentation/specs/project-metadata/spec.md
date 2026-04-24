## ADDED Requirements

### Requirement: Project Core Information
El fitxer `README.md` SHALL contenir el títol del projecte, la llista d'integrants del grup, l'enllaç al gestor de tasques Taiga i una descripció funcional del joc.

#### Scenario: Verify README content
- **WHEN** un usuari obre el fitxer `README.md`
- **THEN** ha de visualitzar clarament els membres del grup i la descripció del projecte "Atrapa el dinosaure"

### Requirement: Language Consistency
Tota la documentació generada SHALL estar redactada íntegrament en català per mantenir la coherència amb les directrius del projecte.

#### Scenario: Verify Language
- **WHEN** s'analitzen els fitxers de documentació
- **THEN** no s'han de trobar seccions en altres idiomes que no siguin el català
