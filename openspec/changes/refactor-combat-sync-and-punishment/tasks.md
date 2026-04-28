## 1. Refactorización de Player.cs (Fase 1: Candados)

- [x] 1.1 Declarar `private bool enCombate = false;` y asegurar que `isStunned` sea accesible.
- [x] 1.2 Insertar guarda al inicio de `OnCollisionEnter2D`: `if (enCombate || isFrozen) return;`.
- [x] 1.3 Establecer `enCombate = true;` inmediatamente después de las guardas de colisión válida.
- [x] 1.4 Modificar `LimpiarEstadoCombate()` para resetear `enCombate = false;`.

## 2. Refactorización de Red (Host y Sincronización)

- [x] 2.1 En `Player.cs`, asegurar que el Host abra la UI localmente ANTES de enviar el mensaje `MINIJOC_START`.
- [x] 2.2 Verificar en `MenuManager.cs` que el listener de `MINIJOC_START` asigne correctamente a los jugadores y abra la UI en el cliente.
- [x] 2.3 Refactorizar todos los scripts de lógica de minijuegos para que devuelvan nombres exactos de `winner` y `loser` (sin strings vacíos).

## 3. Lógica de Castigo y Feedback Visual (Fase 2)

- [x] 3.1 Declarar `private bool combatAcabat = false;` en `MinijocUIManager.cs`.
- [x] 3.2 Implementar la guarda de `combatAcabat` en `FinalitzarCombat` para evitar reentrancia.
- [x] 3.3 Implementar el filtro estricto de identidad: solo procesar `ProcesarDerrota` si `loserUsername == WebSocketClient.LocalUsername`.
- [x] 3.4 Añadir el trigger `anim.SetTrigger("Hurt");` al inicio de `ProcesarDerrota` en `Player.cs`.
- [x] 3.5 Asegurar que `HideUI` y `FinalitzarCombat` llamen a `LimpiarEstadoCombate` para liberar todas las banderas.

## 4. Validación

- [x] 4.1 Probar una colisión multijugador y verificar que el ganador no sufre stun.
- [x] 4.2 Confirmar que la animación de daño se reproduce en el perdedor.
- [x] 4.3 Verificar que el cooldown de combate (3s) y las nuevas banderas permiten pelear de nuevo tras la limpieza.
