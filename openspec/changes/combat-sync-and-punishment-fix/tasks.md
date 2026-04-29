## 1. Refactorización de Player.cs (Estados y Colisión)

- [x] 1.1 Asegurar que `private bool enCombate = false;` esté declarada.
- [x] 1.2 Insertar guarda en `OnCollisionEnter2D`: `if (enCombate || isFrozen || !potCombatre) return;`.
- [x] 1.3 Implementar activación inmediata de `enCombate = true;` tras validar colisión con enemigo.
- [x] 1.4 Modificar `LimpiarEstadoCombate()` para resetear `enCombate = false;` en todos los jugadores locales.

## 2. Refactorización de Apertura y Red

- [x] 2.1 En `Player.cs`, asegurar que el Host abra la UI localmente ANTES de llamar a `MenuManager.Instance.EnviarMinijocStart()`.
- [x] 2.2 Refactorizar todos los scripts de lógica de minijuegos para que sus resoluciones asignen nombres exactos a `winner` y `loser` (evitar strings vacíos).

## 3. Lógica de Castigo y Feedback Visual

- [x] 3.1 Declarar `private bool _combatAcabat = false;` en `MinijocUIManager.cs`.
- [x] 3.2 Implementar guarda de reentrancia en `FinalitzarCombat` usando `_combatAcabat`.
- [x] 3.3 Implementar el filtro estricto de identidad en `FinalitzarCombat`: solo ejecutar `ProcesarDerrota` si el usuario local coincide con el perdedor.
- [x] 3.4 Añadir `anim.SetTrigger("Hurt");` al inicio de `ProcesarDerrota` en `Player.cs`.
- [x] 3.5 Asegurar que `HideUI` y `FinalitzarCombat` llamen a `LimpiarEstadoCombate` para liberar todas las banderas de combate.

## 4. Validación

- [x] 4.1 Probar combate multijugador y verificar apertura síncrona.
- [x] 4.2 Confirmar que el ganador NO recibe stun ni reducción de vida.
- [x] 4.3 Verificar reproducción de la animación de daño en el perdedor.
