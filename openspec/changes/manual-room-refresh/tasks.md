## 1. UI i Vinculació

- [x] 1.1 Declarar i buscar el botó `btnActualitzarSales` al mètode `OnEnable` de `MenuManager.cs`.
- [x] 1.2 Implementar l'esdeveniment de clic per invocar la corrutina de refresc manual.

## 2. Lògica de Refresc

- [x] 2.1 Crear el mètode de refresc manual que realitzi la petició HTTP GET a `/api/games/list`.
- [x] 2.2 Implementar la neteja obligatòria del contenidor (`llistaPartides.itemsSource.Clear()` o equivalent) ABANS de processar les noves dades.
- [x] 2.3 Actualitzar la visualització del `ListView` mitjançant `.Rebuild()` o re-assignació de la font de dades.

## 3. Verificació

- [x] 3.1 Provar el botó a l'escena de lobby i verificar que les sales s'actualitzen correctament.
- [x] 3.2 Confirmar que no es generen duplicats després de múltiples clics.
