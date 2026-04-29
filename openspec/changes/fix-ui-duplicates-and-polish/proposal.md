## Why

Actualment, les llistes de sales i jugadors a la UI es dupliquen en rebre actualitzacions perquè no es netegen els contenidors previs. A més, el disseny visual actual és bàsic i requereix millores en l'alineació, espaiat i colors per oferir una experiència d'usuari més professional i elegant.

## What Changes

- **Frontend (MenuManager.cs)**: Implementació obligatòria de `.Clear()` als contenidors visuals de les llistes abans de repintar dades noves.
- **Backend (Node.js)**: Implementació de broadcast `ROOM_UPDATED` quan un jugador abandona una sala (LEAVE_ROOM) i aquesta encara no està buida.
- **UI (UXML/USS)**: 
    - Centrat de contenidors principals (`justify-content: center; align-items: center;`).
    - Neteja d'imatges de fons innecessàries.
    - Millora de marges i espaiat (padding/margin) per als botons.
    - Refinament de la tipografia i paleta de colors per a les pantalles de creació, unió i espera.

## Capabilities

### New Capabilities
- `ui-list-consistency`: Garanteix que les llistes dinàmiques de la UI es mostrin sense duplicats ni elements obsolets.
- `ui-visual-polish`: Millora l'estètica general i l'alineació de la interfície d'usuari mitjançant UI Toolkit.

### Modified Capabilities
- Cap.

## Impact

- **Codi**: `MenuManager.cs` (C#), `server.js` o controlador de jocs (Node.js).
- **UI Assets**: `MenuUI.uxml` i fitxers `.uss` associats.
- **UX**: Millora significativa en la claredat visual i l'estabilitat de la informació del lobby.
