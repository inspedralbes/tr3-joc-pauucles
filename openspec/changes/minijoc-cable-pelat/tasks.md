## 1. Implementació de la Lògica del Minijoc

- [x] 1.1 Crear el fitxer `MinijocCablePelatLogic.cs` al directori `Assets/Scripts/`.
- [x] 1.2 Afegir les referències necessàries (`using UnityEngine.UIElements`).
- [x] 1.3 Declarar la variable d'estat `bool enCurs = false`.
- [x] 1.4 Implementar el mètode `public void InicialitzarUI(VisualElement root)`.
- [x] 1.5 Realitzar la cerca dels elements `#ZonaInici`, `#ZonaMeta` i `#FonsPerill`.
- [x] 1.6 Registrar els callbacks `RegisterCallback<PointerEnterEvent>` per a cada element.
- [x] 1.7 Implementar la lògica de control d'estat:
  - `enCurs = true` en entrar a `#ZonaInici`.
  - `enCurs = false` i victòria del Jugador 2 en tocar `#FonsPerill` (si `enCurs`).
  - `enCurs = false` i victòria del Jugador 1 en tocar `#ZonaMeta` (si `enCurs`).

## 2. Integració al Gestor de UI

- [x] 2.1 Localitzar el mètode de la ruleta a `MinijocUIManager.cs` i actualitzar el rang a `Random.Range(0, 7)`.
- [x] 2.2 Afegir el `case 6` al bloc `switch` per gestionar el nou minijoc.
- [x] 2.3 Implementar la lògica d'activació per a l'element `#ContenidorCablePelat` i assegurar que els altres contenidors s'amaguen.
- [x] 2.4 Cercar el component `MinijocCablePelatLogic` i executar `InicialitzarUI` passant el contenidor arrel.

## 3. Verificació

- [x] 3.1 Comprovar que el nou minijoc és seleccionat correctament per la ruleta aleatòria.
- [x] 3.2 Verificar que el joc només comença oficialment després de passar per `#ZonaInici`.
- [x] 3.3 Validar que el combat acaba amb el guanyador correcte en funció de si es toca el fons de perill o la meta.
