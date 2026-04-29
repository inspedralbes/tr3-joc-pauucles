## ADDED Requirements

### Requirement: Fixar Escala de la Bandera
El sistema HA DE garantir que la bandera mantingui una escala visual constant de `(3, 3, 1)` quan sigui transportada per un jugador, independentment de l'escala del pare.

#### Scenario: Recollida de Bandera amb Escala Correcta
- **WHEN** un jugador recull la bandera (automàticament o per robatori)
- **THEN** la bandera HA DE ser reparentada al jugador I la seva `localScale` HA DE ser fixada a `(3, 3, 1)` immediatament.

### Requirement: Combat Instantani per Col·lisió
El sistema HA DE iniciar el procés de combat immediatament quan dos jugadors col·lideixen, sense requerir cap entrada addicional per part de l'usuari.

#### Scenario: Inici de Combat Immediat
- **WHEN** el collider d'un jugador entra en col·lisió amb el collider d'un altre jugador (Tag "Player")
- **THEN** el sistema HA DE cridar a `MinijocUIManager.Instance.ShowUI` de forma immediata.

### Requirement: Efecte Visual AFK (Inactivitat)
El sistema HA DE proporcionar un feedback visual de parpelleig quan un jugador estigui inactiu durant un temps determinat.

#### Scenario: Parpelleig per Inactivitat (3s)
- **WHEN** l'input horitzontal d'un jugador és `0` durant més de 3 segons
- **THEN** l'alpha del seu `SpriteRenderer` HA DE variar cíclicament entre `0` i `1` (efecte parpelleig).

#### Scenario: Reset de l'Estat d'Inactivitat
- **WHEN** un jugador realitza un moviment horitzontal (Input != 0) estant en estat AFK
- **THEN** l'alpha del seu `SpriteRenderer` HA DE tornar a `1` immediatament i el temporitzador d'inactivitat HA DE ser resetejat a `0`.
