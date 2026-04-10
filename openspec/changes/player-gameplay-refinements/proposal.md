## Why

Cal polir la jugabilitat i l'aspecte visual del joc per evitar errors d'escalat de la bandera, agilitzar l'inici dels combats i proporcionar feedback visual quan un jugador està inactiu (AFK).

## What Changes

- **Correcció d'Escala de la Bandera**: Fixar l'escala de la bandera a `(3, 3, 1)` immediatament després del reparenting per evitar que hereti deformacions del jugador.
- **Combat Instantani**: Eliminar qualsevol retard o requeriment de tecla per iniciar el combat quan dos jugadors col·lideixen.
- **Efecte Visual AFK**: Implementar un temporitzador d'inactivitat que faci parpellejar el personatge (alpha transparency) després de 3 segons sense moviment.

## Capabilities

### New Capabilities
- `flag-scale-fix`: Garantir que la bandera mantingui una mida constant de `(3, 3, 1)` quan és transportada.
- `instant-combat`: Inici automàtic i immediat del minijoc de combat en col·lidir dos jugadors.
- `afk-visual-effect`: Efecte de parpelleig visual automàtic per a jugadors que no realitzen moviments horitzontals.

### Modified Capabilities
- Cap.

## Impact

- `Player.cs`: Modificació de `AgafarBandera`, `OnCollisionEnter2D` i `Update`.
- UX: Millora de la fluïdesa del joc i comunicació visual de l'estat del jugador.
