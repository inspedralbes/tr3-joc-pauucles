## 1. Declaració de Variables i Neteja

- [x] 1.1 Declarar les variables `private float tempsRestant = 5f;`, `private bool jocActiu = false;` i `private bool respostaEsParell;`.
- [x] 1.2 Eliminar o refactoritzar variables obsoletes com `_faseRevelacio`, `_tempsRevelacio` i `_guanyador` si ja no són necessàries segons el nou disseny.

## 2. Inicialització de la UI i Events

- [x] 2.1 Actualitzar `InicialitzarUI(VisualElement root)` per obtenir les referències a `TextOperacio`, `TextTempsMates`, `BtnParells` i `BtnSenars`.
- [x] 2.2 Assignar els events `.clicked` als botons per comprovar la resposta de l'usuari.

## 3. Lògica del Minijoc

- [x] 3.1 Implementar `IniciarMinijoc()` per generar dos números aleatoris (1-50), calcular `respostaEsParell` i actualitzar el text de l'operació.
- [x] 3.2 Implementar el mètode `Update()` per gestionar el compte enrere de `tempsRestant` i actualitzar la UI.
- [x] 3.3 Implementar el mètode `CridarDerrota()` que tanqui la UI i notifiqui al `Player` local.
- [x] 3.4 Implementar la lògica de comprovació de resposta als botons, cridant `GuanyarMinijoc()` o `PerdreMinijoc()` segons correspongui.

## 4. Verificació

- [x] 4.1 Comprovar que el joc es tanca immediatament després de respondre o esgotar el temps.
- [x] 4.2 Verificar que els mètodes del `Player` local es criden correctament.
