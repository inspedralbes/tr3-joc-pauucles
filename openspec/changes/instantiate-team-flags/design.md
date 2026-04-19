## Context

Per millorar la identificació dels equips en el combat, s'ha de mostrar la bandera de cada equip al seu punt de spawn. La informació dels colors prové del backend i està emmagatzemada al `MenuManager` durant la fase de lobby.

## Goals / Non-Goals

**Goals:**
- Exposar les dades de la sala a `MenuManager`.
- Instanciar banderes dinàmiques basades en el color a `GameManager`.
- Posicionar les banderes prop dels jugadors en iniciar la partida.

**Non-Goals:**
- Sincronitzar el moviment de les banderes via xarxa (la bandera només s'instancia com a objecte local per ara, tot i que podria ser agafable més endavant).
- Canviar el sistema de spawns.

## Decisions

### 1. Variable Pública currentRoomData al MenuManager
S'afegirà `public GameData currentRoomData;` a `MenuManager`.
- **Racional:** Permet que qualsevol script accedeixi a la configuració completa de la sala (colors, màxim de jugadors, etc.) sense haver de fer peticions addicionals.

### 2. Mètode GetFlagPrefab al GameManager
S'implementarà un mètode d'ajuda per mapejar strings de color a GameObjects.
- **Racional:** Centralitza la lògica de selecció i facilita l'addició de nous colors en el futur.

### 3. Offset de Posicionament
S'aplicarà un offset `new Vector3(2f, 0f, 0f)` respecte al transform del punt de spawn.
- **Racional:** Evita solapaments visuals immediats amb el personatge del jugador en aparèixer.

## Risks / Trade-offs

- **[Risk]** Si el `MenuManager.Instance.currentRoomData` és nul en el moment de la instanciació, el procés fallarà. -> **Mitigation:** S'afegiran comprovacions de nul·litat i valors per defecte.
