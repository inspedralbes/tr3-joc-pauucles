## Context

El `MenuManager.cs` actualment permet fer login i crear sales, però no mostra una llista de les sales existents on un jugador es podria unir. Es necessita integrar un component `ListView` per visualitzar aquestes dades des del backend.

## Goals / Non-Goals

**Goals:**
- Obtenir la llista de partides en estat 'waiting' des de l'API.
- Poblar dinàmicament el `ListView` "llistaPartides" amb aquesta informació.
- Refrescar la llista cada vegada que l'usuari entra al Lobby.

**Non-Goals:**
- Implementar la funcionalitat d'unir-se a una partida (només es llisten).
- Implementar refresc automàtic (polling) en temps real (només es carrega en entrar).

## Decisions

- **Estructures de Dades (Classes Serialitzables):**
  Es crearan classes `GameData`, `PlayerData` i un wrapper `GameListWrapper` per parsejar el JSON retornat pel backend. Com que el backend retorna un array d'objectes directament, s'usarà el truc de concatenació de strings per envoltar-lo en un objecte que `JsonUtility` pugui processar.
  ```csharp
  [System.Serializable]
  public class GameData {
      public string roomId;
      public PlayerData[] players;
      public int maxPlayers;
      // ... altres camps si calen
  }
  ```

- **UnityWebRequest (GET):**
  S'implementarà una corrutina `ObtenirPartides()` que farà una crida GET a `/games/list`.

- **Configuració del ListView:**
  - `makeItem`: Retornarà un nou `Label`.
  - `bindItem`: Assignarà el text al Label formatat com: `"Sala: {roomId} - Jugadors: {players.Length}/{maxPlayers}"`.

## Risks / Trade-offs

- **[Risc] Incompatibilitat de Format JSON:** El backend retorna un array directament, cosa que `JsonUtility` no suporta nativament per a l'arrel.
  - **Mitigació:** Envoltar el JSON rebut amb `{"games": [RESULTAT_REBUT]}` abans de fer el `FromJson`.
- **[Risc] Llista Buida:** Si no hi ha partides, el ListView ha de quedar buit sense errors.
  - **Mitigació:** Verificar si la llista de partides és nul·la o buida abans d'assignar-la.
