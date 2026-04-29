## 1. Implementación de Colisiones en DroneAI

- [x] 1.1 Añadir el método `OnTriggerEnter2D(Collider2D other)` al final de la clase `DroneAI.cs`.
- [x] 1.2 Implementar el log de depuración: `Debug.Log($"[DRON-IA] He xocat amb: {other.name}");`.
- [x] 1.3 Implementar la detección de objetivos mediante el componente `Bandera` o el tag `Player`.

## 2. Lógica de Recompensa y Reinicio

- [x] 2.1 Asignar recompensa máxima: `AddReward(1f);` y logear el éxito.
- [x] 2.2 Implementar el reposicionamiento del dinosaurio/jugador a su posición original o un punto de spawn.
- [x] 2.3 Finalizar el episodio mediante `EndEpisode();`.

## 3. Validación y Limpieza

- [x] 3.1 Verificar que no existan restricciones de `teamId` en la nueva lógica de colisión.
- [x] 3.2 Compilar y verificar que no hay errores de sintaxis en Unity.
