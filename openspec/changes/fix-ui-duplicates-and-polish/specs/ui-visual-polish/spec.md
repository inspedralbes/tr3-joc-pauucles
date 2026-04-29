## ADDED Requirements

### Requirement: Alineació centrada dels contenidors
La interfície d'usuari SHALL mostrar els contenidors principals de cada pantalla (Login, Lobby, Sala d'Espera) centrats tant horitzontalment com verticalment.

#### Scenario: Contenidors centrats
- **WHEN** es carrega qualsevol pantalla del menú.
- **THEN** els estils CSS/USS apliquen `justify-content: center` i `align-items: center` al contenidor arrel.

### Requirement: Millora de l'espaiat i llegibilitat
Els elements de la UI SHALL tenir espai suficient (marge i farcit) per garantir una bona llegibilitat i usabilitat.

#### Scenario: Botons amb espaiat adequat
- **WHEN** es visualitzen els botons d'acció.
- **THEN** s'apliquen marges consistents per evitar que els elements estiguin visualment amuntegats.

### Requirement: Refinament estètic
La UI SHALL utilitzar una paleta de colors i tipografia coherent per oferir una imatge elegant i professional.

#### Scenario: Neteja d'imatges de fons
- **WHEN** una imatge de fons dificulta la lectura del text o el disseny dels botons.
- **THEN** s'elimina o se substitueix per un color de fons sòlid o degradat suau que millori el contrast.
