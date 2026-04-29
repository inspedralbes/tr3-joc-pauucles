## 1. Refactorización de Lógica de Minijuegos

- [x] 1.1 Modificar `MinijocPPTLLSLogic.cs` para asignar `_loser` al oponente del ganador antes de enviar el resultado.
- [x] 1.2 Modificar `MinijocParellsSenarsLogic.cs` para asignar `loser` correctamente basándose en los nombres de usuario de los participantes.
- [x] 1.3 Modificar `MinijocAcaparamentMiradesLogic.cs` para asignar `_loser` correctamente basándose en los nombres de usuario de los participantes.
- [x] 1.4 Asegurar que si el ganador es "Empat", el perdedor también sea "Empat" en los tres scripts.

## 2. Feedback de Daño en Player.cs

- [x] 2.1 Localizar el método `ProcesarDerrota` en `Player.cs`.
- [x] 2.2 Añadir `if (anim != null) anim.SetTrigger("Hurt");` al inicio del método para asegurar feedback visual.

## 3. Verificación de Sincronización

- [x] 3.1 Verificar en `MinijocUIManager.cs` que el manejo de "Empat" sigue siendo robusto tras los cambios en los emisores.
- [x] 3.2 Realizar una prueba de combate multijugador para confirmar que el perdedor ve la animación de daño antes del stun.
