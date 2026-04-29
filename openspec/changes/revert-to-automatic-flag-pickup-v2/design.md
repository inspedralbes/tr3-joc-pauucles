## Context

El sistema actual de recollida de bandera es basa en la proximitat i l'entrada manual de l'usuari (tecles E o RightControl). Això afegeix complexitat innecessària al script `Player.cs` i pot generar una experiència de joc poc polida si el "timing" no és perfecte.

## Goals / Non-Goals

**Goals:**
- Implementar una recollida de bandera totalment automàtica al entrar en contacte.
- Eliminar la dependència d'entrades de teclat per a la recollida.
- Simplificar `Player.cs` eliminant variables i funcions obsoletes.

**Non-Goals:**
- Modificar la lògica de "Deixar Bandera" o "Robar Bandera" durant el combat (excepte la part de reparentament si calgués, però es mantindrà la consistència).
- Canviar el comportament de la bandera quan cau al terra.

## Decisions

- **Ús de OnTriggerEnter2D i OnCollisionEnter2D**: S'implementarà la lògica en ambdós mètodes per garantir que la recollida funcioni independentment de com estiguin configurats els colliders/triggers a l'editor d'Unity.
- **Posicionament Immediat**: Al recollir la bandera, es farà un `SetParent(this.transform)` i es fixarà la `localPosition` a `(-0.8, 0, 0)` per a una resposta visual instantània.
- **Desactivació del Collider de la Bandera**: Per evitar conflictes físics mentre es porta la bandera, el seu collider es desactivarà immediatament al ser recollida.
- **Neteja de l'estat 'Fugint'**: S'assegurarà que el script `Bandera` deixi d'estar en estat `fugint` al ser capturada.

## Risks / Trade-offs

- **[Risc] Recollida simultània** → Si dos jugadors toquen la bandera al mateix frame, l'ordre d'execució d'Unity determinarà qui l'agafa. Com que el projecte ja preveu combats per col·lisió de jugadors, aquest comportament és acceptable.
- **[Trade-off] Redundància Trigger/Collision** → Implementar-ho en ambdós llocs duplica lleugerament la lògica, però augmenta la robustesa del sistema davant canvis en la configuració de la física.
