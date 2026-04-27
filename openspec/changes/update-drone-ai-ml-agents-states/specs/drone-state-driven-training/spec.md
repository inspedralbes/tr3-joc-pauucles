## ADDED Requirements

### Requirement: Lógica de Estados del Dinosaurio
El dron SHALL clasificar la situación del dinosaurio de su equipo en uno de tres estados discretos para determinar su estrategia de movimiento y recompensa.

#### Scenario: Dinosaurio en base
- **WHEN** el dinosaurio está a una distancia menor a 0.5 unidades de la base del equipo
- **THEN** el sistema SHALL establecer el estado como `A_Salvo` (0).

#### Scenario: Dinosaurio robado
- **WHEN** un jugador de un equipo rival posee el dinosaurio
- **THEN** el sistema SHALL establecer el estado como `Robado` (1).

#### Scenario: Dinosaurio en el campo
- **WHEN** el dinosaurio no está en base ni lo lleva ningún jugador
- **THEN** el sistema SHALL establecer el estado como `Tirado` (2).

### Requirement: Sistema de Recompensas por Estado
El dron SHALL recibir incentivos específicos según el estado actual para optimizar su aprendizaje.

#### Scenario: Incentivo de guardia en base
- **WHEN** el estado es `A_Salvo`
- **THEN** el sistema SHALL otorgar una pequeña recompensa continua (0.001f) si el dron está cerca de la base y su velocidad es mínima.

#### Scenario: Incentivo de persecución o recuperación
- **WHEN** el estado es `Robado` o `Tirado`
- **THEN** el sistema SHALL otorgar una recompensa continua proporcional a la reducción de distancia hacia el objetivo actual.

#### Scenario: Recompensa por éxito
- **WHEN** el dron colisiona con el portador enemigo o el dinosaurio tirado
- **THEN** el sistema SHALL otorgar una recompensa discreta de 1.0f y SHALL finalizar el episodio.
