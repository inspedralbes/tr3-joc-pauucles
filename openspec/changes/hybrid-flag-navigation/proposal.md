## Why

El sistema de seguiment actual de la mascota (Dino) presenta dificultats quan el jugador canvia de plataforma o es troba a diferents altures, el que sovint provoca que la mascota es quedi bloquejada o caigui innecessàriament. Un sistema híbrid que permeti levitar en situacions crítiques millorarà la robustesa del seguiment.

## What Changes

- **Nou estat de Levitació**: El Dino podrà desactivar la seva gravetat per volar directament cap al jugador quan la diferència d'altura sigui gran o el camí estigui bloquejat.
- **Refinament del seguiment vertical**: S'implementa una lògica que avalua la distància en l'eix Y per decidir entre caminar o levitar.
- **Optimització de salts**: S'eliminen els salts innecessaris, restringint-los només a petits obstacles de terra (esglaons).
- **Recuperació de gravetat**: S'estableix un protocol segur per tornar al mode caminar quan es detecti terra ferm a prop del jugador.

## Capabilities

### New Capabilities
<!-- Cap -->

### Modified Capabilities
- `flag-movement`: Actualització de la navegació física per incloure estats de levitació i gestió de gravetat dinàmica.

## Impact

- `Bandera.cs`: Incorporació de la variable `velocitatLevitacio` i reestructuració de la lògica d'Update per gestionar els estats híbrid.
- Jugabilitat: Millora visual i funcional en la persistència de la mascota a prop del jugador.
