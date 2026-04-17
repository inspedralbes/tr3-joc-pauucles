## Context

L'script `GameManager.cs` és l'encarregat de posicionar el jugador en carregar l'escena 'Bosque'. L'actual implementació utilitza `Object.FindObjectsOfType<Transform>()`, que és un mètode marcat com a obsolet en les versions recents de Unity, generant warnings i possibles problemes de compatibilitat futura. A més, la cerca d'objectes utilitza `name.Contains`, el que és menys precís que una comparació exacta.

## Goals / Non-Goals

**Goals:**
- Eliminar el warning CS0618 en `GameManager.cs`.
- Utilitzar l'API recomanada `UnityEngine.Object.FindObjectsByType`.
- Millorar la precisió de la cerca de punts de spawn utilitzant noms exactes (`PuntSpawn_Equip1` / `PuntSpawn_Equip2`).

**Non-Goals:**
- No es canviarà la lògica de selecció aleatòria (es manté `Random.Range`).
- No es modificarà el comportament del `localPlayer` més enllà de la seva posició.

## Decisions

- **Namespace explícit**: S'utilitzarà `UnityEngine.Object` en lloc de `Object` per evitar conflictes amb `System.Object` i deixar clar que s'utilitza l'API de Unity.
- **SortMode.None**: S'especificarà `FindObjectsSortMode.None` per optimitzar la cerca, ja que l'ordre dels transforms no és rellevant per a la llista de spawns.
- **Comparació exacta**: Se substituirà `t.name.Contains(targetName)` per `t.name == targetName` per assegurar que només es seleccionen els objectes de respawn previstos pel dissenyador de nivells.

## Risks / Trade-offs

- **[Risc] Errors en el disseny de l'escena** → Si els objectes de l'escena es diuen `SpawnEquip1` (nom antic) en lloc de `PuntSpawn_Equip1`, el codi no els trobarà. → **[Mitigació]** Aquest canvi implica que s'han d'actualitzar els noms dels objectes a l'escena Unity per coincidir amb el nou estàndard.
