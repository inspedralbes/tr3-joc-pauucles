## 1. Refactorització del Contenidor Pare

- [x] 1.1 Modificar `#PantallaTitol` a `MenuUI.uxml` per treure el `background-image` i el `-unity-background-scale-mode`.
- [x] 1.2 Configurar `#PantallaTitol` amb `width: 100%`, `height: 100%`, `justify-content: center` i `align-items: center`.

## 2. Reestructuració de la Capsa de la Màquina

- [x] 2.1 Actualitzar `#CapsaMaquina` amb `width: 800px`, `height: 600px` i `position: relative`.
- [x] 2.2 Eliminar l'estil `-unity-background-scale-mode` de `#CapsaMaquina` si no és necessari.

## 3. Reubicació i Posicionament d'Elements Fills

- [x] 3.1 Moure el `Label` ("ATRAPA AL DINOSAURE") directament sota `#CapsaMaquina`.
- [x] 3.2 Moure els botons `#btnStartGame` i `#btnExitGame` directament sota `#CapsaMaquina`.
- [x] 3.3 Eliminar el contenidor `#GrupBotons` un cop estigui buit.
- [x] 3.4 Configurar el `Label` i els dos botons amb `position: absolute` i `margin: 0`.

## 4. Estilització de Botons

- [x] 4.1 Configurar `#btnStartGame` amb `background-color: transparent` i `border-width: 0`.
- [x] 4.2 Configurar `#btnExitGame` amb `background-color: transparent` i `border-width: 0`.

## 5. Verificació

- [x] 5.1 Verificar que la pantalla de títol es manté centrada i els elements conserven una posició coherent dins de la capsa de 800x600.
