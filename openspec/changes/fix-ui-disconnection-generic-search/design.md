## Context

S'ha detectat que el minijoc sovint falla quan es modifiquen els fitxers `.uxml` i els noms dels elements no coincideixen exactament. Per evitar-ho, implementarem una cerca genèrica d'elements.

## Goals / Non-Goals

**Goals:**
- Implementar cerques d'elements UI Toolkit per tipus (`Label`, `Button`) i llistat.
- Eliminar la dependència de `root.Q<T>("nom")`.
- Centralitzar la lògica de resposta en un mètode `Respon`.

**Non-Goals:**
- No es canviarà la lògica matemàtica (suma aleatòria) del minijoc.

## Decisions

- **Accés a l'Arrel**: S'usarà `GetComponent<UIDocument>().rootVisualElement` dins d' `IniciarMinijoc` (o `InicialitzarUI`) per assegurar l'accés actualitzat a la jerarquia visual.
- **Accés per Índex**: 
    - L'operació es mostrarà a la segona etiqueta trobada (`labels[1]`).
    - El botó de "Parell" serà el primer trobat (`botons[0]`).
    - El botó de "Senar" serà el segon trobat (`botons[1]`).
- **Tancament**: S'usarà `this.gameObject.SetActive(false)` per tancar la interfície.

## Risks / Trade-offs

- **[Risc]**: Si l'ordre dels elements al `.uxml` canvia, el comportament podria ser inesperat. → **[Mitigació]**: Aquest mètode és preferit per l'usuari en aquest context de prototipat ràpid per sobre de la fragilitat dels noms.
