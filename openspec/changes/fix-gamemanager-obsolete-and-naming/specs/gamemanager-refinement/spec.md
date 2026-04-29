## ADDED Requirements

### Requirement: Ús d'APIs modernes de Unity
El sistema SHALL utilitzar `UnityEngine.Object.FindObjectsByType<T>` en lloc del mètode obsolet `FindObjectsOfType<T>` per evitar warnings de compilació i assegurar la compatibilitat amb versions recents de Unity.

#### Scenario: Cerca de Transforms sense obsolescència
- **WHEN** el GameManager necessita llistar els punts de spawn.
- **THEN** crida a `UnityEngine.Object.FindObjectsByType<Transform>(UnityEngine.FindObjectsSortMode.None)`.

### Requirement: Precisió en la cerca de punts de respawn
El sistema SHALL filtrar els punts de spawn basant-se en els noms exactes `PuntSpawn_Equip1` i `PuntSpawn_Equip2` per garantir que el jugador és teletransportat a la zona correcta de l'equip.

#### Scenario: Filtratge per nom exacte
- **WHEN** es processa la llista de punts de spawn a l'escena.
- **THEN** només es consideren vàlids els objectes el nom dels quals coincideixi exactament amb el patró de l'equip assignat.
