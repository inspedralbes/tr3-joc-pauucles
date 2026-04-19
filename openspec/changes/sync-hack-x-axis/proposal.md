## Why

La sincronització 2D actual no envia l'eix Z, el que impedeix utilitzar-lo com a senyal ("hack") per notificar esdeveniments de minijocs entre jugadors. Aquest canvi substitueix l'ús de l'eix Z per una posició extrema en l'eix X per garantir que la notificació de victòria/derrota arribi correctament a través del sistema de xarxa existent.

## What Changes

- **Teletransport de Sincronització**: Quan un jugador guanya un minijoc, es teletransportarà momentàniament a una coordenada X extrema (9999f).
- **Restauració de Posició**: S'implementarà una corrutina per retornar el jugador a la seva posició original després d'un breu interval.
- **Detecció de Senyal Remot**: El `GameManager` detectarà si un jugador remot es troba en la coordenada X de senyalització per activar la lògica de derrota local.
- **Gestió de UI**: La interfície de minijocs es tancarà automàticament en detectar el senyal del rival.

## Capabilities

### New Capabilities
- `sync-hack-x-axis`: Sistema de senyalització a través de coordenades de posició per a la sincronització d'estat de minijocs.

### Modified Capabilities
- Cap.

## Impact

- `Player.cs`: S'afegirà la lògica de teletransport i restauració.
- `GameManager.cs`: S'afegirà la lògica de detecció de senyal en el processament de jugadors remots.
- `MinijocUIManager.cs`: S'utilitzarà per tancar la interfície en cas de derrota per senyal remot.
