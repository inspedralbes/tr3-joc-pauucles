## 1. Declaració i Vinculació

- [x] 1.1 Declarar `private Button btnExitGame` a `MenuManager.cs`.
- [x] 1.2 Implementar la cerca `btnExitGame = root.Q<Button>("btnExitGame")` dins de `VincularEsdevenimentsUI`.
- [x] 1.3 Afegir un log informatiu quan el botó es troba correctament.

## 2. Implementació de Lògica

- [x] 2.1 Afegir l'esdeveniment de clic al botó `btnExitGame` per cridar `UnityEngine.Application.Quit()`.
- [x] 2.2 Incloure un log de depuració `UnityEngine.Debug.Log("Sortint del joc...")` dins de l'esdeveniment.
- [x] 2.3 Verificar que el botó té un null-check per evitar crasitjos si no existeix a l'UXML.

## 3. Verificació

- [x] 3.1 Comprovar a la consola d'Unity que el missatge de sortida apareix en prémer el botó en mode Play (el joc no es tancarà a l'editor, però el log confirma la crida).
- [x] 3.2 Assegurar que no hi ha errors de referència nula en carregar el menú.
