## 1. Implementació del Robatori en MinijocUIManager

- [x] 1.1 Eliminar la cerca global `GameObject.FindGameObjectWithTag("Bandera")` a `ProcessarResultatCombat`.
- [x] 1.2 Implementar el bucle `foreach (Transform child in perdedor.transform)` per cercar la bandera.
- [x] 1.3 Afegir la condició `if (child.CompareTag("Bandera"))` dins del bucle.
- [x] 1.4 Reassignar el pare de la bandera al guanyador: `child.SetParent(guanyador.transform);`.
- [x] 1.5 Reset del transform: `child.localPosition = new Vector3(-0.8f, 0, 0);` i `child.localScale = Vector3.one;`.
- [x] 1.6 Finalitzar la cerca amb `break;` un cop s'ha realitzat el robatori.
- [x] 1.7 Afegir un `Debug.Log` confirmant el robatori: `Debug.Log($"ROBATORI EFECTUAT: {guanyador.name} ha robat la bandera a {perdedor.name}");`.

## 2. Validació

- [x] 2.1 Verificar que el robatori només es produeix si el perdedor realment porta la bandera com a fill.
- [x] 2.2 Confirmar que la bandera es posiciona i escala correctament en el nou propietari.
- [x] 2.3 Validar que el log es mostra correctament a la consola un cop robada la bandera.
