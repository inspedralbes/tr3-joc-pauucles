## Context

En el entrenamiento de agentes de ML-Agents, es crucial que los agentes sean capaces de identificar sus objetivos en el entorno sin depender de asignaciones estáticas en el inspector de Unity. El sistema actual depende de referencias directas, lo que dificulta la creación de entornos de entrenamiento con múltiples objetivos o configuraciones variables.

## Goals / Non-Goals

**Goals:**
- Automatizar la localización de los objetos con los Tags "Dinosaurio" y "Base".
- Priorizar el objetivo más cercano en caso de haber múltiples instancias con el mismo Tag.
- Hacer el sistema robusto ante la ausencia de objetivos para evitar excepciones de referencia nula.

**Non-Goals:**
- No se pretende optimizar la búsqueda para cientos de objetos (la búsqueda lineal con `FindGameObjectsWithTag` es suficiente para la escala actual).
- No se modificarán las reglas de colisión o el sistema de recompensas.

## Decisions

- **Búsqueda por Tag y Proximidad:** Se utilizará `GameObject.FindGameObjectsWithTag(tag)` para obtener todos los candidatos y `Vector2.Distance` para seleccionar el más cercano al transform del agente.
- **Visibilidad Privada:** Las variables `targetDinosaurio` y `baseDestino` pasarán a ser `private` para garantizar que la lógica de búsqueda dinámica sea la única encargada de gestionarlas.
- **Observaciones de Seguridad:** Si un objetivo es `null`, se enviará `Vector3.zero` al sensor para mantener el tamaño del vector de observaciones constante sin provocar errores.

## Risks / Trade-offs

- **[Riesgo] Rendimiento de FindGameObjectsWithTag:** Realizar esta búsqueda en cada episodio podría ser costoso si hay demasiados objetos.
  - **Mitigación:** Se realiza solo una vez por episodio (`OnEpisodeBegin`), no en cada paso de simulación.
- **[Riesgo] Ausencia de Tags en la Escena:** Si el usuario olvida configurar los Tags en Unity, el agente no encontrará nada.
  - **Mitigación:** La comprobación de nulidad en `CollectObservations` evita el cierre de la aplicación o errores críticos.
