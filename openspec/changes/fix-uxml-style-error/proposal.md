## Why

L'etiqueta `<Style>` amb contingut de text directe no és vàlida o no és la millor pràctica en UXML (Unity Toolkit), la qual cosa pot causar errors o no aplicar-se correctament. Cal migrar els estils a un fitxer `.uss` extern per a una millor organització i funcionalitat (ús d' `!important`).

## What Changes

- Eliminació de l'etiqueta `<Style>` amb text intern de `MenuUI.uxml`.
- Creació d'un nou fitxer d'estils `MenuStyles.uss` a `Assets/UI/`.
- Definició de la regla `.unity-base-dropdown__container-inner { max-height: 200px !important; }` al nou fitxer `.uss`.
- Vinculació del fitxer `.uss` a `MenuUI.uxml` mitjançant `<Style src="MenuStyles.uss" />`.

## Capabilities

### New Capabilities
- `external-ui-styling`: Ús de fitxers USS externs per gestionar els estils de la interfície d'usuari.

### Modified Capabilities
<!-- Cap canvi en requeriments funcionals -->

## Impact

- `MenuUI.uxml`: Es modifica l'etiqueta d'estils.
- Nou fitxer `MenuStyles.uss`: S'afegeix al projecte.
