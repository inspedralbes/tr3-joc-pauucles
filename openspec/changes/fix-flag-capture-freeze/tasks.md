## 1. Modificación de Bandera.cs

- [x] 1.1 Añadir cláusula de salvaguarda `if (transform.parent != null) return;` al inicio de `OnTriggerEnter2D`.
- [x] 1.2 Eliminar la línea `player.potMoure = false;` dentro del bloque de captura.
- [x] 1.3 Eliminar el bloque de código que invoca a `MinijocUIManager.Instance.ShowUI`.
- [x] 1.4 Limpiar comentarios obsoletos relacionados con el bloqueo de movimiento y minijuegos.

## 2. Verificación

- [ ] 2.1 Verificar en Unity que la captura de la bandera no bloquea al jugador.
- [ ] 2.2 Verificar que no se inician minijuegos al capturar la bandera.
- [ ] 2.3 Confirmar que no se producen errores de consola tras la captura.
