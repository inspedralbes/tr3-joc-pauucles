## ADDED Requirements

### Requirement: Generació d'operació aleatòria
El sistema ha de generar una suma de dos números aleatoris entre 1 i 50 quan s'inicia el minijoc i determinar si el resultat és parell o senar.

#### Scenario: Inici del minijoc
- **WHEN** el minijoc s'activa (OnEnable o similar)
- **THEN** es generen dos números, es calcula si la seva suma és parell i es mostra l'operació a la Label corresponent.

### Requirement: Temporitzador de joc
El sistema ha de disposar d'un compte enrere de 5 segons que, en arribar a zero, resulti en la derrota automàtica del jugador.

#### Scenario: Temps esgotat
- **WHEN** el temporitzador arriba a 0 segons
- **THEN** el joc s'atura, es tanca la interfície i es crida el mètode de derrota del jugador.

### Requirement: Validació de resposta
El sistema ha de permetre a l'usuari triar entre "Parell" o "Senar" i validar si la tria coincideix amb el resultat de la suma generada.

#### Scenario: Resposta correcta
- **WHEN** l'usuari clica el botó que coincideix amb la paritat de la suma
- **THEN** el joc s'atura, es tanca la interfície i es crida el mètode de victòria del jugador.

#### Scenario: Resposta incorrecta
- **WHEN** l'usuari clica el botó que NO coincideix amb la paritat de la suma
- **THEN** el joc s'atura, es tanca la interfície i es crida el mètode de derrota del jugador.
