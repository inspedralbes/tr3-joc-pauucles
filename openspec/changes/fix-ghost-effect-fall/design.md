## Context

L'efecte "Fantasma" per als jugadors derrotats (isTrigger = true) permet que altres jugadors els travessin, millorant la fluïdesa del joc. No obstant això, aquesta acció desactiva les col·lisions físiques amb tot l'entorn, incloent el terra. Això fa que els jugadors caiguin al buit per l'acció de la gravetat si no es gestiona el Rigidbody correctament.

## Goals / Non-Goals

**Goals:**
- Impedir que el jugador caigui pel terra mentre el seu collider és un trigger.
- Assegurar que el jugador quedi suspès en la seva posició actual durant la derrota.
- Restaurar la física normal del jugador un cop acaba el període de càstig.

**Non-Goals:**
- Canviar el mètode de detecció de col·lisions base del projecte.
- Modificar els límits físics de l'escena.

## Decisions

- **Emmagatzematge de gravityScale**: S'afegirà un camp privat `private float originalGravity;` a `Player.cs`. Això permet suportar diferents escales de gravetat si en el futur s'implementen power-ups que la modifiquin, assegurant que tornem sempre al valor correcte.
- **Zero Gravetat vs Kinematic**: S'ha triat posar `gravityScale = 0` en lloc de canviar a Kinematic per mantenir la simplicitat de la implementació i evitar efectes secundaris amb el motor de física que podrien ocórrer en canviar el tipus de cos en temps d'execució.
- **Reset de Velocitat**: En cridar `AplicarCastigDerrota`, es farà `rb.linearVelocity = Vector2.zero` per cancel·lar qualsevol impuls previ (com un salt) que pogués fer que el jugador seguís pujant o movent-se lateralment mentre és fantasma.

## Risks / Trade-offs

- **[Risk] Fallada en la restauració**: Si la corrutina de càstig es cancel·la o l'objecte es destrueix de forma anòmala, el jugador podria quedar-se en gravetat zero. -> **[Mitigation]**: Com que la restauració es fa al final de la corrutina `HandleLossCoroutine`, s'assegurarà que el bloc de codi sigui el més robust possible.
