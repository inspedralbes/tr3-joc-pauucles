## Context

El proyecto es un juego desarrollado en Unity donde los personajes deben interactuar con objetos (banderas o dinosaurios). Se requiere implementar un sistema de Inteligencia Artificial para el personaje Cyborg utilizando el framework Unity ML-Agents. El agente debe aprender a navegar por el entorno, recoger un dinosaurio y entregarlo en una base específica.

## Goals / Non-Goals

**Goals:**
- Implementar la clase `CyborgIA` heredando de `Agent`.
- Configurar el movimiento 2D basado en acciones discretas (4 direcciones).
- Definir el sistema de observación: posición propia, del dinosaurio, de la base y estado de posesión.
- Establecer un sistema de recompensas que incentive la entrega rápida y penalice la inactividad.
- Permitir el control manual mediante `Heuristic` para validación.

**Non-Goals:**
- No se incluye el entrenamiento efectivo del modelo (solo la infraestructura de código).
- No se modificarán las físicas globales del juego, solo el comportamiento del Cyborg.

## Decisions

- **Acciones Discretas:** Se utilizará un único parámetro de acción discreta para las 4 direcciones (Arriba, Abajo, Izquierda, Derecha) para simplificar el espacio de acciones.
- **Físicas con Rigidbody2D:** Se usará `linearVelocity` para el movimiento, asegurando que el agente respete las colisiones del entorno.
- **Parentesco para Transporte:** Al recoger el dinosaurio, este se convertirá en hijo del Cyborg para facilitar el transporte visual y lógico, centrando su posición local.
- **Aleatorización Local:** En cada inicio de episodio, el Cyborg y el dinosaurio se posicionarán aleatoriamente en un rango definido para evitar el sobreajuste a posiciones fijas.

## Risks / Trade-offs

- **[Riesgo] Interferencia de colisiones al emparentar:** El dinosaurio podría causar empujones no deseados al Cyborg si tiene colisionadores activos.
  - **Mitigación:** Asegurarse de que el dinosaurio no interfiera físicamente con el Cyborg mientras está siendo transportado (ajuste de capas o desactivación temporal de triggers si es necesario).
- **[Riesgo] Espacio de observación limitado:** Solo se observan posiciones absolutas locales.
  - **Mitigación:** Si el entrenamiento falla, se considerará añadir distancias relativas o sensores de rayos (RayPerceptionSensor).
