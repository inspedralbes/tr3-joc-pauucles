## Why

El sistema de seguiment actual basat en `SmoothDamp` i posició directa pot presentar conflictes amb la física d'Unity i no permet que la mascota (Dino) salti obstacles. A més, certes lògiques visuals del jugador (parpelleig AFK i escalat forçat) s'han de simplificar per millorar la coherència del joc.

## What Changes

- **Simplificació del Jugador**: Eliminació de la lògica de parpelleig AFK i l'ajust d'escala forçat de la bandera des de `Player.cs`.
- **Millora del Seguiment de la Bandera**: Canvi de seguiment de posició directa a moviment basat en velocitat del `Rigidbody2D`.
- **Intel·ligència Artificial Bàsica**: Implementació d'un sistema de salts per superar obstacles mitjançant Raycasts i detecció de terra.
- **Parametrització**: Configuració de distància mínima, velocitat i força de salt per a la mascota.

## Capabilities

### New Capabilities
<!-- Cap -->

### Modified Capabilities
- `flag-movement`: Actualització dels requisits de seguiment físic per incloure detecció d'obstacles i salts.

## Impact

- `Player.cs`: Neteja de codi obsolet (AFK) i simplificació d'agafar bandera.
- `Bandera.cs`: Canvi estructural en la lògica de moviment cap a un sistema basat en física i salts.
- Prefab de la Bandera: Caldrà assegurar que el Dino tingui un collider adequat per a la detecció de terra.
