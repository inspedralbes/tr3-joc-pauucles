## 1. Modificacions al Backend (Node.js)

- [x] 1.1 Actualitzar el model `User.js` a `backend/src/models/`: afegir camp `skinEquipada` amb valor per defecte 'Woodcutter'.
- [x] 1.2 Implementar l'endpoint `PUT /api/users/skin` al fitxer de rutes d'usuaris.
- [x] 1.3 Crear el mètode `updateSkin` al controlador d'usuaris per gestionar la persistència.
- [x] 1.4 Assegurar que el login retorni el camp `skinEquipada`.

## 2. Desenvolupament de la UI d'Inventari (Unity)

- [x] 2.1 Identificar i vincular el botó `INVENTARI` al `MenuManager.cs`.
- [x] 2.2 Crear el panell visual d'inventari (VisualElement) a l'arxiu UXML corresponent.
- [x] 2.3 Implementar la lògica per canviar de skin: crida API PUT al backend i actualització de `MenuManager.Instance.currentSkin`.
- [x] 2.4 Mostrar visualment quina skin està equipada al lobby.

## 3. Lògica d'Instanciació i Sincronització (Unity)

- [x] 3.1 Modificar `GameManager.cs`: afegir una estructura de dades per mapejar noms de skin a prefabs.
- [x] 3.2 Actualitzar el mètode de spawn local: instanciar el prefab segons la skin guardada al `MenuManager`.
- [x] 3.3 Estendre el missatge `PLAYER_MOVE` a `NetworkSync.cs` per incloure el camp `skin`.
- [x] 3.4 Actualitzar el mètode de processament de moviments remots: instanciar o actualitzar prefabs segons la skin rebuda al JSON.
- [x] 3.5 Garantir que el `Nametag` s'assigni correctament a l'objecte instanciat dinàmicament.

## 4. Verificació i Proves

- [x] 4.1 Provar que canviar de skin a l'inventari persisteix a la base de dades.
- [x] 4.2 Verificar que en entrar a la partida, el jugador local apareix amb la skin triada.
- [x] 4.3 Comprovar amb dos clients que els jugadors es veuen entre ells amb les skins respectives.
