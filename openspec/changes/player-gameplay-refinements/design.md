## Context

El script `Player.cs` gestiona el moviment, les col·lisions i la interacció amb la bandera. Actualment, el combat és per col·lisió però l'usuari vol garantir que sigui instantani. També hi ha una manca de feedback visual quan un jugador deixa de moure's, i s'han detectat problemes amb l'escala de la bandera en ser vinculada al jugador.

## Goals / Non-Goals

**Goals:**
- Fixar l'escala de la bandera a `(3, 3, 1)` en ser recollida.
- Garantir que el combat entre jugadors s'inicia immediatament en el moment de la col·lisió.
- Implementar un estat de parpelleig visual després de 3 segons d'inactivitat (inactivitat definida per la falta d'input horitzontal).

**Non-Goals:**
- Implementar un sistema d'animacions complex (s'usarà només l'alpha del SpriteRenderer).
- Canviar la gravetat o altres paràmetres físics.

## Decisions

- **Ajust d'escala immediat**: S'afegirà l'assignació de `localScale` just després de `SetParent` a `AgafarBandera` per sobreescriure l'escala heretada.
- **Temporitzador AFK**: Es crearà una variable privada `tempsInactiu` (float) que s'incrementarà a l'`Update` si `moveInput == 0`.
- **Efecte de parpelleig**: S'utilitzarà `Mathf.PingPong(Time.time * 4f, 1f)` per variar el component `a` (alpha) del color del `SpriteRenderer` quan `tempsInactiu > 3f`.
- **Reset de l'Estat**: Qualsevol moviment horitzontal tornarà l'alpha a `1` i el temporitzador a `0`.
- **Combat per Col·lisió**: Es verificarà la lògica a `OnCollisionEnter2D` per assegurar que la crida a `MinijocUIManager.Instance.ShowUI` es realitza sense més esperes ni requeriments.

## Risks / Trade-offs

- **[Risc] Confusió amb Invulnerabilitat** → El parpelleig AFK podria confondre's amb un estat d'invulnerabilitat (ja que el personatge es torna groc quan guanya). *Mitigació*: L'efecte AFK només afecta a la transparència (alpha), no al color groc, permetent distingir-los.
- **[Trade-off] Detecció d'Input** → Definir inactivitat només per input horitzontal és senzill però efectiu per a un joc 2D de plataformes.
