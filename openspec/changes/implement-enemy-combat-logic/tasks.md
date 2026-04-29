## 1. Auditoría y Localización

- [x] 1.1 Localizar el método `OnCollisionEnter2D` en `Player.cs`.
- [x] 1.2 Confirmar que la variable `equip` es accesible tanto en el jugador local como en los oponentes.

## 2. Implementación de Lógica de Combate

- [x] 2.1 Implementar filtro inicial para detectar el tag "Player": `if (collision.gameObject.CompareTag("Player"))`.
- [x] 2.2 Obtener el componente `Player` del oponente y validar que no sea nulo.
- [x] 2.3 Implementar la validación de equipos enemigos: `if (opponent.equip != this.equip)`.
- [x] 2.4 Añadir la comprobación de estado de minijuego activo: `if (MinijocUIManager.Instance != null && !MinijocUIManager.Instance.minijocActiu)`.
- [x] 2.5 Ejecutar el bloqueo de movimiento y disparo de UI: `potMoure = false; MinijocUIManager.Instance.ShowUI(this, opponent);`.
- [x] 2.6 Añadir log de depuración: `Debug.Log("[Player] Choque contra enemigo detectado. Iniciando minijuego.");`.

## 3. Verificación

- [x] 3.1 Verificar que el script compila sin errores.
- [ ] 3.2 Validar en juego que el combate se dispara solo con enemigos.
- [ ] 3.3 Validar que el combate NO se dispara con aliados.
- [ ] 3.4 Confirmar que el movimiento se bloquea correctamente al iniciar el minijuego.
