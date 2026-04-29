## Why

La Sala d'Espera actualment no mostra la llista de jugadors que han entrat a la partida, cosa que impedeix als usuaris saber qui més hi ha a la sala. A més, el Lobby a vegades no es refresca correctament en sortir d'una sala degut a un retard en l'actualització de l'estat en el servidor.

## What Changes

- Addició d'un `ListView` (`llistaJugadorsSala`) per mostrar els jugadors a la Sala d'Espera.
- Implementació de la funció `OmplirLlistaJugadors` per visualitzar el nom i l'estat dels jugadors.
- Creació d'una corrutina `RefrescarLobbyAmbRetard` per garantir que el Lobby s'actualitzi correctament després de deixar una sala.
- Integració visual d'aquests elements en el flux de creació i sortida de partides.

## Capabilities

### New Capabilities
- `unity-waiting-room-player-list`: Visualització en temps real (inicial) dels jugadors a la Sala d'Espera.
- `unity-lobby-refresh-stability`: Millora en la sincronització visual del Lobby en tornar de la Sala d'Espera.

### Modified Capabilities
- Cap.

## Impact

- `DAMT3Atrapa la bandera/Assets/Scripts/MenuManager.cs`: S'afegeixen variables, una corrutina i mètodes de configuració de UI.
- UI Toolkit: Es requereix l'existència d'un element `ListView` anomenat `llistaJugadorsSala`.
