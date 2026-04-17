## 1. Actualització de WebSocketClient.cs

- [x] 1.1 Localitzar la crida a `FindObjectOfType<Player>()`.
- [x] 1.2 Substituir-la per `Object.FindFirstObjectByType<Player>()`.

## 2. Actualització de MenuManager.cs

- [x] 2.1 Cercar qualsevol instància de `FindObjectOfType<T>()`.
- [x] 2.2 Substituir totes les ocurrències trobades per `Object.FindFirstObjectByType<T>()`.

## 3. Verificació

- [x] 3.1 Comprovar que el projecte compila sense errors.
- [x] 3.2 Verificar que el warning CS0618 ha desaparegut dels fitxers modificats.
- [x] 3.3 Confirmar que la funcionalitat de cerca d'objectes continua funcionant com s'espera.
