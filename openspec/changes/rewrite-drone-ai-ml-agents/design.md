## Context

La implementación actual de `DroneAI.cs` es funcional pero contiene lógica excesiva que puede dificultar el entrenamiento (múltiples enumeraciones de estados, lógica de colisiones compleja, etc.). El usuario solicita una reescritura "limpia" centrada en el estado del dinosaurio del equipo para optimizar el aprendizaje por refuerzo.

## Goals / Non-Goals

**Goals:**
- Simplificar la máquina de estados a los 3 estados del dinosaurio: `A_Salvo`, `Robado` y `Tirado`.
- Implementar un sensor vectorial de exactamente 8 observaciones (posiciones y velocidades).
- Estandarizar el movimiento continuo y el cálculo de recompensas por proximidad.
- Asegurar que no haya valores nulos en las observaciones para evitar fallos en el entrenamiento.

**Non-Goals:**
- No se implementará lógica de "entrega" o "captura" compleja dentro de este script si no es estrictamente necesario para el entrenamiento básico solicitado.
- No se añadirán sensores de rayos (RayPerceptionSensor) en esta fase.

## Decisions

- **Estructura de Estados:** Se utilizará una lógica de detección en tiempo real para determinar el objetivo del dron según la situación del dinosaurio (propiedad `parent` y posición respecto a la base).
- **Control de Movimiento:** Se usará `Rigidbody2D.MovePosition` o modificación directa de `velocity` basándose en `ContinuousActions`, aplicando `Time.fixedDeltaTime` como solicitó el usuario para asegurar consistencia en la física.
- **Normalización de Observaciones:** Aunque el usuario pidió valores (x,y) directos, se recomienda que el diseño permita futuras normalizaciones si la escala del mapa cambia drásticamente.
- **Target Dinámico:** El "objetivo" del dron cambiará automáticamente entre la base, el jugador enemigo (o aliado que lo robó) y el dinosaurio físico.

## Risks / Trade-offs

- **[Riesgo]** Si el dinosaurio es destruido o no se encuentra en la escena, las observaciones podrían fallar.
  - **Mitigación:** Se implementarán comprobaciones de seguridad para devolver la posición propia del dron o la base como fallback, asegurando que el sensor siempre reciba 8 valores.
- **[Riesgo]** Las recompensas continuas de 0.01f podrían acumularse demasiado si el episodio es muy largo.
  - **Mitigación:** El diseño asume que existen límites de tiempo o penalizaciones por pasos de tiempo (Time Penalty) configuradas en el entorno o en el `MaxStep` del agente.
