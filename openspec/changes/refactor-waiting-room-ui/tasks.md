## 1. Definició de Variables i Enllaç UI

- [x] 1.1 Afegir la variable privada `llistaJugadorsSala` a la classe `MenuManager`.
- [x] 1.2 Actualitzar el mètode `OnEnable` per enllaçar `llistaJugadorsSala` mitjançant `root.Q<ListView>`.

## 2. Implementació de la Lògica de Refresc

- [x] 2.1 Crear la corrutina `RefrescarLobbyAmbRetard` que esperi 0.5 segons i cridi a `ObtenirPartides`.
- [x] 2.2 Modificar el listener del botó `btnTancarSalaEspera` per utilitzar la nova corrutina de refresc amb retard.

## 3. Visualització de Jugadors

- [x] 3.1 Implementar el mètode `OmplirLlistaJugadors(PlayerData[] players)` que configuri `makeItem` i `bindItem` del ListView.
- [x] 3.2 Assegurar que els ítems de la llista tinguin el text en blanc i el format correcte ("Jugador: [nom] (Estat)").
- [x] 3.3 Cridar a `OmplirLlistaJugadors` al final del flux de creació de sala exitosa.

## 4. Verificació

- [x] 4.1 Comprovar que el projecte compila correctament.
- [x] 4.2 Verificar que la llista de jugadors es mostra en entrar a la Sala d'Espera.
- [x] 4.3 Verificar que el Lobby s'actualitza sense elements fantasma en tornar de la sala.
