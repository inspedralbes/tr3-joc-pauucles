## 1. Definició de Variables i Recerca d'Elements

- [x] 1.1 Declarar `private VisualElement pantallaTitol` i `private Button btnStartGame` a `MenuManager.cs`.
- [x] 1.2 Vincular les referències als nous elements dins de `VincularEsdevenimentsUI` mitjançant `root.Q`.
- [x] 1.3 Afegir logs de comprovació per assegurar que els elements es troben correctament a l'escena.

## 2. Lògica de Navegació

- [x] 2.1 Implementar la subscripció al clic de `btnStartGame` per canviar de `pantallaTitol` a `pantallaLogin`.
- [x] 2.2 Modificar `ActualitzarVisibilitatSegonsSessio` per amagar `pantallaTitol` en el bloc de "Force Reset".
- [x] 2.3 Ajustar la condició d'inicialització (quan no hi ha sessió activa) per mostrar `pantallaTitol` en lloc de `pantallaLogin`.

## 3. Verificació i Neteja

- [x] 3.1 Provar el flux d'arrencada sense sessió i comprovar que es mostra la pantalla de títol.
- [x] 3.2 Provar la transició al login fent clic al botó d'inici.
- [x] 3.3 Assegurar que la pantalla de títol no apareix si l'usuari ja té una sessió activa (torna del joc al menú).
