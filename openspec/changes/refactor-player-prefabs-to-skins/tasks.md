## 1. Refactorització de l'Script (Unity)

- [x] 1.1 Localitzar el `GameManager.cs`.
- [x] 1.2 Eliminar les variables `prefabRojo`, `prefabVerde`, `prefabAzul` i `prefabAmarillo`.
- [x] 1.3 Afegir les noves variables públiques: `prefabBiker`, `prefabCyborg`, `prefabGraveRobber`, `prefabPunk`, `prefabSteamMan`, `prefabWoodcutter`.
- [x] 1.4 Actualitzar el mètode `GetPrefabPerSkin` per retornar les variables correctes segons el nom de la skin.

## 2. Neteja de codi

- [x] 2.1 Eliminar el mètode `GetPrefabPerColor` (si no s'utilitza en cap altre lloc o marcar-lo com obsolet).

## 3. Verificació

- [x] 3.1 Comprovar que el projecte compila correctament sense errors de referència.
- [x] 3.2 Verificar visualment al inspector d'Unity que apareixen les 6 noves ranures per a prefabs.
