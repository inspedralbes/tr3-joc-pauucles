## Why

Actualment, el sistema no identifica l'usuari que crea una sala, el que impedeix una gestió correcta de les partides al backend. A més, la navegació entre pantalles (Lobby, Login, Pop-up de creació) és incompleta o té botons amb funcionalitats intercanviades.

## What Changes

- **Identificació d'Usuari**: Emmagatzematge del `userId` en fer login i enviament d'aquest com a `host` en crear una sala.
- **Millora de Navegació**:
  - Implementació del botó "Tancar" al Login per sortir de l'aplicació o tancar la finestra.
  - Implementació de la "X" al Lobby per tornar a la pantalla de Login.
  - Correcció dels botons del pop-up de creació de sala (ajustant noms i funcionalitats de "Crear" i "Cancelar").

## Capabilities

### New Capabilities
- `user-id-persistence`: Gestió de la identitat de l'usuari connectat per a operacions de joc.
- `ui-navigation-fixes`: Correcció i completesa dels fluxos de navegació entre les pantalles principals del menú.

### Modified Capabilities
<!-- No modified capabilities -->

## Impact

- `MenuManager.cs`: Canvis en la lògica de login, creació de sala i vinculació d'esdeveniments.
- `MenuUI.uxml`: Revisió d'IDs i possible reanomenament de botons per coherència.
