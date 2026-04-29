## Context

El sistema actual d'Unity només suporta un únic prefab per al jugador local i cap distinció visual per als remots. Al backend, el model d'usuari només conté credencials bàsiques. Cal estendre ambdues parts per suportar metadades estètiques.

## Goals / Non-Goals

**Goals:**
- Estendre el model d'usuari a MongoDB.
- Implementar un mecanisme de selecció de skin persistent.
- Suportar la instanciació dinàmica de prefabs basats en string de skin.

**Non-Goals:**
- Implementar un sistema de compra/monetització (totes les skins són accessibles per ara).
- Animacions personalitzades per cada skin (es pressuposa que totes les skins comparteixen el mateix set d'animacions bàsiques).

## Decisions

### 1. Model de Dades al Backend
S'afegirà `skinEquipada` com a `String` al model `User`.
- **Racional:** És la forma més flexible de mapejar noms de skin amb assets d'Unity sense haver de guardar IDs complexos o referències a assets externs.

### 2. Diccionari de Skins al GameManager
S'implementarà un llistat de parelles `NomSkin -> Prefab` al `GameManager`.
- **Racional:** Permet a l'artista/dissenyador d'Unity afegir noves skins a l'editor sense haver de tocar el codi de spawn.

### 3. Persistència de la Skin al Frontend
`MenuManager` emmagatzemarà la skin actual en la seva instància persistent (Singleton).
- **Racional:** En carregar l'escena "Bosque", el `GameManager` pot consultar directament a `MenuManager.Instance` quina skin ha de carregar sense haver de fer una nova petició API.

### 4. Transmissió via PLAYER_MOVE
S'afegirà el camp `skin` al missatge de WebSocket `PLAYER_MOVE` (opcionalment) o es transmetrà en el missatge d'inici.
- **Racional:** Els altres jugadors han de saber quina skin està usant cada un. Atès que les sales són petites, transmetre la skin en el missatge de moviment és la solució més senzilla per garantir la sincronització en temps real.

## Risks / Trade-offs

- **[Risk]** Si un client intenta carregar una skin que no té el seu prefab corresponent al diccionari local → **Mitigation**: El `GameManager` utilitzarà un prefab per defecte (Woodcutter) si la skin no es troba.
- **[Trade-off]** Mantenir tants prefabs instanciats pot carregar la memòria → **Mitigation**: Les skins són 2D/Pixel Art de baix pes, el risc és negligible per al prototip actual.
