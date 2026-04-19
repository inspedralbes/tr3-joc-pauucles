## 1. Modificacions al GameManager (Unity)

- [ ] 1.1 Actualitzar el mètode `InstanciarBanderes()`:
    - [ ] 1.1.1 Després d'instanciar cada bandera, obtenir el component `Bandera`.
    - [ ] 1.1.2 Assignar `equipPropietari = "A"` a la bandera 1 i `"B"` a la bandera 2.
- [ ] 1.2 Actualitzar el mètode d'instanciació del jugador local:
    - [ ] 1.2.1 Buscar el component de text (Nametag) dins dels fills de l'objecte instanciat.
    - [ ] 1.2.2 Assignar-li el valor de `MenuManager.Instance.userId` (o el camp que contingui el `username`).

## 2. Modificacions a Bandera.cs (Unity)

- [ ] 2.1 Declarar la variable pública `public string equipPropietari;`.
- [ ] 2.2 Actualitzar la lògica de col·lisió (ex: `OnTriggerEnter2D`):
    - [ ] 2.2.1 Identificar l'equip del jugador que ha col·lisionat (usant `WebSocketClient.Team` o similar).
    - [ ] 2.2.2 Si l'equip del jugador coincideix amb `equipPropietari`, fer un `return` i no processar el xoc.

## 3. Verificació

- [ ] 3.1 Provar amb l'equip A que no pot agafar la seva bandera però sí la de l'equip B.
- [ ] 3.2 Verificar que el nom d'usuari local apareix sobre el cap del personatge en carregar l'escena.
