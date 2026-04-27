## Context

Actualmente el dron utiliza un sistema híbrido entre una máquina de estados para la red y un agente de ML-Agents para el movimiento. El entrenamiento actual carece de contexto sobre el estado global de la bandera (dinosaurio), lo que dificulta que aprenda cuándo debe atacar y cuándo debe patrullar la base.

## Goals / Non-Goals

**Goals:**
- Implementar una clasificación de estados de juego robusta para la IA.
- Optimizar el sensor para proveer solo la información relevante por estado.
- Definir una función de recompensa que incentive la defensa activa y la recuperación rápida.

**Non-Goals:**
- Implementar lógicas de ataque complejas (disparos, etc.).
- Modificar el sistema de red Socket.IO.

## Decisions

### 1. Clasificación de Estados Dinámica
Se creará un método `DeterminarEstadoDinosaurio()` que verificará:
1. Posición del dinosaurio respecto a la base.
2. Si el dinosaurio tiene un padre (parent) que sea un objeto `Player`.
*Rationale*: Usar el sistema de jerarquía de Unity para detectar si alguien lo lleva es más eficiente que iterar sobre todos los jugadores constantemente.

### 2. Estructura de Observaciones (10 entradas)
El vector de observaciones tendrá un tamaño fijo de 10:
- Posición local dron (x, y) [2]
- Posición base (x, y) [2]
- Posición objetivo dinámico (x, y) [2]
- Estado actual (one-hot encoding o valor escalar) [1]
- Velocidad actual dron (x, y) [2]
- Distancia al objetivo [1]

### 3. Lógica de Colisiones para Recompensas
Se usará `OnTriggerEnter2D` para detectar el contacto con el "ladrón" o la "bandera tirada".
- Si `other` tiene el dinosaurio -> `AddReward(1.0f)` + `EndEpisode()`.
- Si `other` es el dinosaurio y está en estado `Tirado` -> `AddReward(1.0f)` + `EndEpisode()`.
*Rationale*: Finalizar el episodio tras un éxito refuerza positivamente la secuencia de acciones que llevó a ese resultado.

## Risks / Trade-offs

- **[Risk] Loop de recompensas infinito** -> **Mitigación**: Asegurar que las recompensas continuas por distancia sean pequeñas (0.01f max) comparadas con la recompensa por éxito (1.0f).
- **[Risk] Jittering en el cambio de estado** -> **Mitigación**: Añadir un pequeño margen (threshold) de distancia para el estado `A_Salvo`.
