## 1. Actualització del GameManager (Unity)

- [x] 1.1 Localitzar el mètode `InstanciarLocalPlayer()` a `GameManager.cs`.
- [x] 1.2 Afegir la lògica per buscar el component `TextMeshPro` (o el component de text utilitzat) als fills de `localPlayer.gameObject`.
- [x] 1.3 Assignar-li el valor de `MenuManager.Instance.userId` (o `username`).

## 2. Restauració del Filtre de Banderes (Unity)

- [x] 2.1 Obrir `Bandera.cs`.
- [x] 2.2 Implementar el mètode `private void OnTriggerEnter2D(Collider2D collision)`.
- [x] 2.3 Afegir la comprovació d'equip: si el jugador que col·lisiona pertany al mateix equip que `equipPropietari`, fer un `return;`.

## 3. Verificació

- [x] 3.1 Comprovar que el personatge local té el seu nom correcte en iniciar la partida.
- [x] 3.2 Verificar que els jugadors de l'equip A no poden agafar la bandera de l'equip A.
