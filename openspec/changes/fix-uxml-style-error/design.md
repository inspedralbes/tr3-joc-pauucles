## Context

Recentment s'ha afegit una etiqueta `<Style>` amb text directe a `MenuUI.uxml` per limitar l'alçada dels desplegables. Aquesta pràctica pot ser problemàtica en Unity UI Toolkit. Es proposa externalitzar aquest estil a un fitxer `.uss`.

## Goals / Non-Goals

**Goals:**
- Netejar `MenuUI.uxml` d'estils incrustats incorrectament.
- Crear un fitxer `.uss` estàndard per a estils globals de la interfície.
- Assegurar que la regla de `max-height` s'apliqui amb prioritat (`!important`).

**Non-Goals:**
- Refactoritzar tots els estils inline de l'UXML (només es mou el que causa l'error).
- Canviar el disseny visual més enllà de la correcció de l'alçada.

## Decisions

- **Fitxer Extern (.uss):** S'ha triat crear `MenuStyles.uss` per seguir les convencions d'Unity i permetre la reutilització d'estils.
- **Selector USS:** S'utilitzarà el selector `.unity-base-dropdown__container-inner` per atacar directament el contenidor intern generat per Unity per als Dropdowns.
- **Ús de `!important`:** S'afegeix `!important` per garantir que aquesta restricció d'alçada prevalgui sobre els estils per defecte del motor que sovint causen el tall visual.

## Risks / Trade-offs

- **[Risc] Camí del fitxer:** Si el fitxer `.uss` no es troba, l'UXML no tindrà estils.
  - **Mitigació:** Es col·locarà a la mateixa carpeta que l'UXML (`Assets/UI/`) i es referenciarà amb un camí relatiu segur.
