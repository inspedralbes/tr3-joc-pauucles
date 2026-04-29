## 1. Definició de Variables

- [x] 1.1 Afegir les variables privades `pantallaSalaEspera`, `btnTancarSalaEspera` i `currentRoomId` a la classe `MenuManager`.

## 2. Enllaç UI i Configuració

- [x] 2.1 Actualitzar el mètode `OnEnable` per enllaçar `pantallaSalaEspera` i `btnTancarSalaEspera`.
- [x] 2.2 Configurar l'estat de visibilitat inicial de la Sala d'Espera (`DisplayStyle.None`).
- [x] 2.3 Implementar l'esdeveniment `clicked` per al botó `btnTancarSalaEspera` per tornar al Lobby i actualitzar partides.

## 3. Lògica de Transició de Sala

- [x] 3.1 Modificar la corrutina `EnviarPeticio` per detectar la resposta exitosa de l'endpoint `/games/create`.
- [x] 3.2 Extreure el `roomId` de la resposta i assignar-lo a `currentRoomId`.
- [x] 3.3 Canviar la visibilitat de les pantalles (amagar Lobby/PopUp, mostrar Sala d'Espera) en cas d'èxit.

## 4. Verificació

- [x] 4.1 Comprovar que el projecte compila correctament.
- [x] 4.2 Verificar que el botó de retorn de la Sala d'Espera funciona correctament i actualitza la llista de partides.
