## 1. Correcció de referències a MinijocUIManager

- [x] 1.1 Declarar la variable `private VisualElement _contenidorCablePelat;` juntament amb els altres contenidors visuals a la part superior de la classe.
- [x] 1.2 Afegir la línia `_contenidorCablePelat = root.Q<VisualElement>("ContenidorCablePelat");` dins del mètode `ShowUI`, on s'assignen la resta de contenidors visuals.

## 2. Verificació

- [x] 2.1 Confirmar que no hi ha errors de compilació CS0103 relacionats amb `_contenidorCablePelat`.
- [x] 2.1 Verificar que el minijoc "Cable Pelat" es pot carregar correctament mitjançant la referència assignada.
