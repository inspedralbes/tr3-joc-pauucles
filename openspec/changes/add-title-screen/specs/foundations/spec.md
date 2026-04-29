## ADDED Requirements

### Requirement: Session-aware UI Initialization
La lògica d'inicialització de la interfície SHALL verificar l'estat de la sessió abans de decidir quina pantalla mostrar, prioritzant la pantalla de títol per a nous usuaris.

#### Scenario: Initialization without session
- **WHEN** el `MenuManager` executa `ActualitzarVisibilitatSegonsSessio` i no hi ha dades d'usuari
- **THEN** s'ha d'assegurar que només la `PantallaTitol` és visible entre les pantalles d'entrada
