## Context

La bandera es col·loca actualment a sobre del jugador, ocupant l'espai on es voldrien col·locar nametags. Per resoldre això, es vol que la bandera es desplaci cap als costats i que la seva posició s'actualitzi dinàmicament segons el moviment.

## Goals / Non-Goals

**Goals:**
- Alliberar l'espai superior del personatge.
- Implementar un comportament de "seguiment lateral" per a la bandera.
- Assegurar que el traspàs de bandera inicialitza la nova posició lateral.

**Non-Goals:**
- Implementar el nametag en aquest canvi.
- Afegir animacions de rotació a la bandera.

## Decisions

- **Lateralització de l'Offset**: S'ha triat l'offset `0.8` en l'eix X per garantir que la bandera quedi fora de l'sprite principal del jugador però encara unida visualment.
- **Actualització en Update**: Donat que el moviment és continu i depèn de l'input de l'usuari, la posició de la bandera es gestionarà dins del mètode `Update` de `Player.cs`. Es farà una cerca de fills per trobar l'objecte amb el tag "Bandera" per evitar dependències rígides entre scripts.
- **Inicialització en Manager**: Per evitar un "salt" visual en el moment del robatori, el `MinijocUIManager` configurarà la posició lateral inicial immediatament després de fer el `SetParent`.

## Risks / Trade-offs

- **[Risk] Rendiment de Find en Update**: Cridar a `GetComponentInChildren` o fer cerques de tags en cada frame pot ser costós. -> **[Mitigation]**: S'afegirà una referència interna `private Transform banderaPortant;` a `Player.cs` que s'actualitzarà només quan es detecti un canvi en la possessió, minimitzant el cost computacional en el bucle principal.
