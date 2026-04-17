## 1. Models de Dades i Referències

- [x] 1.1 Afegir les classes serialitzables `PlayerData`, `GameData` i `GameListWrapper` a `MenuManager.cs`.
- [x] 1.2 Declarar el camp privat `llistaPartides` de tipus `ListView` a `MenuManager.cs`.
- [x] 1.3 Inicialitzar `llistaPartides` al mètode `OnEnable` mitjançant `root.Q<ListView>("llistaPartides")`.

## 2. Integració amb l'API

- [x] 2.1 Implementar la corrutina `ObtenirPartides()` que realitzi una petició GET a l'endpoint `/games/list`.
- [x] 2.2 Implementar el parseig del JSON rebut, aplicant el "wrapper" manual per convertir l'array en un objecte `GameListWrapper`.

## 3. Lògica de la Interfície d'Usuari

- [x] 3.1 Configurar `llistaPartides.makeItem` per retornar un nou element `Label`.
- [x] 3.2 Configurar `llistaPartides.bindItem` per assignar el text al `Label` amb el format: "Sala: [roomId] - Jugadors: [players.Length]/[maxPlayers]".
- [x] 3.3 Modificar la lògica de `EnviarPeticio` (específicament per al login) per cridar a `ObtenirPartides()` un cop s'hagi fet la transició a la pantalla del Lobby.
