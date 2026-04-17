## Why

Actualment, la llista de sales al lobby es refresca automàticament en rebre missatges per WebSocket o en carregar la pantalla, però l'usuari no té una forma directa de forçar l'actualització si hi ha algun problema de sincronització. A més, el refresc actual podria acumular duplicats si no es neteja correctament el contenidor visual abans de repintar.

## What Changes

- **Vinculació del botó de refresc**: A `MenuManager.cs`, es vincularà el botó `#btnActualitzarSales` de la interfície.
- **Implementació de la petició de dades**: En clicar el botó, es realitzarà una petició HTTP GET a `/api/games/list` (o el mètode equivalent de refresc de sales).
- **Gestió de la llista visual**: S'implementarà la neteja obligatòria del contenidor (`.Clear()`) abans d'instanciar les noves sales per evitar duplicats i sales fantasma.

## Capabilities

### New Capabilities
- `manual-lobby-refresh`: Permet als usuaris refrescar manualment la llista de sales disponibles des de la interfície del lobby, garantint la integritat de les dades visuals.

### Modified Capabilities
- Cap.

## Impact

- **Codi**: `MenuManager.cs` (C#).
- **UI**: Botó de refresc al lobby.
- **Flux**: Millora en la robustesa de la sincronització entre el client i el servidor de backend.
