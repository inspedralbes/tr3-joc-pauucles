## Context

El fitxer `MenuUI.uxml` defineix la interfície d'usuari del menú principal i del lobby. Alguns camps de tipus `DropdownField` (com la selecció d'equips o de nombre de jugadors) poden tenir moltes opcions que, per defecte, es tallen si superen l'espai disponible.

## Goals / Non-Goals

**Goals:**
- Limitar l'alçada del desplegable per assegurar que sigui scrollable i no es talli.
- Aplicar l'estil de forma global a tots els `DropdownField` dins de `MenuUI.uxml`.

**Non-Goals:**
- Crear un fitxer `.uss` extern (es farà inline per simplicitat en aquest canvi puntual).
- Modificar el comportament funcional dels desplegables.

## Decisions

- **Estil Inline a UXML:** S'afegirà un element `<Style>` directament al document UXML.
  - **Raó:** És una correcció ràpida i específica per a aquest document.
  - **Alternativa:** Crear un fitxer `.uss`. Es descarta per no afegir més dependències de fitxers si només es necessita aquesta regla.

## Risks / Trade-offs

- **[Risc] Sobrescripció d'estils:** Altres estils podrien entrar en conflicte.
  - **Mitigació:** S'usa un selector prou específic (`DropdownField > VisualElement.unity-base-dropdown__container-inner`).
