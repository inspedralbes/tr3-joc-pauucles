## Context

El `DroneAI` debe transicionar de un sistema basado en episodios a uno de ejecución continua. El mayor desafío técnico es la localización dinámica de objetivos en una escena multijugador y la implementación de una lógica de transporte física que no interfiera con las observaciones del modelo entrenado.

## Goals / Non-Goals

**Goals:**
- Implementar búsqueda dinámica de banderas mediante `FindObjectsByType<Bandera>()`.
- Utilizar jerarquía de transforms (`SetParent`) para el transporte.
- Mantener la compatibilidad con las entradas de la red neuronal (`CollectObservations`).

**Non-Goals:**
- Modificar el archivo `.onnx` o la estructura de la red neuronal.
- Implementar lógica de combate ofensivo para el dron (solo captura/recuperación).

## Decisions

- **Localización de Objetivos**: Se opta por buscar objetos con el componente `Bandera` y comparar su `teamId`. Esto es más robusto que usar Tags, ya que permite tener múltiples banderas con lógica específica.
- **Detección de Portador**: Se verificará `bandera.transform.parent` para saber si un jugador enemigo lleva el dinosaurio de nuestro equipo. Si tiene padre, el objetivo del dron será el padre (el jugador).
- **Transporte Físico**: Al colisionar, el dron se apropia del dinosaurio. Se utiliza `localPosition = Vector3.zero` para centrarlo visualmente bajo el dron.
- **Umbral de Entrega**: Se fija una distancia de `< 1.0f` a la base. Es un compromiso entre precisión y facilidad de maniobra para el agente IA.

## Risks / Trade-offs

- [Riesgo] → Sobrecarga por búsqueda frecuente de objetos.
- [Mitigación] → La búsqueda de la bandera se realizará solo si la referencia actual es nula o se pierde.
- [Riesgo] → El dron puede quedar dando vueltas si no puede soltar al dinosaurio.
- [Mitigación] → `portantDino` se resetea inmediatamente después del `SetParent(null)`.
