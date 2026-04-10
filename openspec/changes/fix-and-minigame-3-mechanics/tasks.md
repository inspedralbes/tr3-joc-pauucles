## 1. Correccions Urgents

- [x] 1.1 Localitzar i corregir l'error de sintaxi a l'string interpolat de `MinijocUIManager.cs` (CS8076).
- [x] 1.2 Verificar que el projecte compila sense errors després de la correcció.

## 2. Implementació Nova Mecànica AturaBarra

- [x] 2.1 Declarar i buscar la referència a `ZonaObjectiu` (VisualElement) a `MinijocUIManager.cs`.
- [x] 2.2 Implementar el posicionament aleatori de `ZonaObjectiu` en el mètode d'activació del minijoc 3.
- [x] 2.3 Modificar `HandleAturaBarraClick()` per validar si la fletxa està dins del rang de la zona objectiu.
- [x] 2.4 Actualitzar el missatge de "TextResultat" perquè indiqui clarament "DINS" o "FORA" i qui guanya.

## 3. Validació

- [x] 3.1 Comprovar que la `ZonaObjectiu` canvia de lloc cada cop que s'obre el minijoc 3.
- [x] 3.2 Verificar que aturar la fletxa a sobre de la zona dona la victòria al Jugador 1.
- [x] 3.3 Confirmar que aturar-la fora de la zona dona la victòria al Jugador 2 (Rival).
- [x] 3.4 Validar que el robatori de bandera i els càstigs s'apliquen correctament després dels 2.5 segons.
