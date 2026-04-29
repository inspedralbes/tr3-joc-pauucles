## Why

Actualment, quan un jugador perd un combat portant la bandera, el guanyador la roba directament. Aquest canvi introdueix una nova mecànica: la "bandera fugitiva". En lloc de ser robada directament, la bandera s'allibera i intenta tornar a la seva posició inicial, creant un moment de caos i una oportunitat perquè qualsevol jugador la recuperi.

## What Changes

- **Nou script `Bandera.cs`**: Gestiona el retorn de la bandera a la seva base quan està en estat "fugint".
- **Modificació del Robatori**: A `MinijocUIManager.cs`, el robatori directe es substitueix per l'alliberament de la bandera en estat fugitiu.
- **Modificació de la Recollida**: A `Player.cs`, s'actualitza la lògica per aturar l'estat fugitiu en recollir la bandera i gestionar correctament el seu collider.

## Capabilities

### New Capabilities
- `fugitive-flag-behavior`: Implementació de la lògica de retorn automàtic de la bandera a la seva posició original.

### Modified Capabilities
- `flag-theft`: La lògica de robatori canvia de traspàs directe a alliberament amb retorn automàtic.
- `flag-acquisition`: La recollida ha de desactivar el comportament fugitiu i el collider físic.

## Impact

- **Assets/Scripts/Bandera.cs**: Nou fitxer.
- **Player.cs**: Canvis en la gestió de col·lisions amb la bandera.
- **MinijocUIManager.cs**: Canvi en la resolució del combat quan hi ha una bandera implicada.
