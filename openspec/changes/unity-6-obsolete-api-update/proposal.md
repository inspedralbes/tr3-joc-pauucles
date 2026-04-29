## Why

Unity 6 ha marcat `Object.FindObjectOfType<T>()` com a obsolet (Warning CS0618). Per complir amb els nous estàndards del motor i millorar el rendiment de la cerca d'objectes, cal migrar cap a `Object.FindFirstObjectByType<T>()`.

## What Changes

- **Actualització d'API**: Substitució de totes les instàncies de `FindObjectOfType<T>()` per `FindFirstObjectByType<T>()`.
- **Correcció de Warnings**: Eliminació dels advertiments de compilació CS0618 relacionats amb mètodes de cerca obsolets.

## Capabilities

### New Capabilities
<!-- Cap -->

### Modified Capabilities
- `unity-api-standards`: Actualització dels mètodes de cerca d'objectes a l'escena segons els estàndards d'Unity 6.

## Impact

- `WebSocketClient.cs`: Migració del mètode de cerca del component `Player`.
- `MenuManager.cs`: Verificació i actualització de crides de cerca d'objectes.
- Estabilitat del projecte: Codi més net i alineat amb les futures versions d'Unity.
