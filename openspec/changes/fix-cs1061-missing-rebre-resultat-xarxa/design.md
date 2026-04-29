## Context

S'ha eliminat un mètode necessari per a la integració amb el sistema de xarxa, provocant un error CS1061. Cal restaurar-lo amb la lògica simplificada que s'ha implementat recentment (sense fase de revelació).

## Goals / Non-Goals

**Goals:**
- Restaurar `RebreResultatXarxa(string winner)`.
- Gestionar la derrota del jugador local si el rival guanya.

**Non-Goals:**
- No s'ha de restaurar la fase de revelació de 3 segons.

## Decisions

- **Identificació del Guanyador**: Si `winner == "RIVAL_WIN"` (o qualsevol valor que no representi al jugador local en el protocol actual), es considerarà derrota local.
- **Acció Immediata**: Per coherència amb el canvi anterior, el tancament de la UI i la crida a `PerdreMinijoc()` seran immediats.

## Risks / Trade-offs

- **[Risc]**: Inconsistència en el protocol de noms de guanyadors. → **[Mitigació]**: Utilitzar una comprovació genèrica o la demanada per l'usuari.
