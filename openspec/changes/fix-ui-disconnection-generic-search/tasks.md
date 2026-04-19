## 1. Refactorització d'Accés a la UI

- [x] 1.1 Modificar `IniciarMinijoc()` per obtenir l'arrel: `var root = GetComponent<UIDocument>().rootVisualElement;`.
- [x] 1.2 Actualitzar el text de l'operació buscant totes les etiquetes i usant `labels[1]`.
- [x] 1.3 Assignar els events `.clicked` als botons cercant per tipus i usant `botons[0]` i `botons[1]`.

## 2. Lògica de Resposta

- [x] 2.1 Crear el mètode `private void Respon(bool triatParell)`.
- [x] 2.2 Dins de `Respon`, implementar la lògica de comprovació, el log de depuració, el tancament de la UI i la crida al jugador local.

## 3. Neteja i Verificació

- [x] 3.1 Eliminar codi de cerca per nom (`Q<T>("nom")`) que ja no sigui necessari.
- [x] 3.2 Verificar que els clics als botons funcionen independentment dels seus noms de selector.
