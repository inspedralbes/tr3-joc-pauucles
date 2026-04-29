## 1. Millora del Flux de Creació

- [x] 1.1 Modificar el mètode `EnviarPeticio` a `MenuManager.cs` per detectar quan l'endpoint és `/games/create` i la petició ha estat exitosa.
- [x] 1.2 Dins d'aquesta condició, amagar el pop-up: `popUpCrearSala.style.display = DisplayStyle.None;`.
- [x] 1.3 Dins d'aquesta mateixa condició, iniciar la corrutina de refresc de la llista: `StartCoroutine(ObtenirPartides());`.

## 2. Robustesa de la Llista de Partides

- [x] 2.1 Revisar el mètode `ObtenirPartides` per assegurar que el "hack" de parseig de JSON envoltant l'array en un objecte `GameListWrapper` funciona correctament.
- [x] 2.2 Verificar que `llistaPartides.itemsSource` s'assigna correctament amb les dades actualitzades del backend per refrescar la UI.
- [x] 2.3 Assegurar que el format dels Labels al `bindItem` del `ListView` es manté correcte: "Sala: [roomId] - Jugadors: [players.Length]/[maxPlayers]".
