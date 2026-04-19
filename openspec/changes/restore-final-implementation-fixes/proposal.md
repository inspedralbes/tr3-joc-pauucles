## Why

A causa d'un error de connexió s'ha perdut part de la implementació final. Cal restaurar la lògica de filtratge d'equips per a les banderes (perquè un jugador no agafi la seva pròpia bandera) i assegurar que el Nametag del jugador local mostri el nom d'usuari correcte en iniciar la partida.

## What Changes

- **Bandera.cs**: Implementació del mètode `OnTriggerEnter2D` (o actualització del mateix) per comprovar si el jugador col·lisionant pertany al mateix equip que la bandera. Si és així, s'ignora el xoc.
- **GameManager.cs**: Dins del mètode `InstanciarLocalPlayer`, s'afegeix la lògica per buscar el component `TextMeshPro` (el Nametag) dins de l'objecte instanciat i assignar-li el `username` del `MenuManager`.

## Capabilities

### New Capabilities
<!-- Cap -->

### Modified Capabilities
- `team-aware-flag-collisions`: Es restaura i assegura el filtratge de col·lisions basat en l'equip propietari.
- `nametag-sync`: Es garanteix la visualització del nom d'usuari local.

## Impact

- `Bandera.cs`: Canvi en la lògica de col·lisió/trigger.
- `GameManager.cs`: Ajust en el mètode d'instanciació del jugador local.
- Experiència de joc: Els jugadors només interactuaran amb les banderes enemigues i veuran el seu propi nom correctament.
