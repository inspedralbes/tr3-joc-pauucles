## Context

La persistència de mètodes antics i parcialment actualitzats pot estar causant la pèrdua de propietats físiques de la bandera en moments crítics (recollida). Cal una reescriptura total per assegurar un estat consistent.

## Goals / Non-Goals

**Goals:**
- Unificar la lògica de recollida a `Player.cs`.
- Unificar la lògica d'activació a `Bandera.cs`.
- Garantir el mode `Dynamic` i el collider habilitat.

**Non-Goals:**
- No es modificarà la lògica de detecció (`OnTriggerEnter2D`).

## Decisions

- **Reescriptura completa**: No es faran pedaços, sinó que es substituiran els mètodes sencers amb les implementacions proporcionades.
- **`IgnoreCollision` recursiu**: S'aplica a tots els fills per assegurar que cap Hitbox o collider secundari empenyi al jugador.
- **Sincronització d'estats**: El mètode `ComençarASeguir` forçarà l'estat `Dynamic` i `enabled = true` del collider local per revertir qualsevol desactivació prèvia.

## Risks / Trade-offs

- **[Risc] Sobreescriure lògica personalitzada** → **Mitigació**: Es pressuposa que la implementació sol·licitada és la definitiva i desitjada per l'usuari.
