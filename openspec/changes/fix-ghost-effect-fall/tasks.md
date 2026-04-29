## 1. Modificacions a Player.cs

- [x] 1.1 Declarar el camp privat `private float originalGravity;` per emmagatzemar l'estat de la física.
- [x] 1.2 Actualitzar `AplicarCastigDerrota()` (o el mètode que activa el mode fantasma) per guardar `rb.gravityScale`.
- [x] 1.3 Implementar el reset de velocitat (`rb.linearVelocity = Vector2.zero`) i gravetat (`rb.gravityScale = 0`) en entrar en mode derrota.
- [x] 1.4 Actualitzar la corrutina `HandleLossCoroutine` (o la corrutina de tancament del càstig) per restaurar `rb.gravityScale` al seu valor original.

## 2. Validació

- [x] 2.1 Verificar a l'editor de Unity que el jugador no cau pel terra quan perd un combat.
- [x] 2.2 Confirmar que el jugador es queda surant en la posició exacta on ha perdut.
- [x] 2.3 Validar que després del temps de càstig, el jugador torna a tenir gravetat i col·lisiona amb el terra normalment.
