## Why

Actualment, la bandera es teletransporta al guanyador en qualsevol combat, independentment de si el perdedor la portava o no. Això és un error lògic que permet "invocar" la bandera des de qualsevol punt de l'escena. Cal assegurar que el robatori només es produeixi si el perdedor realment posseeix la bandera en el moment del combat.

## What Changes

- **Validació de Possessió de Bandera**: Abans de realitzar el traspàs de la bandera, el sistema comprovarà si el jugador perdedor n'és el "pare" (`transform.parent`).
- **Robatori Condicional**: El canvi de pare i l'ajust de la `localPosition` de la bandera només s'executaran si la validació anterior és positiva.
- **Persistència de Càstig**: La penalització d'immobilitat per al perdedor s'aplicarà en tots els casos, independentment de si portava la bandera o no.

## Capabilities

### New Capabilities
- `conditional-flag-theft`: Capacitat de realitzar el traspàs de la bandera només sota condicions de possessió provades.

### Modified Capabilities
- `flag-theft`: Actualització de la lògica de robatori per incloure la validació de parentiu.

## Impact

- **Player.cs**: El mètode `RobarBandera()` necessita una revisió per acceptar la condició de possessió del perdedor.
- **MinijocUIManager.cs**: Modificació de la crida a la resolució del combat per integrar la lògica de comprovació.
- **Gameplay**: Flux de joc més just i realista, on la bandera s'ha de trobar físicament per ser robada.
