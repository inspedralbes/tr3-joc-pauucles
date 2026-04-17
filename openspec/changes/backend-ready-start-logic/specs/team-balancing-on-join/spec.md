## ADDED Requirements

### Requirement: Assignació d'equips en unir-se a una sala
El servidor SHALL assignar automàticament un equip al jugador que s'uneix a una sala existent per garantir un enfrontament equilibrat (habitualment 1vs1).

#### Scenario: Segon jugador s'uneix a sala
- **WHEN** un jugador invoca la ruta `/join` i el host de la sala ja està a l'equip "A" (o "Rojo").
- **THEN** el sistema assigna automàticament el nou jugador a l'equip "B" (o "Azul").

#### Scenario: Prevenció de l'estat Espectador per defecte
- **WHEN** un jugador s'uneix a una sala que té vacants en els equips principals.
- **THEN** el sistema mai assignarà "Espectador" si hi ha lloc en un equip de combat.
