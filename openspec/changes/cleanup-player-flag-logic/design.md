## Context

El projecte ha evolucionat cap a un sistema de mascota físicament independent. Això ha deixat residus a `Player.cs` com la variable `banderaPortant` (anteriorment usada per al parentiu) i mètodes de recollida automàtica que ja no són necessaris degut a la consolidació en Triggers.

## Goals / Non-Goals

**Goals:**
- Netejar `Player.cs` de codi mort i warnings (CS0414).
- Unificar tota la detecció de la bandera en un sol mètode Trigger robus.
- Implementar la ignorància de col·lisions de manera recursiva per a la mascota.

**Non-Goals:**
- No es modificarà la classe `Bandera` en aquest canvi (només com el jugador interacciona amb ella).

## Decisions

- **Eliminació radical**: Es suprimiran mètodes sencers (`AgafarBandera`, `AgafarBanderaAutomàticament`) en lloc de refactoritzar-los, per assegurar que no quedi lògica duplicada.
- **Implementació In-Place**: La lògica de recollida s'escriurà directament dins de `OnTriggerEnter2D` per mantenir-la compacta i vinculada a l'esdeveniment que la dispara.
- **IgnoreCollision amb nuls**: S'inclouran comprovacions de nul·litat dins del bucle `foreach` per evitar errors en temps d'execució si algun collider de la mascota és eliminat o no existeix.

## Risks / Trade-offs

- **[Risc] Altres scripts que cridin a `AgafarBandera`** → **Mitigació**: Es pressuposa que el jugador és l'únic que inicia la recollida. Si el combat utilitza `RobarBandera`, aquest mètode haurà de ser actualitzat en el futur o consolidat amb la nova lògica.
