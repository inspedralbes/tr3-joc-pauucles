## Why

Actualment, el joc no distingeix entre l'equip que posseeix una bandera i el que intenta capturar-la, permetent que un jugador interactuï amb la seva pròpia bandera. A més, el Nametag del jugador local no es mostra correctament en iniciar la partida, dificultant la identificació del propi personatge en l'entorn multijugador.

## What Changes

- **Lògica de Col·lisions de Banderes**:
    - Addició de la variable `equipPropietari` a la classe `Bandera.cs`.
    - Actualització de `GameManager.cs` per assignar l'equip correcte a cada bandera en instanciar-la.
    - Modificació de `Bandera.cs` per ignorar col·lisions amb jugadors del mateix equip.
- **Nametag Local**:
    - Actualització de `GameManager.cs` per buscar i configurar el text del Nametag del jugador local amb el seu `username` en el moment de la instanciació.

## Capabilities

### New Capabilities
- `team-aware-flag-collisions`: Les banderes ara reconeixen quin equip les posseeix i filtren les interaccions en conseqüència.

### Modified Capabilities
- `nametag-sync`: S'estén per garantir que el jugador local també visualitzi el seu propi nom correctament.

## Impact

- `GameManager.cs`: Canvis en el mètode d'instanciació de banderes i jugadors.
- `Bandera.cs`: Nova variable pública i canvi en la lògica de detecció de triggers.
- Experiència de joc: Els jugadors ja no podran capturar la seva pròpia bandera i veuran el seu nom sobre el personatge.
