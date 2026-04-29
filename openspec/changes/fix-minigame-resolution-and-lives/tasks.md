## 1. Refactorización de MinijocUIManager

- [x] 1.1 Declarar la variable `private bool isConcluding = false;` en la clase `MinijocUIManager`.
- [x] 1.2 Implementar la guarda al inicio de `FinalitzarCombat`: si `isConcluding` es true, salir; si no, poner a true.
- [x] 1.3 Refactorizar la lógica de asignación de derrota en `FinalitzarCombat` para usar una comparación estricta de nombres de usuario.
- [x] 1.4 Asegurar que el método `HideUI` resetee `isConcluding = false` para el siguiente combate.

## 2. Ajustes de Temporizadores en Minijuegos

- [x] 2.1 Localizar el método `RebreActualitzacioXarxa` en `MinijocPPTLLSLogic.cs` y eliminar reinicios de temporizador.
- [x] 2.2 Localizar el método `RebreActualitzacioXarxa` en `MinijocParellsSenarsLogic.cs` y eliminar reinicios de temporizador.
- [x] 2.3 Localizar el método `RebreActualitzacioXarxa` en `MinijocAturaBarraLogic.cs` y eliminar reinicios de temporizador.

## 3. Estabilidad del Dron (Modo Piedra)

- [x] 3.1 Modificar `DroneAI.cs` para detectar el estado `A_Salvo` en el método `Update`.
- [x] 3.2 Forzar `rb.linearVelocity = Vector2.zero` cuando el dinosaurio esté en la base.
- [x] 3.3 Desactivar temporalmente el componente `decisionRequester` durante el estado de reposo.

## 4. Limpieza Post-Combate

- [x] 4.1 Implementar un método estático `Player.LimpiarEstadoCombate()` que resetee `ultimXoc` y variables de colisión.
- [x] 4.2 Llamar a este método de limpieza desde `FinalitzarCombat` tras cerrar la interfaz.
- [x] 4.3 Asegurar que no existan estados de stun residuales en el ganador.
