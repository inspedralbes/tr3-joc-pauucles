## ADDED Requirements

### Requirement: Selecció de skin d'usuari
El sistema SHALL permetre a l'usuari visualitzar una llista de skins disponibles i seleccionar-ne una per equipar-la.

#### Scenario: Equipar skin de l'inventari
- **WHEN** L'usuari prem sobre una skin a la llista d'inventari
- **THEN** El sistema envia una petició al backend per guardar la selecció
- **THEN** La skin queda marcada com a "equipada" visualment a la UI

### Requirement: Persistència de la skin seleccionada
El backend SHALL emmagatzemar la skin equipada de cada usuari i retornar-la durant el login o consulta de perfil.

#### Scenario: Recuperació de skin en iniciar sessió
- **WHEN** L'usuari fa login correctament
- **THEN** La resposta del servidor inclou el camp `skinEquipada` amb el valor guardat a la base de dades
