## 1. Implementació de la Correcció a MinijocUIManager

- [x] 1.1 Declarar la variable `private VisualElement _contenidorCablePelat;` a la secció de contenidors visuals de la classe `MinijocUIManager`.
- [x] 1.2 Afegir la línia `_contenidorCablePelat = root.Q<VisualElement>("ContenidorCablePelat");` dins del mètode `ShowUI`, on s'assignen la resta de contenidors visuals.

## 2. Verificació

- [x] 2.1 Confirmar que no hi ha errors de compilació CS0103 relacionats amb `_contenidorCablePelat`.
- [x] 2.2 Verificar que la referència s'obté correctament en temps d'execució.
