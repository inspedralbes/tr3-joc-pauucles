## Context

El projecte presenta inestabilitat en el spawn inicial d'Unity a causa de dependències de xarxa que no sempre es resolen a temps. A més, s'ha identificat una discrepància en el tipus de component utilitzat per al Nametag (Unity UI Text) i el valor que s'hi assigna.

## Goals / Non-Goals

**Goals:**
- Estabilitzar el spawn de dinosaures mitjançant un retard controlat.
- Corregir l'escala visual dels dinosaures instanciats.
- Mostrar el nom d'usuari correcte en el jugador local usant el component visual adequat.

**Non-Goals:**
- Implementar un sistema de reconnexió automàtica.
- Canviar el disseny dels dinosaures o prefabs.

## Decisions

### 1. Corrutina SpawnAmbRetard
Es canviarà la lògica de `WaitUntil` per `WaitForSeconds(0.5f)`.
- **Racional**: `WaitUntil` pot bloquejar-se si la condició no es compleix mai (ex: error de socket). Un retard fix de 0.5 segons és suficient perquè les dades locals i de sala es carreguin sense comprometre l'experiència d'usuari.

### 2. Escalabilitat (4, 4, 1)
S'aplicarà una assignació directa de `localScale` després de cada `Instantiate`.
- **Racional**: Assegura consistència visual independentment de la configuració original del prefab de l'sprite del dinosaure.

### 3. Nametag via UnityEngine.UI.Text
S'utilitzarà `GetComponentInChildren<UnityEngine.UI.Text>()` per accedir al Nametag.
- **Racional**: Segons les evidències visuals, el projecte utilitza el sistema de text estàndard d'Unity UI per a les etiquetes de nom. S'usarà `userId` del `MenuManager` com a font de dades.

## Risks / Trade-offs

- **[Risk]** Si el component de text és realment un `TMPro` i no un `UnityEngine.UI.Text`, la cerca fallarà. -> **Mitigation**: S'ha afegit un `Debug.LogWarning` per informar si no es troba el component.
- **[Trade-off]** 0.5 segons podria ser massa o poc depenent de la latència del servidor, però és una mesura de seguretat més simple que l'espera infinita.
