## Why

Actualment, el `MinijocUIManager` està experimentant errors de referència nul·la (`ArgumentNullException`) en intentar accedir al `UIDocument` o al seu `rootVisualElement`. Això es deu a una inicialització incorrecta del component i a una lògica de Singleton que no aprofita l'objecte existent a l'escena.

## What Changes

- Modificació de la inicialització de `_uiDocument` per utilitzar `GetComponent<UIDocument>()` dins de l' `Awake`.
- Correcció de la lògica de Singleton per assegurar que `Instance = this` s'executa correctament sobre l'objecte existent ("PantallaCombats").
- Eliminació de qualsevol creació dinàmica d'instàncies buides que no tinguin els components necessaris.
- Addició de comprovacions d'estat actiu del GameObject abans d'accedir al `rootVisualElement`.

## Capabilities

### New Capabilities
- `uimanager-initialization-safety`: Robustesa en la inicialització i accés als components de UI Toolkit.

### Modified Capabilities
- `uimanager-null-safety`: Millora de les comprovacions de nul·litat introduïdes prèviament.

## Impact

- **MinijocUIManager.cs**: Refactorització dels mètodes `Awake` i `ShowUI`.
- **Estabilitat del joc**: Eliminació dels crashes durant l'activació de minijocs.
