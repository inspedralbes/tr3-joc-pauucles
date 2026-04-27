## ADDED Requirements

### Requirement: Observació de l'Objectiu Clau
El dron SHALL ser capaç de detectar quin jugador té la possessió de l'ítem clau (bandera o dinosaure) per enfocar la seva recollida d'observacions.

#### Scenario: Jugador amb dinosaure detectat
- **WHEN** un jugador té l'ítem clau (`isCarryingDino` o similar)
- **THEN** la IA SHALL incloure la posició d'aquest jugador en el seu vector d'observacions.

#### Scenario: Cap jugador amb dinosaure
- **WHEN** cap jugador té l'ítem clau
- **THEN** la IA SHALL incloure la posició original de l'ítem (o la seva posició actual al camp) en el seu vector d'observacions.
