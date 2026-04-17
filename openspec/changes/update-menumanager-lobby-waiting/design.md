## Context

El `MenuManager` actualment permet fer login, registre i llistar partides al Lobby, però un cop es crea una partida no hi ha una transició visual clara cap a la sala on s'esperaran els altres jugadors. Aquest disseny defineix com gestionar aquesta nova pantalla de la Sala d'Espera dins de la lògica de Unity.

## Goals / Non-Goals

**Goals:**
- Integrar la UI de la Sala d'Espera al flux de navegació de `MenuManager.cs`.
- Emmagatzemar l'ID de la sala actual per a futures operacions de WebSocket.
- Permetre el retorn al Lobby des de la Sala d'Espera.

**Non-Goals:**
- No s'implementarà la lògica de sincronització de jugadors dins de la sala via WebSocket en aquesta tasca.
- No es modificarà la UI (UXML) mateixa, només la seva gestió des del script.

## Decisions

- **Enllaç a OnEnable**: S'utilitzarà `OnEnable` (o s'afegirà a la lògica existent) per capturar les referències dels nous elements visual de la UI mitjançant `Q<T>`.
- **Estat de Visibilitat**: La pantalla de Sala d'Espera es gestionarà mitjançant `style.display` (`Flex` per mostrar, `None` per amagar).
- **Gestió de l'ID de Sala**: Es capturarà l'ID de la sala retornat pel backend en la petició exitosa de creació de sala.

## Risks / Trade-offs

- **[Risk] Elements UI no existents** → **Mitigation**: Es realitzarà una comprovació de nul·litat abans d'assignar esdeveniments per evitar errors d'execució si el fitxer UXML no està actualitzat.
- **[Trade-off] Navegació Manual** → **Mitigation**: Es gestiona manualment la visibilitat de les pantalles en lloc d'utilitzar un sistema de rutes més complex, donada la simplicitat actual de l'aplicació.

## Migration Plan

1. Definir els membres de classe a `MenuManager.cs`.
2. Actualitzar `OnEnable` per enllaçar els nous elements i configurar el botó de tancar.
3. Modificar la corrutina `EnviarPeticio` per detectar la creació exitosa d'una partida i activar la Sala d'Espera.
