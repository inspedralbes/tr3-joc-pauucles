## 1. Auditoría y Preparación

- [x] 1.1 Localizar el método `OnTriggerEnter2D` en `Player.cs`.
- [x] 1.2 Identificar el bloque de código que gestiona las colisiones con las bases (actualmente usa los tags `BaseRoja` o similares).

## 2. Implementación de Lógica de Bases

- [x] 2.1 Implementar la detección del equipo de la base: determinar si el objeto colisionante es del equipo A o B basándose en su nombre (`PuntSpawn_Equip1` / `Equip2`).
- [x] 2.2 Añadir la guard clause para enemigos: `if (equipoBase != this.equip) return;`.
- [x] 2.3 Validar la entrega de bandera: dentro del bloque de base propia, verificar `if (banderaAgafada != null)`.
- [x] 2.4 Bloquear movimiento: `potMoure = false;`.
- [x] 2.5 Iniciar el minijuego de entrega: `if (MinijocUIManager.Instance != null) { MinijocUIManager.Instance.ShowUI(this, this); }`.
- [x] 2.6 Añadir logs de depuración para confirmar las acciones (ej: "Has entrat a la teva base amb la bandera").

## 3. Verificación

- [x] 3.1 Verificar que el script compila sin errores.
- [ ] 3.2 Validar en juego que los enemigos pueden cruzar las bases contrarias sin detenerse.
- [ ] 3.3 Confirmar que el minijuego se abre solo cuando el jugador entra en SU base con una bandera.
