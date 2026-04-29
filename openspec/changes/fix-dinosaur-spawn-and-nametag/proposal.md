## Why

Actualment, les banderes (dinosaures) desapareixen o no s'instancien correctament per falta de sincronització inicial, i el Nametag del jugador local mostra un text genèric ("Jugador") en lloc del seu nom d'usuari real. A més, l'escala visual dels dinosaures és massa petita per a una experiència de joc correcta.

## What Changes

- **Simplificació del Spawn**: Substitució de la corrutina complexa d'espera per un retard de 0.5 segons (`SpawnAmbRetard`) per garantir que les dades estiguin llestes sense bloquejos indefinits.
- **Correcció d'Escala**: Assignació forçada d'escala `(4, 4, 1)` a les banderes instanciades.
- **Sincronització del Nametag**: Actualització del component `UnityEngine.UI.Text` del jugador local amb el nom d'usuari de `MenuManager.Instance.username`.

## Capabilities

### New Capabilities
- `delayed-room-instantiation`: Mètode simplificat per assegurar la càrrega d'objectes dependents de dades de xarxa.

### Modified Capabilities
- `enhanced-local-identity`: S'actualitza el requeriment per buscar components `Unity UI Text` en lloc de `TMPro`.

## Impact

- `GameManager.cs`: Canvi en el flux de `Start`, mètode `InstanciarBanderes` i `ConfigurarLocalPlayerVisuals`.
- Estabilitat visual: Els dinosaures apareixeran sempre amb la mida correcta i el jugador veurà el seu propi nom.
