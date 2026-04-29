## ADDED Requirements

### Requirement: Retard en el spawn de banderes
El sistema SHALL retardar la instanciació de les banderes 0.5 segons després de l'inici de l'escena.

#### Scenario: Spawn amb retard exitós
- **WHEN** S'executa el mètode `Start()` del `GameManager`.
- **THEN** S'inicia una corrutina que espera 0.5 segons.
- **THEN** Es mostra un missatge de depuració al log indicant l'intent d'instanciació.
- **THEN** Es crida al mètode `InstanciarBanderes()`.

### Requirement: Escalat visual forçat
El sistema SHALL assignar una escala uniforme a totes les banderes instanciades.

#### Scenario: Aplicació d'escala a dinosaure
- **WHEN** Una bandera és instanciada pel `GameManager`.
- **THEN** S'assigna el valor `(4, 4, 1)` a la propietat `localScale` del seu `Transform`.
