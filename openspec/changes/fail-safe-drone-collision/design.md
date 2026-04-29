## Context

El `DroneAI` es responsable de interceptar al ladrón (jugador con bandera) o recuperar la bandera (dinosaurio). Actualmente, no existe una lógica de colisión explícita que premie al dron por contacto físico, confiando únicamente en recompensas por proximidad. Esto dificulta el entrenamiento y la validación en modo local.

## Goals / Non-Goals

**Goals:**
- Implementar `OnTriggerEnter2D` en `DroneAI.cs`.
- Detectar colisiones con objetos que tengan el componente `Bandera` o el tag `Player`.
- Otorgar recompensa máxima (+1.0) y finalizar el episodio en caso de éxito.
- Reposicionar al dinosaurio/jugador para el siguiente episodio.

**Non-Goals:**
- Modificar el sistema de observación del sensor.
- Cambiar la lógica de movimiento o la velocidad del dron.

## Decisions

- **Uso de Triggers**: Se utilizará `OnTriggerEnter2D` asumiendo que el dron o el objetivo tienen un Collider2D configurado como Trigger.
- **Identificación de Objetivo**: 
    - `other.GetComponent<Bandera>() != null` para detectar el dinosaurio/bandera.
    - `other.CompareTag("Player")` para detectar al jugador portador.
- **Reset de Posición**: Se utilizará el primer punto de `spawnPoints` (si existe) o la posición actual del dinosaurio como fallback para el reset antes de llamar a `EndEpisode()`.

## Risks / Trade-offs

- [Riesgo] → Colisiones accidentales con otros objetos. 
- [Mitigación] → Uso estricto de tags y componentes para filtrar solo objetivos válidos.
- [Riesgo] → El dron se queda bloqueado tras el reset.
- [Mitigación] → `EndEpisode()` asegura que el `OnEpisodeBegin()` del dron se ejecute, reseteando su propia posición a `initialPosition`.
