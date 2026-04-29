## Why

S'ha produït un error de compilació CS0104 degut a l'ambigüitat entre `UnityEngine.Object` i el tipus base `object` de C# (System.Object). Això passa quan s'utilitza la classe `Object` sense el namespace qualificat en fitxers que inclouen `using System;` i `using UnityEngine;`.

## What Changes

- **Qualificació de namespace**: Substitució de `Object.FindFirstObjectByType` per `UnityEngine.Object.FindFirstObjectByType`.
- **Eliminació d'ambigüitat**: Assegurar que el compilador identifica correctament la classe d'Unity per a mètodes de cerca d'objectes.

## Capabilities

### New Capabilities
<!-- Cap -->

### Modified Capabilities
- `unity-api-standards`: Refinament de l'ús d'API per incloure namespaces explícits en cas d'ambigüitat.

## Impact

- `WebSocketClient.cs`: Correcció de la referència a `FindFirstObjectByType`.
- Compilació: Resolució de l'error CS0104.
