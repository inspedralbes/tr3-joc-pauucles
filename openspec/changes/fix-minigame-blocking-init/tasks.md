## 1. Refactorización de Player.cs

- [x] 1.1 Implementar la función `IniciarMinijuegoLocal(int gameIndex, GameObject opponent)` que gestione el congelamiento físico y la llamada a `MinijocUIManager`.
- [x] 1.2 Modificar `OnCollisionEnter2D` para calcular el `gameIndex` de forma determinista usando el nombre del jugador alfabéticamente menor como semilla.
- [x] 1.3 Eliminar la restricción que impedía al "Cliente" abrir la interfaz de minijuego, permitiendo que ambos jugadores llamen a `IniciarMinijuegoLocal` inmediatamente.
- [x] 1.4 Optimizar las guardas de estado (`potCombatre`, `ultimXoc`) al inicio de `OnCollisionEnter2D` para silenciar colisiones redundantes.

## 2. Coordinación de Red

- [x] 2.1 Asegurar que la lógica de envío de `MINIJOC_START` permanezca exclusiva del jugador "Master" para informar a la sala.
- [x] 2.2 Verificar que el `gameIndex` enviado por red coincida exactamente con el calculado localmente.

## 3. Validación

- [ ] 3.1 Probar la colisión entre dos jugadores en un entorno multijugador y verificar que la UI aparece instantáneamente en ambos.
- [ ] 3.2 Verificar que no se producen errores de "Skipped: ... està en STUN" de forma repetitiva en el log tras la colisión.
