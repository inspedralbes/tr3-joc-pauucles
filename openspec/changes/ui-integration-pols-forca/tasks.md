## 1. Integració de UI Toolkit en MinijocPolsimForcaLogic.cs

- [x] 1.1 Afegir la clàusula `using UnityEngine.UIElements;`.
- [x] 1.2 Declarar les variables privades `textTemps` (Label) i `barraJ1` (VisualElement).
- [x] 1.3 Implementar el mètode `public void InicialitzarUI(VisualElement root)` per localitzar elements per ID.
- [x] 1.4 Actualitzar l'`Update()` per incloure l'actualització del text de temps i l'amplada de la barra del Jugador 1 basat en el percentatge de puntuació.

## 2. Integració en MinijocUIManager.cs

- [x] 2.1 Afegir le minijoc de pols de força a la rotació/ruleta del gestor.
- [x] 2.2 Implementar la lògica d'activació: mostrar `#ContenidorPolsForca` i amagar la resta.
- [x] 2.3 Obtenir el component `MinijocPolsimForcaLogic` del GameObject actiu.
- [x] 2.4 Cridar `InicialitzarUI(arrelDocument)` i posteriorment `IniciarMinijoc()`.

## 3. Verificació

- [x] 3.1 Comprovar que le temporitzador de la pantalla mostra le temps real del joc.
- [x] 3.2 Comprovar que la barra del Jugador 1 es mou segons les pulsacions.
- [x] 3.3 Verificar que le minijoc es llança correctament quan le `MinijocUIManager` le selecciona.
