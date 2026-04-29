## Why

S'ha detectat que la vinculació de la UI mitjançant noms de selectors (`root.Q<Button>("Nom")`) és fràgil si el fitxer `.uxml` canvia els noms dels elements. Aquest canvi proposa usar cerques genèriques per tipus d'element i índex per assegurar la funcionalitat del minijoc independentment dels noms interns de la UI.

## What Changes

- **Búsqueda Genèrica de l'Arrel**: Obtenir el `rootVisualElement` directament des del component `UIDocument`.
- **Assignació de Labels per Índex**: Buscar totes les `Label` i actualitzar el text de l'operació basant-se en la seva posició a la llista.
- **Assignació de Botons per Índex**: Buscar tots els `Button` i assignar els events de clic per posició (el primer botó és "Parell", el segon és "Senar").
- **Nou Mètode de Resposta**: Centralitzar la lògica de comprovació en un mètode `Respon(bool esParell)` que inclou logs de depuració i tancament immediat de la UI.

## Capabilities

### New Capabilities
- Cap.

### Modified Capabilities
- `minijoc-parells-senars-logic`: Millora de la robustesa en la connexió amb la interfície d'usuari.

## Impact

- `MinijocParellsSenarsLogic.cs`: Es modificarà la forma en què s'inicialitza la UI i es gestionen les respostes.
