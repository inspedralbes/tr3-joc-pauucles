## 1. Correcció d'ambigüitat

- [x] 1.1 Localitzar la crida `Object.FindFirstObjectByType<Player>()` a `WebSocketClient.cs`.
- [x] 1.2 Substituir-la per `UnityEngine.Object.FindFirstObjectByType<Player>()`.
- [x] 1.3 Cercar altres ocurrències de `Object.FindFirstObjectByType` o `Object.FindAnyObjectByType` que no estiguin qualificades i corregir-les.

## 2. Verificació

- [x] 2.1 Confirmar que l'error CS0104 ha desaparegut al compilar `WebSocketClient.cs`.
- [x] 2.2 Verificar que el projecte compila correctament sense advertències d'ambigüit d'ambigüitat en el mètode de cerca.
