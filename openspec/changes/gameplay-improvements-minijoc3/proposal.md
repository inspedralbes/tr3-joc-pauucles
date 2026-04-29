## Why

Aquest canvi té com a objectiu millorar la fluïdesa del joc permetent que els guanyadors travessin els perdedors immobilitzats i assegurant que la bandera s'ajusti correctament al nou propietari. A més, es prepara la infraestructura per al tercer minijoc (AturaBarra).

## What Changes

- **Efecte Fantasma**: En `Player.cs`, el collider del perdedor es convertirà en `isTrigger = true` temporalment durant el càstig de derrota.
- **Millora del Traspàs de Bandera**: S'ajustarà la `localPosition` de la bandera a `Vector3.zero` quan s'assigni al nou pare (guanyador).
- **Interfície Minijoc 3 (AturaBarra)**:
    - Addició de referència a `ContenidorAturaBarra` i botó `BtnAturar` a `MinijocUIManager.cs`.
    - Lògica placeholder per a l'ID 3 de la ruleta que genera puntuacions aleatòries i resol el guanyador.

## Capabilities

### New Capabilities
- `minijoc-ui-atura-barra`: Interfície visual i interacció bàsica per al minijoc d'aturar la barra.
- `ghost-penalty-effect`: Estat de trigger temporal per a jugadors derrotats per evitar bloquejos físics.

### Modified Capabilities
- `flag-theft`: Millora en l'ajust visual de la bandera robada.
- `uimanager-container-management`: Inclusió d'un nou contenidor per al tercer minijoc.

## Impact

- **Player.cs**: Modificació de `AplicarCastigDerrota` i la lògica de la bandera.
- **MinijocUIManager.cs**: Expansió del `switch` i noves referències de UI.
- **UI Toolkit**: Necessitat d'afegir el contenidor d'AturaBarra al fitxer UXML.
