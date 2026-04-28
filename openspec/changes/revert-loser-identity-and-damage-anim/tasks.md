## 1. Reversión en Player.cs

- [x] 1.1 Eliminar la línea `if (anim != null) anim.SetTrigger("Hurt");` del método `ProcesarDerrota`.

## 2. Reversión en Minijuegos (Lógica)

- [x] 2.1 Revertir `MinijocPPTLLSLogic.cs`: eliminar el envío de "Empat" doble y restaurar la asignación de ganador simple sin forzar `loser`.
- [x] 2.2 Revertir `MinijocParellsSenarsLogic.cs`: eliminar el envío de "Empat" doble y restaurar la lógica previa de `Resoldre`.
- [x] 2.3 Revertir `MinijocAcaparamentMiradesLogic.cs`: restaurar la lógica original de `FinalitzarFaseEleccio` y el envío de resultados.

## 3. Reversión en MinijocUIManager.cs

- [x] 3.1 Restaurar el método `FinalitzarCombat` eliminando el filtro estricto de identidad basado en nombres de usuario.
- [x] 3.2 Eliminar el manejo especial de "Empat" que omite stuns/vides si se introdujo en el último paso.
- [x] 3.3 Asegurar que el método `HideUI` mantenga su funcionalidad de limpieza básica sin dependencias de la última refactorización.

## 4. Validación

- [x] 4.1 Verificar que el juego compila sin errores.
- [x] 4.2 Confirmar que las ventanas se abren de forma sincronizada tras una colisión.
