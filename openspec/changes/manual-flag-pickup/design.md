## Context

El sistema de captura de bandera actual és passiu (per contacte). Es requereix una transició a un sistema actiu on el jugador hagi de prémer una tecla per recollir la bandera quan hi estigui a prop. Això requereix mantenir un estat de proximitat dins de cada instància de `Player.cs`.

## Goals / Non-Goals

**Goals:**
- Implementar un sistema de "range detection" simple usant els esdeveniments de col·lisió de Unity.
- Diferenciar l'input segons el jugador (J1 vs J2).
- Mantenir la neteja de referències quan el jugador s'allunya de la bandera sense recollir-la.

**Non-Goals:**
- No es tracta de canviar el sistema de combat, només la recollida del terra o després d'un alliberament (fugida).
- No s'afegeixen indicadors visuals (UI) de "Prem E per recollir" en aquesta fase, tot i que el disseny ho permetria en el futur.

## Decisions

- **Variables d'estat a Player.cs**: S'afegeix `aPropDeBandera` (bool) i `banderaPropera` (GameObject). Això permet a l'`Update` saber exactament amb quin objecte interactuar sense haver de fer cerques globals costoses.
- **Input a l'Update**: S'ha triat `Update` en lloc de l'`InputSystem` (si n'hi hagués un de complex) per mantenir la consistència amb la resta del projecte que sembla usar `Input.GetKeyDown`.
- **Diferenciació d'Input**: S'utilitzarà una comprovació condicional basada en un `idJugador` (que s'hauria d'assegurar que existeix o afegir-lo si no hi és).
- **Desactivació de Collider al recollir**: Per evitar que el mateix jugador torni a disparar l'esdeveniment de proximitat mentre la porta, es desactiva el collider de la bandera un cop és filla.

## Risks / Trade-offs

- **[Risk] Referències nul·les**: Si la bandera es destrueix o desapareix mentre `banderaPropera` la apunta.
    - **Mitigation**: Comprovar sempre `if (banderaPropera != null)` abans d'accedir als seus components.
- **[Risk] Ordre d'Update**: L'input es podria perdre si el frame de col·lisió i el de la tecla no coincideixen exactament en casos molt extrems.
    - **Mitigation**: `GetKeyDown` és prou fiable per a aquest tipus d'interacció.
