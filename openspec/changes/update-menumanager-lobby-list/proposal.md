## Why

Actualment, la pantalla del Lobby a `MenuManager.cs` no mostra cap partida disponible. Els usuaris necessiten veure una llista de partides actives per poder unir-se a elles, millorant l'experiència multijugador.

## What Changes

- Afegir la referència a `llistaPartides` (un `ListView`) a `MenuManager.cs`.
- Implementar la corrutina `ObtenirPartides()` per fer un UnityWebRequest (GET) a l'endpoint `/api/games/list`.
- Configurar la `llistaPartides` amb `makeItem` (per crear Labels) i `bindItem` (per assignar el text amb el format "Sala: [roomId] - Jugadors: [players.Length]/[maxPlayers]").
- Executar `ObtenirPartides()` automàticament després d'un login correcte, quan es mostra la pantalla del Lobby.

## Capabilities

### New Capabilities
- `lobby-game-list`: Llistar les partides actives al Lobby mitjançant un component ListView que es popula des del backend.

### Modified Capabilities
<!-- No requirement changes for existing capabilities -->

## Impact

- `MenuManager.cs`: S'afegirà lògica per gestionar el ListView i la petició GET.
- UI Toolkit: Es requereix que l'arxiu .uxml tingui un ListView anomenat "llistaPartides" (s'assumeix que ja existeix o s'ha de verificar).
