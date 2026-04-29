## Why

Actualment, les opcions dels `DropdownField` a la interfície d'usuari es tallen en desplegar-se, cosa que dificulta la selecció i empitjora l'experiència d'usuari.

## What Changes

- Afegir un bloc d'estils `<Style>` al fitxer `MenuUI.uxml` amb una regla per limitar l'alçada màxima del contenidor del desplegable.
- La regla específica és: `DropdownField > VisualElement.unity-base-dropdown__container-inner { max-height: 200px; }`.

## Capabilities

### New Capabilities
- `ui-styling-fixes`: Millores i correccions d'estils CSS per als components del UI Toolkit.

### Modified Capabilities
<!-- No requirement changes -->

## Impact

- `MenuUI.uxml`: Es modificarà per incloure el nou bloc d'estils.
