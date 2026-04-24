## ADDED Requirements

### Requirement: Initial Welcome Interface
El sistema SHALL mostrar una pantalla de títol ("PantallaTitol") com a primer element visual quan el joc s'inicia i no hi ha cap sessió d'usuari activa.

#### Scenario: Display title screen on start
- **WHEN** l'aplicació s'arrenca per primer cop
- **THEN** l'element `PantallaTitol` ha d'estar visible i els elements de login amagats

### Requirement: Transition to Authentication
El sistema SHALL permetre la transició de la pantalla de títol a la pantalla de login mitjançant un botó d'interacció ("btnStartGame").

#### Scenario: Click start button
- **WHEN** l'usuari fa clic al botó `btnStartGame`
- **THEN** la `PantallaTitol` s'ha d'amagar i la `pantallaLogin` s'ha de mostrar amb un estil `Flex`
