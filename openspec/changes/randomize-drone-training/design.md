## Context

Actualmente `DroneAI.cs` tiene un método `OnEpisodeBegin` que solo resetea la posición del dron. Para un entrenamiento efectivo de ML-Agents, el agente debe estar expuesto a una gran variedad de estados iniciales para aprender a navegar hacia el objetivo independientemente de dónde se encuentre y en qué estado esté.

## Goals / Non-Goals

**Goals:**
- Implementar la aleatorización de la posición del objetivo (dinosaurio o jugador con dinosaurio) usando puntos de spawn.
- Implementar la aleatorización del estado del dinosaurio (hijo de un jugador o en el suelo).
- Asegurar que el dron siempre empiece desde su base para medir su capacidad de búsqueda.

**Non-Goals:**
- No se modificará la lógica de colisiones ni el sistema de recompensas ya implementado.
- No se implementarán nuevos sensores en esta fase.

## Decisions

- **Uso de `Transform[] spawnPoints`**: Proporciona flexibilidad al diseñador de niveles para definir dónde pueden ocurrir los eventos de interés.
- **Teletransporte en `OnEpisodeBegin`**: Es la práctica recomendada en ML-Agents para resetear el entorno.
- **Simulación de 'Robado'**: Al hacer al dinosaurio hijo de un jugador objetivo y teletransportar a ambos, forzamos al dron a rastrear una entidad dinámica.
- **Simulación de 'Tirado'**: Al poner el padre en `null` y teletransportar solo al dinosaurio, forzamos al dron a buscar un objeto estático en el mapa.

## Risks / Trade-offs

- **[Riesgo]** Si el array `spawnPoints` está vacío, el código podría fallar.
  - **Mitigación:** Se añadirá una comprobación para usar la posición inicial como fallback si el array está vacío o es nulo.
- **[Riesgo]** Teletransportar al jugador podría causar problemas si hay otros sistemas de física activos.
  - **Mitigación:** Asegurar que el teletransporte se haga de forma segura (p.ej. reseteando velocidades del Rigidbody si existe).
