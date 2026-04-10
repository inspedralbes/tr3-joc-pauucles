## Why

Actualment, la bandera es col·loca just a sobre del jugador, cosa que podria interferir amb la visualització de futurs elements com ara nametags. Aquest canvi busca millorar l'organització visual del jugador permetent que la bandera es desplaci dinàmicament cap als costats segons la direcció del moviment, actuant com si anés a remolc.

## What Changes

- **Ajust de Posició Inicial**: En el robatori de la bandera (`MinijocUIManager.cs`), la posició local inicial es canviarà de la part superior (`0, 0.8, 0`) al costat (`-0.8, 0, 0`).
- **Moviment Dinàmic de la Bandera**: En `Player.cs`, s'afegirà lògica per actualitzar la `localPosition` de la bandera en cada frame segons la direcció del moviment del jugador.
    - Moviment a la dreta (`input > 0`) -> Bandera a l'esquerra (`-0.8, 0, 0`).
    - Moviment a l'esquerra (`input < 0`) -> Bandera a la dreta (`0.8, 0, 0`).

## Capabilities

### New Capabilities
- `flag-dynamic-positioning`: Capacitat de la bandera d'ajustar la seva posició local basant-se en la direcció del moviment del portador.

### Modified Capabilities
- `flag-theft`: Actualització del punt d'anclatge inicial de la bandera robada.

## Impact

- **Player.cs**: Addició de lògica en l' `Update` per gestionar la posició de la bandera.
- **MinijocUIManager.cs**: Modificació del mètode de resolució de combat on es fa el traspàs de bandera.
- **Visuals**: Millora en la claredat visual del personatge i preparació per a elements superiors (nametags).
