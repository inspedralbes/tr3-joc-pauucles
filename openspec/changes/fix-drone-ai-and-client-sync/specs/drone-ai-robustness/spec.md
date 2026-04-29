## ADDED Requirements

### Requirement: Protecció contra Referències Nul·les en la IA
L'IA del dron SHALL gestionar de forma segura l'absència d'objectius físics a l'escena durant la recollida d'observacions per evitar el bloqueig del model de ML-Agents.

#### Scenario: Objectiu desaparegut durant l'observació
- **WHEN** el sensor de l'IA intenta recollir la posició d'una bandera que ha estat recollida o destruïda
- **THEN** el sistema SHALL realitzar una cerca activa dels jugadors per detectar qui posseeix l'objectiu i, en cas negatiu, retornar una posició per defecte (Vector3.zero) sense llançar errors.

### Requirement: Transició d'Estat IA post-error
L'IA MUST ser capaç de recuperar-se d'un estat d'observació incomplet i continuar executant el seu model de decisions.

#### Scenario: Recuperació de l'estat IDLE
- **WHEN** l'IA no troba cap objectiu vàlid
- **THEN** el sistema SHALL mantenir el dron en un estat segur d'espera i reprendre el moviment immediatament quan es rebi una observació vàlida a través del sensor.
